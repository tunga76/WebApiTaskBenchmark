using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTaskBenchmark.ConsoleApp
{
    public class WebApiClient
    {
        private const string url = "https://localhost:7052/api/test/";

        public async Task CallAsync()
        {
            var client = new HttpClient()
            {
                BaseAddress = new Uri(url)
            };
            await client.GetAsync("Async");
        }

        public async Task CallSync()
        {
            var client = new HttpClient()
            {
                BaseAddress = new Uri(url)
            };
            await client.GetAsync("Sync");
        }
    }
}
