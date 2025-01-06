using AventStack.ExtentReports;
using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using NUnit.Framework.Interfaces;

namespace PlaywrightUIAutomation.CommonUtilities
{
    public class BaseClass
    {
        string lauchUrl;
        public ExtentReports extent;
        public ExtentTest test;
        IConfiguration _configuration;
        public IPage page;
        public IBrowser browser;

        [SetUp]
        public async Task InitialSetUpForTest()
        {
            extent = OneTimeSetUpClass.GetExtentInstance();
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);

            _configuration = new ConfigurationBuilder().AddJsonFile("testSettings.json").Build();

            lauchUrl = _configuration["launchingUrl"];            

            var playwright = await Playwright.CreateAsync();
            browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
            page = await browser.NewPageAsync();
            await page.GotoAsync(lauchUrl);
        }       

        [TearDown]
        public async Task AfterTestFunctions()
        {
            var testCaseStatus = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;

            //Below commented code can be uncommented if user wants to save the screenshot
            //var screenshotPath = $"Screenshot_{DateTime.Now:hh_mm_ss}.png";

            if (testCaseStatus == TestStatus.Failed)
            {
                //var screenshot = await page.ScreenshotAsync(new PageScreenshotOptions { Path = screenshotPath });
                var screenShotForReportInBase64Format = Convert.ToBase64String(await page.ScreenshotAsync());

                test.Fail($"<b><FONT COLOR='RED'> Test case failed: </FONT></b>", MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenShotForReportInBase64Format).Build());

                test.Log(Status.Fail, $"Log trace for test case failed: {stackTrace}");
            }
            else if (testCaseStatus == TestStatus.Passed)
            {
                test.Log(Status.Pass, "<b><FONT COLOR = 'GREEN'> Test case passed successfully </FONT></b>");
            }

            await page.CloseAsync();
            await browser.CloseAsync();
        }
    }
}
