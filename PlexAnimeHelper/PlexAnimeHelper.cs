using System;
using System.Windows.Forms;

namespace PlexAnimeHelper
{
	public partial class PlexAnimeHelper : Form
	{
		public const string NAME = "Plex Anime Helper";

		public static PlexAnimeHelper Instance { get; set; }

		private AnimeController controller;
		private ContextMenu menu;

		public PlexAnimeHelper()
		{
			Instance = this;

			InitializeComponent();

			controller = new AnimeController(this);
			menu = new ContextMenu(new MenuItem[] 
			{
				new MenuItem("Save", (sender, e) =>
				{
					SaveTab_Click(sender, e);
				}),
				new MenuItem("Close", (sender, e) =>
				{
					CloseTab_Click(sender, e);
				}),
				new MenuItem("Close All", (sender, e) =>
				{
					CloseAllTabs_Click(sender, e);
				}),
				new MenuItem("Close All But This", (sender, e) =>
				{
					CloseAllTabsExceptActive();
				})
			});

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

		public void Reinit()
		{
			CloseAllTabs(false);

			controller.Init();

			if (animeTabs.TabCount > 0)
			{
				AnimeTabs_Selected(this, new TabControlEventArgs(CurrentPage, animeTabs.TabCount - 1, TabControlAction.Selected));
			}
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

		private TextBox GetAnimeNameBox(TabPage page)
		{
			return (TextBox)page.Controls.Find("name", true)[0];
		}

		private NumericUpDown GetSeasonsBox(TabPage page)
		{
			return (NumericUpDown)page.Controls.Find("seasons", true)[0];
		}

		private CheckBox GetAutoMoveBox(TabPage page)
		{
			return (CheckBox)page.Controls.Find("autoMoveCheckbox", true)[0];
		}

		private CheckBox GetAutoScanBox(TabPage page)
		{
			return (CheckBox)page.Controls.Find("autoScanCheckbox", true)[0];
		}

		private ComboBox GetLeftSeasonList(TabPage page)
		{
			return (ComboBox)page.Controls.Find("leftSeasonList", true)[0];
		}

		private ComboBox GetRightSeasonList(TabPage page)
		{
			return (ComboBox)page.Controls.Find("rightSeasonList", true)[0];
		}

		private ListBox GetLeftEpList(TabPage page)
		{
			return (ListBox)page.Controls.Find("leftEpList", true)[0];
		}

		private ListBox GetRightEpList(TabPage page)
		{
			return (ListBox)page.Controls.Find("rightEpList", true)[0];
		}

		private Button GetMoveLeftButton(TabPage page)
		{
			return (Button)page.Controls.Find("leftButton", true)[0];
		}

		private Button GetMoveRightButton(TabPage page)
		{
			return (Button)page.Controls.Find("rightButton", true)[0];
		}

		private void CreatePage()
		{
			bool noneOpened = animeTabs.TabCount == 0;

			TabPage page = new TabPage();
			page.Controls.Add(new AnimeTab() { Dock = DockStyle.Fill });
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

		/// <summary>
		/// Recreate the episode lists on a given tab page
		/// </summary>
		/// <param name="index">Index of tab page to rebuild</param>
		public void RebuildEpisodeLists(int index)
		{
			TabPage page = animeTabs.TabPages[index];
			RebuildEpisodeList(GetLeftSeasonList(page), GetLeftEpList(page));
			RebuildEpisodeList(GetRightSeasonList(page), GetRightEpList(page));
		}

		/// <summary>
		/// Rebuild the currently selected tab page left episode list
		/// </summary>
		private void RebuildLeftEpisodeList()
		{
			RebuildEpisodeList(LeftSeasonList, LeftEpList);
		}

		/// <summary>
		/// Rebuild the currently selected tab page right episode list
		/// </summary>
		private void RebuildRightEpisodeList()
		{
			RebuildEpisodeList(RightSeasonList, RightEpList);
		}

		private void RebuildEpisodeList(ComboBox seasonList, ListBox epList)
		{
			Log.D("Rebuilding ep list");

			epList.Items.Clear();
			Season s = (Season)seasonList.SelectedItem;
			foreach (Episode e in s.Episodes.Values)
			{
				epList.Items.Add(e);
			}
		}

		public void ShowTrayNoti(string message)
		{
			taskbarIcon.BalloonTipText = message;
			taskbarIcon.ShowBalloonTip(1000);
		}

		private void CloseTab(int index, bool removeFromWatch = true)
		{
			if (animeTabs.TabCount > 0)
			{
				Log.D($"Closing tab index={index}");
				controller.CloseTab(index, removeFromWatch);

				animeTabs.Selecting -= AnimeTabs_Selecting;
				animeTabs.Selected -= AnimeTabs_Selected;

				//warning: don't use TabPages.RemoveAt(index), it has some sort of race condition that fucks up shit
				animeTabs.TabPages.Remove(animeTabs.TabPages[index]);

				animeTabs.Selecting += AnimeTabs_Selecting;
				animeTabs.Selected += AnimeTabs_Selected;
			}
		}

		private void CloseActiveTab(bool removeFromWatch = true)
		{
			CloseTab(animeTabs.SelectedIndex, removeFromWatch);
		}

		private void CloseAllTabsExceptActive(bool removeFromWatch = true)
		{
			int currentSelected = animeTabs.SelectedIndex;

			for (int i = animeTabs.TabCount - 1; i >= 0; i--)
			{
				if (i == currentSelected)
				{
					continue;
				}
				
				CloseTab(i);
			}
		}

		private void CloseAllTabs(bool removeFromWatch = true)
		{
			while (animeTabs.TabPages.Count > 0)
			{
				CloseActiveTab(false);
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

		private void CloseAllTabs_Click(object sender, EventArgs e)
		{
			CloseAllTabs();
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

		private void ImportSettingsButton_Click(object sender, EventArgs e)
		{
			using (FolderBrowserDialog browser = new FolderBrowserDialog())
			{
				if (browser.ShowDialog() == DialogResult.OK)
				{
					ApplicationSettings.LoadFrom(browser.SelectedPath);
				}
			}
		}

		private void ExportSettingsButton_Click(object sender, EventArgs e)
		{
			using (SaveFileDialog dialog = new SaveFileDialog())
			{
				dialog.AddExtension = true;
				dialog.DefaultExt = ".json";
				dialog.DereferenceLinks = true;
				dialog.FileName = ApplicationSettings.SETTINGS_FILE;
				dialog.Filter = "JSON Files (*.json)|*.json";
				dialog.OverwritePrompt = true;
				dialog.ValidateNames = true;

				if (dialog.ShowDialog() == DialogResult.OK)
				{
					ApplicationSettings.SaveTo(dialog.FileName);
				}
			}
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

		private void TrayIcon_MouseClick(object sender, MouseEventArgs e)
		{
			Show();
			WindowState = FormWindowState.Normal;
		}

		/// <summary>
		/// Handle keyboard shortcuts
		/// </summary>
		/// <param name="msg"></param>
		/// <param name="keyData"></param>
		/// <returns></returns>
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
				case (Keys.Control | Keys.Shift | Keys.W):
					Log.DD("Ctrl + Shift + W");
					Log.D("Closing all tabs...");
					CloseAllTabs();
					return true;
				case (Keys.Control | Keys.Left):
					MoveSelectedTabLeft();
					return true;
				case (Keys.Control | Keys.Right):
					MoveSelectedTabRight();
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
			taskbarIcon.Visible = false;
			taskbarIcon.Icon = null;
		}

		private void TaskbarIcon_BalloonTipClicked(object sender, EventArgs e)
		{
			Show();
			WindowState = FormWindowState.Normal;
		}

		private void MoveSelectedTabLeft()
		{
			animeTabs.SelectTab((animeTabs.SelectedIndex - 1 + animeTabs.TabCount) % animeTabs.TabCount);
		}

		private void MoveSelectedTabRight()
		{
			animeTabs.SelectTab((animeTabs.SelectedIndex + 1) % animeTabs.TabCount);
		}

		private void AnimeTabs_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				for (int i = 0; i < animeTabs.TabCount; i++)
				{
					if (animeTabs.GetTabRect(i).Contains(e.Location))
					{
						animeTabs.SelectTab(i);
						break;
					}
				}
				
				menu.Show(this, PointToClient(animeTabs.PointToScreen(e.Location)));
			}
		}
	}
}
