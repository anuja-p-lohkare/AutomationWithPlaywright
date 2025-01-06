using AventStack.ExtentReports;
using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using PlaywrightUIAutomation.CommonUtilities;
using PlaywrightUIAutomation.Pages.LoginPage;

namespace PlaywrightUIAutomation.Tests;

[TestFixture]
public class SampleLoginTestClass
{  
    public async Task LoginTestFlow(string lgnTestData, IPage page, ExtentTest test)
    {
        TestDataReader datareader = new TestDataReader();
        var testCaseSettings = new ConfigurationBuilder().AddJsonFile("testSettings.json").Build();
        string loginTestDataFilePath = testCaseSettings["loginTestData"];

        test.Info($"<b><FONT COLOR ='BLUE'> Test cae started </FONT></b>");

        test.Info("Perform login");

        LoginPage loginpg = new LoginPage(page);
        await loginpg.ClickOnLoginOption();
        string userName = await datareader.ReadTestDataFromTestDataFile(lgnTestData + ".user", loginTestDataFilePath);
        string passwrd = await datareader.ReadTestDataFromTestDataFile(lgnTestData + ".password", loginTestDataFilePath);
        await loginpg.Login(userName, passwrd);

        var isEmployeeDetExists = await loginpg.IsEmployeeDetailsExists();
        test.Info("Login successful");
        test.Info("Verify that employee details link exists");
        Assert.IsTrue(isEmployeeDetExists);
        test.Info("Employee details link exists and verified");

        test.Info($"<b><FONT COLOR = 'BLUE'>Test case completed</FONT><b>");
    }
}