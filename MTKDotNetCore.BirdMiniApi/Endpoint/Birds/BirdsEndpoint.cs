namespace MTKDotNetCore.BirdMiniApi.Endpoint.Birds
{
    public static class BirdsEndpoint
    {
        public static void MapBirdsEndpoint(this IEndpointRouteBuilder app)
        {
            #region GetBirds

            app.MapGet("/birds", () =>
            {
                string folderPath = "Data/Bird.json";

                var jsonStr = File.ReadAllText(folderPath);
                var result = JsonConvert.DeserializeObject<BirdResponseModel>(jsonStr)!;

                return Results.Ok(result.Tbl_Bird);

            }).WithName("GetBirds")
            .WithOpenApi();

            #endregion
        }
    }
}
