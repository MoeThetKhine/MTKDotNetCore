namespace MTKDotNetCore.ConsoleApp4.Dapper
{
    public class DapperQueries
    {
        public string GetReadQuery() =>
            "SELECT * FROM tbl_blog WHERE DeleteFlag = 0;";

        public string GetCreateQuery() => @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle], [BlogAuthor], [BlogContent], [DeleteFlag])
           VALUES (@BlogTitle, @BlogAuthor, @BlogContent, 0);";

        public string GetEditQuery() => 
            "SELECT * FROM tbl_blog WHERE DeleteFlag = 0 AND BlogId = @BlogId;";

        public string GetDeleteQuery() => @"UPDATE [dbo].[Tbl_Blog]
                         SET [DeleteFlag] = 1
                         WHERE BlogId = @BlogId;";

        public string GetUpdateQuery() => @"UPDATE [dbo].[Tbl_Blog]
                         SET [BlogTitle] = @BlogTitle,
                             [BlogAuthor] = @BlogAuthor,
                             [BlogContent] = @BlogContent,
                             [DeleteFlag] = 0
                         WHERE BlogId = @BlogId;";
    }
}
