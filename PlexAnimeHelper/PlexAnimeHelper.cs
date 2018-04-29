using System;
using System.Windows.Forms;

namespace PlexAnimeHelper
{
	public partial class PlexAnimeHelper : Form
	{
		private FolderBrowserDialog browser;
		private AnimeController controller;
		private ContextMenuStrip menu;

		public PlexAnimeHelper()
		{
			InitializeComponent();

			browser = new FolderBrowserDialog();
			controller = new AnimeController(this);
			menu = new ContextMenuStrip();

			controller.Init();
			
			AnimeTabs_Selected(this, new TabControlEventArgs(CurrentPage, animeTabs.TabCount - 1, TabControlAction.Selected));
		}

		private void AnimeTabs_Selecting(object sender, TabControlCancelEventArgs e)
		{
			Log.D($"Unregistering events {CurrentPage?.Text}...");

			AnimeNameBox.TextChanged -= AnimeName_TextChanged;
			SeasonsBox.ValueChanged -= Seasons_ValueChanged;
			LeftSeasonList.SelectedIndexChanged -= LeftSeasonList_SelectedIndexChanged;
			RightSeasonList.SelectedIndexChanged -= RightSeasonList_SelectedIndexChanged;
			MoveLeftButton.Click -= MoveLeftButton_Click;
			MoveRightButton.Click -= MoveRightButton_Click;

			Log.D("Done");
		}

		private void AnimeTabs_Selected(object sender, TabControlEventArgs e)
		{
			Log.D($"Registering events {CurrentPage.Text}...");

			AnimeNameBox.TextChanged += AnimeName_TextChanged;
			SeasonsBox.ValueChanged += Seasons_ValueChanged;
			LeftSeasonList.SelectedIndexChanged += LeftSeasonList_SelectedIndexChanged;
			RightSeasonList.SelectedIndexChanged += RightSeasonList_SelectedIndexChanged;
			MoveLeftButton.Click += MoveLeftButton_Click;
			MoveRightButton.Click += MoveRightButton_Click;

			Log.D("Done");

			controller.SetSelected(animeTabs.SelectedIndex);
		}

		private TabPage CurrentPage { get { return animeTabs.SelectedTab; } }
		private TextBox AnimeNameBox { get { return ((TextBox)CurrentPage.Controls.Find("name", true)[0]); } }
		public string AnimeName
		{
			get { return AnimeNameBox.Text; }
			set { AnimeNameBox.Text = value; }
		}
		private NumericUpDown SeasonsBox { get { return ((NumericUpDown)CurrentPage.Controls.Find("seasons", true)[0]); } }
		public string Seasons
		{
			get { return SeasonsBox.Text; }
			set { SeasonsBox.Text = value; }
		}
		private ComboBox LeftSeasonList { get { return ((ComboBox)CurrentPage.Controls.Find("leftSeasonList", true)[0]); } }
		private Season LeftSeason
		{
			get { return (Season)LeftSeasonList.SelectedItem; }
		}
		private ComboBox RightSeasonList { get { return ((ComboBox)CurrentPage.Controls.Find("rightSeasonList", true)[0]); } }
		private Season RightSeason
		{
			get { return (Season)RightSeasonList.SelectedItem; }
		}
		private ListBox LeftEpList { get { return ((ListBox)CurrentPage.Controls.Find("leftEpList", true)[0]); } }
		private ListBox RightEpList { get { return ((ListBox)CurrentPage.Controls.Find("rightEpList", true)[0]); } }
		private Button MoveLeftButton { get { return ((Button)CurrentPage.Controls.Find("leftButton", true)[0]); } }
		private Button MoveRightButton { get { return ((Button)CurrentPage.Controls.Find("rightButton", true)[0]); } }

		private void CreatePage()
		{
			TabPage page = new TabPage();
			page.Controls.Add(new AnimeTab());
			animeTabs.TabPages.Add(page);
			animeTabs.SelectTab(animeTabs.TabCount - 1);
		}

		public void AddAnimeTab(Anime anime)
		{
			Log.D($"Adding anime tab {anime}");

			CreatePage();
			CurrentPage.Text = anime.Name;

			AnimeNameBox.Enabled = true;
			SeasonsBox.Enabled = true;

			AnimeName = anime.Name;
			Seasons = $"{anime.NumberSeasons}";

			LeftSeasonList.Items.Clear();
			RightSeasonList.Items.Clear();

			foreach (Season s in anime.Seasons.Values)
			{
				LeftSeasonList.Items.Add(s);
				RightSeasonList.Items.Add(s);
			}

			LeftSeasonList.SelectedIndex = 0;
			RightSeasonList.SelectedIndex = 1;

			RebuildEpisodeLists();
		}

		private void RebuildSeasonList()
		{
			Log.D("Rebuilding season lists");

			LeftSeasonList.Items.Clear();
			RightSeasonList.Items.Clear();

			foreach (Season s in controller.Selected.Seasons.Values)
			{
				LeftSeasonList.Items.Add(s);
				RightSeasonList.Items.Add(s);
			}

			LeftSeasonList.SelectedIndex = 0;
			RightSeasonList.SelectedIndex = 1;
		}

