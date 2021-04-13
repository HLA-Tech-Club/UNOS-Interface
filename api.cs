using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Newtonsoft.Json;
using RestSharp;

namespace UNOSInterface
{
    class API
    {
        public static string RequestAuthToken(string userName, string passWord, string grantType, string refreshToken = "")
        {
            string baseURL = "";
            var request = new RestRequest(Method.POST);
            if (grantType == "password")
            {
                baseURL = "https://api-beta.unos.org/oauth/accesstoken?grant_type=password";
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                request.AddParameter("username", userName);
                request.AddParameter("password", passWord);
            }
            else if (grantType == "refresh")
            {
                baseURL =
                    "https://api-beta.unos.org/oauth/accesstoken?grant_type=refresh_token&refresh_token=" + refreshToken;
            }
            else if (grantType == "cc")
            {
                baseURL = "https://api-beta.unos.org/oauth/accesstoken?grant_type=client_credentials";
            }

            request.AddHeader("Authorization", "Basic SE1XUlhRSGUwVkFzeUdRRmJ4cHE2SFhYWTJmYzVHU2Y6eVZTazNFT0RCYWFaUE9VeQ==");
            var client = new RestClient(baseURL);
            IRestResponse response = client.Execute(request);
            //var token = JsonConvert.DeserializeObject<Dictionary<string, object>>(response.Content)["access_token"].ToString();
            return response.Content;
        }

        public static string GetClientCredentialsToken()
        {
            var client = new RestClient("https://api-beta.unos.org/oauth/accesstoken?grant_type=client_credentials");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Basic SE1XUlhRSGUwVkFzeUdRRmJ4cHE2SFhYWTJmYzVHU2Y6eVZTazNFT0RCYWFaUE9VeQ==");
            IRestResponse response = client.Execute(request);
            var token = JsonConvert.DeserializeObject<Dictionary<string, object>>(response.Content)["access_token"].ToString();
            return token;
        }

        public static void GetUA()
        {
            var client = new RestSharp.RestClient("https://api-beta.unos.org/waitlist-registration/v1/registrations/189361/unacceptable-antigens");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("X-Center-Code", "CCCC");
            request.AddHeader("X-Center-Type", "TX1");
            request.AddHeader("X-Program-Type", "KI");
            request.AddHeader("Authorization", "Bearer HdeIM1QkYCJsyzLlCTUAoHQZmLeV");
            IRestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);
            MessageBox.Show(response.Content);
        }

    }
}
