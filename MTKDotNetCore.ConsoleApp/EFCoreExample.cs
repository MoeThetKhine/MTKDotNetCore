using Microsoft.EntityFrameworkCore;
using MTKDotNetCore.ConsoleApp.Models;

namespace MTKDotNetCore.ConsoleApp;

public class EFCoreExample
{
    #region Read

    public void Read()
    {
        AppDbContext db = new AppDbContext();
        var lst = db.Blogs.Where(x => x.DeleteFlag == false)
            .AsNoTracking()
            .ToList();

        foreach (var item in lst)
        {
            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
        }
    }

    #endregion

    public void Create(string title,string author,string content)
    {
        BlogDataModel blog = new BlogDataModel()
        {
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content
        };
        AppDbContext db = new AppDbContext();
        db.Blogs.Add(blog);
        var result = db.SaveChanges();
        Console.WriteLine(result == 1 ? "Saving Successful." : "Saving Fail.");
    }
}
