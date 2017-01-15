using System;
using System.Collections.Generic;
using System.Text;

using InPassing.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(KeychainTokenStorage))]
namespace InPassing.iOS
{
    class KeychainTokenStorage
    {
        public string accessToken;
        public string refreshToken;

        public KeychainTokenStorage() { }

        public void setAccessToken(string token)
        {
            accessToken = token;
        }
        public void setRefreshToken(string token)
        {
            refreshToken = token;
        }
        public string getAccessToken()
        {
            return accessToken;
        }
        public string getRefreshToken()
        {
            return refreshToken;
        }
    }
}
