namespace MTKDotNetCore.ConsoleApp4.Dapper
{
    public class DapperExample
    {
        private readonly DapperService _dapperService;
        private readonly DapperQueries _dapperQueries;

        public DapperExample(DapperService dapperService, DapperQueries dapperQueries)
        {
            _dapperService = dapperService;
            _dapperQueries = dapperQueries;
        }

        #region Read

        public void Read()
        {
            var lst = _dapperService.Query<BlogDataDapperModel>
                (_dapperQueries.GetReadQuery()).ToList();
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

        public void Create(string title, string author, string  content)
        {
            int result = _dapperService.Execute
                (_dapperQueries.GetCreateQuery(), new BlogDataDapperModel
                {
                    BlogTitle = title,
                    BlogAuthor = author,
                    BlogContent = content
                });
            string message = result == 1 ? "Saving Successful." : "Saving Failed.";
            Console.WriteLine(message);
        }

        #endregion

        #region Edit

        public void Edit(int id)
        {
            var item = _dapperService.QueryFirstOrDefault<BlogDataDapperModel>(_dapperQueries.GetEditQuery(),
                new { BlogId = id });

            if(item is null)
            {
                Console.WriteLine("No Data Found");
                return;
            }
            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
        }

        #endregion

        #region Update

        public void Update(int id, string title, string author, string content)
        {
            int result = _dapperService.Execute(_dapperQueries.GetUpdateQuery(),
                new
                {
                    BlogId = id,
                    BlogTitle = title,
                    BlogAuthor = author,
                    BlogContent = content
                });
            string message = result == 1 ? "Updating Successful." : "Updating Failed.";
            Console.WriteLine(message);
        }

        #endregion

    }
}
