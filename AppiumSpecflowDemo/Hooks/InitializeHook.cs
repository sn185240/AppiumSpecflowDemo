using AppiumSpecflowDemo.Drivers;
using AppiumSpecflowDemo.Helpers;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace AppiumSpecflowDemo.Hooks
{
    [Binding]
    internal class InitializeHook
    {
        private readonly ScenarioContext _scenarioContext;

        public InitializeHook(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            ClearOutputFolder();
            //ClearTestJson();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            string startEmulatorCMD = "emulator -avd Axium_API_29_1";
            new CommandHelper().RunCommand(startEmulatorCMD);
            AppiumDriver appiumDriver = new AppiumDriver();
            //context injection sets the type
            //_scenarioContext.Set(appiumDriver.InitializeAppium(),"Driver");
            _scenarioContext["AppiumDriver"] = appiumDriver.InitializeAppium();
            
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            GenerateReport();
        }

        public static void GenerateReport()
        {
            //string testExecutionJsonPath = $"{Environment.CurrentDirectory}\\TestExecution.json";
            //WaitForFile(testExecutionJsonPath);
            string command = "livingdoc test-assembly AppiumSpecflowDemo.dll -t TestExecution.json --output \"C:\\GitHub Repositories\\AppiumSpecflowDemo\\AppiumSpecflowDemo\\Output\\MyReport.html\"";
            //string command = "livingdoc test-assembly AppiumSpecflowDemo.dll --output \"C:\\GitHub Repositories\\AppiumSpecflowDemo\\AppiumSpecflowDemo\\Output\\MyReport.html\"";
            new CommandHelper().RunCommand(command);
        }

        public static void ClearOutputFolder()
        {

            string outputFolderPath = @"C:\GitHub Repositories\AppiumSpecflowDemo\AppiumSpecflowDemo\Output\";
                                       
            DirectoryInfo di = new DirectoryInfo(outputFolderPath);
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
        }

        public static void ClearTestJson()
        {
            string testExecutionJsonPath = $"{Environment.CurrentDirectory}\\TestExecution.json";
            DeleteFile(testExecutionJsonPath);
        }

        static void WaitForFile(string filePath, int maxRetryAttempts = 60, int retryIntervalMilliseconds = 1000)
        {
            int retryCount = 0;
            while (!File.Exists(filePath) && retryCount < maxRetryAttempts)
            {
                System.Threading.Thread.Sleep(retryIntervalMilliseconds);
                retryCount++;
            }

            if (!File.Exists(filePath))
            {
                // File was not generated within the specified time
                Console.WriteLine("File was not generated within the specified time.");
            }
        }

        public static void DeleteFile(string filePath)
        {
            try
            {
                // Check if the file exists before attempting to delete
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    Console.WriteLine($"File '{filePath}' has been deleted.");
                }
                else
                {
                    Console.WriteLine($"File '{filePath}' does not exist.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting the file: {ex.Message}");
            }
        }

        
    }
}
