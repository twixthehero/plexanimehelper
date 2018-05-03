using System;
using System.Windows.Forms;

namespace PlexAnimeHelper
{
	public partial class PlexAnimeHelper : Form
	{
		public const string NAME = "Plex Anime Helper";

		private AnimeController controller;
		private ContextMenuStrip menu;

		public PlexAnimeHelper()
		{
			InitializeComponent();

			controller = new AnimeController(this);
			menu = new ContextMenuStrip();

			controller.Init();

			if (animeTabs.TabCount > 0)
			{
				AnimeTabs_Selected(this, new TabControlEventArgs(CurrentPage, animeTabs.TabCount - 1, TabControlAction.Selected));
			}

			switch (ApplicationSettings.Instance.StartMode)
			{
				case EStartMode.Minimized:
					WindowState = FormWindowState.Minimized;
					break;
				case EStartMode.Maximized:
					WindowState = FormWindowState.Maximized;
					break;
			}

			FormClosing += OnStopping;
		}

		private void AnimeTabs_Selecting(object sender, TabControlCancelEventArgs e)
		{
			Log.D($"Unregistering events {CurrentPage?.Text}...");

			AnimeNameBox.TextChanged -= AnimeName_TextChanged;
			AutoMoveBox.CheckedChanged -= AutoMoveBox_CheckedChanged;
			AutoScanBox.CheckedChanged -= AutoScanBox_CheckedChanged;
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
			AutoMoveBox.CheckedChanged += AutoMoveBox_CheckedChanged;
			AutoScanBox.CheckedChanged += AutoScanBox_CheckedChanged;
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
		private CheckBox AutoMoveBox { get { return ((CheckBox)CurrentPage.Controls.Find("autoMoveCheckbox", true)[0]); } }
		public bool AutoMove
		{
			get { return AutoMoveBox.Checked; }
			set { AutoMoveBox.Checked = value; }
		}
		private CheckBox AutoScanBox { get { return ((CheckBox)CurrentPage.Controls.Find("autoScanCheckbox", true)[0]); } }
		public bool AutoScan
		{
			get { return AutoScanBox.Checked; }
			set { AutoScanBox.Checked = value; }
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
			bool noneOpened = animeTabs.TabCount == 0;

			TabPage page = new TabPage();
			page.Controls.Add(new AnimeTab());
			animeTabs.TabPages.Add(page);
			animeTabs.SelectTab(animeTabs.TabCount - 1);

			if (noneOpened)
			{
				AnimeTabs_Selected(this, new TabControlEventArgs(CurrentPage, animeTabs.TabCount - 1, TabControlAction.Selected));
			}
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

			AutoMove = anime.AutoMove;
			AutoScan = anime.AutoScan;

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

		public void ShowTrayNoti(string message)
		{
			taskbarIcon.BalloonTipText = message;
			taskbarIcon.ShowBalloonTip(1000);
		}

		private void CloseActiveTab()
		{
			if (animeTabs.TabCount > 0)
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

		#region menu bar events

		private void OpenFolder_Click(object sender, EventArgs e)
		{
			ShowAnimeFolderBrowser();
		}

		private void AddEpisode_Click(object sender, EventArgs e)
		{
			using (FolderBrowserDialog browser = new FolderBrowserDialog())
			{
				if (browser.ShowDialog() == DialogResult.OK)
				{
					controller.OpenEpisode(browser.SelectedPath);
				}
			}
		}

		private void AddFolder_Click(object sender, EventArgs e)
		{
			using (FolderBrowserDialog browser = new FolderBrowserDialog())
			{
				if (browser.ShowDialog() == DialogResult.OK)
				{
					controller.OpenEpisodeFolder(browser.SelectedPath);
				}
			}
		}

		private void CloseTab_Click(object sender, EventArgs e)
		{
			CloseActiveTab();
		}

		private void SaveTab_Click(object sender, EventArgs e)
		{
			controller.SaveActiveTab();
		}

		private void SaveAll_Click(object sender, EventArgs e)
		{
			controller.SaveAll();
		}

		private void SaveAnimeList_Click(object sender, EventArgs e)
		{
			controller.SaveAnimeList();
		}

		private void Preferences_Click(object sender, EventArgs e)
		{
			using (SettingsControl control = new SettingsControl())
			{
				control.StartPosition = FormStartPosition.CenterParent;
				control.ShowDialog();
			}
		}

		private void Exit_Click(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

		private void About_Click(object sender, EventArgs e)
		{
			using (AboutPlexAnimeHelper window = new AboutPlexAnimeHelper())
			{
				window.StartPosition = FormStartPosition.CenterParent;
				window.ShowDialog();
			}
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

		private void AutoMoveBox_CheckedChanged(object sender, EventArgs e)
		{
			controller.SetAutoMove(AutoMove);
		}

		private void AutoScanBox_CheckedChanged(object sender, EventArgs e)
		{
			controller.SetAutoScan(AutoScan);
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

		private void TrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			Show();
			WindowState = FormWindowState.Normal;
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			switch (keyData)
			{
				case (Keys.Control | Keys.S):
					Log.DD("Ctrl + S");
					Log.D("Saving...");
					controller.SaveActiveTab();
					return true;
				case (Keys.Control | Keys.Shift | Keys.S):
					Log.DD("Ctrl + Shift + S");
					Log.D("Saving all...");
					controller.SaveAll();
					return true;
				case (Keys.Control | Keys.O):
					Log.DD("Ctrl + O");
					Log.D("Opening...");
					ShowAnimeFolderBrowser();
					return true;
				case (Keys.Control | Keys.W):
					Log.DD("Ctrl + W");
					Log.D("Closing tab...");
					CloseActiveTab();
					return true;
			}

			return base.ProcessCmdKey(ref msg, keyData);
		}

		private void ShowAnimeFolderBrowser()
		{
			using (FolderBrowserDialog browser = new FolderBrowserDialog())
			{
				if (browser.ShowDialog() == DialogResult.OK)
				{
					controller.OpenAnimeFolder(browser.SelectedPath);
				}
			}
		}

		private void OnStopping(object sender, FormClosingEventArgs e)
		{
			taskbarIcon.Dispose();
		}
	}
}
