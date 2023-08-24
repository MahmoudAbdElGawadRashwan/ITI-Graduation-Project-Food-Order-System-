using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderSystemAPI.BL.DTOs
{
    public class OrderReadDto
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }

        public int TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }

    }
}
