using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit.Abstractions;

namespace MyRayusTestProject.Tests
{
    [Collection("Test Collection")]
    public class SecondTestSuite : BaseTest
    {
        public SecondTestSuite(ITestOutputHelper MyOutput) : base(MyOutput) { }
        [Theory]
        [InlineData(1)]
        public void FirstTest(int test)
        {
            RecordTestResult(currentTestName, TestResult.Pass);
        }

        [Theory]
        [InlineData(1)]
        public void SecondTest(int test)
        {
            RecordTestResult(currentTestName, TestResult.Pass);
        }
    }
}