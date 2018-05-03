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

		/// <summary>
		/// Copy constructor
		/// </summary>
		/// <param name="season"></param>
		public Season(Season season)
		{
			Number = season.Number;
			Name = season.Name;
			
			foreach (Episode ep in season.Episodes.Values)
			{
				Episodes.Add(ep.Number, new Episode(ep));
			}
		}

		public int NumberEpisodes
		{
			get { return Episodes.Count; }
		}

		public bool ContainsEpisode(string path)
		{
			foreach (Episode e in Episodes.Values)
			{
				if (e.Path == path)
				{
					return true;
				}
			}

			return false;
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

		public override int GetHashCode()
		{
			int hash = 23;

			hash = (hash * 7) + Number.GetHashCode();
			hash = (hash * 7) + Name.GetHashCode();

			return hash;
		}

		public override bool Equals(object obj)
		{
			if (obj == null || !(obj is Season))
			{
				return false;
			}

			Season other = (Season)obj;

			if (Number != other.Number || Name != other.Name)
			{
				return false;
			}
			
			foreach (KeyValuePair<int, Episode> ep in Episodes)
			{
				if (!other.Episodes.ContainsKey(ep.Key) || other.Episodes[ep.Key] != ep.Value)
				{
					return false;
				}
			}

			foreach (KeyValuePair<int, Episode> ep in other.Episodes)
			{
				if (!Episodes.ContainsKey(ep.Key) || Episodes[ep.Key] != ep.Value)
				{
					return false;
				}
			}

			return true;
		}

		public static bool operator ==(Season s1, Season s2)
		{
			return s1.Equals(s2);
		}

		public static bool operator !=(Season s1, Season s2)
		{
			return !s1.Equals(s2);
		}
	}
}
