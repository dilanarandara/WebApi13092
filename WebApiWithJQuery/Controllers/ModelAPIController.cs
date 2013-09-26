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

    // GET api/Model/id
    public IQueryable<Model> GetModels(Guid makeId)
    {
      var models = db.Models.Where(c => c.MakeId == makeId).AsQueryable();

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

    protected override void Dispose(bool disposing)
    {
      db.Dispose();
      base.Dispose(disposing);
    }
  }
}