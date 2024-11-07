using MTKDotNetCore.DreamDictionaryMinimalApi.Models;
using Newtonsoft.Json;

namespace MTKDotNetCore.DreamDictionaryMinimalApi.Endpoint.Dreams
{
    public static class DreamsEndpoint
    {
        public static void MapDreamsEndpoint(this IEndpointRouteBuilder app)
        {
            #region Get Dream Title

            app.MapGet("/dreams", () =>
            {
                string folderPath = "Data/dreams.json";

                var jsonStr = File.ReadAllText(folderPath);
                var result = JsonConvert.DeserializeObject<DreamsResponseModel>(jsonStr)!;

                return Results.Ok(result.BlogHeader);

            }).WithName("GetBirds")
            .WithOpenApi();

            #endregion
        }
    }
}
