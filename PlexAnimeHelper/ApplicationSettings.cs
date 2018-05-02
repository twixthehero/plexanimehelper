using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace PlexAnimeHelper
{
	class ApplicationSettings
	{
		private const string SETTINGS_FILE = "settings.json";
		private static string APP_DATA;
		private static string DATA_DIR;
		private static string DATA_FILE;

		public static ApplicationSettings Instance { get; private set; }

		public int Version { get; private set; } = 1;

		/// <summary>
		/// Time in minutes to rescan all managed shows
		/// </summary>
		public int RescanTime { get; set; } = 5;

		/// <summary>
		/// Stores individual show settings
		/// </summary>
		public Dictionary<int, AnimeSettings> AnimeSettings = new Dictionary<int, AnimeSettings>();

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
			if (File.Exists(DATA_FILE) && Load())
			{
				Log.D("Loaded application settings!");
			}
			else
			{
				Log.D($"Settings file doesn't exist or was corrupt! Recreating...");
				Instance = new ApplicationSettings();
				Save();
			}
		}

		private ApplicationSettings()
		{

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

		public static void Save()
		{
			JsonSerializer serializer = new JsonSerializer
			{
				NullValueHandling = NullValueHandling.Include,
				Formatting = Formatting.Indented
			};

			using (StreamWriter sw = new StreamWriter(File.Open(DATA_FILE, FileMode.Create, FileAccess.Write, FileShare.None)))
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

			using (StreamReader r = new StreamReader(File.Open(DATA_FILE, FileMode.Open, FileAccess.Read, FileShare.Read)))
			using (JsonReader reader = new JsonTextReader(r))
			{
				Instance = serializer.Deserialize<ApplicationSettings>(reader);
				return true;
			}
		}
	}
}
