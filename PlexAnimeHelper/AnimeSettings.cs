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
	}
}
