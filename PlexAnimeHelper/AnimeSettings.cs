namespace PlexAnimeHelper
{
	public class AnimeSettings
	{
		/// <summary>
		/// Unique id
		/// </summary>
		public SetOnce<int> ID { get; set; } = new SetOnce<int>();

		/// <summary>
		/// Whether to automatically manage newly found episodes
		/// </summary>
		public bool AutoMove { get; set; } = false;

		/// <summary>
		/// Whether to automatically scan for new episodes
		/// </summary>
		public bool AutoScan { get; set; } = true;

		/// <summary>
		/// Path to this anime
		/// </summary>
		public string FolderPath { get; set; }

		/// <summary>
		/// Name of the anime
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Number of seasons
		/// </summary>
		public int Seasons { get; set; } = 1;

		public AnimeSettings()
		{

		}

		/// <summary>
		/// Copy constructor
		/// </summary>
		/// <param name="settings"></param>
		public AnimeSettings(AnimeSettings settings)
		{
			ID.Value = settings.ID;
			AutoMove = settings.AutoMove;
			AutoScan = settings.AutoScan;
			FolderPath = settings.FolderPath;
			Name = settings.Name;
			Seasons = settings.Seasons;
		}

		public override int GetHashCode()
		{
			int hash = 23;

			hash = (hash * 7) + ID.GetHashCode();
			hash = (hash * 7) + AutoMove.GetHashCode();
			hash = (hash * 7) + AutoScan.GetHashCode();
			hash = (hash * 7) + FolderPath.GetHashCode();
			hash = (hash * 7) + Name.GetHashCode();

			return hash;
		}

		public override bool Equals(object obj)
		{
			if (obj == null || !(obj is AnimeSettings))
			{
				return false;
			}

			AnimeSettings other = (AnimeSettings)obj;

			return ID == other.ID && AutoMove == other.AutoMove &&
				AutoScan == other.AutoScan && FolderPath == other.FolderPath &&
				Name == other.Name;
		}

		public static bool operator ==(AnimeSettings s1, AnimeSettings s2)
		{
			return s1.Equals(s2);
		}

		public static bool operator !=(AnimeSettings s1, AnimeSettings s2)
		{
			return !s1.Equals(s2);
		}
	}
}
