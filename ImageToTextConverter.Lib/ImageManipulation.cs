using ImageToTextConverter.Lib.Contracts;
using System.Drawing;

namespace ImageToTextConverter.Lib
{
    public class ImageManipulation : IImageManipulation
    {
        public Bitmap ConvertToGrayScale(Bitmap btmap)
        {
            Bitmap bmap = (Bitmap)btmap.Clone();

            Color c;
            for (int i = 0; i < bmap.Width; i++)
            {
                for (int j = 0; j < bmap.Height; j++)
                {
                    c = bmap.GetPixel(i, j);
                    int gray = (c.R + c.G + c.B) / 3;

                    bmap.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
                }
            }

            return (Bitmap)bmap.Clone();
        }

        public Color[,] GetImageAsMatrix(Bitmap image)
        {
            var colors = new Color[image.Height, image.Width];

            for (int row = 0; row < colors.GetLength(0); row++)
            {
                for (int col = 0; col < colors.GetLength(1); col++)
                {
                    colors[row, col] = image.GetPixel(col, row);
                }
            }

            return colors;
        }
    }
}
