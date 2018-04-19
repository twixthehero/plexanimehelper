using System;
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
			
			//todo - fix bug where path doesn't exist
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

			//add unsorted eps
			foreach (string file in Directory.GetFiles(FolderPath).Where(s => EXTENSIONS.Contains(Path.GetExtension(s))))
			{
				Console.WriteLine($"Adding unsorted ep: {file}");
				Seasons[0].AddUnsortedEpisode(file);
			}

			for (int i = 1; i <= numSeasons; i++)
			{
				Console.WriteLine($"Adding season {i}");
				Seasons.Add(i, new Season(i));
				string seasonPath = Path.Combine(FolderPath, $"Season {i:00}");

				if (!Directory.Exists(seasonPath))
				{
					continue;
				}

				string[] files = Directory.GetFiles(seasonPath);

				//add other videos found that aren't in the correct named format
				foreach (string file in
					files.Where(s => EXTENSIONS.Contains(Path.GetExtension(s)) &&
					!Path.GetFileNameWithoutExtension(s).StartsWith(name)))
				{
					Console.WriteLine($"Adding unsorted ep: {file}");
					Seasons[0].AddUnsortedEpisode(file);
				}

				foreach (string file in
					files.Where(s => EXTENSIONS.Contains(Path.GetExtension(s)) &&
					Path.GetFileNameWithoutExtension(s).StartsWith(name)))
				{
					string epName = Path.GetFileNameWithoutExtension(file);
					int sIndex = epName.LastIndexOf('s');
					int eIndex = epName.LastIndexOf('e');

					string animeName = epName.Substring(0, sIndex - 1);
					int seasonNum = int.Parse(epName.Substring(sIndex + 1, eIndex - (sIndex + 1)));
					int epNum = int.Parse(epName.Substring(eIndex + 1));

					Console.WriteLine($"Adding ep: {epName} | {animeName} | {seasonNum} | {epNum}");

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
		}

		public int NumberSeasons
		{
			get { return Seasons.Count - 1; }
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
