using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Server.Models;

namespace Client.Task
{
    class PlayerTaskSingleton
    {
        private static PlayerTaskSingleton instance = new PlayerTaskSingleton();
        static HttpClient client = new HttpClient();
        static string requestUri = "api/player/";
        static string mediaType = "application/json";

        private PlayerTaskSingleton()
        {
            Console.WriteLine("Player Task Singleton initialized");
        }

        public static PlayerTaskSingleton getInstance()
        {
            return instance;
        }

        public void ShowPlayer(Player player)
        {
            //\tposX: {player.PosX}\tposY: {player.PosY}");
            Console.WriteLine($"Id: {player.Id}\tName: {player.Username}\tDeathcount: " + $"{player.DeathCount}");
        }

        public async Task<Uri> CreatePlayerAsync(Player player)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(requestUri, player);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            Player player2 = await response.Content.ReadAsAsync<Player>();
            if (player2 != null)
            {
                ShowPlayer(player);
            }

            // return URI of the created resource.
            return response.Headers.Location;
        }

        public async Task<ICollection<Player>> GetAllPlayerAsync(string path)
        {
            ICollection<Player> players = null;

            HttpResponseMessage response = await client.GetAsync(path + "api/player");

            if (response.IsSuccessStatusCode)
            {
                players = await response.Content.ReadAsAsync<ICollection<Player>>();
            }

            return players;
        }

        public async Task<Player> GetPlayerAsync(string path)
        {
            Player player = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                player = await response.Content.ReadAsAsync<Player>();
            }
            return player;
        }

        public async Task<HttpStatusCode> UpdatePlayerAsync(Player player)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                requestUri + $"{player.Id}", player);
            response.EnsureSuccessStatusCode();

            return response.StatusCode;
        }

        public async Task<HttpStatusCode> PatchPlayerAsync(Position coordinates)
        {
            //"{\"id\":1, \"posX\":777,\"posY\":777}";
            string jsonString = JsonConvert.SerializeObject(coordinates);

            HttpContent httpContent = new StringContent(jsonString, System.Text.Encoding.UTF8, mediaType);
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = new HttpMethod("PATCH"),
                RequestUri = new Uri(client.BaseAddress + requestUri),
                Content = httpContent,
            };

            HttpResponseMessage response = await client.SendAsync(request);
            return response.StatusCode;

        }

        public async Task<HttpStatusCode> DeletePlayerAsync(long id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                requestUri + $"{id}");
            return response.StatusCode;
        }
    }
}