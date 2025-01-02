using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using static System.Net.Mime.MediaTypeNames;

namespace PlaywrightUIAutomation;

public class NUnitPlaywrightTest: PageTest
{ 
    [Test]
    public async Task NUnitSampleTest()
    {
        await Page.GotoAsync("http://www.somee.com");
        await Page.ClickAsync("text=Login");
        await Page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = "screenshot.jpg"
        });

        await Page.FillAsync("#Input_UserID", "admin");
        await Page.FillAsync("#Input_Password", "password");
        await Page.ClickAsync("text='Log In'");
        await Expect(Page.Locator("text='Invalid login attempt.'")).ToBeVisibleAsync();
    }
}