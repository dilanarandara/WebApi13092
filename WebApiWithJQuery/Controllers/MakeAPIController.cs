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

    protected override void Dispose(bool disposing)
    {
      db.Dispose();
      base.Dispose(disposing);
    }
  }
}