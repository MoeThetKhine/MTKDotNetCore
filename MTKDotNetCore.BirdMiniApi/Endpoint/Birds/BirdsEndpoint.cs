namespace MTKDotNetCore.BirdMiniApi.Endpoint.Birds;

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

        #region Edit Birds

        app.MapGet("/birds/{id}", (int id) =>
        {
            string folderPath = "Data/Bird.json";

            var jsonStr = File.ReadAllText(folderPath);
            var result = JsonConvert.DeserializeObject<BirdResponseModel>(jsonStr)!;

            var item = result.Tbl_Bird.FirstOrDefault(x => x.Id == id);

            if (item is null)
            {
                return Results.BadRequest("No Data Found");
            }
            return Results.Ok(item);
        }).WithName("EditBird")
        .WithOpenApi();

        #endregion
    }
}
