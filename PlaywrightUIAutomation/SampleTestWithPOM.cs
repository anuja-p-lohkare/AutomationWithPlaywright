using Microsoft.Playwright;
using PlaywrightUIAutomation.Pages.LoginPage;

namespace PlaywrightUIAutomation;

public class Tests
{
    [Test]
    public async Task Test1()
    {
        //Download playwright(Connection happens), dowload browser drivers and other stuff from Playwright
        using var playwright = await Playwright.CreateAsync();

        //Browser
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false
        });

        //Page
        var page = await browser.NewPageAsync();
        await page.GotoAsync("http://www.eaapp.somee.com");

        LoginPage loginpg = new LoginPage(page);
        await loginpg.ClickOnLoginOption();
        await loginpg.Login("admin", "password");

        var isEmployeeDetExists = await loginpg.IsEmployeeDetailsExists();
        Assert.IsTrue(isEmployeeDetExists);
    }
}