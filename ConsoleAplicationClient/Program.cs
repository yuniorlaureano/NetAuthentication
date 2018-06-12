using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAplicationClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var handler = new HttpClientHandler
            {
                UseDefaultCredentials = true
            };
            HttpClient client = new HttpClient(handler)
            {
                BaseAddress = new Uri("http://localhost:57936/api/")
            };

            var resonse = client.GetAsync("identity/").Result;
            resonse.EnsureSuccessStatusCode();

            var content = resonse.Content.ReadAsStringAsync().Result;
            Console.WriteLine(content);
        }
    }
}
