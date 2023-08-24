using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodOrderSystemAPI;

public class OrderProductModel
{
    [Range(0, int.MaxValue, ErrorMessage = "Quantity Should Be Positive")]
    public int Quantity { get; set; }


    // FKs & Composit PK
    [ForeignKey(nameof(Order))]
    [Column(Order = 1)]
    public int OrderId { get; set; }

    [Column(Order = 2)]
    [ForeignKey(nameof(Product))]
    public int ProductId { get; set; }

    public OrderModel? Order { get; set; }
    public ProductModel? Product { get; set; }
}