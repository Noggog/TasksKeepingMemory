using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TasksKeepingMemory
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await Test();
            System.Console.WriteLine($"Done");
            GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
            GC.Collect();
            System.Console.ReadKey();
        }

        static Task Test()
        {
            var bytes = new byte[100000000];
            return Test2(bytes);
        }

        public static async Task Test2(byte[] wrapper)
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < wrapper.Length; i++)
                {
                    wrapper[i] = 1;
                }
            });
        }
    }
}
