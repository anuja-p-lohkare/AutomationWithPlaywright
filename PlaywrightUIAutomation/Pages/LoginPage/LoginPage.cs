using Microsoft.Playwright;

namespace PlaywrightUIAutomation.Pages.LoginPage
{
    public class LoginPage
    {
        private IPage _page;
        //private  ILocator _lnkLogin => _page.Locator("text=Login");
        private  ILocator _lnkLogin => _page.GetByRole(AriaRole.Link, new PageGetByRoleOptions() { Name = "Login"});
        //private ILocator _txtUserName => _page.Locator("#UserName");
        private ILocator _txtUserName => _page.GetByLabel("UserName");
        //private ILocator _txtPassword => _page.Locator("#Password");
        private ILocator _txtPassword => _page.GetByLabel("Password");
        //private ILocator _loginBtn => _page.Locator("text=Log in");
        private ILocator _loginBtn => _page.GetByRole(AriaRole.Button, new PageGetByRoleOptions() { Name = "Log in"});
        //private ILocator _employeeDetailsLink => _page.Locator("text='Employee Details'");
        private ILocator _employeeDetailsLink => _page.GetByRole(AriaRole.Link, new PageGetByRoleOptions() { Name = "Employee Details" });
        public LoginPage(IPage page) => _page = page;

        public async Task ClickOnLoginOption() => await _lnkLogin.ClickAsync();

        public async Task Login(string userName, string password)
        {
            await _txtUserName.FillAsync(userName);
            await _txtPassword.FillAsync(password);
            await _loginBtn.ClickAsync();
        }

        public async Task<bool> IsEmployeeDetailsExists() => await _employeeDetailsLink.IsVisibleAsync();
    }
}
