using System;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;


namespace Asyncawait
{
    class Program
    {
        static async Task Main()
        {   
           
            Console.WriteLine("Hello world");
            string URL = "https://jsonplaceholder.typicode.com/posts/1";
    
            var tasks = new List<Task<string>> {Writelocaly(), TextfromURL(URL)};
            
            // await Task.WhenAll();
            var results = await Task.WhenAll(tasks);

            Console.WriteLine("\n--- Aggregated Results ---");
            foreach (var result in results)
            {
                Console.WriteLine(result);
                Console.WriteLine("--------------------------");
            }

        }
        static async Task<string> Writelocaly()
        {
            Console.WriteLine("Wrting a line locally ...");
            await Task.Delay(1000);
            string t = await File.ReadAllTextAsync("data.txt");

            return $"Text in file : \n{t}";

        }
    
        static async Task<string> TextfromURL(string URL)
        {
            Console.WriteLine("Writing txt from url...");
            await Task.Delay(2000);
            using(var httpClient = new HttpClient())
            {
                string result = await httpClient.GetStringAsync(URL);
                return $"got the text from url \n {result}" ;
            }
        }
    }
}