using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace InPassing
{
  public partial class App : Application
  {
    public Page appPage { get; set; }
    public App()
    {
      InitializeComponent();
      appPage = new NavigationPage(new ContentPage());
      MainPage = new Signup();
    }

    protected override void OnStart()
    {
      // Handle when your app starts
    }

    protected override void OnSleep()
    {
      // Handle when your app sleeps
    }

    protected override void OnResume()
    {
      // Handle when your app resumes
    }
  }
}