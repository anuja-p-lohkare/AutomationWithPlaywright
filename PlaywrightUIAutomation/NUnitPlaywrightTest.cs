using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using static System.Net.Mime.MediaTypeNames;

namespace PlaywrightUIAutomation;

public class NUnitPlaywrightTest: PageTest
{ 
    [Test]
    public async Task NUnitSampleTest()
    {
        //To overcome auto wait option we can specify
        //Page.SetDefaultTimeout(10);
        
        await Page.GotoAsync("http://www.eaapp.somee.com");
        await Page.ClickAsync("text=Login");
        await Page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = "screenshot.jpg"
        });

        await Page.FillAsync("#UserName", "admin");
        await Page.FillAsync("#Password", "password");
        await Page.ClickAsync("text='Log in'");
        await Expect(Page.Locator("text='Employee Details'")).ToBeVisibleAsync();
    }
}