using ImageToTextConverter.Lib.Contracts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageToTextConverter.Lib
{
    public class ImageTextConverter : IImageTextConverter
    {
        private string outputFileName;
        private string density;
        private string filePath;
        private Color[,] greyscaleMatrix;

        public ImageTextConverter(string filePath, string outputFileName, string density = " .\":<|X0█")
        {
            this.outputFileName = outputFileName;
            this.density = density;
            this.filePath = filePath;
        }

        public void Convert()
        {
            var bitmapImage = new Bitmap(filePath);

            var imageManipulator = new ImageManipulation();

            var graysclaeBitmap = imageManipulator.ConvertToGrayScale(bitmapImage);
            this.greyscaleMatrix = imageManipulator.GetImageAsMatrix(graysclaeBitmap);

            using var sw = new StreamWriter($@"../../../{this.outputFileName}.txt", false, Encoding.UTF8);

            for (int row = 0; row < greyscaleMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < greyscaleMatrix.GetLength(1); col++)
                {
                    var colorR = greyscaleMatrix[row, col].R; // This can be R G or B
                    var indexPercent = Math.Ceiling(colorR / 2.56);
                    var index = (int)((indexPercent / 100) * (density.Length - 1));
                    sw.Write($"{density[index]} ");
                }
                sw.WriteLine();
            }
        }

    }
}
