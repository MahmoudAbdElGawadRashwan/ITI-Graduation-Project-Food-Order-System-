using FoodOrderSystemAPI.BL;
using FoodOrderSystemAPI.BL.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrderSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersManager _OrderManager;

        public OrdersController(IOrdersManager orderManager)
        {
            _OrderManager = orderManager;
        }

        [HttpGet]

        public ActionResult<List<OrderReadDto>> GetAll()
        {
            return _OrderManager.GetAll(); //Ok 200 //  
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<OrderReadDetailDto> GetById(int id)
        {
            OrderReadDetailDto? readDto = _OrderManager.GetById(id);
            if (readDto is null)
                return NotFound();

            return readDto; //Status 200 Ok
        }

        [HttpPost]
        public ActionResult Add(OrderAddDto OrderAddDto)
        {
            int newOrderId;
            try
            {
                newOrderId = _OrderManager.Add(OrderAddDto);
            }
            catch (Exception e)
            {
                return NotFound(new GeneralResponseDto { Message = $"{e.Message}" });
            }
            return CreatedAtAction(
                nameof(GetById),
                new { Id = newOrderId },
                new GeneralResponseDto { Message = "Order Created Successfully" });
        }



        [HttpPut]
        public ActionResult Update(OrderUpdateDto OrderDto)
        {
            var targetedOrder = _OrderManager.GetById(OrderDto.OrderId);
            if (targetedOrder == null)
                return NotFound();

            _OrderManager.update(OrderDto);
            return NoContent();  //204 Success with not content
        }



        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            var targetedOrder = _OrderManager.GetById(id);
            if (targetedOrder is null)
                return NotFound();

            _OrderManager.Delete(id);
            return NoContent();
        }


    }
}
