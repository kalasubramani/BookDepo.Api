using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BookDepo.Api.Domain;

//[Table("book")]
public record Book
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Column("book_name")]
    [MaxLength(100)]
    public string? BookName { get; set; }

    [Column("book_code")]
    [MaxLength(10)]
    public string? BookCode { get; set; }

    [Column("price", TypeName = "decimal(7,2)")]
    public decimal Price { get; set; }

    [Column("stock_available")]
    public int StockAvailable { get; set; }
}
