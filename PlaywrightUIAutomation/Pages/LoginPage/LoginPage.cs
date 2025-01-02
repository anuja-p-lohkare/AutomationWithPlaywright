using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightUIAutomation.Pages.LoginPage
{
    public class LoginPage
    {
        private IPage _page;
        private  ILocator _lnkLogin => _page.Locator("text=Login");
        private ILocator _txtUserName => _page.Locator("#UserName");
        private ILocator _txtPassword => _page.Locator("#Password");
        private ILocator _loginBtn => _page.Locator("text=Log in");
        private ILocator _employeeDetailsLink => _page.Locator("text='Employee Details'");
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
