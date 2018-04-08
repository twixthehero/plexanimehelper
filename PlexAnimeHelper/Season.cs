using System.Collections.Generic;

namespace PlexAnimeHelper
{
	public class Season
	{
		public int Number { get; set; }
		public string Name { get; private set; }

		public SortedList<int, Episode> Episodes = new SortedList<int, Episode>();

		public Season(int number)
		{
			Number = number;

			if (Number == 0)
			{
				Name = "Unsorted";
			}
			else
			{
				Name = $"Season {Number:00}";
			}
		}

		public int NumberEpisodes
		{
			get { return Episodes.Count; }
		}

		/// <summary>
		/// Only used by Season 0
		/// </summary>
		/// <param name="path"></param>
		public void AddUnsortedEpisode(string path)
		{
			int num = Episodes.Count + 1;
			Episodes.Add(num, new Episode(num, path)
			{
				Correct = false
			});
		}

		public void AddEpisode(int number, string path, bool correct)
		{
			Episodes.Add(number, new Episode(number, path)
			{
				Correct = correct
			});
		}

		public void AddEpisode(Episode ep)
		{
			int num = Episodes.Count + 1;
			ep.Number = num;
			Episodes.Add(ep.Number, ep);
		}

		public void RemoveEpisode(Episode ep)
		{
			RemoveEpisode(ep.Number);
		}

		public void RemoveEpisode(int number)
		{
			Episodes.Remove(number);

			List<KeyValuePair<int, Episode>> needShift = new List<KeyValuePair<int, Episode>>();
			int consecutive = 1;
			foreach (KeyValuePair<int, Episode> pair in Episodes)
			{
				if (pair.Key == consecutive)
				{
					consecutive++;
				}
				else
				{
					needShift.Add(pair);
				}
			}

			foreach (KeyValuePair<int, Episode> pair in needShift)
			{
				Episodes.Remove(pair.Key);
			}
			foreach (KeyValuePair<int, Episode> pair in needShift)
			{
				AddEpisode(pair.Value);
			}
		}

		public override string ToString()
		{
			return Name;
		}
	}
}
