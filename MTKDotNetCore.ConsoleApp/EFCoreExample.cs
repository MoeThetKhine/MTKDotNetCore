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

    public void Create(string title, string author, string content)
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
        var item = db.Blogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);
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

    #region Update

    public void Update(int id, string title, string author, string content)
    {
        AppDbContext db = new AppDbContext();
        var item = db.Blogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);
        if (item == null)
        {
            Console.WriteLine("No Data Found");
            return;
        }

        if (!string.IsNullOrEmpty(title))
        {
            item.BlogTitle = title;
        }
        if (!string.IsNullOrEmpty(author))
        {
            item.BlogAuthor = author;
        }
        if (!string.IsNullOrEmpty(content))
        {
            item.BlogContent = content;
        }
        db.Entry(item).State = EntityState.Modified;
        var result = db.SaveChanges();
        Console.WriteLine(result == 1 ? "Updaing Successful." : "Updating Fail.");
    }

    #endregion

    #region HardDelete

    public void HardDelete(int id)
    {
        AppDbContext db = new AppDbContext();
        var item = db.Blogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);

        if(item is null)
        {
            Console.WriteLine("No Data Found");
            return;
        }
        db.Entry(item).State = EntityState.Deleted;
        var result = db.SaveChanges();
        Console.WriteLine(result == 1 ? "Deleting Successful." : "Deleting Fail.");
    }

    #endregion

    #region SoftDelete

    public void SoftDelete(int id)
    {
        AppDbContext db = new AppDbContext();
        var item = db.Blogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);

        if (item is null)
        {
            Console.WriteLine("No Data Found");
            return;
        }

        item.DeleteFlag = true;
        db.Entry(item).State = EntityState.Modified;
        var result = db.SaveChanges();
        Console.WriteLine(result == 1 ? "Deleting Successful." : "Deleting Fail.");
    }

    #endregion

}
