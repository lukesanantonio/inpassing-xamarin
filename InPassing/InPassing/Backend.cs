using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Flurl;
using Flurl.Http;
using System.Runtime.Serialization;

namespace InPassing
{
  // <summary>
  // Wraps functionality of the parking app backend.
  // </summary>
  public class Backend
  {
    public const string BackendUrl = "http://159.203.130.135";

    // <summary>
    // The current auth token used for making API requests.
    // </summary>
    private string AuthToken = null;

    // <summary>
    // Information about the current user.
    // </summary>
    public User CurUser = null;

    // <summary>
    // The most recent error that has occurred.
    // </summary>
    public ErrorType? CurError = null;

    public Backend() { }

    public void ProcessHttpException(FlurlHttpException ex)
    {
      if (ex.Call.Response != null)
      {
        // What was the error?
        dynamic res = ex.GetResponseJson();
        string err = (string)res.err;
        CurError = ErrorTypeAPIParser.ParseStringErr(err);
      }
      else
      {
        // I don't know if a missing response always means a connection failed but what the hell
        CurError = ErrorType.ConnectionFailed;
      }
    }

    async public Task AuthenticateAsync(string email, string password)
    {
      // Already authenticated?
      if (Authenticated()) return;

      try
      {
        var authData = await BackendUrl
          .AppendPathSegment("users/auth")
          .PostJsonAsync(new { email = email, password = password })
          .ReceiveJson<IDictionary<string, string>>();

        // Make sure we got a token back
        if (!authData.ContainsKey("access_token"))
        {
          CurError = ErrorType.AuthFailed;
          return;
        }

        // Copy the auth token
        AuthToken = (string)authData["access_token"];
      }
      catch (FlurlHttpException ex)
      {
        ProcessHttpException(ex);
      }

      // Query our user with the shiny new auth token.
      await RefreshMe();
    }

    // <summary>
    // Update CurUser using the /me API endpoint.
    // </summary>
    async public Task RefreshMe()
    {
      try
      {
        // GET /me
        var userData = await BackendUrl
          .AppendPathSegment("users/me")
          .WithOAuthBearerToken(AuthToken)
          .GetJsonAsync<IDictionary<string, object>>();

        // Convert relevant fields, later on we may want passes, associated orgs, etc.
        CurUser = new User(
          Convert.ToInt32(userData["id"]), (string)userData["first_name"], (string)userData["last_name"], (string)userData["email"]
        );
      }
      catch (FlurlHttpException ex)
      {
        // Handle errors
        ProcessHttpException(ex);
      }
    }

    // <summary>
    // Signs up the user and authenticates as them.
    // </summary>
    async public Task SignupAsync(string first_name, string last_name, string email, string password)
    {
      try
      {
        // POST /users
        var signupResponse = await BackendUrl
        .AppendPathSegment("users")
        .PostJsonAsync(new
        {
          first_name = first_name,
          last_name = last_name,
          email = email,
          password = password
        }).ReceiveJson<IDictionary<string, object>>();

        // Now authenticate!
        await AuthenticateAsync(email, password);
      }
      catch (FlurlHttpException ex)
      {
        ProcessHttpException(ex);
      }
    }

    public bool Authenticated()
    {
      // Are we authenticated?
      return AuthToken != null;
    }
  }
}
