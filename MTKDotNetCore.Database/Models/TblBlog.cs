using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MTKDotNetCore.Database.Models;

public partial class TblBlog
{
    [Key] 
    public long BlogId { get; set; }

    public string BlogTitle { get; set; } = null!;

    public string BlogAuthor { get; set; } = null!;

    public string BlogContent { get; set; } = null!;

    public bool DeleteFlag { get; set; }
}
