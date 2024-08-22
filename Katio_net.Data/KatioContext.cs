using System;
using Katio.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Katio_net.Data;

public class KatioContext : DbContext
{
    public KatioContext(DbContextOptions<KatioContext> options) : base(options)
    {}

    public DbSet<Book> Books{get;set;} = null;
}
