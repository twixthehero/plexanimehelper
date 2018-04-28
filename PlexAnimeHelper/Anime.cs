using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PlexAnimeHelper
{
	public class Anime
	{
		public string Name { get; set; }
		public string FolderPath { get; private set; }
		public SortedList<int, Season> Seasons { get; } = new SortedList<int, Season>();

		public static List<string> EXTENSIONS = new List<string>() { ".mkv", ".mp4" };

		public Anime(string path)
		{
			FolderPath = path;
			Name = path.Substring(path.LastIndexOf('\\') + 1);
			Seasons.Add(0, new Season(0)); //unsorted eps are here | deleted season eps are moved here
			Seasons.Add(1, new Season(1));
			
			foreach (string file in Directory.GetFiles(FolderPath).Where(s => EXTENSIONS.Contains(Path.GetExtension(s))))
			{
				Seasons[0].AddUnsortedEpisode(file);
			}
		}

		public Anime(string name, string path, int numSeasons)
		{
			Name = name;
			FolderPath = path;
			Seasons.Add(0, new Season(0)); //unsorted eps are here | deleted season eps are moved here

			Log.D("==========================================================================");

			//add unsorted eps
			foreach (string file in Directory.GetFiles(FolderPath).Where(s => EXTENSIONS.Contains(Path.GetExtension(s))))
			{
				Log.D($"Adding unsorted ep: {file}");
				Seasons[0].AddUnsortedEpisode(file);
			}

			for (int i = 1; i <= numSeasons; i++)
			{
				Log.I($"Adding season {i}");
				Seasons.Add(i, new Season(i));
				string seasonPath = Path.Combine(FolderPath, $"Season {i:00}");

				if (!Directory.Exists(seasonPath))
				{
					continue;
				}

				string[] files = Directory.GetFiles(seasonPath);

				foreach (string file in files.Where(s => EXTENSIONS.Contains(Path.GetExtension(s))))
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

		public int NumberSeasons
		{
			get { return Seasons.Count - 1; }
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
	}
}
