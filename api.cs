using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Newtonsoft.Json;
using RestSharp;

namespace UAUpload
{
    class api
    {
        public static string RequestPasswordToken(string userName, string passWord)
        {
            string url = "https://api-beta.unos.org/oauth/accesstoken";
            string client_id = "";
            string client_secret = "";
            //request token
            var restclient = new RestSharp.RestClient(url);
            RestRequest request = new RestRequest("request/oauth") { Method = Method.POST };
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("client_id", client_id);
            request.AddParameter("username", userName);
            request.AddParameter("password", passWord);
            request.AddParameter("client_secret", client_secret);
            request.AddParameter("grant_type", "password");
            var tResponse = restclient.Execute(request);
            var responseJson = tResponse.Content;
            var token = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson)["access_token"].ToString();
            return token.Length > 0 ? token : null;
            return responseJson;
        }

        public static string RefreshPasswordToken(string userName, string passWord)
        {
            string url = "https://api-beta.unos.org/oauth/accesstoken";
            string client_id = "";
            string client_secret = "";
            var restclient = new RestSharp.RestClient(url);
            RestRequest request = new RestRequest("request/oauth") { Method = Method.POST };
            request.AddParameter("client_id", client_id);
            request.AddParameter("username", userName);
            request.AddParameter("password", passWord);
            request.AddParameter("client_secret", client_secret);
            request.AddParameter("grant_type", "password");
            var tResponse = restclient.Execute(request);
            var responseJson = tResponse.Content;
            //var token = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson)["access_token"].ToString();
            //return token.Length > 0 ? token : null;
            return responseJson;
        }


        public static void GetUA()
        {
            var client = new RestSharp.RestClient("https://api-beta.unos.org/waitlist-registration/v1/registrations/189361/unacceptable-antigens");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("X-Center-Code", "CCCC");
            request.AddHeader("X-Center-Type", "TX1");
            request.AddHeader("X-Program-Type", "KI");
            request.AddHeader("Authorization", "Bearer 4HWlcxfSIzY5ulqiEbNp35RdMWut");
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            MessageBox.Show(response.Content);
        }

    }
}
