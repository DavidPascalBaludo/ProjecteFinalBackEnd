using Api.Models;
using Microsoft.EntityFrameworkCore;

public class MyContext : DbContext
{
    public DbSet<Dice> Dice { get; set; }

    public MyContext(DbContextOptions<MyContext> options) : base(options)
    {
    }
}
