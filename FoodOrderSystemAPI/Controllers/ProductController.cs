using FoodOrderSystemAPI.BL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrderSystemAPI.Controllers
{
    [ApiController]
    [Route("api/Products")]
    public class ProductController : Controller
    {
        private readonly IProductManager _productManager;

        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        [HttpGet]
        //[Authorize]

        public ActionResult<List<ProductCardDto>> GetAll([FromQuery] List<string> FilterRestaurants, [FromQuery] string? word, [FromQuery] List<string> FilterTags, [FromQuery] List<float> FilterPrices)
        {
            return _productManager.GetAll(FilterRestaurants, word, FilterTags, FilterPrices);
        }

        [HttpGet]
        [Route("Tags")]
        public ActionResult<List<string>> GetProductTags() 
        { 
            return _productManager.GetProductTags();
        }


        [HttpGet]
        [Route("PriceBounds")]
        public ActionResult<List<float>> GetProductPricesBounds()
        {
            return _productManager.GetProductPricesBounds();
        }

        //[HttpGet]
        //[Route("FilterTags")]
        
        //public ActionResult<List<ProductCardDto>> GetAllFilterTag([FromQuery] List<string> FilterTags)
        //{
        //    return _productManager.GetAllFilterTag(FilterTags);
        //}

        //[HttpGet]
        //[Route("searchProduct")]
        //public ActionResult<List<ProductCardDto>> searchProductByName([FromQuery] string query)
        //{
        //    return _productManager.searchProductByName(query);
        //}

        //[HttpGet]
        //[Route("FilterRestaurants")]

        //public ActionResult<List<ProductCardDto>> GetAllFilterRestaurant([FromQuery] List<string> FilterRestaurants)
        //{
        //    return _productManager.GetAllFilterRestaurant(FilterRestaurants);
        //}

        //[HttpGet]
        //[Route("FilterPrices")]
        //public ActionResult<List<ProductCardDto>> GetAllFilterPrice([FromQuery] List<float> FilterPrices)
        //{
        //    return _productManager.GetAllFilterPrice(FilterPrices);
        //}

        [HttpGet]
        [Route("{id}")]
        //[Authorize]
        public ActionResult<ProductCardDto> GetById(int id)
        {
            ProductCardDto? product = _productManager.GetById(id);
            if (product is null)
            {
                return NotFound();
            }
            return product;
        }

        [HttpPost]
        public ActionResult<int> Add(ProductAddDto product)
        {
            var addresult =  _productManager.Add(product);
            if (addresult == 0)
                return BadRequest(0);
            return Ok(addresult);
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            ProductCardDto? product = _productManager.GetById(id);
            if (product is null)
            {
                return NotFound();
            }
            _productManager.delete(id);
            return NoContent();
        }

        [HttpPut]
        public ActionResult Update(ProductCardDto product)
        {
            _productManager.update(product);
            return NoContent();
        }


    }
}
