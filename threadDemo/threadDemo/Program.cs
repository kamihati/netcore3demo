using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;


namespace threadDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = ProcessTasksAsync();
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }

        static async Task<int> DelayAndReturnAsync(int val)
        {
            await Task.Delay(TimeSpan.FromSeconds(val));
            return val;
        }

        static async Task AwaitAndProcessAsync(Task<int> task)
        {
            var result = await task;
            // Trace.WriteLine(result);
            Console.WriteLine(result);
        }

        static async Task ProcessTasksAsync()
        {
            Task<int> taskA = DelayAndReturnAsync(2);
            Task<int> taskB = DelayAndReturnAsync(10);
            Task<int> taskC = DelayAndReturnAsync(1);

            var tasks = new[] {taskA, taskB, taskC };

            var processingTasks = (from t in tasks select AwaitAndProcessAsync(t)).ToArray();

            await Task.WhenAll(processingTasks);
        }
    }
}