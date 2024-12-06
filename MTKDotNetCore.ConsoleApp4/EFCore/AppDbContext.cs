namespace MTKDotNetCore.ConsoleApp4.EFCore;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public virtual DbSet<TblBlog> TblBlogs { get; set; }

    #region OnModelCreating

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblBlog>(entity =>
        {
            entity.HasKey(e => e.BlogId);

            entity.ToTable("Tbl_Blog");

            entity.Property(e => e.BlogAuthor).HasMaxLength(50);
            entity.Property(e => e.BlogTitle).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    #endregion

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
