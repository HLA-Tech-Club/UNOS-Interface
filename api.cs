using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace UNOSInterface
{
    class api
    {
        public static string passwordToken;
        public static string ccToken;

        public static readonly IDictionary<string, string> urlList = new Dictionary<string, string>()
        {
            {"lookupEthnicity", "https://api-beta.unos.org/waitlist-registration/v1/lookups/ethnicity-race"},
            {"lookupEthnicity2", "https://api-beta.unos.org/waitlist-registration/v1/lookups/ethnicity-race"},
            {"passwordAuth","https://api-beta.unos.org/oauth/accesstoken?grant_type=password"},
            {"refreshToken", "https://api-beta.unos.org/oauth/accesstoken?grant_type=refresh_token&refresh_token="},
            {"clientCredentials","https://api-beta.unos.org/oauth/accesstoken?grant_type=client_credentials"},
            {"basicAuth","Basic SE1XUlhRSGUwVkFzeUdRRmJ4cHE2SFhYWTJmYzVHU2Y6eVZTazNFT0RCYWFaUE9VeQ=="}
        };

        
        public static string RequestAuthToken(string userName, string passWord, string grantType, string refreshToken = "")
        {
            string baseURL = "";
            var request = new RestRequest(Method.POST);
            if (grantType == "password")
            {
                baseURL = urlList["passwordAuth"];
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                request.AddParameter("username", userName);
                request.AddParameter("password", passWord);
            }
            else if (grantType == "refresh")
            {
                baseURL = urlList["refreshToken"] + refreshToken;
            }
            else if (grantType == "cc")
            {
                baseURL = urlList["clientCredentials"];
            }

            request.AddHeader("Authorization", "Basic SE1XUlhRSGUwVkFzeUdRRmJ4cHE2SFhYWTJmYzVHU2Y6eVZTazNFT0RCYWFaUE9VeQ==");
            var client = new RestClient(baseURL);
            IRestResponse response = client.Execute(request);
            data.PasswordTokenRoot passToken = JsonConvert.DeserializeObject<data.PasswordTokenRoot>(response.Content);
            if (passToken.Value.AccessToken != null)
            {
                ini.Write("PreviousToken",passToken.Value.ToString());
                passwordToken = passToken.Value.AccessToken;
                return passToken.Value.AccessToken;
            }
            return null;
        }

        public static data.UA GetUA(string patientID)
        {
            //189361
            var client = new RestSharp.RestClient("https://api-beta.unos.org/waitlist-registration/v1/registrations/" + patientID + "/unacceptable-antigens");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("X-Center-Code", "CCCC");
            request.AddHeader("X-Center-Type", "TX1");
            request.AddHeader("X-Program-Type", "KI");
            request.AddHeader("Authorization", "Bearer " + passwordToken);
            IRestResponse response = client.Execute(request);
            data.UARoot ua = JsonConvert.DeserializeObject<data.UARoot>(response.Content);
            return ua.Value;
        }

        public static List<data.Waitlist> GetWaitlist(string centerCode, string centerType, string programType)
        {
            var client = new RestClient("https://api-beta.unos.org/waitlist-registration/v1/registrations");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("X-Center-Code", centerCode);
            request.AddHeader("X-Center-Type", centerType);
            request.AddHeader("X-Program-Type", programType);
            request.AddHeader("Authorization", "Bearer " + passwordToken);
            IRestResponse response = client.Execute(request);
            data.WaitlistRoot waitlist = JsonConvert.DeserializeObject<data.WaitlistRoot>(response.Content);
            return waitlist.Value;
        }

        public static string lookups(string table)
        {
            var client = new RestClient(urlList[table]);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Bearer " + ccToken);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }

    }
}
