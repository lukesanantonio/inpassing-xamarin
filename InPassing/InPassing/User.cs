using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InPassing
{
  public class User
  {
    public int Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }

    public User(int id, string firstName, string lastName, string email)
    {
      Id = id;
      FirstName = firstName;
      LastName = lastName;
      Email = email;
    }
  }
}
