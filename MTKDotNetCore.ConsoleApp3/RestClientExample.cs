using RestSharp;

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

        #region ReadAync

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
    }
}
