using ImageToTextConverter.Lib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace ImageToTextConverter
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.Write("Въведете път до файла, който искате да конвертирате: ");
            var path = Console.ReadLine();

            Console.Write("Въведете име на финалния файл: ");
            var fileName = Console.ReadLine();

            var convertor = new ImageTextConverter(path, fileName);
            convertor.Convert();

            Console.WriteLine("Готово! Потърсете файла в папката на проекта!");
        }
    }
}
