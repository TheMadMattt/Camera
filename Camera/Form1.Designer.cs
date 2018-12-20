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
			this.SuspendLayout();
			// 
			// videoPlayer
			// 
			this.videoPlayer.Location = new System.Drawing.Point(12, 12);
			this.videoPlayer.Name = "videoPlayer";
			this.videoPlayer.Size = new System.Drawing.Size(402, 346);
			this.videoPlayer.TabIndex = 0;
			this.videoPlayer.Text = "videoSourcePlayer1";
			this.videoPlayer.VideoSource = null;
			// 
			// deviceListBox
			// 
			this.deviceListBox.FormattingEnabled = true;
			this.deviceListBox.Location = new System.Drawing.Point(12, 364);
			this.deviceListBox.Name = "deviceListBox";
			this.deviceListBox.Size = new System.Drawing.Size(363, 24);
			this.deviceListBox.TabIndex = 1;
			// 
			// findDevicesButton
			// 
			this.findDevicesButton.Location = new System.Drawing.Point(12, 394);
			this.findDevicesButton.Name = "findDevicesButton";
			this.findDevicesButton.Size = new System.Drawing.Size(184, 43);
			this.findDevicesButton.TabIndex = 2;
			this.findDevicesButton.Text = "Znajdź urządzenia";
			this.findDevicesButton.UseVisualStyleBackColor = true;
			this.findDevicesButton.Click += new System.EventHandler(this.findDevicesButton_Click);
			// 
			// cameraButton
			// 
			this.cameraButton.Location = new System.Drawing.Point(202, 394);
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
			this.makePhoto.Location = new System.Drawing.Point(420, 12);
			this.makePhoto.Name = "makePhoto";
			this.makePhoto.Size = new System.Drawing.Size(120, 53);
			this.makePhoto.TabIndex = 4;
			this.makePhoto.Text = "Zrób zdjęcie";
			this.makePhoto.UseVisualStyleBackColor = true;
			this.makePhoto.Click += new System.EventHandler(this.makePhoto_Click);
			// 
			// cameraSettingsButton
			// 
			this.cameraSettingsButton.Enabled = false;
			this.cameraSettingsButton.Location = new System.Drawing.Point(677, 394);
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
			this.recordVideoButton.Location = new System.Drawing.Point(420, 71);
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
			this.resolutionBox.Location = new System.Drawing.Point(546, 41);
			this.resolutionBox.Name = "resolutionBox";
			this.resolutionBox.Size = new System.Drawing.Size(212, 24);
			this.resolutionBox.TabIndex = 7;
			this.resolutionBox.SelectedIndexChanged += new System.EventHandler(this.resolutionBox_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(577, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(148, 17);
			this.label1.TabIndex = 8;
			this.label1.Text = "Rozdzielczość kamery";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.resolutionBox);
			this.Controls.Add(this.recordVideoButton);
			this.Controls.Add(this.cameraSettingsButton);
			this.Controls.Add(this.makePhoto);
			this.Controls.Add(this.cameraButton);
			this.Controls.Add(this.findDevicesButton);
			this.Controls.Add(this.deviceListBox);
			this.Controls.Add(this.videoPlayer);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

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
	}
}

