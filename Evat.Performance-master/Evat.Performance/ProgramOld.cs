//using Evat.Performance.Helpers;
//using Evat.Performance.Models;
//using Evat.Performance.Performance;
//using Evat.Performance.Performance.Operations;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Hosting;
//using Microsoft.Extensions.Logging;
//using Serilog;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Net.Http;
//using System.Threading.Tasks;
//using Spectre.Console;

//namespace Evat.Performance
//{

//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            MainMenuHelper.DisplayMainMenu();
//            var loop = true;

//            while (loop)
//            {
//                string userchoice = Console.ReadLine();

//                switch (userchoice.ToUpper())
//                {
//                    case "1":
                        
//                        Console.WriteLine("Select a sub item instead!");
//                        break;
//                    case "1A": // Display Everday Account Balance
//                        Console.Clear();
//                        //DisplayBalance(everyday);
//                        break;

//                    case "1B": // Display Investment Account Balance
//                        Console.Clear();
//                        //DisplayBalance(investment);
//                        break;

//                    case "1C": // Display Omni Account Balance
//                        Console.Clear();
//                        //DisplayBalance(omni);
//                        break;

//                    case "2A": // Display Everday Account Balance
//                        Console.Clear();
//                        //DisplayBalance(everyday);
//                        break;

//                    case "2B": // Display Investment Account Balance
//                        Console.Clear();
//                        //DisplayBalance(investment);
//                        break;

//                    case "2C": // Display Omni Account Balance
//                        Console.Clear();
//                        //DisplayBalance(omni);
//                        break;

//                    case "3A": // Everyday Account Deposit

//                        //DepositAmount(everyday);
//                        break;

//                    case "3B": // Investment Account Deposit

//                        //DepositAmount(investment);
//                        break;

//                    case "3C": // Omni Account Deposit

//                        //DepositAmount(omni);
//                        break;

//                    case "4A": // Everyday account Withdrawal

//                        //WithdrawAmount(everyday);
//                        break;

//                    case "4B": // Investment Account Withdrawal

//                        // WithdrawAmount(investment);
//                        break;

//                    case "4C": // Omni Account Withdrawal

//                        // WithdrawAmount(omni);
//                        break;

//                    case "5": // Everyday Details

//                        //DisplayDetails(everyday);
//                        break;

//                    case "6": // Investment Details

//                        //DisplayDetails(investment);
//                        break;

//                    case "7": // Omni Details

//                        //DisplayDetails(omni);
//                        break;

//                    case "4": // Exit Banking

//                        Console.WriteLine("You have chosen to exit evat performance tool. Thanks and come again!");
//                        loop = false;

//                        break;
//                    default: // catch all, breaks the loop
//                             //Console.Clear()
//                        break;
//                }
//            }

//        }


//        private static void AppConfig(string command)
//        {
//            var builder = new ConfigurationBuilder();

//            builder.SetBasePath(Directory.GetCurrentDirectory())
//                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
//                .AddEnvironmentVariables();

//            var url = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);

//            string loggingType = string.Empty;

//            switch (int.Parse(command))
//            {
//                case 1:
//                    loggingType = "algo-original";
//                    break;
//                case 2:
//                    loggingType = "algo-original-refactor";
//                    break;
//                case 3:
//                    loggingType = "persol-original";
//                    break;
//            }

//            Log.Logger = new LoggerConfiguration()
//                            .ReadFrom.Configuration(builder.Build())
//                            .Enrich.FromLogContext()
//                            .WriteTo.File($@"c:\log\evat\{loggingType}.txt", rollingInterval: RollingInterval.Day)
//                            .WriteTo.Console()
//                            .CreateLogger();

//            Log.Logger.Information("Application Starting........");

//            var host = Host.CreateDefaultBuilder()
//                        .ConfigureServices((context, services) =>
//                        {

//                        })
//                        .UseSerilog()
//                        .Build();
//        }

//    }
//}
