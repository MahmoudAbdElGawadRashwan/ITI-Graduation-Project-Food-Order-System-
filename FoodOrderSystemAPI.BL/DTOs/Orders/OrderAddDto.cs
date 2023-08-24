namespace FoodOrderSystemAPI.BL.DTOs;

public class OrderAddDto
{
    public int CustomerId { get; set; }
    public int TotalPrice { get; set; }
    public DateTime OrderDate { get; set; }
    public ICollection<OrderAddDtoOrderProductsDto> OrderProducts { get; set; } = new HashSet<OrderAddDtoOrderProductsDto>();
}
