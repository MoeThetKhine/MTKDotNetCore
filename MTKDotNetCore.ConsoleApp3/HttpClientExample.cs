using Newtonsoft.Json;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace MTKDotNetCore.ConsoleApp3
{
    public class HttpClientExample
    {
        private readonly HttpClient _client;
        private readonly string _postEndpoint = "https://jsonplaceholder.typicode.com/posts";


        public HttpClientExample(HttpClient client)
        {
            _client = client;
        }

        #region PostModel

        public class PostModel
        {
            public int userId { get; set; }
            public int id { get; set; } 
            public string title { get; set; }
            public string body { get; set; }
        }

        #endregion

        #region Read

        public async Task Read()
        {
            var response = await _client.GetAsync(_postEndpoint);

            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                Console.WriteLine(jsonStr);
            }
        }

        #endregion 
    }
}
