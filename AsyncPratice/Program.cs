using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsyncPratice {
    class Program {
        static void Main(string[] args) {
            PrintPageLength();

            Console.ReadKey();
        }

        static async Task<int> GetPageLengthAsync(string url) {
            using(var client = new HttpClient()) {
                Task<string> task = client.GetStringAsync(url);
                int length = (await task).Length;
                return length;
            }
        }
        static void PrintPageLength() {
            Task<int> lengthTask = GetPageLengthAsync("http://csharpindepth.com");
            Console.WriteLine(lengthTask.Result);
        }
    }
}
