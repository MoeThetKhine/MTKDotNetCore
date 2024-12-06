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


    }


}
