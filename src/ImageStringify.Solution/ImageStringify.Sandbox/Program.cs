using ImageStringify.Lib;
using System.Text;

namespace ImageStringify.Sandbox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var imageStringifier = new ImageStringifier("C:\\Users\\Ivan Mihaylov\\Desktop\\41xsPjrM-pL._AC_UF894,1000_QL80_.jpg");

            var imageAsString = imageStringifier.ToString();

            File.WriteAllText("hello.txt", imageAsString);
        }
    }
}
