using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PlexAnimeHelper
{
	public class Anime
	{
		public SortedList<int, Season> Seasons { get; } = new SortedList<int, Season>();

		public AnimeSettings Settings { get; private set; }

		private Anime(string path)
		{
			Settings = new AnimeSettings();

			Name = path.Substring(path.LastIndexOf('\\') + 1);
			FolderPath = path;

			Init();
		}

		public Anime(AnimeSettings settings)
		{
			Settings = settings;

			Init();
		}

		private Anime(string name, string path, int numSeasons)
		{
			Settings = new AnimeSettings();

			Name = name;
			FolderPath = path;

			Init();
		}

		/// <summary>
		/// Copy constructor
		/// </summary>
		/// <param name="anime"></param>
		public Anime(Anime anime)
		{
			Settings = new AnimeSettings(anime.Settings);

			foreach (Season season in Seasons.Values)
			{
				Seasons.Add(season.Number, new Season(season));
			}
		}

		private void Init()
		{
			Log.D("==========================================================================");

			Seasons.Add(0, new Season(0)); //unsorted eps are here | deleted season eps are moved here

			//add unsorted eps
			foreach (string file in Directory.GetFiles(FolderPath).Where(s => Episode.EXTENSIONS.Contains(Path.GetExtension(s))))
			{
				Log.D($"Adding unsorted ep: {file}");
				Seasons[0].AddUnsortedEpisode(file);
			}

			for (int i = 1; i <= Settings.Seasons; i++)
			{
				Log.I($"Adding season {i}");
				Seasons.Add(i, new Season(i));
				string seasonPath = Path.Combine(FolderPath, $"Season {i:00}");

				if (!Directory.Exists(seasonPath))
				{
					continue;
				}

				string[] files = Directory.GetFiles(seasonPath);

				foreach (string file in files.Where(s => Episode.EXTENSIONS.Contains(Path.GetExtension(s))))
				{
					if (IsEpisodeNamedCorrectly(file))
					{
						string epName = Path.GetFileNameWithoutExtension(file);
						int sIndex = epName.LastIndexOf('s');
						int eIndex = epName.LastIndexOf('e');

						string animeName = epName.Substring(0, sIndex - 1);
						int seasonNum = int.Parse(epName.Substring(sIndex + 1, eIndex - (sIndex + 1)));
						int epNum = int.Parse(epName.Substring(eIndex + 1));

						Log.I($"Adding ep: {epName} | {animeName} | {seasonNum} | {epNum}");

						//if ep data is correct
						if (Name == animeName && seasonNum == i)
						{
							Seasons[i].AddEpisode(epNum, file, true);
						}
						else
						{
							Seasons[i].AddEpisode(epNum, file, false);
						}
					}
					else
					{
						//add other videos found that aren't in the correct named format - consider them unsorted
						Log.D($"Adding unsorted ep: {file}");
						Seasons[0].AddUnsortedEpisode(file);
					}
				}
			}
		}

		public int ID
		{
			get { return Settings.ID; }
		}

		public bool AutoMove
		{
			get
			{
				return Settings.AutoMove;
			}
			set
			{
				Settings.AutoMove = value;
			}
		}

		public bool AutoScan
		{
			get
			{
				return Settings.AutoScan;
			}
			set
			{
				Settings.AutoScan = value;
			}
		}

		public string Name
		{
			get
			{
				return Settings.Name;
			}
			set
			{
				Settings.Name = value;
			}
		}

		public string FolderPath
		{
			get
			{
				return Settings.FolderPath;
			}
			set
			{
				Settings.FolderPath = value;
			}
		}

		public int NumberSeasons
		{
			get { return Seasons.Count - 1; }
		}

		public bool Scan()
		{
			Log.DD($"Scanning '{FolderPath}'...");
			bool foundNew = false;

			Log.DD("Checking base directory...");
			foreach (string file in Directory.GetFiles(FolderPath).Where(s => Episode.EXTENSIONS.Contains(Path.GetExtension(s))))
			{
				if (!Seasons[0].ContainsEpisode(file))
				{
					foundNew = true;

					Log.D($"Adding unsorted ep: {file}");
					Seasons[0].AddUnsortedEpisode(file);
				}
			}

			Log.DD("Checking season directories...");
			for (int i = 1; i <= NumberSeasons; i++)
			{
				if (!Seasons.ContainsKey(i))
				{
					continue;
				}

				string seasonPath = Path.Combine(FolderPath, $"Season {i:00}");

				if (!Directory.Exists(seasonPath))
				{
					continue;
				}

				string[] files = Directory.GetFiles(seasonPath);

				foreach (string file in files.Where(s => Episode.EXTENSIONS.Contains(Path.GetExtension(s))))
				{
					if (IsEpisodeNamedCorrectly(file))
					{
						if (!Seasons[i].ContainsEpisode(file))
						{
							string epName = Path.GetFileNameWithoutExtension(file);
							int sIndex = epName.LastIndexOf('s');
							int eIndex = epName.LastIndexOf('e');

							string animeName = epName.Substring(0, sIndex - 1);
							int seasonNum = int.Parse(epName.Substring(sIndex + 1, eIndex - (sIndex + 1)));
							int epNum = int.Parse(epName.Substring(eIndex + 1));

							Log.I($"Adding ep: {epName} | {animeName} | {seasonNum} | {epNum}");

							//if ep data is correct
							if (Name == animeName && seasonNum == i)
							{
								Seasons[i].AddEpisode(epNum, file, true);
							}
							else
							{
								Seasons[i].AddEpisode(epNum, file, false);
							}
						}
					}
					else
					{
						//add other videos found that aren't in the correct named format - consider them unsorted
						if (!Seasons[0].ContainsEpisode(file))
						{
							foundNew = true;

							Log.D($"Adding unsorted ep: {file}");
							Seasons[0].AddUnsortedEpisode(file);
						}
					}
				}
			}

			return foundNew;
		}

		/// <summary>
		/// Checks if a file is named correctly for this anime
		/// </summary>
		/// <param name="file">Path to the episode file</param>
		/// <returns>true if correct, false otherwise</returns>
		private bool IsEpisodeNamedCorrectly(string file)
		{
			//doesn't start with the anime's name
			string epName = Path.GetFileNameWithoutExtension(file);
			if (!epName.StartsWith(Name))
			{
				Log.DD($"Filename doesn't start with '{Name}': {file}");
				return false;
			}

			//doesn't have a space between the name and details
			string spacer = epName.Substring(Name.Length);
			if (spacer[0] != ' ')
			{
				Log.DD($"Filename doesn't have a space (' ') after '{Name}': {file}");
				return false;
			}

			//missing season 's'
			string details = spacer.Substring(1);
			if (details[0] != 's')
			{
				Log.DD($"Filename is missing the season 's': {file}");
				return false;
			}

			//missing episode 'e'
			if (!details.Contains('e'))
			{
				Log.DD($"Filename is missing the episode 'e': {file}");
				return false;
			}

			string[] pieces = details.Split('e');
			string season = pieces[0].Substring(1);
			string episode = pieces[1];

			//force leading zero on seasons under 10
			if (int.Parse(season) < 10 && season[0] != '0')
			{
				Log.DD($"Seasons under 10 must have a leading zero: {file}");
				return false;
			}

			//force leading zero on episodes under 10
			if (int.Parse(episode) < 10 && episode[0] != '0')
			{
				Log.DD($"Episodes under 10 must have a leading zero: {file}");
				return false;
			}

			return true;
		}

		public void AddSeason()
		{
			int num = Seasons.Count;
			Seasons.Add(num, new Season(num));
		}

		public void DeleteSeason(int season = -1)
		{
			if (season == -1)
			{
				season = Seasons.Count;
			}

			if (NumberSeasons == 0)
			{
				return;
			}

			foreach (Episode ep in Seasons[season].Episodes.Values)
			{
				Seasons[0].AddEpisode(ep);
			}
		}

		public override string ToString()
		{
			return $"Anime[Name={Name},NumSeasons={NumberSeasons}]";
		}

		public override bool Equals(object obj)
		{
			if (obj == null || !(obj is Anime))
			{
				return false;
			}

			Anime other = (Anime)obj;

			if (Settings != other.Settings)
			{
				return false;
			}

			foreach (KeyValuePair<int, Season> pair in Seasons)
			{
				if (!other.Seasons.ContainsKey(pair.Key) || other.Seasons[pair.Key] != pair.Value)
				{
					return false;
				}
			}

			foreach (KeyValuePair<int, Season> Pair in other.Seasons)
			{
				if (!Seasons.ContainsKey(Pair.Key) || Seasons[Pair.Key] != Pair.Value)
				{
					return false;
				}
			}

			return true;
		}

		public override int GetHashCode()
		{
			int hash = 23;

			hash = (hash * 7) + Seasons.GetHashCode();
			hash = (hash * 7) + Settings.GetHashCode();

			return hash;
		}

		public static bool operator==(Anime a1, Anime a2)
		{
			return a1.Equals(a2);
		}

		public static bool operator !=(Anime a1, Anime a2)
		{
			return !a1.Equals(a2);
		}

		public class Builder
		{
			private string name;
			private string folderPath;
			private int seasons;

			public string GetName()
			{
				return name;
			}

			public Builder SetName(string name)
			{
				this.name = name;
				return this;
			}

			public string GetFolderPath()
			{
				return folderPath;
			}

			public Builder SetFolderPath(string folderPath)
			{
				this.folderPath = folderPath;
				return this;
			}

			public int GetSeasons()
			{
				return seasons;
			}

			public Builder SetSeasons(int seasons)
			{
				this.seasons = seasons;
				return this;
			}

			public Anime Build()
			{
				Anime anime;

				if (name != null)
				{
					anime = new Anime(name, folderPath, seasons);
				}
				else
				{
					anime = new Anime(folderPath);
				}
				
				ApplicationSettings.Instance.Add(anime);

				return anime;
			}
		}
	}
}
