using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiWithJQuery.Models
{
  public class Make
  {
    public Guid MakeId { get; set; }
    public string Name { get; set; }

    public IEnumerable<Model> Models { get; set; }
  }
}