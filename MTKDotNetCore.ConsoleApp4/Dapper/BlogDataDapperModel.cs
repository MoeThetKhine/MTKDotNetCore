namespace MTKDotNetCore.ConsoleApp4.Dapper;

#region BlogDataDapperModel

public class BlogDataDapperModel
{
    public int BlogId { get; set; }
    public string BlogTitle { get; set; }
    public string BlogAuthor { get; set; }
    public string BlogContent { get; set; }
    public int DeleteFlag { get; set; }
}

#endregion
