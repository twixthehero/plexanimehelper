namespace PlexAnimeHelper
{
	public class AnimeSettings
	{
		/// <summary>
		/// 
		/// </summary>
		public SetOnce<int> ID { get; set; } = new SetOnce<int>();

		/// <summary>
		/// Whether to automatically manage newly found episodes
		/// </summary>
		public bool AutoMove { get; set; } = false;

		/// <summary>
		/// Path to this anime
		/// </summary>
		public string FolderPath { get; set; }

		/// <summary>
		/// Name of the anime
		/// </summary>
		public string Name { get; set; }

		public int Seasons { get; set; } = 1;
	}
}
