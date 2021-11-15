using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.Structure;



namespace cameraCapture
{
    public partial class Form1 : Form
    {

        private VideoCapture capture;
        private bool pictureinproggress;



        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (capture == null)
            {
                capture = new Emgu.CV.VideoCapture(0); // select different cameras 0-4
            }
            capture.ImageGrabbed += Capture_ImaGrabbed1;
            capture.Start();


        }

        private void Capture_ImaGrabbed1(object sender, EventArgs e)
        {
            try
            {
                Mat m = new Mat();
                capture.Retrieve(m);
                pictureBox1.Image = m.ToImage<Bgr, byte>().AsBitmap();
            }
            catch(Exception)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(capture!=null)
            {
                capture.Pause();
            }
        }
    }
}
