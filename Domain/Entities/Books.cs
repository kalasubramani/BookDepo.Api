using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BookDepo.Api.Domain.Entities;

[Table("books")]
public record Books
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; init; }

    [Column("book_name")]
    [MaxLength(100)]
    public string? BookName { get; init; }

    [Column("book_code")]
    [MaxLength(10)]
    public string? BookCode { get; init; }

    [Column("price", TypeName = "decimal(7,2)")]
    public decimal Price { get; init; }

    [Column("stock_available")]
    public int StockAvailable { get; init; }
}
