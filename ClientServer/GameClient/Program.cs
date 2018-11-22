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
        static HttpClient client = new HttpClient();
        static string mediaType = "application/json";
        
        static void Main()
        {
            Console.WriteLine("Web API Client Started!");

            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            string serverUrl = "http://localhost:5000/";
            client.BaseAddress = new Uri(serverUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
            
            PlayerTaskSingleton playerTask = PlayerTaskSingleton.getInstance();

            try
            {
                Console.WriteLine("Retrieve all players");

                ICollection<Player> playersList = await playerTask.GetAllPlayerAsync(serverUrl);

                foreach (Player p in playersList)
                {
                    PlayerTaskSingleton.getInstance().ShowPlayer(p);
                }

                Console.WriteLine("Enter your username: ");
                string playerUsername = Console.ReadLine();

                if (String.IsNullOrEmpty(playerUsername))
                {
                    throw new Exception("Invalid username provided");
                }
                
                Player player = new Player
                {
                    Id = 777,
                    Username = playerUsername,
                    DeathCount = 0
                };
                player.fac
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }

    }
}