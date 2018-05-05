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
			this.autoMoveCheckbox = new System.Windows.Forms.CheckBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.panel5 = new System.Windows.Forms.Panel();
			this.panel6 = new System.Windows.Forms.Panel();
			this.panel7 = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.seasons)).BeginInit();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel6.SuspendLayout();
			this.panel7.SuspendLayout();
			this.SuspendLayout();
			// 
			// leftEpList
			// 
			this.leftEpList.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.leftEpList.FormattingEnabled = true;
			this.leftEpList.Location = new System.Drawing.Point(0, 24);
			this.leftEpList.Name = "leftEpList";
			this.leftEpList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.leftEpList.Size = new System.Drawing.Size(381, 329);
			this.leftEpList.TabIndex = 6;
			// 
			// rightEpList
			// 
			this.rightEpList.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.rightEpList.FormattingEnabled = true;
			this.rightEpList.Location = new System.Drawing.Point(0, 24);
			this.rightEpList.Name = "rightEpList";
			this.rightEpList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.rightEpList.Size = new System.Drawing.Size(382, 329);
			this.rightEpList.TabIndex = 7;
			// 
			// leftSeasonList
			// 
			this.leftSeasonList.Dock = System.Windows.Forms.DockStyle.Top;
			this.leftSeasonList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.leftSeasonList.Location = new System.Drawing.Point(0, 0);
			this.leftSeasonList.Name = "leftSeasonList";
			this.leftSeasonList.Size = new System.Drawing.Size(381, 21);
			this.leftSeasonList.TabIndex = 8;
			// 
			// rightSeasonList
			// 
			this.rightSeasonList.Dock = System.Windows.Forms.DockStyle.Top;
			this.rightSeasonList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.rightSeasonList.FormattingEnabled = true;
			this.rightSeasonList.Location = new System.Drawing.Point(0, 0);
			this.rightSeasonList.Name = "rightSeasonList";
			this.rightSeasonList.Size = new System.Drawing.Size(382, 21);
			this.rightSeasonList.TabIndex = 9;
			// 
			// leftButton
			// 
			this.leftButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.leftButton.Location = new System.Drawing.Point(4, 300);
			this.leftButton.Name = "leftButton";
			this.leftButton.Size = new System.Drawing.Size(62, 50);
			this.leftButton.TabIndex = 11;
			this.leftButton.Text = "<-----";
			this.leftButton.UseVisualStyleBackColor = true;
			// 
			// rightButton
			// 
			this.rightButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.rightButton.Location = new System.Drawing.Point(3, 24);
			this.rightButton.Name = "rightButton";
			this.rightButton.Size = new System.Drawing.Size(62, 50);
			this.rightButton.TabIndex = 10;
			this.rightButton.Text = "----->";
			this.rightButton.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(419, 13);
			this.label1.TabIndex = 12;
			this.label1.Text = "Name:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Top;
			this.label2.Location = new System.Drawing.Point(0, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(419, 13);
			this.label2.TabIndex = 13;
			this.label2.Text = "Number of Seasons";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// seasons
			// 
			this.seasons.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.seasons.Enabled = false;
			this.seasons.Location = new System.Drawing.Point(0, 44);
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
			this.seasons.Size = new System.Drawing.Size(419, 20);
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
			this.name.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.name.Enabled = false;
			this.name.Location = new System.Drawing.Point(0, 44);
			this.name.Name = "name";
			this.name.Size = new System.Drawing.Size(419, 20);
			this.name.TabIndex = 14;
			this.name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// autoScanCheckbox
			// 
			this.autoScanCheckbox.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.autoScanCheckbox.AutoSize = true;
			this.autoScanCheckbox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.autoScanCheckbox.Location = new System.Drawing.Point(170, 26);
			this.autoScanCheckbox.Name = "autoScanCheckbox";
			this.autoScanCheckbox.Size = new System.Drawing.Size(79, 17);
			this.autoScanCheckbox.TabIndex = 16;
			this.autoScanCheckbox.Text = "Auto Scan:";
			this.autoScanCheckbox.UseVisualStyleBackColor = true;
			// 
			// autoMoveCheckbox
			// 
			this.autoMoveCheckbox.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.autoMoveCheckbox.AutoSize = true;
			this.autoMoveCheckbox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.autoMoveCheckbox.Location = new System.Drawing.Point(168, 23);
			this.autoMoveCheckbox.Name = "autoMoveCheckbox";
			this.autoMoveCheckbox.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.autoMoveCheckbox.Size = new System.Drawing.Size(81, 17);
			this.autoMoveCheckbox.TabIndex = 19;
			this.autoMoveCheckbox.Text = "Auto Move:";
			this.autoMoveCheckbox.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.panel1, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 143);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(850, 359);
			this.tableLayoutPanel1.TabIndex = 11;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.Control;
			this.panel1.Controls.Add(this.rightSeasonList);
			this.panel1.Controls.Add(this.rightEpList);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(465, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(382, 353);
			this.panel1.TabIndex = 0;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.SystemColors.Control;
			this.panel2.Controls.Add(this.leftSeasonList);
			this.panel2.Controls.Add(this.leftEpList);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(3, 3);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(381, 353);
			this.panel2.TabIndex = 1;
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.SystemColors.Control;
			this.panel3.Controls.Add(this.rightButton);
			this.panel3.Controls.Add(this.leftButton);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(390, 3);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(69, 353);
			this.panel3.TabIndex = 2;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.Controls.Add(this.panel4, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.panel5, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.panel6, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.panel7, 1, 1);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 2;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(850, 140);
			this.tableLayoutPanel2.TabIndex = 20;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.label1);
			this.panel4.Controls.Add(this.name);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel4.Location = new System.Drawing.Point(3, 3);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(419, 64);
			this.panel4.TabIndex = 0;
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.autoScanCheckbox);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel5.Location = new System.Drawing.Point(428, 3);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(419, 64);
			this.panel5.TabIndex = 1;
			// 
			// panel6
			// 
			this.panel6.Controls.Add(this.label2);
			this.panel6.Controls.Add(this.seasons);
			this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel6.Location = new System.Drawing.Point(3, 73);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(419, 64);
			this.panel6.TabIndex = 2;
			// 
			// panel7
			// 
			this.panel7.Controls.Add(this.autoMoveCheckbox);
			this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel7.Location = new System.Drawing.Point(428, 73);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(419, 64);
			this.panel7.TabIndex = 3;
			// 
			// AnimeTab
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel2);
			this.Controls.Add(this.tableLayoutPanel1);
			this.DoubleBuffered = true;
			this.Name = "AnimeTab";
			this.Size = new System.Drawing.Size(850, 502);
			((System.ComponentModel.ISupportInitialize)(this.seasons)).EndInit();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.panel6.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.panel7.PerformLayout();
			this.ResumeLayout(false);

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
		private System.Windows.Forms.CheckBox autoMoveCheckbox;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel7;
	}
}
