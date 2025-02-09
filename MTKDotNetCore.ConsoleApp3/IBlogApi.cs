﻿namespace MTKDotNetCore.ConsoleApp3;

#region IBlogApi

public interface IBlogApi
{
    [Get("/api/blogs")]
    Task<List<BlogModel>> GetBlogs();

    [Get("/api/blogs/{id}")]
    Task<List<BlogModel>> GetBlog(int id);

    [Get("/api/blogs")]
    Task<BlogModel> CreateBlog(BlogModel blog);
    
}

#endregion