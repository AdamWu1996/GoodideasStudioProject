using Microsoft.AspNetCore.Mvc;

namespace MyWaiterAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        // POST: api/order
        [HttpPost]
        public IActionResult PlaceOrder([FromBody] OrderRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.DishName))
            {
                return BadRequest(new { Message = "Dish name is required!" });
            }

            var response = new OrderResponse
            {
                Message = $"Your order for '{request.DishName}' has been placed successfully!",
                EstimatedTime = "15 minutes"
            };

            return Ok(response);
        }
    }

    // 請求物件
    public class OrderRequest
    {
        public string DishName { get; set; }
    }

    // 回應物件
    public class OrderResponse
    {
        public string Message { get; set; }
        public string EstimatedTime { get; set; }
    }
}