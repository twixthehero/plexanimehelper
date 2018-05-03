namespace PlexAnimeHelper
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
			// SettingsControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(534, 361);
			this.Controls.Add(this.startupBehaviour);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.saveButton);
			this.Controls.Add(this.cancelButton);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "SettingsControl";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Settings";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button saveButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox startupBehaviour;
	}
}