using RestSharp;
using System.Reflection.PortableExecutable;

namespace MTKDotNetCore.ConsoleApp3
{
    public class RestClientExample
    {
        private readonly RestClient _client;
        private readonly string _postEndpoint = "https://jsonplaceholder.typicode.com/posts";

        public RestClientExample()
        {
            _client = new RestClient();
        }

        #region PostModel

        public class PostModel
        {
            public int userId { get; set; }
            public int id { get; set; }
            public string title { get; set; }
            public string body { get; set; }

        }

        #region Read Async

        public async Task ReadAsync()
        {
            RestRequest request = new RestRequest(_postEndpoint,Method.Get);
            var response = await _client.ExecuteAsync(request);

            if(response.IsSuccessStatusCode)
            {
                string jsonStr = response.Content!;
                Console.WriteLine(jsonStr);
            }
        }

        #endregion

        #region Edit Async

        public async Task EditAsync(int id)
        {
            RestRequest request = new RestRequest($"{_postEndpoint}/{id}", Method.Get);
            var response = await _client.ExecuteAsync(request);

            if(response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                Console.WriteLine("No Data Found");
                return;
            }
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = response.Content!;
                Console.WriteLine(jsonStr); 
            }
        }

        #endregion

        #region Create Async

        public async Task CreateAsync(string title, string body, int userId)
        {
            PostMdoel request = new
        }

        #endregion


    }
}
