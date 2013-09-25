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

    // GET api/Car
    public IQueryable<Car> GetCars()
    {
      var cars = db.Cars.Include(c => c.Model);
      return cars.AsQueryable();
    }

    // GET api/Car/5
    public Car GetCar(Guid id)
    {
      Car car = db.Cars.Find(id);
      if (car == null)
      {
        throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
      }

      return car;
    }

    // PUT api/Car/5
    public HttpResponseMessage PutCar(Guid id, Car car)
    {
      if (!ModelState.IsValid)
      {
        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
      }

      if (id != car.CarId)
      {
        return Request.CreateResponse(HttpStatusCode.BadRequest);
      }

      db.Entry(car).State = EntityState.Modified;

      try
      {
        db.SaveChanges();
      }
      catch (DbUpdateConcurrencyException ex)
      {
        return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
      }

      return Request.CreateResponse(HttpStatusCode.OK);
    }

    // POST api/Car
    public HttpResponseMessage PostCar(Car car)
    {
      if (ModelState.IsValid)
      {
        db.Cars.Add(car);
        db.SaveChanges();

        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, car);
        response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = car.CarId }));
        return response;
      }
      else
      {
        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
      }
    }

    // DELETE api/Car/5
    public HttpResponseMessage DeleteCar(Guid id)
    {
      Car car = db.Cars.Find(id);
      if (car == null)
      {
        return Request.CreateResponse(HttpStatusCode.NotFound);
      }

      db.Cars.Remove(car);

      try
      {
        db.SaveChanges();
      }
      catch (DbUpdateConcurrencyException ex)
      {
        return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
      }

      return Request.CreateResponse(HttpStatusCode.OK, car);
    }

    protected override void Dispose(bool disposing)
    {
      db.Dispose();
      base.Dispose(disposing);
    }
  }
}