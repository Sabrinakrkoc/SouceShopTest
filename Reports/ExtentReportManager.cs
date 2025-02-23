using AventStack.ExtentReports;
using System;
using System.IO;

namespace SauceDemoShop.Reports
{
    public class ExtentReportManager
    {
        private static ExtentReports extentReports;
        private static ExtentTest test;

        public static ExtentReports GetExtentReports()
        {
            if (extentReports == null)
            {
                string reportPath = Path.Combine(Directory.GetCurrentDirectory(), "Reports", "ExtentReports");
                if (!Directory.Exists(reportPath))
                {
                    Directory.CreateDirectory(reportPath);
                }

                extentReports = new ExtentReports();
            }

            return extentReports;
        }

        public static void CreateTest(string testName)
        {
            test = GetExtentReports().CreateTest(testName);
        }

        public static void EndTest()
        {
            extentReports.Flush();
        }

        public static void LogTestInfo(string message)
        {
            test.Info(message);
        }

        public static void LogTestPass(string message)
        {
            test.Pass(message);
        }

        public static void LogTestFail(string message)
        {
            test.Fail(message);
        }
    }
}
