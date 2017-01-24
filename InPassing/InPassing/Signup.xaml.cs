using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Flurl;
using Flurl.Http;

namespace InPassing
{
  public partial class Signup : ContentPage
  {
    public Signup()
    {
      InitializeComponent();
    }

    async void OnSignup()
    {
      Backend backend = ((App)Application.Current).AppBackend;

      // Sign up and get an auth token
      await backend.SignupAsync(
        firstName.Text, lastName.Text, signupEmail.Text, signupPassword.Text
      );

      if (backend.CurError != null)
      {
        // Something went wrong
        errorNotify.Text = backend.CurError?.ToFriendlyString();
        return;
      }

      // Otherwise we are good
      Application.Current.MainPage = ((App)Application.Current).AppPage;
    }
    void OnLoginPressed()
    {
      Application.Current.MainPage = new Login();
    }
  }
}
