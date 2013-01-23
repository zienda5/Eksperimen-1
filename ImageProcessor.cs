using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.Structure;

namespace MultiFaceRec
{
    public class ConvolutionMatrix
    {
        public int MatrixSize = 3;

        public double[,] Matrix;
        public double Factor = 1;
        public double Offset = 1;

        public ConvolutionMatrix(int size)
        {
            MatrixSize = 3;
            Matrix = new double[size, size];
        }

        public void SetAll(double value)
        {
            for (int i = 0; i < MatrixSize; i++)
            {
                for (int j = 0; j < MatrixSize; j++)
                {
                    Matrix[i, j] = value;
                }
            }
        }
    }

    public class ImageProcessor
    {
        public Image<Bgr, Byte> currentFrame; 
        private Bitmap bitmapImage;
      
        public void SetImage(string path)
        {
            bitmapImage = new Bitmap(path);
        }

        public Bitmap GetImage()
        {
            return bitmapImage;
        }
        //invert mulai
        public void ApplyInvert()
        {
            byte A, R, G, B;
            Color pixelColor;

            for (int y = 0; y < currentFrame.Height; y++)
            {
                for (int x = 0; x < bitmapImage.Width; x++)
                {
                    pixelColor = bitmapImage.GetPixel(x, y);
                    A = pixelColor.A;
                    R = (byte)(255 - pixelColor.R);
                    G = (byte)(255 - pixelColor.G);
                    B = (byte)(255 - pixelColor.B);
                    bitmapImage.SetPixel(x, y, Color.FromArgb((int)A, (int)R, (int)G, (int)B));
                }
            }

        }
        //invert akhir
