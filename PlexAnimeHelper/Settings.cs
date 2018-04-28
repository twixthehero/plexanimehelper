using System.Collections.Generic;
using System.IO;

namespace PlexAnimeHelper
{
	class Settings
	{
		private const string DATA_FILE = "data.txt";

		public int Version { get; private set; } = 1;

		public List<string> ManagedAnime { get; private set; } = new List<string>();

		public void Add(string path)
		{
			if (!ManagedAnime.Contains(path))
			{
				Log.I($"Added '{path}' to watch list");
				ManagedAnime.Add(path);
			}
		}

		public void Remove(string path)
		{
			if (ManagedAnime.Contains(path))
			{
				Log.I($"Removing '{path}' from watch list");
				ManagedAnime.Remove(path);
			}
			else
			{
				Log.W($"'{path}' is not watched!");
			}
		}

		public void Save()
		{
			FileStream fs = File.Open(DATA_FILE, FileMode.Create, FileAccess.Write, FileShare.None);
			StreamWriter w = new StreamWriter(fs)
			{
				AutoFlush = true
			};

			ManagedAnime.Sort();

			foreach (string path in ManagedAnime)
			{
				w.WriteLine($"path={path}");
			}

			w.Close();
		}

		public void Load()
		{
			Log.D($"Checking for {DATA_FILE}...");
			if (File.Exists(DATA_FILE))
			{
				Log.D($"Found {DATA_FILE}");
				FileStream fs = File.Open(DATA_FILE, FileMode.Open, FileAccess.Read, FileShare.Read);
				StreamReader r = new StreamReader(fs);
				string line;

				while ((line = r.ReadLine()) != null)
				{
					if (line.Length == 0)
					{
						continue;
					}

					if (line.StartsWith("#"))
					{
						Log.D($"Ignoring '{line}'");
						continue;
					}

					string path = line.Split('=')[1];

					if (Directory.Exists(path))
					{
						Log.I($"Found path '{path}'");
						ManagedAnime.Add(path);
					}
					else
					{
						Log.W($"Ignoring non-existant path '{path}'");
					}
				}

				r.Close();
			}
		}
	}
}