		public void RebuildEpisodeLists()
		{
			Log.D("Rebuilding ep lists");

			RebuildLeftEpisodeList();
			RebuildRightEpisodeList();
		}

		private void RebuildLeftEpisodeList()
		{
			Log.D("Rebuilding left ep list");

			LeftEpList.Items.Clear();
			Season s = (Season)LeftSeasonList.SelectedItem;
			foreach (Episode e in s.Episodes.Values)
			{
				LeftEpList.Items.Add(e);
			}
		}

		private void RebuildRightEpisodeList()
		{
			Log.D("Rebuilding right ep list");

			RightEpList.Items.Clear();
			Season s = (Season)RightSeasonList.SelectedItem;
			foreach (Episode e in s.Episodes.Values)
			{
				RightEpList.Items.Add(e);
			}
		}

		#region menu bar events

		private void OpenFolderToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (browser.ShowDialog() == DialogResult.OK)
			{
				controller.OpenAnimeFolder(browser.SelectedPath);
			}
		}

		private void EpisodesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (browser.ShowDialog() == DialogResult.OK)
			{
				controller.OpenEpisode(browser.SelectedPath);
			}
		}

		private void FolderToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (browser.ShowDialog() == DialogResult.OK)
			{
				controller.OpenEpisodeFolder(browser.SelectedPath);
			}
		}

		private void SaveTab_Click(object sender, EventArgs e)
		{
			controller.SaveActiveTab();
		}

		private void SaveAll_Click(object sender, EventArgs e)
		{
			controller.SaveAll();
		}

		private void CloseTab_Click(object sender, EventArgs e)
		{
			if (animeTabs.TabCount > 1)
			{
				int selected = animeTabs.SelectedIndex;
				Log.I($"Closing tab index={selected}");
				controller.CloseTab(selected);

				//warning: don't use TabPages.RemoveAt(index), it has some sort of race condition that fucks up shit
				animeTabs.Selecting -= AnimeTabs_Selecting;
				animeTabs.Selected -= AnimeTabs_Selected;

				animeTabs.TabPages.Remove(animeTabs.SelectedTab);

				animeTabs.Selecting += AnimeTabs_Selecting;
				animeTabs.Selected += AnimeTabs_Selected;
			}
		}

		private void SaveAnimeList_Click(object sender, EventArgs e)
		{
			controller.SaveAnimeList();
		}

		private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

		private void AboutToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			//new AboutPlexAnimeHelper().Show();
		}

		#endregion menu bar events
		
		#region user control events

		private void Episodes_Click(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				ListView lv = (ListView)sender;

				if (lv.FocusedItem.Bounds.Contains(e.Location))
				{
					menu.Show(Cursor.Position);
				}
			}
		}

		private void AnimeName_TextChanged(object sender, EventArgs e)
		{
			controller.SetName(AnimeName);
		}

		private void Seasons_ValueChanged(object sender, EventArgs e)
		{
			int curNum = controller.GetNumSeasons();
			int num = int.Parse(Seasons) + 1;
			bool increase = curNum < num;

			while (curNum != num)
			{
				if (increase)
				{
					controller.AddSeason();
				}
				else
				{
					controller.DeleteSeason();
				}

				curNum = controller.GetNumSeasons();
			}

			RebuildSeasonList();
		}

		private void RightSeasonList_SelectedIndexChanged(object sender, EventArgs args)
		{
			RebuildRightEpisodeList();
		}

		private void LeftSeasonList_SelectedIndexChanged(object sender, EventArgs args)
		{
			RebuildLeftEpisodeList();
		}

		private void MoveRightButton_Click(object sender, EventArgs args)
		{
			if (LeftSeasonList.SelectedItem == RightSeasonList.SelectedItem ||
				LeftEpList.SelectedItems.Count == 0)
			{
				return;
			}

			foreach (object o in LeftEpList.SelectedItems)
			{
				controller.MoveEpisode(LeftSeason, RightSeason, (Episode)o);
			}

			RebuildLeftEpisodeList();
			RebuildRightEpisodeList();
		}

		private void MoveLeftButton_Click(object sender, EventArgs args)
		{
			if (LeftSeasonList.SelectedItem == RightSeasonList.SelectedItem ||
				RightEpList.SelectedItems.Count == 0)
			{
				return;
			}

			foreach (object o in RightEpList.SelectedItems)
			{
				controller.MoveEpisode(RightSeason, LeftSeason, (Episode)o);
			}

			RebuildLeftEpisodeList();
			RebuildRightEpisodeList();
		}

		#endregion user control events

		private void PlexAnimeHelper_Resize(object sender, EventArgs e)
		{
			if (WindowState == FormWindowState.Minimized)
			{
				Hide();
				taskbarIcon.ShowBalloonTip(1000);
			}
		}

		private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			Show();
			WindowState = FormWindowState.Normal;
		}
	}
}
