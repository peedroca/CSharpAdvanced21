using System;
using System.IO;

namespace system.stream
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamWriter sw = new StreamWriter("text2.txt"))
            {
                sw.NewLine = ";";

                sw.WriteLine("Hel{0}", "lo"); // Hello;
                sw.WriteLine("Hello World 2"); // Hello;Hello World 2;
                
                sw.Write(true); // Hello;Hello World 2;True
                sw.Write("Hello World 2"); // Hello;Hello World 2;TrueHello World 2
                sw.WriteLine("Hello World 2"); // Hello;Hello World 2;TrueHello World 2Hello World 2;

                var text = new char[5] { 'P', 'E', 'D', 'R', 'O' };

                sw.Write(text, 2, 3); // Hello;Hello World 2;TrueHello World 2Hello World 2;DRO
            }

            using (StreamReader sr = new StreamReader("text.txt"))
            {
                var r = (Char)sr.Read();
                Console.WriteLine(r);

                var line = sr.ReadLine();
                Console.WriteLine(line);

                char[] buffer = new char[5];
                var iavel = sr.ReadBlock(buffer, 0, 2);

                Console.WriteLine(buffer);
                Console.WriteLine(iavel);
            }
        }
    }
}
