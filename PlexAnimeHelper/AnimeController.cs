using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PlexAnimeHelper
{
	public class AnimeController
	{
		private Settings settings = new Settings();

		private PlexAnimeHelper helper;
		private List<Anime> animes = new List<Anime>();

		public Anime Selected { get; set; }
		private Season LeftSeason { get; set; }
		private Season RightSeason { get; set; }

		public AnimeController(PlexAnimeHelper helper)
		{
			this.helper = helper;
		}

		public void Init()
		{
			LoadData();
		}

		private void LoadData()
		{
			settings.Load();

			foreach (string path in settings.ManagedAnime)
			{
				OpenAnimeFolder(path);
			}
		}

		public void OpenAnimeFolder(string path)
		{
			string info = Path.Combine(path, "info.txt");
			if (File.Exists(info))
			{
				StreamReader r = new StreamReader(File.OpenRead(info));
				string name = null;
				int seasons = -1;

				string line;
				while ((line = r.ReadLine()) != null)
				{
					if (!line.Contains("="))
					{
						continue;
					}

					int index = line.IndexOf('=');
					string key = line.Substring(0, index);
					string value = line.Substring(index + 1);

					switch (key)
					{
						case "Name":
							name = value;
							break;
						case "Seasons":
							seasons = int.Parse(value);
							break;
						default:
							break;
					}
				}
				r.Close();

				if (name == null || seasons == -1)
				{
					Console.WriteLine($"Corrupt info file! Name={name} Seasons={seasons}");
					return;
				}

				AddAnime(name, seasons, path);
			}
			else
			{
				AddAnime(path);
			}

			helper.AddAnimeTab(Selected);
		}

		/// <summary>
		/// Adds selected episodes to unsorted
		/// </summary>
		public void OpenEpisode(string path)
		{
			Selected.Seasons[0].AddUnsortedEpisode(path);
		}

		/// <summary>
		/// Adds all episodes in selected folder to unsorted
		/// </summary>
		public void OpenEpisodeFolder(string path)
		{
			foreach (string file in Directory.GetFiles(path).Where(s => Anime.EXTENSIONS.Contains(Path.GetExtension(s))))
			{
				Selected.Seasons[0].AddUnsortedEpisode(file);
			}

			helper.RebuildEpisodeLists();
		}

		public void AddAnime(string path)
		{
			AddAnime(new Anime(path));
		}

		public void AddAnime(string name, int seasons, string path)
		{
			AddAnime(new Anime(name, path, seasons));
		}

		private void AddAnime(Anime anime)
		{
			animes.Add(anime);
			Selected = anime;
			LeftSeason = Selected.Seasons[0];
			RightSeason = Selected.Seasons[1];

			Console.WriteLine($"newAnime: {anime}");
		}

		public void AddSeason()
		{
			Selected.AddSeason();
		}

		public void DeleteSeason()
		{
			Selected.DeleteSeason();
		}

		public int GetNumSeasons()
		{
			return Selected.NumberSeasons;
		}

		public void SetName(string name)
		{
			Selected.Name = name;
		}

		public void MoveEpisode(Season from, Season to, Episode e)
		{
			from.RemoveEpisode(e);
			to.AddEpisode(e);
		}

		public void Save()
		{
			settings.Save();

			foreach (KeyValuePair<int, Season> pair in Selected.Seasons)
			{
				if (pair.Key == 0)
				{
					continue;
				}

				Console.WriteLine($"Saving {pair.Value}");

				string seasonPath = Path.Combine(Selected.FolderPath, pair.Value.Name);
				Console.WriteLine($"Creating {seasonPath}...");
				if (!Directory.Exists(seasonPath))
				{
					Console.WriteLine($"Created {seasonPath}");
					Directory.CreateDirectory(seasonPath);
				}
				else
				{
					Console.WriteLine($"{seasonPath} exists");
				}

				foreach (Episode e in pair.Value.Episodes.Values)
				{
					string dest = Path.Combine(seasonPath, $"{Selected.Name} s{pair.Value.Number:00}e{e.Number:00}.{e.Extension}");
					e.Correct = e.Path == dest;
					Console.WriteLine($"{e.Path} | {dest} | {e.Correct}");

					if (!e.Correct)
					{
						DialogResult result = DialogResult.Retry;
						while (result == DialogResult.Retry)
						{
							try
							{
								File.Move(e.Path, dest);
								
								e.Correct = true;
								e.Path = dest;
								break;
							}
							catch (UnauthorizedAccessException uae)
							{
								result = MessageBox.Show(uae.Message, "Failed to move file", MessageBoxButtons.AbortRetryIgnore);

								if (result == DialogResult.Abort || result == DialogResult.Cancel)
								{
									break;
								}
							}
						}
					}
				}
			}

			helper.RebuildEpisodeLists();

			StreamWriter w = File.CreateText(Path.Combine(Selected.FolderPath, "info.txt"));
			w.AutoFlush = true;
			w.WriteLine($"Name={Selected.Name}");
			w.WriteLine($"Seasons={Selected.NumberSeasons}");
			w.Close();
		}

		public void SaveAll()
		{

		}
	}
}
