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



    }


}
