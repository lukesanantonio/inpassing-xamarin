using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace InPassing
{
  public partial class Signup : ContentPage
  {
    public Signup()
    {
      InitializeComponent();
    }

    void OnSignup()
    {
      Application.Current.MainPage = ((App) Application.Current).appPage;
    }
    void OnLoginPressed()
    {
      Application.Current.MainPage = new Login();
    }
  }
}
