using MTKDotNetCore.Database.Models;
using Newtonsoft.Json;

AppDbContext db = new AppDbContext();

var blog = new BlogModel
{
    Id = 1,
    Title = "Test Title",
    Author = "Test Author",
    Content = "Test Content",
};

string jsonStr = blog.ToJson(); // C# to JSON

Console.WriteLine(jsonStr);

string jsonStr2 = """{"id":1,"title":"Test Title","author":"Test Author","content":"Test Content"}""";
var blog2 = JsonConvert.DeserializeObject<BlogModel>(jsonStr2);


Console.WriteLine(blog2.Title);

Console.ReadLine();

public class BlogModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Content { get; set; }
}

public static class Extensions // DevCode
{
    public static string ToJson(this object obj)
    {
        string jsonStr = JsonConvert.SerializeObject(obj, Formatting.Indented);
        return jsonStr;
    }
}