using Microsoft.EntityFrameworkCore;
using MTKDotNetCore.Database.Models;

namespace MTKDotNetCore.ConsoleApp4.EFCore
{
    public class EfcoreExample
    {
        private readonly AppDbContext _appDbContext;

        public EfcoreExample(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        #region Read

        public void Read()
        {
            var lst = _appDbContext.TblBlogs.Where(x => x.DeleteFlag == false)
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
