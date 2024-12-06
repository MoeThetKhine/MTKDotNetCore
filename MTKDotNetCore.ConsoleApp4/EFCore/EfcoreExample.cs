using Microsoft.EntityFrameworkCore;
using MTKDotNetCore.Database.Models;

namespace MTKDotNetCore.ConsoleApp4.EFCore
{
    public class EfcoreExample
    {
        private readonly AppDbContext _db;

        public EfcoreExample(AppDbContext db)
        {
            _db = db;
        }

        #region Read

        public void Read()
        {
            var lst = _db.TblBlogs.Where(x => x.DeleteFlag == false)
                .AsNoTracking()
                .ToList();
            foreach(var item in lst)
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
            var blog = new TblBlog()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content,
                DeleteFlag = false 
            };

            _db.TblBlogs.Add(blog);
            var result = _db.SaveChanges();
            Console.WriteLine(result == 1 ? "Saving Successful." : "Saving Failed.");
        }

        #endregion

        #region Edit

        public void Edit(int id)
        {
            var item = _db.TblBlogs
                .AsNoTracking()
                .FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                Console.WriteLine("No Data Found");
                return;
            }

            Console.WriteLine("Blog Id: " + item.BlogId);
            Console.WriteLine("Blog Title: " + item.BlogTitle);
            Console.WriteLine("Blog Author: " + item.BlogAuthor);
            Console.WriteLine("Blog Content: " + item.BlogContent);
        }

        #endregion

        #region Update

        public void Update(int id, string title, string author, string content)
        {
            var item = _db.TblBlogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
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

            _db.Entry(item).State = EntityState.Modified;
            var result = _db.SaveChanges();
            Console.WriteLine(result == 1 ? "Updating Successful." : "Updating Failed.");
        }

        #endregion

        #region SoftDelete

        public void SoftDelete(int id)
        {
            var item = _db.TblBlogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                Console.WriteLine("No Data Found");
                return;
            }

            item.DeleteFlag = true;
            _db.Entry(item).State = EntityState.Modified;
            var result = _db.SaveChanges();
            Console.WriteLine(result == 1 ? "Soft Deleting Successful." : "Soft Deleting Failed.");
        }

        #endregion

        #region HardDelete

        public void HardDelete(int id)
        {
            var item = _db.TblBlogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                Console.WriteLine("No Data Found");
                return;
            }

            _db.Entry(item).State = EntityState.Deleted;
            var result = _db.SaveChanges();
            Console.WriteLine(result == 1 ? "Deleting Successful." : "Deleting Failed.");
        }

        #endregion

    }


}
