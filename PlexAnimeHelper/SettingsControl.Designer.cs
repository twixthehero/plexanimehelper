﻿namespace PlexAnimeHelper
{
	partial class SettingsControl
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsControl));
			this.cancelButton = new System.Windows.Forms.Button();
			this.saveButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.startupBehaviour = new System.Windows.Forms.ComboBox();
			this.rescanTime = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.closeBehaviour = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.rescanTime)).BeginInit();
			this.SuspendLayout();
			// 
			// cancelButton
			// 
			this.cancelButton.Location = new System.Drawing.Point(447, 326);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 0;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.Cancel_Click);
			// 
			// saveButton
			// 
			this.saveButton.Location = new System.Drawing.Point(366, 326);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(75, 23);
			this.saveButton.TabIndex = 1;
			this.saveButton.Text = "Save";
			this.saveButton.UseVisualStyleBackColor = true;
			this.saveButton.Click += new System.EventHandler(this.Save_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(95, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Startup Behaviour:";
			// 
			// startupBehaviour
			// 
			this.startupBehaviour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.startupBehaviour.FormattingEnabled = true;
			this.startupBehaviour.Location = new System.Drawing.Point(366, 10);
			this.startupBehaviour.Name = "startupBehaviour";
			this.startupBehaviour.Size = new System.Drawing.Size(156, 21);
			this.startupBehaviour.TabIndex = 3;
			// 
			// rescanTime
			// 
			this.rescanTime.Location = new System.Drawing.Point(365, 64);
			this.rescanTime.Maximum = new decimal(new int[] {
            1440,
            0,
            0,
            0});
			this.rescanTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.rescanTime.Name = "rescanTime";
			this.rescanTime.Size = new System.Drawing.Size(156, 20);
			this.rescanTime.TabIndex = 4;
			this.rescanTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.rescanTime.ThousandsSeparator = true;
			this.rescanTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 66);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(119, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Rescan Time (Minutes):";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(13, 40);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(87, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Close Behaviour:";
			// 
			// closeBehaviour
			// 
			this.closeBehaviour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.closeBehaviour.FormattingEnabled = true;
			this.closeBehaviour.Location = new System.Drawing.Point(366, 37);
			this.closeBehaviour.Name = "closeBehaviour";
			this.closeBehaviour.Size = new System.Drawing.Size(155, 21);
			this.closeBehaviour.TabIndex = 7;
			this.closeBehaviour.SelectedValueChanged += new System.EventHandler(this.CloseBehaviourChanged);
			// 
			// SettingsControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(534, 361);
			this.Controls.Add(this.closeBehaviour);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.rescanTime);
			this.Controls.Add(this.startupBehaviour);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.saveButton);
			this.Controls.Add(this.cancelButton);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "SettingsControl";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Settings";
			((System.ComponentModel.ISupportInitialize)(this.rescanTime)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button saveButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox startupBehaviour;
		private System.Windows.Forms.NumericUpDown rescanTime;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox closeBehaviour;
	}
}