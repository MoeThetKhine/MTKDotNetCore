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

        #endregion

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
            PostModel requestModel = new PostModel
            {
                body = body,
                title = title,
                userId = userId
            };

            RestRequest request = new RestRequest(_postEndpoint, Method.Post);
            request.AddJsonBody(requestModel);
            var response = await _client.ExecuteAsync(request);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.Content!);
            }
        }

        #endregion

        #region Update Async

        public async Task UpdateAsync(int id, string title, string  body, int userId)
        {
            PostModel requestModel = new PostModel
            {
                body = body,
                title = title,
                userId = userId
            };

            RestRequest request = new RestRequest(_postEndpoint, Method.Patch);
            request.AddJsonBody(requestModel);
            var response = await _client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.Content!);
            }
        }

        #endregion

        #region Delete Async

        public async Task Delete(int id)
        {
            RestRequest request = new RestRequest($"{_postEndpoint}/{id}", Method.Delete);
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


    }
}
