using BookDepo.Api.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookDepo.Api.Data;

public class BookDbContext:DbContext
{
    public BookDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {

    }

    public DbSet<Book> Books {  get; set; } 
}
