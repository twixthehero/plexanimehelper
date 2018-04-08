using System;
using System.Collections.Generic;
using System.IO;

namespace PlexAnimeHelper
{
	class Settings
	{
		private const string DATA_FILE = "data.txt";

		public int Version { get; private set; } = 1;

		public List<string> ManagedAnime { get; private set; } = new List<string>();

		public void Save()
		{
			FileStream fs = File.Open(DATA_FILE, FileMode.Create, FileAccess.Write, FileShare.None);
			StreamWriter w = new StreamWriter(fs)
			{
				AutoFlush = true
			};
			
			foreach (string path in ManagedAnime)
			{
				w.WriteLine($"path={path}");
			}

			w.Close();
		}

		public void Load()
		{
			if (File.Exists(DATA_FILE))
			{
				FileStream fs = File.Open(DATA_FILE, FileMode.Open, FileAccess.Read, FileShare.Read);
				StreamReader r = new StreamReader(fs);
				string line;

				while ((line = r.ReadLine()) != null)
				{
					string path = line.Split('=')[1];
					Console.WriteLine($"Found path {path}");
					ManagedAnime.Add(path);
				}

				r.Close();
			}
		}
	}
}
