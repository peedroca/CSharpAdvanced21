using System;
using System.Threading;
using System.Threading.Tasks;

namespace semaphore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("...: Starting.");

            Semaphore pool = new Semaphore(2, 6);

            int tasks = 4;

            Task[] ts = new Task[tasks];
            for (int i = 0; i < tasks; i++)
            {
                ts[i] = Task.Factory.StartNew(() => 
                {
                    var id = new Random().Next(11, 99);

                    pool.WaitOne();
                    System.Console.WriteLine($"Worker #{id}");
                    
                    System.Threading.Thread.Sleep(1000);

                    System.Console.WriteLine($"Worker #{id} Released");
                    pool.Release();
                });
            }

            Task.WaitAll(ts);

            System.Console.WriteLine("...: The End!");
        }
    }
}
