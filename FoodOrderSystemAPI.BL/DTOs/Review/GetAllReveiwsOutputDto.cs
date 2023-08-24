using System.ComponentModel.DataAnnotations;

namespace FoodOrderSystemAPI;

public class GetAllReveiwsOutputDto
{
    [MaxLength(500)]
    public string? Comment { get; set; }

    [Range(0, 5, ErrorMessage = "Rating must be from 0 to 5")]
    public int Rating { get; set; }
}
