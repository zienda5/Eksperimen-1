using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV.Util;
using Emgu.CV;
using Emgu.CV.Structure;

namespace MultiFaceRec
{
    public partial class mainForm : Form
    {
       
        Image<Bgr, Byte> currentFrame;
        Capture grabber;

        public mainForm()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //Menginisialisasi variable capture untuk menampung image yang diambil
            grabber = new Capture();
            grabber.QueryFrame();
            //Menginisialisasi variable FrameGraber untuk mengambil tiap frame dari webcam
            Application.Idle += new EventHandler(FrameGrabber);
            button1.Enabled = false;
        }

        void FrameGrabber(object sender, EventArgs e)
        {

            //Mengambil Frame dari WebCam
            DateTime StarTime = DateTime.Now;
            currentFrame = grabber.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            
                   
            //Menampilkan Kecepatan Kamera
            imageBoxFrameGrabber.Image = currentFrame;
            DateTime endTime = DateTime.Now;
            textBox2.Text = (endTime - StarTime).ToString();
        }

    }
}
