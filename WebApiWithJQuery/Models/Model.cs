using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiWithJQuery.Models
{
  public class Model
  {
    public Guid ModelId { get; set; }
    public string Name { get; set; }

    public Make Make { get; set; }
    public Guid MakeId { get; set; }

    public IEnumerable<Car> Cars { get; set; }
  }
}