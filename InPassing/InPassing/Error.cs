using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InPassing
{
  // <summary>
  // Possible errors from the backend.
  // </summary>
  public enum ErrorType
  {
    ConnectionFailed,
    UserExists,
    AuthFailed,
    UnknownError,
  }

  public static class ErrorTypeAPIParser
  {
    // <summary>
    // Converts string 'err' field from API json to an ErrorType value.
    // </summary>
    public static ErrorType ParseStringErr(string err)
    {
      if (err == "user_exists")
      {
        return ErrorType.UserExists;
      }
      else
      {
        return ErrorType.UnknownError;
      }
    }
  };

  public static class ErrorTypeExtensions
  {
    // <summary>
    // Returns a user-friendly string explaining the given ErrorType.
    // </summary>
    public static string ToFriendlyString(this ErrorType err)
    {
      switch (err)
      {
        case ErrorType.ConnectionFailed:
          return "Connection Failed";
        case ErrorType.UserExists:
          return "A user with this email already exists";
        case ErrorType.AuthFailed:
          return "Invalid username or password";
        default:
          return "Unknown error occurred";
      }
    }
  }
}