using Microsoft.EntityFrameworkCore;

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

   
}
