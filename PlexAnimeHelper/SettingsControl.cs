using System;
using System.Windows.Forms;

namespace PlexAnimeHelper
{
	public partial class SettingsControl : Form
	{
		private ApplicationSettings settings;
		private ApplicationSettings temp;

		private bool isSaved = false;

		public SettingsControl()
		{
			InitializeComponent();
			
			settings = ApplicationSettings.Instance;
			//store copy to reset back to
			temp = new ApplicationSettings(settings);
			
			startupBehaviour.Items.Add(EStartMode.None);
			startupBehaviour.Items.Add(EStartMode.Minimized);
			startupBehaviour.Items.Add(EStartMode.Visible);
			startupBehaviour.Items.Add(EStartMode.Maximized);
			startupBehaviour.SelectedIndex = (int)settings.StartMode;
			startupBehaviour.SelectedIndexChanged += StartBehaviourChanged;

			rescanTime.Value = settings.RescanTime;
			rescanTime.ValueChanged += RescanTime_ValueChanged;

			FormClosing += OnStopping;

			saveButton.Enabled = false;
		}

		private void RescanTime_ValueChanged(object sender, EventArgs e)
		{
			settings.RescanTime = (int)rescanTime.Value;
			Log.D($"RescanTime: {settings.RescanTime}");
			CheckEnableSave();
		}

		private void CheckEnableSave()
		{
			saveButton.Enabled = settings != temp;
		}

		private void StartBehaviourChanged(object sender, EventArgs e)
		{
			settings.StartMode = (EStartMode)startupBehaviour.SelectedIndex;
			Log.D($"StartMode: {settings.StartMode}");
			CheckEnableSave();
		}

		private void Save_Click(object sender, EventArgs e)
		{
			ApplicationSettings.Save();
			isSaved = true;
			Close();
		}

		private void Cancel_Click(object sender, EventArgs e)
		{
			ApplicationSettings.ResetInstance(temp);
			Close();
		}

		private void OnStopping(object sender, EventArgs e)
		{
			return;
			if (!isSaved && settings != temp)
			{
				((FormClosingEventArgs)e).Cancel = MessageBox.Show("Cancel without saving?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes;
			}
			else
			{
				Close();
			}
		}
	}
}
