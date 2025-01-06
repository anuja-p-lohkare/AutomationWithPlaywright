using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;


namespace PlaywrightUIAutomation.CommonUtilities
{
    public class ExtentReportManager
    {
        public static ExtentReports extent;
        public static ExtentSparkReporter reporter;
        public static ExtentTest test;

        public static ExtentReports SetExtentReport()
        {
            string reportPath = GetPaths.GetExtentReportPath();
            reporter = new ExtentSparkReporter(reportPath);

            extent = new ExtentReports();
            extent.AttachReporter(reporter);

            return extent;
        }

        public static void EndExtentReport(ExtentReports extent)
        {
            extent.Flush();
        }
    }
}
