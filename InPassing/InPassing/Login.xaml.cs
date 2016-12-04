using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace InPassing
{
  public partial class Login : ContentPage
  {
    public Login()
    {
      InitializeComponent();
    }
    public void OnLogin()
    {
      Application.Current.MainPage = ((App)Application.Current).appPage;
    }
  }
}
