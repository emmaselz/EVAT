using Evat.Performance.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Evat.Performance.Helpers
{
    internal class ApiCallHelper<TRequest, TResponse>
       where TRequest : class, new()
       where TResponse : class, new()       
    {

        public static async Task<TResponse> Api(string apiUrl, TRequest data, HttpMethod method, string invoice, DateTime startTime, bool isLogging = true, string AlgoHeader = "")
        {
            TResponse result = null;

            using (var client = new HttpClient())
            {
                var jsonString = JsonConvert.SerializeObject(data);

                var request = new HttpRequestMessage(method, $"{apiUrl}");

                if (AlgoHeader != string.Empty)
                {
                    request.Headers.Add("security_key", AlgoHeader);
                }
                else
                { }


                var content = new StringContent(jsonString,null,"application/json");


                request.Content = content;

                var response = await client.SendAsync(request);
                var check = await response.Content.ReadAsStringAsync();
                try
                {
                    response.EnsureSuccessStatusCode();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
               

                var sendResponse = await response.Content.ReadAsStringAsync();

                result = JsonConvert.DeserializeObject<TResponse>(sendResponse);

                return result;

            }
        }
    }
}
