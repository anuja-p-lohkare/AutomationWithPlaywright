using Microsoft.Playwright;

namespace PlaywrightUIAutomation;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

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
        await page.GotoAsync("http://www.somee.com");
        await page.ClickAsync("text=Login");
        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = "screenshot.jpg"
        });

        await page.FillAsync("#Input_UserID", "admin");
        await page.FillAsync("#Input_Password", "password");
        await page.ClickAsync("text='Log In'");

        var isLinkExists = await page.Locator("text='Invalid login attempt.'").IsVisibleAsync();
        Assert.IsTrue(isLinkExists);
    }
}