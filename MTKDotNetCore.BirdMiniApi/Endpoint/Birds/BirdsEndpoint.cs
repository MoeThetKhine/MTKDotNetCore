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

        #region Create Birds

        app.MapPost("/birds", (BirdModel requestModel) =>
        {
            string folderPath = "Data/Birds.json";
            var jsonStr = File.ReadAllText(folderPath);
            var result = JsonConvert.DeserializeObject<BirdResponseModel>(jsonStr)!;

            requestModel.Id = result.Tbl_Bird.Count == 0 ? 1 : result.Tbl_Bird.Max(x => x.Id) + 1;
            result.Tbl_Bird.Add(requestModel);

            var jsonStrToWrite = JsonConvert.SerializeObject(result);
            File.WriteAllText(folderPath, jsonStrToWrite);

            return Results.Ok(requestModel);
        }).WithName("GetBird")
        .WithOpenApi();

        #endregion


    }

}
