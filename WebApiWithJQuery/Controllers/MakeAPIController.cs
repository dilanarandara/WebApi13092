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
  public class MakeAPIController : ApiController
  {
    private VehicleContext db = new VehicleContext();

    // GET api/Make
    public IQueryable<Make> GetMakes()
    {
      return db.Makes.AsQueryable();
    }

    // GET api/Make/5
    public Make GetMake(Guid id)
    {
      Make make = db.Makes.Find(id);
      if (make == null)
      {
        throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
      }

      return make;
    }

    // PUT api/Make/5
    public HttpResponseMessage PutMake(Guid id, Make make)
    {
      if (!ModelState.IsValid)
      {
        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
      }

      if (id != make.MakeId)
      {
        return Request.CreateResponse(HttpStatusCode.BadRequest);
      }

      db.Entry(make).State = EntityState.Modified;

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

    // POST api/Make
    public HttpResponseMessage PostMake(Make make)
    {
      if (ModelState.IsValid)
      {
        db.Makes.Add(make);
        db.SaveChanges();

        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, make);
        response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = make.MakeId }));
        return response;
      }
      else
      {
        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
      }
    }

    // DELETE api/Make/5
    public HttpResponseMessage DeleteMake(Guid id)
    {
      Make make = db.Makes.Find(id);
      if (make == null)
      {
        return Request.CreateResponse(HttpStatusCode.NotFound);
      }

      db.Makes.Remove(make);

      try
      {
        db.SaveChanges();
      }
      catch (DbUpdateConcurrencyException ex)
      {
        return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
      }

      return Request.CreateResponse(HttpStatusCode.OK, make);
    }

    protected override void Dispose(bool disposing)
    {
      db.Dispose();
      base.Dispose(disposing);
    }
  }
}