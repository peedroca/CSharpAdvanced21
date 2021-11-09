using System;
using System.Threading;
using System.Threading.Tasks;

namespace task
{
    class Program
    {
        static async void Main(string[] args)
        {
            ShowMessage("Hello World Principal Thread");
            
            Action show = () => ShowMessage("Hello World Other Thread");

            Task t1 = Task.Run(show);
            Task.Run(show);
            Task.Run(show);
            Task.Run(show);
            Task.Run(show);

            Task t2 = await Task.WhenAny(t1);
        }

        private static void ShowMessage(string message)
        {
            Console.WriteLine("{0} - {1}"
                , Thread.CurrentThread.ManagedThreadId
                , message);
        }
    }
}
