using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InPassing.Model
{
  public class User
  {
    public int Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public List<Org> Participates { get; private set; }
    public List<Org> Moderates { get; private set; }

    public User(int id, string firstName, string lastName, string email, List<Org> participates, List<Org> mods)
    {
      Id = id;
      FirstName = firstName;
      LastName = lastName;
      Email = email;
      Participates = participates;
      Moderates = mods;
    }

    public static User FromDynamic(dynamic obj)
    {
      List<Org> participates = new List<Org>();
      foreach (dynamic org_obj in obj.participates)
      {
        participates.Add(Org.FromDynamic(org_obj));
      }
      List<Org> mods = new List<Org>();
      foreach (dynamic org_obj in obj.moderates)
      {
        mods.Add(Org.FromDynamic(org_obj));
      }
      return new User(Convert.ToInt32(obj.id), obj.first_name, obj.last_name, obj.email, participates, mods);
    }
  }
}
