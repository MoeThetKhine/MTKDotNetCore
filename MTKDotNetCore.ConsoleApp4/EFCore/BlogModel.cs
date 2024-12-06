using System.ComponentModel.DataAnnotations;

namespace MTKDotNetCore.ConsoleApp4.EFCore
{
    public class BlogModel
    {
        [Key]
        public long BlogId { get; set; }

        public string BlogTitle { get; set; } = null!;

        public string BlogAuthor { get; set; } = null!;

        public string BlogContent { get; set; } = null!;

        public bool DeleteFlag { get; set; }
    }
}
