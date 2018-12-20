namespace Camera
{
    partial class Form1
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
			this.videoPlayer = new AForge.Controls.VideoSourcePlayer();
			this.deviceListBox = new System.Windows.Forms.ComboBox();
			this.findDevicesButton = new System.Windows.Forms.Button();
			this.cameraButton = new System.Windows.Forms.Button();
			this.makePhoto = new System.Windows.Forms.Button();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.cameraSettingsButton = new System.Windows.Forms.Button();
			this.recordVideoButton = new System.Windows.Forms.Button();
			this.resolutionBox = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.cameraPage = new System.Windows.Forms.TabPage();
			this.motionBox = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.recordedFilesPage = new System.Windows.Forms.TabPage();
			this.fileList = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tabControl.SuspendLayout();
			this.cameraPage.SuspendLayout();
			this.recordedFilesPage.SuspendLayout();
			this.SuspendLayout();
			// 
			// videoPlayer
			// 
			this.videoPlayer.Location = new System.Drawing.Point(3, 3);
			this.videoPlayer.Name = "videoPlayer";
			this.videoPlayer.Size = new System.Drawing.Size(434, 346);
			this.videoPlayer.TabIndex = 0;
			this.videoPlayer.Text = "videoSourcePlayer1";
			this.videoPlayer.VideoSource = null;
			// 
			// deviceListBox
			// 
			this.deviceListBox.FormattingEnabled = true;
			this.deviceListBox.Location = new System.Drawing.Point(6, 355);
			this.deviceListBox.Name = "deviceListBox";
			this.deviceListBox.Size = new System.Drawing.Size(363, 24);
			this.deviceListBox.TabIndex = 1;
			// 
			// findDevicesButton
			// 
			this.findDevicesButton.Location = new System.Drawing.Point(6, 386);
			this.findDevicesButton.Name = "findDevicesButton";
			this.findDevicesButton.Size = new System.Drawing.Size(184, 43);
			this.findDevicesButton.TabIndex = 2;
			this.findDevicesButton.Text = "Znajdź urządzenia";
			this.findDevicesButton.UseVisualStyleBackColor = true;
			this.findDevicesButton.Click += new System.EventHandler(this.findDevicesButton_Click);
			// 
			// cameraButton
			// 
			this.cameraButton.Location = new System.Drawing.Point(196, 385);
			this.cameraButton.Name = "cameraButton";
			this.cameraButton.Size = new System.Drawing.Size(173, 43);
			this.cameraButton.TabIndex = 3;
			this.cameraButton.Text = "Start/Stop capture";
			this.cameraButton.UseVisualStyleBackColor = true;
			this.cameraButton.Click += new System.EventHandler(this.cameraButton_Click);
			// 
			// makePhoto
			// 
			this.makePhoto.Enabled = false;
			this.makePhoto.Location = new System.Drawing.Point(443, 6);
			this.makePhoto.Name = "makePhoto";
			this.makePhoto.Size = new System.Drawing.Size(120, 53);
			this.makePhoto.TabIndex = 4;
			this.makePhoto.Text = "Zrób zdjęcie";
			this.makePhoto.UseVisualStyleBackColor = true;
			this.makePhoto.Click += new System.EventHandler(this.makePhoto_Click);
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.InitialDirectory = "Nagrania\\";
			// 
			// cameraSettingsButton
			// 
			this.cameraSettingsButton.Enabled = false;
			this.cameraSettingsButton.Location = new System.Drawing.Point(688, 388);
			this.cameraSettingsButton.Name = "cameraSettingsButton";
			this.cameraSettingsButton.Size = new System.Drawing.Size(111, 44);
			this.cameraSettingsButton.TabIndex = 5;
			this.cameraSettingsButton.Text = "Ustawienia";
			this.cameraSettingsButton.UseVisualStyleBackColor = true;
			this.cameraSettingsButton.Click += new System.EventHandler(this.cameraSettingsButton_Click);
			// 
			// recordVideoButton
			// 
			this.recordVideoButton.Enabled = false;
			this.recordVideoButton.Location = new System.Drawing.Point(443, 65);
			this.recordVideoButton.Name = "recordVideoButton";
			this.recordVideoButton.Size = new System.Drawing.Size(120, 54);
			this.recordVideoButton.TabIndex = 6;
			this.recordVideoButton.Text = "Nagraj film";
			this.recordVideoButton.UseVisualStyleBackColor = true;
			this.recordVideoButton.Click += new System.EventHandler(this.recordVideoButton_Click);
			// 
			// resolutionBox
			// 
			this.resolutionBox.FormattingEnabled = true;
			this.resolutionBox.Location = new System.Drawing.Point(569, 35);
			this.resolutionBox.Name = "resolutionBox";
			this.resolutionBox.Size = new System.Drawing.Size(212, 24);
			this.resolutionBox.TabIndex = 7;
			this.resolutionBox.SelectedIndexChanged += new System.EventHandler(this.resolutionBox_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(604, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(148, 17);
			this.label1.TabIndex = 8;
			this.label1.Text = "Rozdzielczość kamery";
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.cameraPage);
			this.tabControl.Controls.Add(this.recordedFilesPage);
			this.tabControl.Location = new System.Drawing.Point(2, 3);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(813, 467);
			this.tabControl.TabIndex = 9;
			// 
			// cameraPage
			// 
			this.cameraPage.Controls.Add(this.motionBox);
			this.cameraPage.Controls.Add(this.label2);
			this.cameraPage.Controls.Add(this.videoPlayer);
			this.cameraPage.Controls.Add(this.cameraSettingsButton);
			this.cameraPage.Controls.Add(this.label1);
			this.cameraPage.Controls.Add(this.deviceListBox);
			this.cameraPage.Controls.Add(this.findDevicesButton);
			this.cameraPage.Controls.Add(this.cameraButton);
			this.cameraPage.Controls.Add(this.makePhoto);
			this.cameraPage.Controls.Add(this.resolutionBox);
			this.cameraPage.Controls.Add(this.recordVideoButton);
			this.cameraPage.Location = new System.Drawing.Point(4, 25);
			this.cameraPage.Name = "cameraPage";
			this.cameraPage.Padding = new System.Windows.Forms.Padding(3);
			this.cameraPage.Size = new System.Drawing.Size(805, 438);
			this.cameraPage.TabIndex = 0;
			this.cameraPage.Text = "Camera";
			this.cameraPage.UseVisualStyleBackColor = true;
			// 
			// motionBox
			// 
			this.motionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.motionBox.FormattingEnabled = true;
			this.motionBox.Items.AddRange(new object[] {
            "0",
            "10",
            "20",
            "30",
            "40",
            "50",
            "60",
            "70",
            "80",
            "90",
            "95",
            "100"});
			this.motionBox.Location = new System.Drawing.Point(442, 156);
			this.motionBox.Name = "motionBox";
			this.motionBox.Size = new System.Drawing.Size(168, 24);
			this.motionBox.TabIndex = 11;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(443, 136);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(167, 17);
			this.label2.TabIndex = 10;
			this.label2.Text = "Czułość Motion Detection";
			// 
			// recordedFilesPage
			// 
			this.recordedFilesPage.Controls.Add(this.fileList);
			this.recordedFilesPage.Location = new System.Drawing.Point(4, 25);
			this.recordedFilesPage.Name = "recordedFilesPage";
			this.recordedFilesPage.Padding = new System.Windows.Forms.Padding(3);
			this.recordedFilesPage.Size = new System.Drawing.Size(805, 438);
			this.recordedFilesPage.TabIndex = 1;
			this.recordedFilesPage.Text = "Nagrania";
			this.recordedFilesPage.UseVisualStyleBackColor = true;
			// 
			// fileList
			// 
			this.fileList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
			this.fileList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.fileList.Location = new System.Drawing.Point(3, 3);
			this.fileList.Name = "fileList";
			this.fileList.Size = new System.Drawing.Size(799, 432);
			this.fileList.TabIndex = 0;
			this.fileList.UseCompatibleStateImageBehavior = false;
			this.fileList.View = System.Windows.Forms.View.Details;
			this.fileList.DoubleClick += new System.EventHandler(this.fileList_DoubleClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Filename";
			this.columnHeader1.Width = 703;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(817, 469);
			this.Controls.Add(this.tabControl);
			this.Name = "Form1";
			this.Text = "Camera";
			this.tabControl.ResumeLayout(false);
			this.cameraPage.ResumeLayout(false);
			this.cameraPage.PerformLayout();
			this.recordedFilesPage.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private AForge.Controls.VideoSourcePlayer videoPlayer;
        private System.Windows.Forms.ComboBox deviceListBox;
        private System.Windows.Forms.Button findDevicesButton;
        private System.Windows.Forms.Button cameraButton;
		private System.Windows.Forms.Button makePhoto;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.Button cameraSettingsButton;
		private System.Windows.Forms.Button recordVideoButton;
		private System.Windows.Forms.ComboBox resolutionBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage cameraPage;
		private System.Windows.Forms.TabPage recordedFilesPage;
		private System.Windows.Forms.ListView fileList;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox motionBox;
	}
}

