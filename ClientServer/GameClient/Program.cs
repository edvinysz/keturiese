using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Server.Models;
using Client.Task;

namespace GameClient
{
    class Program
    {
        static string serverUrl = "http://localhost:5000/";
        static HttpClient client = new HttpClient();
        static string mediaType = "application/json";
        
        static void Main()
        {
            Console.WriteLine("Web API Client Started!");

            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            client.BaseAddress = new Uri(serverUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
            
            try
            {
                Console.WriteLine("Design pattern implementation:");

                Console.WriteLine(new string('-', 40));
                Console.WriteLine("Implemented patterns: ");
                Console.WriteLine(new string('-', 40));

                Console.WriteLine("1. Singleton pattern");
                Console.WriteLine("2. Factory pattern");
                Console.WriteLine("3. Abstract Factory pattern");
                Console.WriteLine("4. Strategy pattern");
                Console.WriteLine("5. Observer pattern");
                Console.WriteLine("6. Builder pattern");
                Console.WriteLine("7. Prototype pattern");
                    
                while (true)
                {
                    Console.WriteLine(new string('-', 40));
                    Console.Write("Choose pattern key: ");
                    ConsoleKey patternKey = Console.ReadKey().Key;
                    Console.WriteLine();

                    switch (patternKey)
                    {
                        case ConsoleKey.D1:
                            Console.WriteLine("Singleton pattern");
                            await executeSingletonPattern();
                            break;
                        case ConsoleKey.D2:
                            Console.WriteLine("Factory pattern");
                            // executeFactoryPattern();
                            break;
                        case ConsoleKey.D3:
                            Console.WriteLine("Abstract Factory pattern");
                            break;
                        case ConsoleKey.D4:
                            Console.WriteLine("Strategy pattern");
                            break;
                        case ConsoleKey.D5:
                            Console.WriteLine("Observer pattern");
                            break;
                        case ConsoleKey.D6:
                            Console.WriteLine("Builder pattern");
                            break;
                        case ConsoleKey.D7:
                            Console.WriteLine("Prototype pattern");
                            break;
                        case ConsoleKey.D8:
                            Console.WriteLine("Decorator pattern");
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }

        static async Task executeSingletonPattern()
        {
            PlayerTaskSingleton playerTask = PlayerTaskSingleton.getInstance();

            try
            {
                Console.WriteLine("Retrieve all players");

                ICollection<Player> playersList = await playerTask.GetAllPlayerAsync(serverUrl);

                foreach (Player p in playersList)
                {
                    PlayerTaskSingleton.getInstance().ShowPlayer(p);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}