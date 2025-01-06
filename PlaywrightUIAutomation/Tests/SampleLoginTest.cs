using PlaywrightUIAutomation.CommonUtilities;

namespace PlaywrightUIAutomation.Tests
{
    public class SampleLoginTest: BaseClass
    {
        [TestCase("loginTest")]
        public async Task SampleLoginFlowTest(string loginTD)
        {
            SampleLoginTestClass loginTest = new SampleLoginTestClass();
            await loginTest.LoginTestFlow(loginTD, page, test);
        }
    }
}
