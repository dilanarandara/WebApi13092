using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebApiWithJQuery.Models;

namespace WebApiWithJQuery.Controllers
{
  public class CarAPIController : ApiController
  {
    private VehicleContext db = new VehicleContext();

    // GET api/Car/5
    public IQueryable<Car> GetCar(Guid modelId)
    {
      var models = db.Cars.Where(c => c.ModelId == modelId).AsQueryable();

      return models;
    }

    //// GET api/Car/5
    //public Car GetCar(Guid id)
    //{
    //  Car car = db.Cars.Find(id);
    //  if (car == null)
    //  {
    //    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
    //  }

    //  return car;
    //}

    protected override void Dispose(bool disposing)
    {
      db.Dispose();
      base.Dispose(disposing);
    }
  }
}