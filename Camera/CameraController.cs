using Accord.Video.FFMPEG;
using AForge.Video.DirectShow;
using AForge.Vision.Motion;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AForge.Video;

namespace Camera
{
	class CameraController
	{
		public FilterInfoCollection videoDeviceCollection;
		public VideoCaptureDevice camera;
		public Bitmap picture;
		public VideoFileWriter videoWriter;
		public MotionDetector detector;
		public bool recording = false;

		public CameraController()
		{
			videoDeviceCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);

			camera = new VideoCaptureDevice();
		}

		public void getCameraDevices()
		{
			videoDeviceCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
		}

		public List<string> getCamerasName()
		{
			List<string> camerasName = new List<string>();

			foreach (FilterInfo camera in videoDeviceCollection)
			{
				camerasName.Add(camera.Name);
			}

			return camerasName;
		}

		public List<string> InitResolution(int index)
		{
			List<string> resolutionList = new List<string>();
			VideoCaptureDevice getResolution =
				new VideoCaptureDevice(videoDeviceCollection[index].MonikerString);
			for (int i = 0; i < getResolution.VideoCapabilities.Length; i++)
			{
				resolutionList.Add(getResolution.VideoCapabilities[i].FrameSize.ToString());
			}

			return resolutionList;
		}

		public void InitCamera(int deviceIndex, int resolutionIndex)
		{
			camera = new VideoCaptureDevice(videoDeviceCollection[deviceIndex].MonikerString);

			detector = new MotionDetector(new SimpleBackgroundModelingDetector(), new MotionAreaHighlighting());

			camera.VideoResolution = camera.VideoCapabilities[resolutionIndex];
		}

		public void WriteFrame()
		{
			videoWriter.WriteVideoFrame(picture);
		}

		public float GetProcessFrame()
		{
			return detector.ProcessFrame(picture);
		}

		public void CameraSettings()
		{
			camera.DisplayPropertyPage(IntPtr.Zero);
		}

		public void ChangeResolution(int resolutionIndex)
		{
			if (camera.IsRunning)
			{
				camera.SignalToStop();
				camera.WaitForStop();
				camera.VideoResolution = camera.VideoCapabilities[resolutionIndex];
				detector = new MotionDetector(new SimpleBackgroundModelingDetector(), new MotionAreaHighlighting());
				camera.Start();
			}
		}

		public void SaveVideo(string filename)
		{
			videoWriter = new VideoFileWriter();
			int h = picture.Height;
			int w = picture.Width;
			videoWriter.Open(filename, w, h);
			recording = true;
		}

		public bool StopRecording()
		{
			recording = false;
			videoWriter.Close();

			return recording;
		}
	}
}
