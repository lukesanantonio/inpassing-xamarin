using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using InPassing.Droid;

[assembly: Xamarin.Forms.Dependency (typeof (AndroidAPITokenStorage))]
namespace InPassing.Droid
{
  class AndroidAPITokenStorage : IAPITokenStorage
  {
    private static string ACCESS_TOKEN_KEY = "accessToken";
    private static string REFRESH_TOKEN_KEY = "refreshToken";

    private ISharedPreferences Prefs { get; set; }

    public AndroidAPITokenStorage()
    {
      Prefs = Xamarin.Forms.Forms.Context.GetSharedPreferences("InPassing", FileCreationMode.Private);
    }

    public void setAccessToken(string token)
    {
      var editor = Prefs.Edit();
      editor.PutString(ACCESS_TOKEN_KEY, token);
      editor.Apply();
    }
    public void setRefreshToken(string token)
    {
      var editor = Prefs.Edit();
      editor.PutString(REFRESH_TOKEN_KEY, token);
      editor.Apply();
    }
    public string getAccessToken()
    {
      if (!Prefs.Contains(ACCESS_TOKEN_KEY))
      {
        return null;
      }
      return Prefs.GetString(ACCESS_TOKEN_KEY, "");
    }
    public string getRefreshToken()
    {
      if (!Prefs.Contains(REFRESH_TOKEN_KEY))
      {
        return null;
      }
      return Prefs.GetString(REFRESH_TOKEN_KEY, "");
    }
  }
}