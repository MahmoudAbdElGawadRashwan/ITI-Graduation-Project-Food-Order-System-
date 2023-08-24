using FoodOrderSystemAPI.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Pipelines;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderSystemAPI.BL
{
    public class ProductManager : IProductManager
    {
        private IUnitOfWork _unitOfWork;
        public ProductManager(IUnitOfWork unitOfWork) {
            _unitOfWork=unitOfWork;
        }

        public int Add(ProductAddDto productDto)           //not working (move to DAL? | )
        {
            var product = new ProductModel()
            {
                describtion = productDto.describtion,
                img = productDto.img,
                offer = productDto.offer,
                price = productDto.price,
                Productname = productDto.Productname,
                rate = productDto.rate,
                RestaurantID = productDto.restaurantID
            };
            _unitOfWork.Products.Add(product);
           _unitOfWork.Save();
            foreach (var tag in productDto.tags)
            {
                _unitOfWork.ProductTags.Add(new ProductTag { ProductId= product.ProductId,tag= tag});
            }

            
            _unitOfWork.Save();
            return product.ProductId;
        }

        public void delete(int id)
        {
            ProductModel? productToDelete = _unitOfWork.Products.GetById(id);
            if (productToDelete is null)
                return;

            IEnumerable<ProductTag>? tagsToDelete = _unitOfWork.ProductTags.GetAll().Where(t=>t.ProductId==id);
            _unitOfWork.Products.Delete(productToDelete);
            foreach(var tag in tagsToDelete)
            {
                _unitOfWork.ProductTags.Delete(tag);
            }
            _unitOfWork.Save();
        }

        //public List<ProductCardDto> GetAll()
        //{
        //    var products = _unitOfWork.Products.GetAll().Select(p => new ProductCardDto() 
        //    {
        //        ProductID = p.ProductId,
        //        describtion= p.describtion,
        //        img= p.img,
        //        offer = p.offer,
        //        price = p.price,
        //        Productname = p.Productname,
        //        rate = p.rate,
        //        restaurantID = p.RestaurantID,
        //        restaurantName = p.restaurant.RestaurantName,
        //    }).ToList();

        //    foreach (var product in products)
        //    {
        //        product.tags = _unitOfWork.ProductTags.GetAll().Where(t => t.ProductId == product.ProductID).Select(t => t.tag).ToList();
        //    }
        //    return products;

        //}
        public List<ProductCardDto> GetAll(List<string> FilterRestaurants, string word, List<string> FilterTags , List<float> FilterPrices)
        {
            //if(word is null || FilterRestaurants.Count==0 || FilterTags.Count == 0 || FilterPrices.Count == 0 )
            //    return new List<ProductCardDto>() { };

            var products = _unitOfWork.Products.GetAll().Select(p => new ProductCardDto()
            {
                ProductID = p.ProductId,
                describtion = p.describtion,
                img = p.img,
                offer = p.offer,
                price = p.price,
                Productname = p.Productname,
                rate = p.rate,
                restaurantID = p.RestaurantID,
                restaurantName = p.restaurant.RestaurantName,
            }).ToList();

            foreach (var product in products)
            {
                product.tags = _unitOfWork.ProductTags.GetAll().Where(t => t.ProductId == product.ProductID).Select(t => t.tag).ToList();
            }


            if (word is not null)
                products=products.Where(p => p.Productname.ToLower().Contains(word.ToLower())).ToList();

            if (FilterTags.Count != 0)
                products = products.Where(p => p.tags.Any(item => FilterTags.Contains(item))).ToList();

            if (FilterRestaurants.Count != 0)
                products = products.Where(p => FilterRestaurants.Contains(p.restaurantName)).ToList();

            if (FilterPrices.Count != 0)
                products = products.Where(p => p.price * (p.offer==0?1:p.offer) >= FilterPrices.Min() && p.price * (p.offer == 0 ? 1 : p.offer) <= FilterPrices.Max()).ToList();

            return products;

        }
        public List<ProductCardDto> searchProductByName(string word)
        {
            var products = _unitOfWork.Products.GetAll().Select(p => new ProductCardDto()
            {
                ProductID = p.ProductId,
                describtion = p.describtion,
                img = p.img,
                offer = p.offer,
                price = p.price,
                Productname = p.Productname,
                rate = p.rate,
                restaurantID = p.RestaurantID,
                restaurantName = p.restaurant.RestaurantName,
            }).ToList();

            foreach (var product in products)
            {
                product.tags = _unitOfWork.ProductTags.GetAll().Where(t => t.ProductId == product.ProductID).Select(t => t.tag).ToList();
            }
            return products.Where(p => p.Productname.ToLower().Contains(word.ToLower())).ToList();

        }

        public List<ProductCardDto> GetAllFilterTag(List<string> FilterTags)
        {
            var products = _unitOfWork.Products.GetAll().Select(p => new ProductCardDto()
            {
                ProductID = p.ProductId,
                describtion = p.describtion,
                img = p.img,
                offer = p.offer,
                price = p.price,
                Productname = p.Productname,
                rate = p.rate,
                restaurantID = p.RestaurantID,
                restaurantName = p.restaurant.RestaurantName,
            }).ToList();

            foreach (var product in products)
            {
                product.tags = _unitOfWork.ProductTags.GetAll().Where(t => t.ProductId == product.ProductID).Select(t => t.tag).ToList();
            }
            return products.Where(p=> p.tags.Any(item => FilterTags.Contains(item))).ToList();

        }

        public List<ProductCardDto> GetAllFilterRestaurant(List<string> FilterRestaurants)
        {
            var products = _unitOfWork.Products.GetAll().Select(p => new ProductCardDto()
            {
                ProductID = p.ProductId,
                describtion = p.describtion,
                img = p.img,
                offer = p.offer,
                price = p.price,
                Productname = p.Productname,
                rate = p.rate,
                restaurantID = p.RestaurantID,
                restaurantName = p.restaurant.RestaurantName,
            }).ToList();

            foreach (var product in products)
            {
                product.tags = _unitOfWork.ProductTags.GetAll().Where(t => t.ProductId == product.ProductID).Select(t => t.tag).ToList();
            }
            return products.Where(p => FilterRestaurants.Contains(p.restaurantName)).ToList();

        }

        public List<ProductCardDto> GetAllFilterPrice(List<float> FilterPrices)
        {
            var products = _unitOfWork.Products.GetAll().Select(p => new ProductCardDto()
            {
                ProductID = p.ProductId,
                describtion = p.describtion,
                img = p.img,
                offer = p.offer,
                price = p.price,
                Productname = p.Productname,
                rate = p.rate,
                restaurantID = p.RestaurantID,
                restaurantName = p.restaurant.RestaurantName,
            }).ToList();

            foreach (var product in products)
            {
                product.tags = _unitOfWork.ProductTags.GetAll().Where(t => t.ProductId == product.ProductID).Select(t => t.tag).ToList();
            }
            return products.Where(p => p.price*p.offer >= FilterPrices.Min() && p.price*p.offer <= FilterPrices.Max()).ToList();

        }

        public ProductCardDto? GetById(int id)
        {
            ProductModel? ProductToRead = _unitOfWork.Products.GetById(id);
            if (ProductToRead is null)
                return null;
            return new ProductCardDto()
            {
                ProductID = ProductToRead.ProductId,
                describtion = ProductToRead.describtion,
                img = ProductToRead.img,
                offer = ProductToRead.offer,
                price = ProductToRead.price,
                Productname = ProductToRead.Productname,
                rate = ProductToRead.rate,
                tags = _unitOfWork.ProductTags.GetAll().Where(t => t.ProductId == ProductToRead.ProductId).Select(t => t.tag).ToList(),
                restaurantID = ProductToRead.restaurant.Id,
                restaurantName = ProductToRead.restaurant.RestaurantName,
            };
        }

        public void update(ProductCardDto productDto)           // doesn't update tag list
        {
            ProductModel? ProductfromDb = _unitOfWork.Products.GetById(productDto.ProductID);
            if (ProductfromDb is null)
                return;

            ProductfromDb.describtion = productDto.describtion;
            ProductfromDb.img = productDto.img;
            ProductfromDb.offer = productDto.offer;
            ProductfromDb.price = productDto.price;
            ProductfromDb.Productname = productDto.Productname;
            ProductfromDb.rate = productDto.rate;

            _unitOfWork.Products.Update(ProductfromDb);
            _unitOfWork.Save();
        }

         
        public List<string> GetProductTags()
        {
            return _unitOfWork.Products.GetProductTags().ToList();
        }

        public List<float> GetProductPricesBounds()
        {
            var prices =_unitOfWork.Products.GetAll().Select(p=>p.price*p.offer);
            List<float> bounds = new List<float>
            {
               (float)Math.Floor(prices.Min()),
               (float)Math.Ceiling(prices.Max())
            };
            //bounds.Sort();

            return bounds;
        }



    }
}
