using System;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Windows.Forms;

namespace EmguCVTutorial
{
    public partial class Form1 : Form
    {
        VideoCapture device;
        System.Drawing.Size windowSize { get; set; }
        public Form1()
        {
            InitializeComponent();
            device = new VideoCapture(0);
            
        }

        private void Start_Click(object sender, EventArgs e)
        {
            if (device == null)
                device = new VideoCapture(0); 

            device.ImageGrabbed += Capture_ImageGrab;
            pictureBox1.Size = windowSize;
            device.Start();


        }

        private void Capture_ImageGrab(object sender, EventArgs e)
        {
            if (device != null)
            {
                try
                {
                    Mat m = new Mat();
                    device.Retrieve(m);
                    windowSize = new System.Drawing.Size(m.Width, m.Height);

                    pictureBox1.Image = m.ToImage<Bgr, byte>().ToBitmap();
                }
                catch (Exception)
                {

                    throw;
                }

            }
            else
            {
                Mat m = new Mat();
                pictureBox1.Image = m.ToImage<Bgr, byte>().ToBitmap();
            }
            
        }

        private void Pause_Click(object sender, EventArgs e)
        {
            if (device != null)
                device.Pause();
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            if (device != null)
                device = null;
        }
    }
}
