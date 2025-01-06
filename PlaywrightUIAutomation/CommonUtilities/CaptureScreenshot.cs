using Microsoft.Playwright;

namespace PlaywrightUIAutomation.CommonUtilities
{
    public class CaptureScreenshot
    {
        public static async Task<byte[]> CaptureScreenShot(IPage page)
        {
            var base64Screenshot = await page.ScreenshotAsync(new PageScreenshotOptions { Type = ScreenshotType.Png, FullPage = true });

            return base64Screenshot;
        }
    }
}
