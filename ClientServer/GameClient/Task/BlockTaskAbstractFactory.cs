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
    class BlockTaskAbstractFactory
    {
        static HttpClient client = new HttpClient();
        static string requestUri = "api/block/";
        static string mediaType = "application/json";

        private BlockTaskAbstractFactory()
        {
            Console.WriteLine("Block Task Abstract Factory initialized");
        }

        public static void createBlock()
        {
            /*BlockTaskAbstractFactory f = new BlockTaskAbstractFactory();
            BlockFactory factory = new BlockFactory();
            Block test1 = factory.createEnemyD();
            f.ShowBlock(test1);
            f.CreateBlockAsync(test1);
            */
        }

        public void ShowBlock(Block block)
        {
            Console.WriteLine($"Id: {block.Id}\tName: {block.Name}\tImageId: " + $"{block.ImageId}\tHeight: " + $"{block.Height}\tWidth: " + $"{block.Width}\tDamage: " + $"{block.Damage}");
        }

        public async Task<Uri> CreateBlockAsync(Block block)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(requestUri, block);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            Block block2 = await response.Content.ReadAsAsync<Block>();
            if (block2 != null)
            {
                ShowBlock(block);
            }

            // return URI of the created resource.
            return response.Headers.Location;
        }

        public async Task<ICollection<Block>> GetAllBlockAsync(string path)
        {
            ICollection<Block> blocks = null;

            HttpResponseMessage response = await client.GetAsync(path + "api/block");

            if (response.IsSuccessStatusCode)
            {
                blocks = await response.Content.ReadAsAsync<ICollection<Block>>();
            }

            return blocks;
        }

        public async Task<Block> GetBlockAsync(string path)
        {
            Block blocks = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                blocks = await response.Content.ReadAsAsync<Block>();
            }
            return blocks;
        }

        public async Task<HttpStatusCode> UpdateBlockAsync(Block block)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                requestUri + $"{block.Id}", block);
            response.EnsureSuccessStatusCode();

            return response.StatusCode;
        }

        public async Task<HttpStatusCode> PatchBlockAsync(Position coordinates)
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

        public async Task<HttpStatusCode> DeleteBlockAsync(long id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                requestUri + $"{id}");
            return response.StatusCode;
        }
    }
}