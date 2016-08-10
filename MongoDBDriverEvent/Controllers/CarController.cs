using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBDriverEvent.App_Start;
using MongoDBDriverEvent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MongoDBDriverEvent.Controllers
{
    public class CarController : Controller
    {
        public static CarContext Context = new CarContext();

        public async Task<ActionResult> Index()
        {
            var cars = await Context.Cars.Find<Car>(new BsonDocument()).ToListAsync();
            var model = new CarList
            {
                Cars = cars
            };
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> PostCar(Car car)
        {
            await Context.Cars.InsertOneAsync(car);
            return RedirectToAction("Index");
        }

        public ActionResult PostCar()
        {
            return View();
        }
    }
}