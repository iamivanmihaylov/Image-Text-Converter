using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace StringImage.Lib
{
    public class StringifiedImage
    {
        private string density;
        private string filePath;
        public StringifiedImage(string filePath, string density = " .\":<|X0█")
        {
            this.density = density;
            this.filePath = filePath;
        }

        public override string ToString()
        {
            var image = Image.Load<Rgba32>(filePath);
            image.Mutate(x => x.Grayscale());

            var sb = new StringBuilder();

            for (int row = 0; row < image.Height; row++)
            {
                for (int col = 0; col < image.Width; col++)
                {
                    var colorR = image[col, row].R;
                    var indexPercent = Math.Ceiling(colorR / 2.56);
                    var densityIndex = (int)((indexPercent / 100) * (density.Length - 1));
                    sb.Append($"{density[densityIndex]} ");
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }

    }
}
