using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit.Abstractions;

namespace MyRayusTestProject.Tests
{
    [Collection("Test Collection")]
    public class FirstTestSuite : BaseTest
    {

        public FirstTestSuite(ITestOutputHelper MyOutput) : base(MyOutput) 
        {

        }
        
        
        [Fact]
        public void FirstTest()
        {
            Console.WriteLine("Test Run");
            Assert.True(false);
            RecordTestResult(currentTestName, TestResult.Pass);
        }

        [Fact]
        public void SecondTest()
        {
            //Assert.True(true);
            try
            {
                RecordTestResult(currentTestName, TestResult.Pass);
            }

            catch (Exception ex)
            {
                RecordTestResult(currentTestName, TestResult.Fail);
            }
            
        }
    }
}