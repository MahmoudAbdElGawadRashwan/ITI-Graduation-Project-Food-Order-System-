using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderSystemAPI.BL
{
    public class ProductCardDto
    {
        public int ProductID { get; set; }

        public String Productname { get; set; } = "";

        public float price { get; set; }

        public String describtion { get; set; } = "";

        public String img { get; set; } = "";

        public float offer { get; set; }

        public float rate { get; set; }

        public List<string> tags { get; set; } = new List<string>();
        public int restaurantID { get; set; } 

        public string restaurantName { get; set; } = "";
    }
}
