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
  public class ModelAPIController : ApiController
  {
    private VehicleContext db = new VehicleContext();

    // GET api/Model
    public IQueryable<Model> GetModels()
    {
      var models = db.Models.Include(m => m.Make);
      return models.AsQueryable();
    }

    //[HttpGet]
    // GET api/Model
    public IQueryable<Model> GetModels(Guid id)
    {
      var models = db.Models.Where(c => c.MakeId == id).AsQueryable();

      return models;
    }

    //// GET api/Model/5
    //public Model GetModel(Guid id)
    //{
    //  Model model = db.Models.Find(id);
    //  if (model == null)
    //  {
    //    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
    //  }

    //  return model;
    //}

    // PUT api/Model/5
    public HttpResponseMessage PutModel(Guid id, Model model)
    {
      if (!ModelState.IsValid)
      {
        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
      }

      if (id != model.ModelId)
      {
        return Request.CreateResponse(HttpStatusCode.BadRequest);
      }

      db.Entry(model).State = EntityState.Modified;

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

    // POST api/Model
    public HttpResponseMessage PostModel(Model model)
    {
      if (ModelState.IsValid)
      {
        db.Models.Add(model);
        db.SaveChanges();

        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, model);
        response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = model.ModelId }));
        return response;
      }
      else
      {
        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
      }
    }

    // DELETE api/Model/5
    public HttpResponseMessage DeleteModel(Guid id)
    {
      Model model = db.Models.Find(id);
      if (model == null)
      {
        return Request.CreateResponse(HttpStatusCode.NotFound);
      }

      db.Models.Remove(model);

      try
      {
        db.SaveChanges();
      }
      catch (DbUpdateConcurrencyException ex)
      {
        return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
      }

      return Request.CreateResponse(HttpStatusCode.OK, model);
    }

    protected override void Dispose(bool disposing)
    {
      db.Dispose();
      base.Dispose(disposing);
    }
  }
}