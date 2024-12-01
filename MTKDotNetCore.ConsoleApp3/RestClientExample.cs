using RestSharp;

namespace MTKDotNetCore.ConsoleApp3
{
    public class RestClientExample
    {
        private readonly RestClient _client;
        private readonly string _postEndpoint = "https://jsonplaceholder.typicode.com/posts";

        public RestClientExample(RestClient client)
        {
            _client = client;
        }

        #region Read

        public async Task Read()
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

        #region Edit

        public async Task Edit(int id)
        {
            RestRequest request = new RestRequest($"{_postEndpoint}/{id}", Method.Get);
            var response = await _client.ExecuteAsync(request);
            
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                Console.WriteLine("No data found.");
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

    #region PostModel

    public class PostModel
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
    }

    #endregion
}
