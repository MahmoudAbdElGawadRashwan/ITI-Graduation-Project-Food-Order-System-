using AutoMapper;
using FoodOrderSystemAPI.BL.DTOs.Restaurants;
using FoodOrderSystemAPI.DAL;

namespace FoodOrderSystemAPI.BL;

public class AutoMapperProfile: Profile
{
    AutoMapperProfile()
    {
        #region ReviewModel mappings
        // inputs
        CreateMap<AddReviewInputDto, ReviewModel>();
        CreateMap<UpdateReviewInputDto, ReviewModel>();
        // outputs
        CreateMap<ReviewModel, AddReviewOutputDto>();
        CreateMap<ReviewModel, GetAllReveiwsOutputDto>();
        CreateMap<ReviewModel, GetReviewOutputDto>();

        #endregion

        #region RestaurantModel mappings
        // inputs
        CreateMap<RestaurantAddDto, RestaurantModel>()
            .ReverseMap();
        CreateMap<RestaurantUpdateDto, RestaurantModel>();
        // outputs
        CreateMap<RestaurantModel, RestaurantsReadDto>();
        CreateMap<RestaurantModel, RestaurantsProductsReadDto>();
        CreateMap<ProductModel, ProductCardDto>().ReverseMap();
        CreateMap<RestaurantModel, RestaurantProductsDto>();
        CreateMap<RestaurantModel, RestaurantPaymentMethodDto>();
        // I/O
        CreateMap<RestaurantModel, RestaurantDetailsDto>()
            .ReverseMap();
        #endregion
    }
}
