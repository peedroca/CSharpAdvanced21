using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            Type type1 = typeof(Pessoa);

            var test = type1.GetMethods();

            WriteList(test?.Select(s => s.Name).ToList());
            Console.WriteLine("\n\n");

            var test2 = type1.GetConstructors()
                .Select(s => s.Name)
                .ToList();

            WriteList(test2);
            Console.WriteLine("\n\n");

            var test3 = type1.GetConstructors();

            System.Console.WriteLine("Primeiro Construtor");
            WriteList(test3[0].GetParameters().Select(s => s.Name).ToList());

            System.Console.WriteLine("Segundo Construtor");
            WriteList(test3[1].GetParameters().Select(s => s.Name).ToList());

            var body = test3[1].GetMethodBody();
            WriteList(body.LocalVariables.Select(s => s.ToString()).ToList());
            Console.WriteLine("\n\n");

            System.Console.WriteLine(body.ToString());

            //System.Console.WriteLine(test[1].Name);
        }

        static void WriteList<T>(IEnumerable<T> write)
        {
            System.Console.WriteLine(string.Join("\n", write));
        }
    }
}
