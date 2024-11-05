﻿namespace MTKDotNetCore.MinimalApi.Endpoints.Blog;

public static class BlogEndpoint
{
    public static void MapBlogEndpoint(this IEndpointRouteBuilder app)
    {

        #region GetBlog 

        app.MapGet("/blogs", () =>
        {
            AppDbContext db = new AppDbContext();
            var model = db.TblBlogs.AsNoTracking().ToList();
            return Results.Ok(model);

        }).WithName("GetBlog")
        .WithOpenApi();

        #endregion

        #region CreateBlog

        app.MapPost("/blogs", (TblBlog blog) =>
        {
            AppDbContext db = new AppDbContext();
            db.TblBlogs.Add(blog);
            db.SaveChanges();
            return Results.Ok(blog);

        }).WithName("CreateBlog")
        .WithOpenApi();

        #endregion

        #region UpdateBlog

        app.MapPut("/blogs/{id}", (int id ,TblBlog blog) =>
        {
            AppDbContext db = new AppDbContext();
           var item = db.TblBlogs.AsNoTracking()
                                 .FirstOrDefault(x => x.BlogId == id);

            if(item is null)
            {
                return Results.BadRequest("No Data Found");
            }

            item.BlogTitle = blog.BlogTitle;
            item.BlogAuthor = blog.BlogAuthor;
            item.BlogContent = blog.BlogContent;

            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
            return Results.Ok(blog);

        }).WithName("UpdateBlog")
        .WithOpenApi();

        #endregion

        #region DeleteBlog

        app.MapDelete("/blogs/{id}", (int id) =>
        {
            AppDbContext db = new AppDbContext();
            var item = db.TblBlogs.AsNoTracking()
                                  .FirstOrDefault(x => x.BlogId == id);

            if (item is null)
            {
                return Results.BadRequest("No Data Found");
            }
            db.Entry(item).State = EntityState.Deleted;
            db.SaveChanges();
            return Results.Ok();
        });

        #endregion

        #region EditBlog 

        app.MapGet("/blogs/{id}", (int id) =>
        {
            AppDbContext db = new AppDbContext();
            var item = db.TblBlogs
                .AsNoTracking()
                .FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return Results.BadRequest("No data found.");
            }

            return Results.Ok(item);
        })
        .WithName("GetBlogs")
        .WithOpenApi();

        #endregion

        #region PatchBlog

        app.MapPatch("/blogs/{id}", (int id, TblBlog blog) =>
        {
            AppDbContext db = new AppDbContext();
            var item = db.TblBlogs.AsNoTracking()
                                  .FirstOrDefault(x => x.BlogId == id);
            if(item is null)
            {
                return Results.BadRequest("No Data Found");
            }
            if(!string.IsNullOrEmpty(blog.BlogTitle))
            {
                item.BlogTitle = blog.BlogTitle;
            }
            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                item.BlogAuthor = blog.BlogAuthor;
            }
            if(!string.IsNullOrEmpty (blog.BlogContent))
            {
                item.BlogContent = blog.BlogContent;
            }

            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
            return Results.Ok(item);

        }).WithName("PatchBlog")
        .WithOpenApi();

        #endregion
    }
}