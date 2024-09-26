﻿using Microsoft.EntityFrameworkCore;
using MTKDotNetCore.ConsoleApp.Models;

namespace MTKDotNetCore.ConsoleApp;

public class AppDbContext: DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            string connectionString = "Data Source=.;Initial Catalog=DotNetTrainingBatch5;User ID=sa;Password=sasa@123;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
    public DbSet<BlogDataModel> Blogs { get; set; }
}