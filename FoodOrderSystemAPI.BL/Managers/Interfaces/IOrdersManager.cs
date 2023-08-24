using FoodOrderSystemAPI.BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderSystemAPI.BL
{

    public interface IOrdersManager
    {
        List<OrderReadDto> GetAll();

        OrderReadDetailDto? GetById(int id);

        int Add(OrderAddDto orderDto);

        void update(OrderUpdateDto orderDto);

        void Delete(int id);

    }
}
