using Evat.Performance.Helpers;
using Evat.Performance.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Evat.Performance
{
    internal class Program
    {
        public const string COMPANY_SECURITY_KEY = "IYDCMRQGEYDAMBUGIYDCMRQGEYAMBUGIYDCMRQGEY";
        public const int MAX_REQUEST = 100;
        public const string API_URL = "https://apitest.e-vatgh.com/evat_apiqa/post_receipt_Json.jsp";
        public const string API_URL_RESPONSE = "https://apitest.e-vatgh.com/evat_apiqa/get_Response_JSON.jsp";
        public const string API_URL_ALGO_REFAC = "https://api-qa.evatgra.com/evat_api/post_receipt_vsdc_rite_Json.jsp";
        public const string API_URL_PERSOL = "https://apivsdcqa.evatgra.com/vsdc/invoice";



        static void Main(string[] args)
        {

            Console.Write("A. Choose Log Enviroment ? \n    1. [ALGORITHIM ORIGINAL] \n    2. [ALGORITHIM ORIGINAL REFACTOR] \n    3. [PERSOL ORIGINAL] \n    Answer [Default 1]: ");

            string command = Console.ReadLine();
            command = command == string.Empty ? "1" : command;

            switch (command)
            {
                case "1":
                    AlgorithmOriginal(command);
                    break;
                case "2":
                    AlgorithmOriginalRefactor(command);
                    break;
                case "3":
                    PersolOriginal(command);
                    break;
                default:
                    Console.WriteLine("{0} does not exist in Menu option", command);
                    break;
            }


            Console.ReadLine();
        }

        private static async void PersolOriginal(string command)
        {
            AppConfig(command);

            var dtStart = DateTime.Now;
            Log.Information($"Start Time : {dtStart}");


            var durationTime = 0.0;

            for (int i = 0; i < MAX_REQUEST; i++)
            {
                var num = $"DOC1190{DateTime.Now.Day}{DateTime.Now.Second}{DateTime.Now.Hour}#11111111{i}";

                PersolRootRequest data = DataHelper.JsonToPersolObject();
                data.invoiceNumber = num;

                var firstCallTime = DateTime.Now;

                var callResult = await ApiCallHelper<PersolRootRequest, PersolRootResponse>.Api(API_URL_PERSOL, data, HttpMethod.Post, num, DateHelper.CurrentDate(), false, COMPANY_SECURITY_KEY);

                var FirstCallEndTime = DateTime.Now;

                var timeDiffForFirstCall = (FirstCallEndTime - firstCallTime).TotalSeconds;

                if (!string.IsNullOrEmpty(callResult.error))
                {
                    Log.Error($"PrintOut STATUS : {callResult.status} ---- {callResult.error}");
                }
                else
                {
                    var diff = DateTime.Now.Subtract(firstCallTime).TotalSeconds;

                    durationTime += diff;
                    Log.Information($"Time Difference [{num}] ---------> {timeDiffForFirstCall} ---------> Duration: { durationTime }");

                }
            }

            Log.Information($"Request End Time  : {DateTime.Now}");
        }

        private static async void AlgorithmOriginalRefactor(string command)
        {
            AppConfig(command);

            var dtStart = DateTime.Now;
            Log.Information($"Start Time : {dtStart}");


            var durationTime = 0.0;

            for (int i = 0; i < MAX_REQUEST; i++)
            {
                var num = $"102{DateTime.Now.Second}{DateTime.Now.Hour}931300000{i}";

                RootRequest data = DataHelper.JsonToAlgoRefacObject();
                data.header.NUM = num;

                var firstCallTime = DateTime.Now;

                var callResult = await ApiCallHelper<RootRequest, RootResponse>.Api(API_URL_ALGO_REFAC, data, HttpMethod.Post, num, DateHelper.CurrentDate(), false, string.Empty);

                var FirstCallEndTime = DateTime.Now;

                var timeDiffForFirstCall = (FirstCallEndTime - firstCallTime).TotalSeconds;

                if (callResult.RESPONSE.STATUS == "ERROR")
                {
                    Log.Error($"PrintOut STATUS : {callResult.RESPONSE.STATUS}");
                }
                else
                {
                    var diff = DateTime.Now.Subtract(firstCallTime).TotalSeconds;

                    durationTime += diff;
                    Log.Information($"Time Difference [{num}] ---------> {timeDiffForFirstCall} ---------> Duration: { durationTime }");

                }
            }

            Log.Information($"Request End Time  : {DateTime.Now}");
        }

        private static async void AlgorithmOriginal(string command)
        {
            AppConfig(command);

            var dtStart = DateTime.Now;
            Log.Information($"Start Time : {dtStart}");

            List<string> invoiceArrList = new();

            var durationTime = 0.0;

            for (int i = 0; i < MAX_REQUEST; i++)
            {
                var num = $"20239115{i}";

                invoiceArrList.Add(num);

                RootRequest data = DataHelper.JsonToObject();
                data.header.NUM = num;

                var firstCallTime = DateTime.Now;

                var callResult =
                   await ApiCallHelper<RootRequest, RootResponse>.Api(API_URL, data, HttpMethod.Post, num, DateHelper.CurrentDate(), false);

                var FirstCallEndTime = DateTime.Now;

                var timeDiffForFirstCall = (FirstCallEndTime - firstCallTime).TotalSeconds;




                if (callResult.RESPONSE.STATUS == "ERROR")
                {
                    Log.Error($"PrintOut STATUS : {callResult.RESPONSE.STATUS}");
                }
                else
                {
                    RootRequest dataSec = DataHelper.BuildEvatFirstRequestResponseData(num);

                    var secondCallTime = DateTime.Now;

                    var callResultSec = await ApiCallHelper<RootRequest, RootResponse>
                        .Api(API_URL_RESPONSE, dataSec, HttpMethod.Post, num, dtStart, true);

                    var secondCallEndTime = DateTime.Now;
                    var timeDiffForSecondCall = (secondCallEndTime - secondCallTime).TotalSeconds;

                    var timeDifference = timeDiffForSecondCall + timeDiffForFirstCall;

                    durationTime += timeDifference;

                    Log.Information($"Time Difference [{num}] ---------> {timeDifference} ---------> Duration: { durationTime}");

                    if (callResultSec.RESPONSE.STATUS == "ERROR")
                    { Log.Error($"ResponseOnRequest PrintOut STATUS : {callResultSec.RESPONSE.STATUS}"); }


                }
            }

            Log.Information($"Request End Time  : {DateTime.Now}");
        }


        private static void AppConfig(string command)
        {
            var builder = new ConfigurationBuilder();

            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            var url = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);

            string loggingType = string.Empty;

            switch (int.Parse(command))
            {
                case 1:
                    loggingType = "algo-original";
                    break;
                case 2:
                    loggingType = "algo-original-refactor";
                    break;
                case 3:
                    loggingType = "persol-original";
                    break;
            }

            Log.Logger = new LoggerConfiguration()
                            .ReadFrom.Configuration(builder.Build())
                            .Enrich.FromLogContext()
                            .WriteTo.File($@"c:\log\evat\{loggingType}.txt", rollingInterval: RollingInterval.Day)
                            .WriteTo.Console()
                            .CreateLogger();

            Log.Logger.Information("Application Starting........");

            var host = Host.CreateDefaultBuilder()
                        .ConfigureServices((context, services) =>
                        {

                        })
                        .UseSerilog()
                        .Build();
        }

    }
}
