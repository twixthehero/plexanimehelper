namespace PlexAnimeHelper
{
	partial class AnimeTab
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.leftEpList = new System.Windows.Forms.ListBox();
			this.rightEpList = new System.Windows.Forms.ListBox();
			this.leftSeasonList = new System.Windows.Forms.ComboBox();
			this.rightSeasonList = new System.Windows.Forms.ComboBox();
			this.leftButton = new System.Windows.Forms.Button();
			this.rightButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.seasons = new System.Windows.Forms.NumericUpDown();
			this.name = new System.Windows.Forms.TextBox();
			this.autoScanCheckbox = new System.Windows.Forms.CheckBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.autoMoveCheckbox = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.seasons)).BeginInit();
			this.SuspendLayout();
			// 
			// leftEpList
			// 
			this.leftEpList.FormattingEnabled = true;
			this.leftEpList.Location = new System.Drawing.Point(3, 168);
			this.leftEpList.Name = "leftEpList";
			this.leftEpList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.leftEpList.Size = new System.Drawing.Size(378, 329);
			this.leftEpList.TabIndex = 6;
			// 
			// rightEpList
			// 
			this.rightEpList.FormattingEnabled = true;
			this.rightEpList.Location = new System.Drawing.Point(468, 168);
			this.rightEpList.Name = "rightEpList";
			this.rightEpList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.rightEpList.Size = new System.Drawing.Size(379, 329);
			this.rightEpList.TabIndex = 7;
			// 
			// leftSeasonList
			// 
			this.leftSeasonList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.leftSeasonList.Location = new System.Drawing.Point(3, 141);
			this.leftSeasonList.Name = "leftSeasonList";
			this.leftSeasonList.Size = new System.Drawing.Size(378, 21);
			this.leftSeasonList.TabIndex = 8;
			// 
			// rightSeasonList
			// 
			this.rightSeasonList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.rightSeasonList.FormattingEnabled = true;
			this.rightSeasonList.Location = new System.Drawing.Point(468, 141);
			this.rightSeasonList.Name = "rightSeasonList";
			this.rightSeasonList.Size = new System.Drawing.Size(379, 21);
			this.rightSeasonList.TabIndex = 9;
			// 
			// leftButton
			// 
			this.leftButton.Location = new System.Drawing.Point(387, 348);
			this.leftButton.Name = "leftButton";
			this.leftButton.Size = new System.Drawing.Size(75, 23);
			this.leftButton.TabIndex = 11;
			this.leftButton.Text = "<-----";
			this.leftButton.UseVisualStyleBackColor = true;
			// 
			// rightButton
			// 
			this.rightButton.Location = new System.Drawing.Point(387, 288);
			this.rightButton.Name = "rightButton";
			this.rightButton.Size = new System.Drawing.Size(75, 23);
			this.rightButton.TabIndex = 10;
			this.rightButton.Text = "----->";
			this.rightButton.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Location = new System.Drawing.Point(26, 30);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(144, 20);
			this.label1.TabIndex = 12;
			this.label1.Text = "Name:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.Location = new System.Drawing.Point(26, 91);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(144, 20);
			this.label2.TabIndex = 13;
			this.label2.Text = "Number of Seasons";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// seasons
			// 
			this.seasons.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.seasons.Enabled = false;
			this.seasons.Location = new System.Drawing.Point(176, 91);
			this.seasons.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this.seasons.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.seasons.Name = "seasons";
			this.seasons.Size = new System.Drawing.Size(145, 20);
			this.seasons.TabIndex = 15;
			this.seasons.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.seasons.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// name
			// 
			this.name.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.name.Enabled = false;
			this.name.Location = new System.Drawing.Point(176, 30);
			this.name.Name = "name";
			this.name.Size = new System.Drawing.Size(145, 20);
			this.name.TabIndex = 14;
			this.name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// autoScanCheckbox
			// 
			this.autoScanCheckbox.AutoSize = true;
			this.autoScanCheckbox.Location = new System.Drawing.Point(610, 36);
			this.autoScanCheckbox.Name = "autoScanCheckbox";
			this.autoScanCheckbox.Size = new System.Drawing.Size(15, 14);
			this.autoScanCheckbox.TabIndex = 16;
			this.autoScanCheckbox.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(530, 36);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(60, 13);
			this.label3.TabIndex = 17;
			this.label3.Text = "Auto Scan:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(530, 91);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(62, 13);
			this.label4.TabIndex = 18;
			this.label4.Text = "Auto Move:";
			// 
			// autoMoveCheckbox
			// 
			this.autoMoveCheckbox.AutoSize = true;
			this.autoMoveCheckbox.Location = new System.Drawing.Point(610, 91);
			this.autoMoveCheckbox.Name = "autoMoveCheckbox";
			this.autoMoveCheckbox.Size = new System.Drawing.Size(15, 14);
			this.autoMoveCheckbox.TabIndex = 19;
			this.autoMoveCheckbox.UseVisualStyleBackColor = true;
			// 
			// AnimeTab
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.autoMoveCheckbox);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.autoScanCheckbox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.seasons);
			this.Controls.Add(this.name);
			this.Controls.Add(this.leftButton);
			this.Controls.Add(this.rightButton);
			this.Controls.Add(this.rightSeasonList);
			this.Controls.Add(this.leftSeasonList);
			this.Controls.Add(this.rightEpList);
			this.Controls.Add(this.leftEpList);
			this.Name = "AnimeTab";
			this.Size = new System.Drawing.Size(850, 500);
			((System.ComponentModel.ISupportInitialize)(this.seasons)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.ListBox leftEpList;
		private System.Windows.Forms.ListBox rightEpList;
		private System.Windows.Forms.ComboBox leftSeasonList;
		private System.Windows.Forms.ComboBox rightSeasonList;
		private System.Windows.Forms.Button leftButton;
		private System.Windows.Forms.Button rightButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown seasons;
		private System.Windows.Forms.TextBox name;
		private System.Windows.Forms.CheckBox autoScanCheckbox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.CheckBox autoMoveCheckbox;
	}
}
