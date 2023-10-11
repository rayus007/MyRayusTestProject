using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using MyRayusTestProject.Reports;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V115.Debugger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace MyRayusTestProject
{
    public class BaseTest : IDisposable
    {
        public IWebDriver Driver { get; private set; }
        public ExtentTest CurrentTest { get; private set; }
        private readonly ITestOutputHelper output;
        private static readonly Dictionary<string, TestResult> testResults = new Dictionary<string, TestResult>();
        protected String currentTestName;
        
        public BaseTest(ITestOutputHelper My_output)
        {
            output = My_output;
            
            //Initialize WebDriver
            Driver = new ChromeDriver();
            Driver.Url = "http://www.facebook.com";

            //Create Test Instance in the Report
            currentTestName = output.GetTestName();  //Use a method or extension to extract test name
            CurrentTest = ReportUtils.Extent.CreateTest(currentTestName);
            RecordTestResult(currentTestName, TestResult.Unknown);

        }


        public void Dispose()
        {
            String path = System.AppDomain.CurrentDomain.BaseDirectory + "screenshot";
            bool exists = System.IO.Directory.Exists(path);
            if(!exists)
                System.IO.Directory.CreateDirectory(path);
            //Access test results
            TestResult currentTestResult = testResults.GetValueOrDefault(currentTestName);

            switch (currentTestResult)
            {
                case TestResult.Pass:
                    CurrentTest.Log(Status.Pass, currentTestName + " ran successfully");
                    break;
                case TestResult.Fail:
                case TestResult.Unknown:
                    output.WriteLine("Test Failed");
                    CurrentTest.Log(Status.Fail, currentTestName + " Failed");

                    var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                    var screenshotFileName = $"{Guid.NewGuid()}.png";
                    var screenshotFilePath = path + "//" + screenshotFileName;
                    screenshot.SaveAsFile(screenshotFilePath, ScreenshotImageFormat.Png);
                    CurrentTest.AddScreenCaptureFromPath(screenshotFilePath, "Test failure screenshot");
                    break;
            }

            Driver.Quit();
        }

        protected void RecordTestResult(string testName, TestResult result)
        {
            //store the test result in the static dictionary
            testResults[testName] = result;
        }

        public enum TestResult
        {
            Pass,
            Fail,
            Unknown
        }
    }
}
