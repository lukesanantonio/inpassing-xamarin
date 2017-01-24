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

    async void OnLogin()
    {
      Backend backend = ((App)Application.Current).AppBackend;

      await backend.AuthenticateAsync(loginEmail.Text, loginPassword.Text);

      if (backend.CurError != null)
      {
        errorNotify.Text = backend.CurError?.ToFriendlyString();
        return;
      }

      // Otherwise we are good to go!
      Application.Current.MainPage = ((App)Application.Current).AppPage;
    }
    public void OnSignupPressed()
    {
      Application.Current.MainPage = new Signup();
    }
  }
}
