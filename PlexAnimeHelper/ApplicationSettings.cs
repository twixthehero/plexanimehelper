using IWshRuntimeLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace PlexAnimeHelper
{
	class ApplicationSettings
	{
		public const string SETTINGS_FILE = "settings.json";
		private static string APP_DATA;
		private static string DATA_DIR;
		private static string DATA_FILE;

		public static ApplicationSettings Instance { get; private set; }

		public int Version { get; private set; } = 1;

		private EStartMode startMode = EStartMode.Visible;
		public EStartMode StartMode
		{
			get
			{
				return startMode;
			}
			set
			{
				startMode = value;

				CheckStartMode();
			}
		}

		/// <summary>
		/// Time in minutes to rescan all managed shows
		/// </summary>
		public int RescanTime { get; set; } = 5;

		/// <summary>
		/// Stores individual show settings
		/// </summary>
		public Dictionary<int, AnimeSettings> AnimeSettings = new Dictionary<int, AnimeSettings>();

		public ELogLevel LogLevel { get; set; } = ELogLevel.DoubleDebug;

		static ApplicationSettings()
		{
			APP_DATA = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			DATA_DIR = Path.Combine(APP_DATA, PlexAnimeHelper.NAME);
			DATA_FILE = Path.Combine(DATA_DIR, SETTINGS_FILE);

			Log.D($"Checking for '{DATA_DIR}'...");
			if (!Directory.Exists(DATA_DIR))
			{
				Log.D($"Creating '{DATA_DIR}'...");
				Directory.CreateDirectory(DATA_DIR);
			}

			Log.D($"Checking for '{DATA_FILE}'");
			if (System.IO.File.Exists(DATA_FILE) && Load())
			{
				Log.D("Loaded application settings!");
			}
			else
			{
				Log.D($"Settings file doesn't exist or was corrupt! Recreating...");
				Instance = new ApplicationSettings();
				Save();
			}

			Instance.CheckStartMode();
		}

		[JsonConstructor]
		private ApplicationSettings()
		{
			
		}

		/// <summary>
		/// Copy constructor
		/// </summary>
		/// <param name="settings"></param>
		public ApplicationSettings(ApplicationSettings settings)
		{
			Version = settings.Version;
			startMode = settings.StartMode;
			RescanTime = settings.RescanTime;

			foreach (AnimeSettings set in settings.AnimeSettings.Values)
			{
				AnimeSettings.Add(set.ID, new AnimeSettings(set));
			}
		}

		private void CheckStartMode()
		{
			if (StartMode == EStartMode.None)
			{
				UninstallBootShortcut();
			}
			else
			{
				InstallBootShortcut();
			}
		}

		private void InstallBootShortcut()
		{
			string startup = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
			string shortcutPath = Path.Combine(startup, "PlexAnimeHelper.lnk");
			
			if (!System.IO.File.Exists(shortcutPath))
			{
				Log.D($"Creating shortcut '{shortcutPath}'...");
				WshShortcut shortcut = new WshShell().CreateShortcut(shortcutPath);
				string exe = System.Reflection.Assembly.GetExecutingAssembly().Location;
				shortcut.TargetPath = exe;
				shortcut.WorkingDirectory = Path.GetDirectoryName(exe);
				shortcut.Save();
			}
		}

		private void UninstallBootShortcut()
		{
			string startup = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
			string shortcutPath = Path.Combine(startup, "PlexAnimeHelper.lnk");

			if (System.IO.File.Exists(shortcutPath))
			{
				Log.D($"Removing shortcut '{shortcutPath}'...");
				System.IO.File.Delete(shortcutPath);
			}
		}

		private int GetNextID()
		{
			int id = 0;

			do
			{
				id++;
			}
			while (AnimeSettings.ContainsKey(id));

			return id;
		}

		public void Add(Anime anime)
		{
			int id = GetNextID();
			anime.Settings.ID.Value = id;

			AnimeSettings.Add(id, anime.Settings);

			Log.I($"Added '{anime.FolderPath}' to watch list");
		}

		public void Remove(int id)
		{
			if (AnimeSettings.ContainsKey(id))
			{
				AnimeSettings ass = AnimeSettings[id];
				AnimeSettings.Remove(id);

				Log.I($"Removed '{ass.Name}' from watch list");
			}
			else
			{
				Log.W($"Tried to remove invalid id {id}");
			}
		}

		public override bool Equals(object obj)
		{
			if (obj == null || !(obj is ApplicationSettings))
			{
				return false;
			}

			ApplicationSettings other = (ApplicationSettings)obj;

			if (Version != other.Version || StartMode != other.StartMode ||
				RescanTime != other.RescanTime)
			{
				return false;
			}

			foreach (KeyValuePair<int, AnimeSettings> pair in AnimeSettings)
			{
				if (!other.AnimeSettings.ContainsKey(pair.Key) || other.AnimeSettings[pair.Key] != pair.Value)
				{
					return false;
				}
			}

			foreach (KeyValuePair<int, AnimeSettings> Pair in other.AnimeSettings)
			{
				if (!AnimeSettings.ContainsKey(Pair.Key) || AnimeSettings[Pair.Key] != Pair.Value)
				{
					return false;
				}
			}

			return true;
		}

		public override int GetHashCode()
		{
			int hash = 23;

			hash = (hash * 7) + Version.GetHashCode();
			hash = (hash * 7) + StartMode.GetHashCode();
			hash = (hash * 7) + RescanTime.GetHashCode();

			return hash;
		}

		public static bool operator ==(ApplicationSettings a1, ApplicationSettings a2)
		{
			return a1.Equals(a2);
		}

		public static bool operator !=(ApplicationSettings a1, ApplicationSettings a2)
		{
			return !a1.Equals(a2);
		}

		public static void Save()
		{
			JsonSerializer serializer = new JsonSerializer
			{
				NullValueHandling = NullValueHandling.Include,
				Formatting = Formatting.Indented
			};

			using (StreamWriter sw = new StreamWriter(System.IO.File.Open(DATA_FILE, FileMode.Create, FileAccess.Write, FileShare.None)))
			using (JsonWriter writer = new JsonTextWriter(sw))
			{
				serializer.Serialize(writer, Instance);
			}
		}

		public static bool Load()
		{
			JsonSerializer serializer = new JsonSerializer
			{
				NullValueHandling = NullValueHandling.Include
			};

			using (StreamReader r = new StreamReader(System.IO.File.Open(DATA_FILE, FileMode.Open, FileAccess.Read, FileShare.Read)))
			using (JsonReader reader = new JsonTextReader(r))
			{
				Instance = serializer.Deserialize<ApplicationSettings>(reader);
				return true;
			}
		}
		
		public static void Apply(ApplicationSettings settings)
		{
			Instance = settings;
			Save();

			PlexAnimeHelper.Instance.Reinit();
		}

		public static void SaveTo(string path)
		{
			JsonSerializer serializer = new JsonSerializer
			{
				NullValueHandling = NullValueHandling.Include,
				Formatting = Formatting.Indented
			};

			using (StreamWriter sw = new StreamWriter(System.IO.File.Open(path, FileMode.Create, FileAccess.Write, FileShare.None)))
			using (JsonWriter writer = new JsonTextWriter(sw))
			{
				serializer.Serialize(writer, Instance);
			}
		}

		public static void LoadFrom(string path)
		{
			JsonSerializer serializer = new JsonSerializer
			{
				NullValueHandling = NullValueHandling.Include
			};

			using (StreamReader r = new StreamReader(System.IO.File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read)))
			using (JsonReader reader = new JsonTextReader(r))
			{
				Apply(serializer.Deserialize<ApplicationSettings>(reader));
			}
		}
	}
}
