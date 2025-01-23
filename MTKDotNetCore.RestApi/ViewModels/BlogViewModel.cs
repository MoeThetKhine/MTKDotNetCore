namespace MTKDotNetCore.RestApi.ViewModels;

#region BlogViewModel

public class BlogViewModel
{
    public int BlogId { get; set; }
    public string? BlogTitle { get; set; }
    public string? BlogAuthor { get; set; }
    public string? BlogContent { get; set; }
    public bool DeleteFlag { get; set; }
}

#endregion