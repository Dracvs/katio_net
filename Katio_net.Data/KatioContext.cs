using System;
using Katio.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Katio_net.Data;

public class KatioContext : DbContext
{
    public KatioContext(DbContextOptions<KatioContext> options) : base(options)
    {}

    public DbSet<Book> Books{get;set;} = null;
    public DbSet<Author> Authors{get;set;} = null;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        if(builder == null)
        { 
            return;
        }

        builder.Entity<Book>().ToTable("Book").HasKey(k => k.Id);
        builder.Entity<Author>().ToTable("Author").HasKey(k => k.Id);
        base.OnModelCreating(builder);
    }
}
