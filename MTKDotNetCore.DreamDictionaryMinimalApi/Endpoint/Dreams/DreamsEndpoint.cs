namespace MTKDotNetCore.DreamDictionaryMinimalApi.Endpoint.Dreams;

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

        }).WithName("GetDreams")
        .WithOpenApi();

        #endregion

        #region Get Dream Title By Id

        app.MapGet("/dreams/{id}", (int id) =>
        {
            string folderPath = "Data/dreams.json";

            var jsonStr = File.ReadAllText(folderPath);
            var result = JsonConvert.DeserializeObject<DreamsResponseModel>(jsonStr)!;

            var item = result.BlogHeader.FirstOrDefault(x => x.BlogId == id);

            if (item is null)
            {
                return Results.BadRequest("No Data Found");
            }
            return Results.Ok(item);
        }).WithName("EditDreams")
    .WithOpenApi();

        #endregion

        #region Get Dreams Answer

        app.MapGet("/dreams_answer", () =>
        {
            string folderPath = "Data/dreams.json";

            var jsonStr = File.ReadAllText(folderPath);
            var result = JsonConvert.DeserializeObject<DreamsResponseModel>(jsonStr)!;

            return Results.Ok(result.BlogDetail);

        }).WithName("GetDreamsAnswer")
        .WithOpenApi();

        #endregion

        #region Get Dream Answer By Id

        app.MapGet("/dreams_answer/{id}", (int id) =>
        {
            string folderPath = "Data/dreams.json";

            var jsonStr = File.ReadAllText(folderPath);
            var result = JsonConvert.DeserializeObject<DreamsResponseModel>(jsonStr)!;

            var item = result.BlogDetail.FirstOrDefault(x => x.BlogDetailId == id);

            if (item is null)
            {
                return Results.BadRequest("No Data Found");
            }
            return Results.Ok(item);
        }).WithName("EditDreamsAnswer")
    .WithOpenApi();

        #endregion

        #region Get Dream Answer By Tile_Id

        app.MapGet("/answer/{title_id}", (int title_id) =>
        {
            string folderPath = "Data/dreams.json";

            var jsonStr = File.ReadAllText(folderPath);
            var result = JsonConvert.DeserializeObject<DreamsResponseModel>(jsonStr)!;

            var item = result.BlogDetail.Where(x => x.BlogId == title_id).ToList();

            if (item is null)
            {
                return Results.BadRequest("No Data Found");
            }
            return Results.Ok(item);
        }).WithName("EditDreamsAnswerBy_TitleId")
    .WithOpenApi();

        #endregion

    }
}
