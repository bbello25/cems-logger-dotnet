using System;
using System.Net;
using cems_logger_dotnet.Interfaces;
using Newtonsoft.Json;

namespace cems_logger_dotnet
{
    public class CemsLoggerSender
    {
        public string ApiKey { get; set; }
        public string AppName { get; set; }
        public string Email { get; set; }
        public string CemsEndpointUrl { get; set; }

        public CemsLoggerSender(string apiKey, string appName = "unknown", string email = "", string endpointUrl = "http://localhost:5000/")
        {
            ApiKey = apiKey;
            AppName = appName;
            Email = email;
            CemsEndpointUrl = endpointUrl;

            StartSession();
        }

        private void StartSession()
        {
            var url = CemsEndpointUrl + "api/log/healthCheck";
            using (var client = new WebClient())
            {
                client.Headers.Add("api-key", ApiKey);
                var res = client.DownloadString(new Uri(url));
            }
        }

        public void SendLog(ICemsLogEvent logEvent)
        {
            var url = CemsEndpointUrl + "api/log/dotnet";

            var body = JsonConvert.SerializeObject(logEvent);

            using (var client = new WebClient())  
            {
                client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                client.Headers.Add("api-key", ApiKey);
                client.UploadString(new Uri(url), "POST", body);
                Console.WriteLine($"Log sent to cems..");
            }

        }
    }
}
