using AventStack.ExtentReports;
using Microsoft.Playwright;
using PlaywrightUIAutomation.CommonUtilities;

[SetUpFixture]
   public class OneTimeSetUpClass
    {
        public static ExtentReports extent;
        public IPlaywright playwright;
        
        [OneTimeSetUp]
        public async Task SetUp()
        {
            extent = ExtentReportManager.SetExtentReport();

            GetPaths.ClearOldExtentReport();
            //playwright = await Playwright.CreateAsync();

    }

        public static ExtentReports GetExtentInstance()
        {
            return extent;
        }

        [OneTimeTearDown]
        public void FinalTearDown()
        {
            ExtentReportManager.EndExtentReport(extent);

            GetPaths.SaveExtentReport("TestReports");
        }
    }

