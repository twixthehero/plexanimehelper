namespace PlexAnimeHelper
{
	partial class PlexAnimeHelper
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlexAnimeHelper));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.openFolderButton = new System.Windows.Forms.ToolStripMenuItem();
			this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addEpisodesButton = new System.Windows.Forms.ToolStripMenuItem();
			this.addFolderButton = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.closeTabButton = new System.Windows.Forms.ToolStripMenuItem();
			this.closeAllTabsButton = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.saveTabButton = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAllTabsButton = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAnimeListButton = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.importSettingsButton = new System.Windows.Forms.ToolStripMenuItem();
			this.exportSettingsButton = new System.Windows.Forms.ToolStripMenuItem();
			this.settingsButton = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.exitButton = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutButton = new System.Windows.Forms.ToolStripMenuItem();
			this.animeTabs = new System.Windows.Forms.TabControl();
			this.taskbarIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.aboutMenu});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(972, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileMenu
			// 
			this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFolderButton,
            this.addToolStripMenuItem,
            this.toolStripSeparator4,
            this.closeTabButton,
            this.closeAllTabsButton,
            this.toolStripSeparator2,
            this.saveTabButton,
            this.saveAllTabsButton,
            this.saveAnimeListButton,
            this.toolStripSeparator1,
            this.importSettingsButton,
            this.exportSettingsButton,
            this.settingsButton,
            this.toolStripSeparator3,
            this.exitButton});
			this.fileMenu.Name = "fileMenu";
			this.fileMenu.Size = new System.Drawing.Size(37, 20);
			this.fileMenu.Text = "File";
			// 
			// openFolderButton
			// 
			this.openFolderButton.Name = "openFolderButton";
			this.openFolderButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.openFolderButton.Size = new System.Drawing.Size(224, 22);
			this.openFolderButton.Text = "Open Folder...";
			this.openFolderButton.Click += new System.EventHandler(this.OpenFolder_Click);
			// 
			// addToolStripMenuItem
			// 
			this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addEpisodesButton,
            this.addFolderButton});
			this.addToolStripMenuItem.Name = "addToolStripMenuItem";
			this.addToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
			this.addToolStripMenuItem.Text = "Add";
			// 
			// addEpisodesButton
			// 
			this.addEpisodesButton.Name = "addEpisodesButton";
			this.addEpisodesButton.Size = new System.Drawing.Size(129, 22);
			this.addEpisodesButton.Text = "Episodes...";
			this.addEpisodesButton.Click += new System.EventHandler(this.AddEpisode_Click);
			// 
			// addFolderButton
			// 
			this.addFolderButton.Name = "addFolderButton";
			this.addFolderButton.Size = new System.Drawing.Size(129, 22);
			this.addFolderButton.Text = "Folder...";
			this.addFolderButton.Click += new System.EventHandler(this.AddFolder_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(221, 6);
			// 
			// closeTabButton
			// 
			this.closeTabButton.Name = "closeTabButton";
			this.closeTabButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
			this.closeTabButton.Size = new System.Drawing.Size(224, 22);
			this.closeTabButton.Text = "Close Tab";
			this.closeTabButton.Click += new System.EventHandler(this.CloseTab_Click);
			// 
			// closeAllTabsButton
			// 
			this.closeAllTabsButton.Name = "closeAllTabsButton";
			this.closeAllTabsButton.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.W)));
			this.closeAllTabsButton.Size = new System.Drawing.Size(224, 22);
			this.closeAllTabsButton.Text = "Close All Tabs";
			this.closeAllTabsButton.Click += new System.EventHandler(this.CloseAllTabs_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(221, 6);
			// 
			// saveTabButton
			// 
			this.saveTabButton.Name = "saveTabButton";
			this.saveTabButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.saveTabButton.Size = new System.Drawing.Size(224, 22);
			this.saveTabButton.Text = "Save Tab";
			this.saveTabButton.Click += new System.EventHandler(this.SaveTab_Click);
			// 
			// saveAllTabsButton
			// 
			this.saveAllTabsButton.Name = "saveAllTabsButton";
			this.saveAllTabsButton.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
			this.saveAllTabsButton.Size = new System.Drawing.Size(224, 22);
			this.saveAllTabsButton.Text = "Save All Tabs";
			this.saveAllTabsButton.Click += new System.EventHandler(this.SaveAll_Click);
			// 
			// saveAnimeListButton
			// 
			this.saveAnimeListButton.Name = "saveAnimeListButton";
			this.saveAnimeListButton.Size = new System.Drawing.Size(224, 22);
			this.saveAnimeListButton.Text = "Save Anime List";
			this.saveAnimeListButton.Click += new System.EventHandler(this.SaveAnimeList_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(221, 6);
			// 
			// importSettingsButton
			// 
			this.importSettingsButton.Name = "importSettingsButton";
			this.importSettingsButton.Size = new System.Drawing.Size(224, 22);
			this.importSettingsButton.Text = "Import Settings";
			this.importSettingsButton.Click += new System.EventHandler(this.ImportSettingsButton_Click);
			// 
			// exportSettingsButton
			// 
			this.exportSettingsButton.Name = "exportSettingsButton";
			this.exportSettingsButton.Size = new System.Drawing.Size(224, 22);
			this.exportSettingsButton.Text = "Export Settings";
			this.exportSettingsButton.Click += new System.EventHandler(this.ExportSettingsButton_Click);
			// 
			// settingsButton
			// 
			this.settingsButton.Name = "settingsButton";
			this.settingsButton.Size = new System.Drawing.Size(224, 22);
			this.settingsButton.Text = "Settings...";
			this.settingsButton.Click += new System.EventHandler(this.Preferences_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(221, 6);
			// 
			// exitButton
			// 
			this.exitButton.Name = "exitButton";
			this.exitButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
			this.exitButton.Size = new System.Drawing.Size(224, 22);
			this.exitButton.Text = "Exit";
			this.exitButton.Click += new System.EventHandler(this.Exit_Click);
			// 
			// aboutMenu
			// 
			this.aboutMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutButton});
			this.aboutMenu.Name = "aboutMenu";
			this.aboutMenu.Size = new System.Drawing.Size(52, 20);
			this.aboutMenu.Text = "About";
			// 
			// aboutButton
			// 
			this.aboutButton.Name = "aboutButton";
			this.aboutButton.Size = new System.Drawing.Size(107, 22);
			this.aboutButton.Text = "About";
			this.aboutButton.Click += new System.EventHandler(this.About_Click);
			// 
			// animeTabs
			// 
			this.animeTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.animeTabs.Location = new System.Drawing.Point(13, 27);
			this.animeTabs.Name = "animeTabs";
			this.animeTabs.SelectedIndex = 0;
			this.animeTabs.Size = new System.Drawing.Size(947, 592);
			this.animeTabs.TabIndex = 9;
			this.animeTabs.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.AnimeTabs_Selecting);
			this.animeTabs.Selected += new System.Windows.Forms.TabControlEventHandler(this.AnimeTabs_Selected);
			this.animeTabs.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AnimeTabs_MouseClick);
			// 
			// taskbarIcon
			// 
			this.taskbarIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			this.taskbarIcon.BalloonTipText = "Plex Anime Helper is now running in the background.";
			this.taskbarIcon.BalloonTipTitle = "Plex Anime Helper";
			this.taskbarIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("taskbarIcon.Icon")));
			this.taskbarIcon.Text = "Plex Anime Helper";
			this.taskbarIcon.Visible = true;
			this.taskbarIcon.BalloonTipClicked += new System.EventHandler(this.TaskbarIcon_BalloonTipClicked);
			this.taskbarIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TrayIcon_MouseClick);
			// 
			// PlexAnimeHelper
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(972, 631);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.animeTabs);
			this.DoubleBuffered = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(500, 650);
			this.Name = "PlexAnimeHelper";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "PlexAnimeHelper";
			this.Resize += new System.EventHandler(this.PlexAnimeHelper_Resize);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileMenu;
		private System.Windows.Forms.ToolStripMenuItem openFolderButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem exitButton;
		private System.Windows.Forms.ToolStripMenuItem aboutMenu;
		private System.Windows.Forms.ToolStripMenuItem aboutButton;
		private System.Windows.Forms.ToolStripMenuItem saveTabButton;
		private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addEpisodesButton;
		private System.Windows.Forms.ToolStripMenuItem addFolderButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.TabControl animeTabs;
		private System.Windows.Forms.ToolStripMenuItem closeTabButton;
		private System.Windows.Forms.ToolStripMenuItem saveAllTabsButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem saveAnimeListButton;
		private System.Windows.Forms.NotifyIcon taskbarIcon;
		private System.Windows.Forms.ToolStripMenuItem settingsButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem importSettingsButton;
		private System.Windows.Forms.ToolStripMenuItem exportSettingsButton;
		private System.Windows.Forms.ToolStripMenuItem closeAllTabsButton;
	}
}

