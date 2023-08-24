using System.ComponentModel.DataAnnotations;

namespace FoodOrderSystemAPI;

public class ReviewModel
{
    // Properties
    [MaxLength(500)]
    public string? Comment { get; set; }

    [Range(0,5, ErrorMessage = "Rating must be from 0 to 5")]
    public int Rating { get; set; }

    // FKs & Composite PK
    public int ProductId { get; set; }
    public int CustomerId { get; set; }

    // Navigation properties
    public ProductModel? Product { get; set; }
    public CustomerModel? Customer { get; set; }

}
