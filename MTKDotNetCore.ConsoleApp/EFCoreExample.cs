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

    #region Create

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

    #endregion

    #region Edit

    public void Edit(int id)
    {
        AppDbContext db = new AppDbContext();
      //  db.Blogs.Where(x => x.BlogId == id).FirstOrDefaultAsync();
      var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);
        if (item == null)
        {
            Console.WriteLine("No Data Found");
            return;
        }
        Console.WriteLine("Blog Id : " + item.BlogId);
        Console.WriteLine("Blog Title : " + item.BlogTitle);
        Console.WriteLine("Blog Author : " + item.BlogAuthor);
        Console.WriteLine("Blog Content : " + item.BlogContent);
    }

    #endregion
}
