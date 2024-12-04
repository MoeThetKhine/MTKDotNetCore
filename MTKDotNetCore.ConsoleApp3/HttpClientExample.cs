namespace MTKDotNetCore.ConsoleApp3
{
    public class HttpClientExample
    {
        private readonly HttpClient _client;
        private readonly string _postEndpoint = "https://jsonplaceholder.typicode.com/posts";

        public HttpClientExample()
        {
            _client = new HttpClient();
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

        #region ReadAsync

        public async Task ReadAsync()
        {
            var response = await _client.GetAsync(_postEndpoint);
            if(response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                Console.WriteLine(jsonStr);
            }
        }

        #endregion

        #region EditAsync

        public async Task EditAsync(int id)
        {
            var response = await _client.GetAsync($"{_postEndpoint}/{id}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                Console.WriteLine("No Data Found");
                return;
            }

            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                Console.WriteLine(jsonStr);
            }
        }

        #endregion

    }
}
