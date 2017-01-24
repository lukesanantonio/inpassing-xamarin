using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace InPassing
{
  public partial class App : Application
  {
    public Page AppPage { get; set; }
    public Backend AppBackend { get; set; }
    public App()
    {
      InitializeComponent();
      AppPage = new NavigationPage(new ContentPage());

      // Load the backend, auth token, etc.
      //AppBackend = new Backend(DependencyService.Get<IAPITokenStorage>());
      AppBackend = new TestBackend();

      // Show the sign up page if necessary.
      if (!AppBackend.Authenticated())
      {
        MainPage = new Signup();
      }
      else
      {
        MainPage = AppPage;
      }

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