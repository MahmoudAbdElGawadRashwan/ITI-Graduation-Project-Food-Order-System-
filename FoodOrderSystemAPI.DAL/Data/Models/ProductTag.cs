using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderSystemAPI.DAL
{
    public class ProductTag
    {
        [ForeignKey("product")]
        public int ProductId { get; set; }
        public ProductModel product { get; set; }

        public string tag { get; set; } = string.Empty;

    }
}
