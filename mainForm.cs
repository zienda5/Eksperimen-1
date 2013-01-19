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
using System.Diagnostics;

namespace MultiFaceRec
{
    public partial class mainForm : Form
    {
        public ImageProcessor imagesProcessor = new ImageProcessor();

        public Image<Bgr, Byte> currentFrame;
        public Capture grabber;
        
       
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

        private void button2_Click(object sender, EventArgs e)
        {
            //Menginisialisasi variable capture untuk menampung image yang diambil
            grabber = new Capture();
            grabber.QueryFrame();
            //Menginisialisasi variable FrameGraber untuk mengambil tiap frame dari webcam
            Application.Idle -= new EventHandler(FrameGrabber);
            button1.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            imagesProcessor.ApplySepia(20);
            pictureBox1.Image = imagesProcessor.GetImage();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            imagesProcessor.ApplyEmboss(4);
            pictureBox1.Image = imagesProcessor.GetImage();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            imagesProcessor.ApplyInvert();
            pictureBox1.Image = imagesProcessor.GetImage();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            imagesProcessor.ApplyGreyscale();
            pictureBox1.Image = imagesProcessor.GetImage();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.InitialDirectory = "c:\\";
            saveFileDialog.Filter = "Bitmap files (*.bmp)|*.bmp|Jpeg files (*.jpg)|*.jpg|All valid files (*.bmp/*.jpg)|*.bmp/*.jpg";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (DialogResult.OK == saveFileDialog.ShowDialog())
            {
                pictureBox1.Image = imagesProcessor.GetImage();
                pictureBox1.Image.Save(saveFileDialog.FileName);
                // m_Bitmap.Save(saveFileDialog.FileName);
            }
        }

    }
}
