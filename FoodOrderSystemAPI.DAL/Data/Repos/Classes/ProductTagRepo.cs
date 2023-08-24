using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderSystemAPI.DAL
{
    public class ProductTagRepo : EntityRepo<ProductTag>, IProductTagRepo
    {
        public ProductTagRepo(SystemContext dbContext) : base(dbContext)
        {
        }
    }
}
