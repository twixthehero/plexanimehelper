using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Timers;
using System.Windows.Forms;

namespace PlexAnimeHelper
{
	public class AnimeController
	{
		private Settings settings = new Settings();

		private PlexAnimeHelper helper;
		private SortedList<int, Anime> animes = new SortedList<int, Anime>();

		public Anime Selected { get; set; }
		private Season LeftSeason { get; set; }
		private Season RightSeason { get; set; }

		/// <summary>
		/// Number of minutes to wait before rescanning this directory
		/// </summary>
		public int RescanTime { get; set; } = 5;
		private System.Timers.Timer watchTimer;

		public AnimeController(PlexAnimeHelper helper)
		{
			this.helper = helper;
			watchTimer = new System.Timers.Timer(RescanTime * 60 * 1000);
			watchTimer.Elapsed += Scan;
			watchTimer.Start();
		}

		private void Scan(object sender, ElapsedEventArgs e)
		{
			bool foundNew = false;

			foreach (Anime a in animes.Values)
			{
				foundNew = a.Scan() || foundNew;
			}

			if (foundNew)
			{
				helper.ShowTrayNoti("Found new episodes!");
				helper.RebuildEpisodeLists();
			}
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
					Log.E($"Corrupt info file! Name={name} Seasons={seasons}");
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
			animes.Add(animes.Count, anime);
			settings.Add(anime.FolderPath);
			Selected = anime;
			LeftSeason = Selected.Seasons[0];
			RightSeason = Selected.Seasons[1];
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

		public void SetSelected(int index)
		{
			Selected = animes.Values[index];
			Log.D($"Selected index={index} anime={Selected}");
		}

		public void CloseTab(int index)
		{
			Anime closing = animes[index];
			Log.D($"Closing index={index} anime={closing}");

			animes.Remove(index);

			//shift indices down
			for (int i = index + 1; i <= animes.Count; i++)
			{
				Anime toMove = animes[i];
				animes.Remove(i);
				animes.Add(i - 1, toMove);
			}

			settings.Remove(closing.FolderPath);
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

		public void SaveActiveTab()
		{
			settings.Save();

			Log.I($"Saving {Selected}...");
			foreach (KeyValuePair<int, Season> pair in Selected.Seasons)
			{
				if (pair.Key == 0)
				{
					continue;
				}

				Log.D($"Saving {pair.Value}");

				string seasonPath = Path.Combine(Selected.FolderPath, pair.Value.Name);
				if (!Directory.Exists(seasonPath))
				{
					Log.D($"Creating '{seasonPath}'...");
					Directory.CreateDirectory(seasonPath);
					Log.D($"Created '{seasonPath}'");
				}
				else
				{
					Log.D($"'{seasonPath}' already exists");
				}

				foreach (Episode e in pair.Value.Episodes.Values)
				{
					string dest = Path.Combine(seasonPath, $"{Selected.Name} s{pair.Value.Number:00}e{e.Number:00}.{e.Extension}");
					e.Correct = e.Path == dest;
					Log.D($"{e.Path} | {dest} | {e.Correct}");

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
							catch (Exception ee)
							{
								result = MessageBox.Show(ee.Message, "Failed to move file", MessageBoxButtons.AbortRetryIgnore);

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

			Log.I("Done saving");
		}

		public void SaveAll()
		{

		}

		public void SaveAnimeList()
		{
			settings.Save();
		}
	}
}
