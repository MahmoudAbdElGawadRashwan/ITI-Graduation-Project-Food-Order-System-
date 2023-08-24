using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodOrderSystemAPI;

public enum PaymentType
{
    Credit,
    Cash,
    Both
}

[Table("RestaurantModel")]
public class RestaurantModel : UserModel
{
    [Required(ErrorMessage = "Please enter a valid restaurant name.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Restaurant name must be between 3 and 50 characters.")]
    public string RestaurantName { set; get; } = string.Empty;

    [Required(ErrorMessage = "Address is required.")]
    [StringLength(100, MinimumLength = 5, ErrorMessage = "Address must be between 5 and 100 characters.")]
    public string Address { set; get; } = string.Empty;

    public string Logo { set; get; } = string.Empty;

    [Phone]
    [RegularExpression(@"^[0-9]{11,16}$", ErrorMessage = "Please enter a valid Phone number.")]
    public string Phone { set; get; } = string.Empty;

    [EnumDataType(typeof(PaymentType), ErrorMessage = "Payment details should be either 'Credit', 'Cash' or 'Both'.")]
    public PaymentType PaymentMethods { set; get; } = PaymentType.Cash;

    // 1-M Relation with product
    public ICollection<ProductModel> Products { set; get; } = new HashSet<ProductModel>();
}