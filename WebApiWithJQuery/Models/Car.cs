using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiWithJQuery.Models
{
  public class Car
  {
    public Guid CarId { get; set; }
    public string Name { get; set; }

    public Model Model { get; set; }
    public Guid ModelId { get; set; }

    //public Make Make { get; set; }
    //public Guid MakeId { get; set; }
  }
}