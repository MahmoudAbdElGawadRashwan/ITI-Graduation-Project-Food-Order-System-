using FoodOrderSystemAPI.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderSystemAPI;

public  class OrderResturntReadDto
{
    public int OrderId { get; set; }
    public string CustomerName { get; set; }
    public string CustomerPhone { get; set; }
    public string CustomerAddress { get; set; }
    public DateTime OrderDate { get; set; }
    public float TotalPrice { get; set; }
    public List <ProductOrder > OrderProducts { get; set; }


}
