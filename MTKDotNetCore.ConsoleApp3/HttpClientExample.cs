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

        #region CreateAsync

        public async Task CreateAsync(string title,  string body, int userId)
        {
            PostModel requestModel = new PostModel()
            {
                body = body,
                title = title,
                userId = userId
            };

            var jsonRequest = JsonConvert.SerializeObject(requestModel);
            var content = new StringContent(jsonRequest, Encoding.UTF8,Application.Json);
            var response = await _client.PostAsync(_postEndpoint, content);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());  
            }
        }

        #endregion

        #region UpdateAsync

        public async Task UpdateAsync(int id, string title,string body, int userId)
        {
            PostModel requestModel = new PostModel()
            {
                id = id,
                body = body,
                title = title,
                userId = userId
            };
            var jsonRequest = JsonConvert.SerializeObject(requestModel);
            var content = new StringContent(jsonRequest,Encoding.UTF8,Application.Json);
            var response = await _client.PatchAsync($"{_postEndpoint}/{id}", content);
            if (response.IsSuccessStatusCode)
            { 
                var result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);  
            }
        }

        #endregion

        #region DeleteAsync

        public async Task DeleteAsync(int id)
        {
            var response = await _client.DeleteAsync($"{_postEndpoint}/{id}");
            if(response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                Console.WriteLine("No Data Found.");
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
