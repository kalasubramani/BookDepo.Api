using BookDepo.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookDepo.Api.Data;

public class BooksDbContext:DbContext
{
    public BooksDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {

    }

    public DbSet<Books> Books {  get; set; } 
}
