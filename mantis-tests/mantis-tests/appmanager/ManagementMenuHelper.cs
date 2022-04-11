using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class ManagementMenuHelper : HelperBase
    {
        public ManagementMenuHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void OpenManagePage()
        {
            //driver.FindElement(By.ClassName("menu-text")).FindElement(By.LinkText("Manage")).Click();
            driver.FindElement(By.XPath("//a[@href='/mantisbt-2.25.2/manage_overview_page.php']")).Click();
        }
    }
}