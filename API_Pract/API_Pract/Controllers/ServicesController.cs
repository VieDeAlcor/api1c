using API_Pract.Orders;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace API_Pract.Controllers
{
    [ApiController]
    [Route("/api_pract/orders/services")]
    public class ServicesController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            MainDbContext db = new MainDbContext();
            List<Services> services = db.services.ToList();
            string jsonOrders = JsonSerializer.Serialize(services);
            return Ok(jsonOrders);
        }
        [HttpPost]
        public ActionResult Add(Services services) 
        {
            MainDbContext db = new MainDbContext();
            db.services.Add(services);
            db.SaveChanges();
            db.services.FirstOrDefault(s => s.name == services.name);
            string jsonServices = JsonSerializer.Serialize(services);
            return Ok(jsonServices);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            MainDbContext db = new MainDbContext();
            Services services = db.services.Where(s => s.id == id).Single();
            db.Remove(services);
            db.SaveChanges();
            string jsonServices = "Process of delete is successfully ended!";
            return Ok(jsonServices);
        }
    }
}
