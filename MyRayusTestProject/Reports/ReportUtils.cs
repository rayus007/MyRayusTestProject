using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRayusTestProject.Reports
{
    public class ReportUtils
    {
        public static ExtentReports Extent;
        //public static ExtentTest Test;

        public static void Initialize()
        {
            string reportPath = "C:\\Users\\Home\\source\\repos\\MyRayusTestProject\\Report.html";
            var spark = new ExtentSparkReporter(reportPath);
            Extent = new ExtentReports();
            Extent.AttachReporter(spark);
        }

        public static void FlushReport() 
        {
            Extent.Flush();
        }

    }
}
