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

		public override string ToString()
		{
			return $"{Number} - {Filename}";
		}
	}
}
