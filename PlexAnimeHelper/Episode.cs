using System.Collections.Generic;

namespace PlexAnimeHelper
{
	public class Episode
	{
		public static List<string> EXTENSIONS = new List<string>() { ".mkv", ".mp4" };

		public int Number { get; set; }
		public string Filename { get; private set; }
		public string Extension { get; private set; }

		public bool Correct { get; set; }

		public Episode(int number, string path)
		{
			Number = number;
			Path = path;
		}

		/// <summary>
		/// Copy constructor
		/// </summary>
		/// <param name="episode"></param>
		public Episode(Episode episode)
		{
			Number = episode.Number;
			Filename = episode.Filename;
			Extension = episode.Extension;
			Correct = episode.Correct;
		}

		private string path;
		public string Path
		{
			get
			{
				return path;
			}
			set
			{
				path = value;
				Filename = path.Substring(path.LastIndexOf('\\') + 1);
				Extension = System.IO.Path.GetExtension(Filename).Substring(1);
			}
		}

		public override int GetHashCode()
		{
			int hash = 23;

			hash = (hash * 7) + Number.GetHashCode();
			hash = (hash * 7) + Filename.GetHashCode();
			hash = (hash * 7) + Extension.GetHashCode();
			hash = (hash * 7) + Correct.GetHashCode();

			return hash;
		}

		public override bool Equals(object obj)
		{
			if (obj == null || !(obj is Episode))
			{
				return false;
			}

			Episode other = (Episode)obj;

			return Number == other.Number && Filename == other.Filename &&
				Extension == other.Extension && Correct == other.Correct;
		}

		public override string ToString()
		{
			return $"{Number} - {Filename}";
		}

		public static bool operator ==(Episode e1, Episode e2)
		{
			return e1.Equals(e2);
		}

		public static bool operator !=(Episode e1, Episode e2)
		{
			return !e1.Equals(e2);
		}
	}
}
