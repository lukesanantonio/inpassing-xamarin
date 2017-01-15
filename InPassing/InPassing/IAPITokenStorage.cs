using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InPassing
{
  public interface IAPITokenStorage
  {
    void setAccessToken(string token);
    void setRefreshToken(string token);
    string getAccessToken();
    string getRefreshToken();
  }
}
