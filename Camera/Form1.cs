using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Accord.Video.FFMPEG;
using Accord.Video.VFW;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Vision.Motion;

namespace Camera
{
	public partial class Form1 : Form
	{
		private CameraController cameraController;
		private List<String> fileCollection = new List<string>();
		public Form1()
		{
			InitializeComponent();
			motionBox.SelectedIndex = 0;
			cameraController = new CameraController();
			InitListView();
		}

		private void findDevicesButton_Click(object sender, EventArgs e)
		{
			deviceListBox.Items.Clear();

			cameraController.getCameraDevices();

			deviceListBox.DataSource = cameraController.getCamerasName();

			if (deviceListBox.Items.Count > 0)
			{
				deviceListBox.SelectedIndex = deviceListBox.FindStringExact(cameraController.videoDeviceCollection[0].Name);
			}

			int index = deviceListBox.SelectedIndex;
			resolutionBox.DataSource = cameraController.InitResolution(index);

			/*if (resolutionBox.Items.Count > 0)
			{
				resolutionBox.SelectedIndex = resolutionBox.FindStringExact(resolutionBox.DataSource[0]);
			}*/
		}

		private void InitListView()
		{
			DirectoryInfo dinfo = new DirectoryInfo(System.AppDomain.CurrentDomain.BaseDirectory + @"Nagrania\");

			// get all files
			FileInfo[] filesInfo = dinfo.GetFiles();

			foreach (FileInfo fi in filesInfo)
			{
				fileCollection.Add(fi.Directory + @"\" + fi.ToString());
			}
			foreach (var file in fileCollection)
			{
				fileList.Items.Add(file);
			}
		}

		private void UpdateListView()
		{
			fileList.Items.Clear();
			foreach (var file in fileCollection)
			{
				fileList.Items.Add(file);
			}
		}

		private void cameraButton_Click(object sender, EventArgs e)
		{
			try
			{
				if (cameraController.camera.IsRunning)
				{
					cameraController.camera.SignalToStop();
					cameraController.camera.WaitForStop();
					makePhoto.Enabled = false;
					cameraSettingsButton.Enabled = false;
					recordVideoButton.Enabled = false;
					cameraPage.BackColor = Color.White;
				}
				else
				{
					int deviceIndex = deviceListBox.SelectedIndex, resolutionIndex = resolutionBox.SelectedIndex;

					cameraController.InitCamera(deviceIndex,resolutionIndex);

					videoPlayer.VideoSource = cameraController.camera;

					cameraController.camera.NewFrame += Camera_NewFrame;

					cameraController.camera.Start();

					makePhoto.Enabled = true;
					cameraSettingsButton.Enabled = true;
					recordVideoButton.Enabled = true;
				}
			}
			catch (Exception exep)
			{
				MessageBox.Show("Wystapil blad: Nie wybrano kamery", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public void Camera_NewFrame(object sender, NewFrameEventArgs eventArgs)
		{
			float motionLevel = (float)(100 - int.Parse(motionBox.SelectedItem.ToString()))/100;
			cameraController.picture = eventArgs.Frame.Clone() as Bitmap;

			if (cameraController.recording)
			{
				cameraController.WriteFrame();
			}
			if (cameraController.GetProcessFrame() >= motionLevel)
			{
				cameraPage.BackColor = Color.Red;
			}
			else
			{
				cameraPage.BackColor = Color.White;
			}
		}

		private void makePhoto_Click(object sender, EventArgs e)
		{
			cameraController.camera.Stop();
			saveFileDialog.Filter = @"Obraz bmp|*.bmp |Obraz JPEG |*.jpg";
			saveFileDialog.InitialDirectory = System.AppDomain.CurrentDomain.BaseDirectory + @"Nagrania\";
			if (!Directory.Exists(saveFileDialog.InitialDirectory))
			{
				Directory.CreateDirectory(saveFileDialog.InitialDirectory);
			}
			saveFileDialog.RestoreDirectory = true;
			saveFileDialog.FileName = String.Empty;
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				cameraController.picture.Save(saveFileDialog.FileName);
				fileCollection.Add(saveFileDialog.FileName);
			}
			cameraController.camera.Start();
			UpdateListView();
		}

		private void cameraSettingsButton_Click(object sender, EventArgs e)
		{
			cameraController.CameraSettings();
		}

		private void recordVideoButton_Click(object sender, EventArgs e)
		{
			if (!cameraController.StopRecording())
			{
				recordVideoButton.Text = "Nagraj film";
			}
			else
			{
				recordVideoButton.Text = "Zatrzymaj nagrywanie";
				saveFileDialog.Filter = @"Film |*.avi";
				saveFileDialog.InitialDirectory = System.AppDomain.CurrentDomain.BaseDirectory + @"Nagrania\";
				if (!Directory.Exists(saveFileDialog.InitialDirectory))
				{
					Directory.CreateDirectory(saveFileDialog.InitialDirectory);
				}
				saveFileDialog.RestoreDirectory = true;
				saveFileDialog.FileName = String.Empty;
				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					cameraController.SaveVideo(saveFileDialog.FileName);
					fileCollection.Add(saveFileDialog.FileName);
				}
			}
			UpdateListView();
		}

		private void resolutionBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			int index = resolutionBox.SelectedIndex;

			cameraController.ChangeResolution(index);
		}

		private void fileList_DoubleClick(object sender, EventArgs e)
		{
			if (fileList.SelectedItems.Count != 0)
			{
				try
				{
					string fileToOpen;

					fileToOpen = fileList.SelectedItems[0].Text;

					System.Diagnostics.Debug.WriteLine(fileToOpen);
					System.Diagnostics.Process.Start(fileToOpen);
				}
				catch (Win32Exception ex)
				{

					MessageBox.Show("Failed opening the file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
	}
}
