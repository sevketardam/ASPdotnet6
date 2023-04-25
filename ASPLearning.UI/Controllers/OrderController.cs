using ASPLearning.UI.IServices;
using ASPLearning.UI.Models.IM;
using Microsoft.AspNetCore.Mvc;

namespace ASPLearning.UI.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        public IActionResult SubmitOrder()
        {
            return View();
        }

        [HttpPost("submit-order",Name ="SubmitOrder")]
        public IActionResult SubmitOrder(SubmitOrderIM submit)
        {
            this.orderService.SubmitOrder(submit);

            return Json(new {data=submit});
        }
    }
}
