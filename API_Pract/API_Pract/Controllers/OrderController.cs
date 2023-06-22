using API_Pract.Orders;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace API_Pract.Controllers
{
    [ApiController]
    [Route("/api_pract/orders/order")]
    public class OrderController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            MainDbContext db = new MainDbContext();
            List<Order> orders = db.orders.ToList();
            string jsonOrders = JsonSerializer.Serialize(orders);
            return Ok(jsonOrders);
        }
        [HttpPost]
        public ActionResult Add(Order order)
        {
            MainDbContext db = new MainDbContext();
            db.orders.Add(order);
            db.SaveChanges();
            db.orders.FirstOrDefault(o => o.client == order.client);
            string jsonOrder = JsonSerializer.Serialize(order);
            return Ok(jsonOrder);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            MainDbContext db = new MainDbContext();
            Order order = db.orders.Where(o => o.id == id).Single();
            db.Remove(order);
            db.SaveChanges();
            string jsonOrder = "Process of delete is successfully ended!";
            return Ok(jsonOrder);
        }
    }
}