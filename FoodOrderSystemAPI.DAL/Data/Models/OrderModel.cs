using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FoodOrderSystemAPI;

public class OrderModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int OrderId { get; set; }

    [ForeignKey("CustomerModel")]
    public int CustomerId { get; set; }
    
    [Range(0,float.MaxValue)]
    public int TotalPrice { get; set; }
    public DateTime OrderDate { get; set; }

    [StringLength(30, MinimumLength = 3)]
    public string? OrderStatus { get; set; } = string.Empty;


    // navigation properties

    public CustomerModel? Customer { get; set; }
    public ICollection<OrderProductModel> OrderProducts { get; set; } = new HashSet<OrderProductModel>();

}
