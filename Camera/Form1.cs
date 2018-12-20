using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accord.IO;
using Accord.Video.FFMPEG;
using AForge.Controls;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Vision.Motion;

namespace Camera
{
	public partial class Form1 : Form
	{
		private FilterInfoCollection videoDeviceCollection;
		private VideoCaptureDevice camera;
		private Bitmap picture;
		private VideoFileWriter videoWriter;
		private MotionDetector detector;
		private bool recording = false;

		public Form1()
		{
			InitializeComponent();
			Text = "Camera";
		}

		private void findDevicesButton_Click(object sender, EventArgs e)
		{
			deviceListBox.Items.Clear();
			videoDeviceCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);

			foreach (FilterInfo videoDevice in videoDeviceCollection)
			{
				deviceListBox.Items.Add(videoDevice.Name);
			}

			if (deviceListBox.Items.Count > 0)
			{
				deviceListBox.SelectedIndex = deviceListBox.FindStringExact(videoDeviceCollection[0].Name);
			}

			camera = new VideoCaptureDevice();

			InitResolution();
		}

		private void InitResolution()
		{
			VideoCaptureDevice getResolution =
				new VideoCaptureDevice(videoDeviceCollection[deviceListBox.SelectedIndex].MonikerString);
			resolutionBox.Items.Clear();
			for (int i = 0; i < getResolution.VideoCapabilities.Length; i++)
			{
				resolutionBox.Items.Add(getResolution.VideoCapabilities[i].FrameSize.ToString());
			}

			if (resolutionBox.Items.Count > 0)
			{
				resolutionBox.SelectedIndex = resolutionBox.FindStringExact(getResolution.VideoCapabilities[0].FrameSize.ToString());
			}
		}

		private void cameraButton_Click(object sender, EventArgs e)
		{
			try
			{
				if (camera.IsRunning)
				{
					camera.SignalToStop();
					camera.WaitForStop();
					makePhoto.Enabled = false;
					cameraSettingsButton.Enabled = false;
					recordVideoButton.Enabled = false;
				}
				else
				{
					camera = new VideoCaptureDevice(videoDeviceCollection[deviceListBox.SelectedIndex].MonikerString);

					detector = new MotionDetector(new SimpleBackgroundModelingDetector(), new MotionAreaHighlighting());

					camera.VideoResolution = camera.VideoCapabilities[resolutionBox.SelectedIndex];

					camera.NewFrame += Camera_NewFrame;

					videoPlayer.VideoSource = camera;

					camera.Start();

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

		private void Camera_NewFrame(object sender, NewFrameEventArgs eventArgs)
		{
			picture = eventArgs.Frame.Clone() as Bitmap;

			if (recording)
			{
				videoWriter.WriteVideoFrame(picture);
			}

			if (detector.ProcessFrame(picture) >= 0.05)
			{
				this.BackColor = Color.Red;
			}
			else
			{
				this.BackColor = DefaultBackColor;
			}
		}

		private void makePhoto_Click(object sender, EventArgs e)
		{
			camera.Stop();
			saveFileDialog.Filter = @"Obraz bmp|*.bmp |Obraz JPEG |*.jpg";
			saveFileDialog.FileName = "";
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				picture.Save(saveFileDialog.FileName);
			}
			camera.Start();
		}

		private void cameraSettingsButton_Click(object sender, EventArgs e)
		{
			camera.DisplayPropertyPage(IntPtr.Zero);
		}

		private void recordVideoButton_Click(object sender, EventArgs e)
		{
			if (recording)
			{
				recordVideoButton.Text = "Nagraj film";
				recording = false;
				videoWriter.Close();
			}
			else
			{
				recordVideoButton.Text = "Zatrzymaj nagrywanie";

				saveFileDialog.Filter = @"Film |*.avi";
				saveFileDialog.FileName = "";
				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					videoWriter = new VideoFileWriter();
					int h = picture.Height;
					int w = picture.Width;
					videoWriter.Open(saveFileDialog.FileName, w, h);
					recording = true;
				}
			}
		}

		private void resolutionBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (camera.IsRunning)
			{
				camera.SignalToStop();
				camera.WaitForStop();
				camera.VideoResolution = camera.VideoCapabilities[resolutionBox.SelectedIndex];
				detector = new MotionDetector(new SimpleBackgroundModelingDetector(), new MotionAreaHighlighting());
				camera.Start();
			}
		}
	}
}
