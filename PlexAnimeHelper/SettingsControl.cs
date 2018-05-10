using System;
using System.Windows.Forms;

namespace PlexAnimeHelper
{
	public partial class SettingsControl : Form
	{
		private ApplicationSettings temp;

		private bool isSaved = false;

		public SettingsControl()
		{
			InitializeComponent();
			
			//use copy to modify
			temp = new ApplicationSettings(ApplicationSettings.Instance);
			
			startupBehaviour.Items.Add(EStartMode.None);
			startupBehaviour.Items.Add(EStartMode.Minimized);
			startupBehaviour.Items.Add(EStartMode.Visible);
			startupBehaviour.Items.Add(EStartMode.Maximized);
			startupBehaviour.SelectedIndex = (int)temp.StartMode;
			startupBehaviour.SelectedIndexChanged += StartBehaviourChanged;

			closeBehaviour.Items.Add(ECloseBehaviour.Exit);
			closeBehaviour.Items.Add(ECloseBehaviour.MinimizeTray);
			closeBehaviour.SelectedIndex = (int)temp.CloseBehaviour;

			rescanTime.Value = temp.RescanTime;
			rescanTime.ValueChanged += RescanTime_ValueChanged;

			FormClosing += OnStopping;

			saveButton.Enabled = false;
		}

		private void RescanTime_ValueChanged(object sender, EventArgs e)
		{
			temp.RescanTime = (int)rescanTime.Value;
			Log.D($"RescanTime: {temp.RescanTime}");
			CheckEnableSave();
		}

		private void CheckEnableSave()
		{
			saveButton.Enabled = temp != ApplicationSettings.Instance;
		}

		private void StartBehaviourChanged(object sender, EventArgs e)
		{
			temp.StartMode = (EStartMode)startupBehaviour.SelectedIndex;
			Log.D($"StartMode: {temp.StartMode}");
			CheckEnableSave();
		}

		private void CloseBehaviourChanged(object sender, EventArgs e)
		{
			temp.CloseBehaviour = (ECloseBehaviour)closeBehaviour.SelectedIndex;
			Log.D($"CloseBehaviour: {temp.CloseBehaviour}");
			CheckEnableSave();
		}

		private void Save_Click(object sender, EventArgs e)
		{
			ApplicationSettings.Apply(temp);
			isSaved = true;
			Close();
		}

		private void Cancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void OnStopping(object sender, EventArgs e)
		{
			if (!isSaved && temp != ApplicationSettings.Instance)
			{
				((FormClosingEventArgs)e).Cancel = MessageBox.Show("Cancel without saving?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes;
			}
		}
	}
}
