using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        static bool processed = false;
        static string clientId; //a0ece5db-cd14-4f21-812f-966633e7be86
        static string apiURL; //https://localhost:44347/api/users/GetByName/test

        static void Main(string[] args)
        {
            Console.WriteLine("Process started");
            Console.WriteLine("------------------");
            Console.WriteLine();

            Console.WriteLine("Insert the URL");
            apiURL = Console.ReadLine();
            Console.WriteLine("Insert the clientId to autenticate");
            clientId = Console.ReadLine();

            Console.WriteLine(Environment.NewLine + "Processing, please wait..." + Environment.NewLine);

            Task.Run(() => MainAsync(args));
            while (!processed) Thread.Sleep(500);

            Console.WriteLine(Environment.NewLine + Environment.NewLine + "Process finished, press any key to exit");
            Console.ReadKey();
        }

        static async void MainAsync(string[] args)
        {
            try
            {
                var baseAddress = new Uri(apiURL);
                var handler = new HttpClientHandler();
                handler.CookieContainer = new CookieContainer();
                handler.CookieContainer.Add(baseAddress, new Cookie("clientId", clientId));
                var client = new HttpClient(handler);
                var response = await client.GetAsync(baseAddress);
                var contents = await response.Content.ReadAsStringAsync();
                Console.WriteLine("The API return the message:" + Environment.NewLine + contents);
            }
            catch (Exception ex)
            {
                Console.WriteLine("The aplication throw an unexpected exception");
            }
            
            processed = true;
        }
    }
}