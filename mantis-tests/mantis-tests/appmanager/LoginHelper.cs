using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }
                Logout();
            }
            Type(By.Id("username"), account.Name);
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
            Type(By.Id("password"), account.Password);
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
        }

        public void Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.ClassName("user-info")).Click();
                driver.FindElement(By.XPath("//a[@href='/mantisbt-2.25.2/logout_page.php']")).Click();
            }
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.XPath("//a[@href='/mantisbt-2.25.2/my_view_page.php']"));
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
              && IsElementPresent(By.XPath("//span[text()='" + account.Name + "']"));
        }
    }
}