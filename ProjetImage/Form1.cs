///<summary>
///This the main class where we can see the stream , and if a gesture is recognised a message box is printed
///
/// </summary>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Kinect;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

namespace ProjetImage
{
    public partial class Form1 : Form
    {
        private KinectSensor sensor;
        private byte[] colorData = null;
        private IntPtr colorPtr;
        private Bitmap kinectVideoBitmap = null;
        private Point3D point;
        private Graphics g;

        private static  Gesturer gesturer = new Gesturer();

        private Gesture right = new SGestureRight();
        private Gesture left = new SGestureLeft();

        // Declarge Gestures 
        private void editGesturer()
        {
           gesturer.addGesture("Right", right);
            //gesturer.addGesture("Left", left);
        }

        bool gestureDetected = false;

        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {

                editGesturer();
                sensor = KinectSensor.KinectSensors[0];  //Une seule Kinect connectée
                MessageBox.Show("Kinect Detected!");
                sensor.ColorStream.Enable(ColorImageFormat.RgbResolution640x480Fps30);
                sensor.ColorFrameReady += SensorColorFrameReady;
                sensor.SkeletonStream.Enable();
                sensor.SkeletonFrameReady += SensorSkeletonFrameReady;
                gesturer.GestureFound += Gesturer_GestureFound;

            }
            catch
            {
                MessageBox.Show("Kinnect not Detected");
                Application.Exit();
            }
        }

        private void Gesturer_GestureFound(object sender, EventArgs e)
        {
            MessageBox.Show("Movment detected");
        }

        /* Function to print the scream */
        private void SensorColorFrameReady(object sender, ColorImageFrameReadyEventArgs e)
        {
            
            using (ColorImageFrame colorFrame = e.OpenColorImageFrame())
            {
                if (colorFrame == null) return;
                if (colorData == null) colorData = new byte[colorFrame.PixelDataLength];
                colorFrame.CopyPixelDataTo(colorData);

                Marshal.FreeHGlobal(colorPtr);
                colorPtr = Marshal.AllocHGlobal(colorData.Length);
                Marshal.Copy(colorData, 0, colorPtr, colorData.Length);

                kinectVideoBitmap = new Bitmap(colorFrame.Width,
                                               colorFrame.Height,
                                               colorFrame.Width * colorFrame.BytesPerPixel,
                                               PixelFormat.Format32bppRgb,
                                               colorPtr);

                pbKinectVideo.Image = kinectVideoBitmap;
            }
        }
        /*Function to detect the movment */
        private void SensorSkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
           
            Skeleton[] skeletons = new Skeleton[0];

            using (SkeletonFrame skeletonFrame = e.OpenSkeletonFrame())
            {
                if (skeletonFrame != null)
                {
                    skeletons = new Skeleton[skeletonFrame.SkeletonArrayLength];
                    skeletonFrame.CopySkeletonDataTo(skeletons);
                }
                foreach (Skeleton skeleton in skeletons)
                {
                    if (skeleton.TrackingState == SkeletonTrackingState.Tracked)
                    {
                        Joint rightHand = skeleton.Joints[JointType.HandRight];
                        Joint leftHand = skeleton.Joints[JointType.HandLeft];
                        float rightX = rightHand.Position.X;
                        float rightY = rightHand.Position.Y;
                        float rightZ = rightHand.Position.Z;

                        float leftX = leftHand.Position.X;
                        float leftY = leftHand.Position.Y;
                        float leftZ = leftHand.Position.Z;
                        
                        if (rightHand.TrackingState == JointTrackingState.Tracked)
                        {
                            gesturer.update(skeleton);
                            drawHand(rightX, rightY);                 
                        }
                        if (leftHand.TrackingState == JointTrackingState.Tracked)
                        {   
                            drawHand(leftX, leftY);
                        }
                        LRX.Text = "X=" + rightX.ToString();
                        LRZ.Text = "Y=" + rightY.ToString();
                        LRY.Text = "Z=" + rightZ.ToString();

                        LXL.Text = "X=" + rightX.ToString();
                        LYL.Text = "Y=" + rightY.ToString();
                        LZL.Text = "Z=" + rightZ.ToString();
                    }
                }
            }
        }
        private  void Gesture_GestureRecognized(object sender, EventArgs e)
        {
            gestureDetected = true;
            MessageBox.Show("A droite");
            Console.WriteLine("You just waved!");
        }
       
        private Point3D oneHandPosition(Skeleton skeleton)
        {
            Point3D point = null ;
            return point;
        }
        private  Point3D[] twoHandPosition(Skeleton skeleton )
        {
            Joint rightHand = skeleton.Joints[JointType.HandRight];
            Joint leftHand = skeleton.Joints[JointType.HandLeft];
            Point3D[] positions = new Point3D[2];
            positions[0].x = rightHand.Position.X; 
            positions[0].y = rightHand.Position.Y; 
            positions[0].z = rightHand.Position.Z;

            positions[1].x = leftHand.Position.X;
            positions[1].y = leftHand.Position.Y;
            positions[1].z = leftHand.Position.Z;

            return positions;
        }
        public void drawRandomCercle()
        {
            Random rnd = new Random();
            int x = rnd.Next(0,600);
            int y = rnd.Next(0,600);
            try {
                using (g = pbKinectVideo.CreateGraphics())
                {
                    Pen p = new Pen(Color.Red, 10.0f);
                    g.DrawEllipse(p, x, y, 150, 150);
                }
            } catch (Exception e) {  }
        }
        public void drawHand(float x, float y) {
            try
            {
                using (g = pbKinectVideo.CreateGraphics())
                {
                    Pen p = new Pen(Color.Blue, 10.0f);
                    g.DrawEllipse(p, 320 * (1 + x) - 5, 240 * (1 - y) - 5, 25, 25);

                }
            }
            catch { }

        }
        /* Method to start the sensor */
        private void start_Click(object sender, EventArgs e)
        {
            sensor.Start();
        }
        /**/
        private void stop_Click(object sender, EventArgs e)
        {
            sensor.Stop();
        }
    }
}