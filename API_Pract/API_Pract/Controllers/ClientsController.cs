using API_Pract.Orders;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace API_Pract.Controllers
{
    [ApiController]
    [Route("/api_pract/orders/clients")]
    public class ClientsController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            MainDbContext db = new MainDbContext();
            List<Clients> clients = db.clients.ToList();
            string jsonClients = JsonSerializer.Serialize(clients);
            return Ok(jsonClients);
        }
        [HttpPost]
        public ActionResult Add(Clients clients)
        {
            MainDbContext db = new MainDbContext();
            db.clients.Add(clients);
            db.SaveChanges();
            db.clients.FirstOrDefault(s => s.name == clients.name);
            string jsonClients = JsonSerializer.Serialize(clients);
            return Ok(jsonClients);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            MainDbContext db = new MainDbContext();
            Clients clients = db.clients.Where(s => s.id == id).Single();
            db.Remove(clients);
            db.SaveChanges();
            string jsonClients = "Process of delete is successfully ended!";
            return Ok(jsonClients);
        }
    }
}
