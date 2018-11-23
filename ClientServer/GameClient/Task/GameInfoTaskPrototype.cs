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
    class GameInfoTaskPrototype
    {
        static HttpClient client = new HttpClient();
        static string requestUri = "api/gameinfo/";
        static string mediaType = "application/json";

        private GameInfoTaskPrototype()
        {
            Console.WriteLine("Game Info Task Prototype initialized");
        }

        public static void createBlock()
        {
            GameInfoTaskPrototype f = new GameInfoTaskPrototype();
            BlockFactory factory = new BlockFactory();
            GameInfo test1 = factory.createEnemyD();
            f.ShowBlock(test1);
            f.CreateBlockAsync(test1);

        }

        public void ShowGameInfo(GameInfo gameinfo)
        {
            Console.WriteLine($"Id: {gameinfo.Id}\tTitle: {gameinfo.GameTitle}\tMapId: " + $"{gameinfo.MapId}\tTime: " + $"{gameinfo.GameTime}");
        }

        public async Task<Uri> CreateGameInfoAsync(GameInfo gameinfo)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(requestUri, gameinfo);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            GameInfo gameinfo2 = await response.Content.ReadAsAsync<GameInfo>();
            if (gameinfo2 != null)
            {
                ShowGameInfo(gameinfo);
            }

            // return URI of the created resource.
            return response.Headers.Location;
        }

        public async Task<ICollection<GameInfo>> GetAllGameInfoAsync(string path)
        {
            ICollection<GameInfo> gameinfos = null;

            HttpResponseMessage response = await client.GetAsync(path + "api/gameinfo");

            if (response.IsSuccessStatusCode)
            {
                gameinfos = await response.Content.ReadAsAsync<ICollection<GameInfo>>();
            }

            return gameinfos;
        }

        public async Task<GameInfo> GetGameInfoAsync(string path)
        {
            GameInfo gameinfos = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                gameinfos = await response.Content.ReadAsAsync<GameInfo>();
            }
            return gameinfos;
        }

        public async Task<HttpStatusCode> UpdateGameInfoAsync(GameInfo gameinfo)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                requestUri + $"{gameinfo.Id}", gameinfo);
            response.EnsureSuccessStatusCode();

            return response.StatusCode;
        }
        
        public async Task<HttpStatusCode> PatchGameInfoAsync(Position coordinates)
        {
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

        public async Task<HttpStatusCode> DeleteGameInfoAsync(long id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                requestUri + $"{id}");
            return response.StatusCode;
        }
    }
}
