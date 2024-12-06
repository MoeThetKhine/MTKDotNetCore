﻿namespace MTKDotNetCore.ConsoleApp4.Dapper
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
            var lst = _dapperService.Query<BlogDataDapperModel>(_dapperQueries.GetReadQuery()).ToList();
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
}
