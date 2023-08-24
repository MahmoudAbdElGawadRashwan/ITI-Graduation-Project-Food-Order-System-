using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderSystemAPI;

public class DeleteReviewInputDto
{
    public int ProductId { get; set; }
    public int CustomerId { get; set; }
}
