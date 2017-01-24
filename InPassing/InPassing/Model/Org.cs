using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InPassing.Model
{
  public class Org
  {
    public int Id { get; private set; }
    public string Name { get; private set; }
    public Org(int id, string name)
    {
      Id = id;
      Name = name;
    }
    public static Org FromDynamic(dynamic obj)
    {
      return new Org(obj.id, obj.name);
    }
  }
}
