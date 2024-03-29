﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;
        protected LoginHelper loginHelper;
        protected ProjectManagementHelper pmHelper;
        protected ManagementMenuHelper managamentHelper;
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/mantisbt-2.25.2";
            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
            James = new JamesHelper(this);
            Mail = new MailHelper(this);
            loginHelper = new LoginHelper(this);
            pmHelper = new ProjectManagementHelper(this);
            managamentHelper = new ManagementMenuHelper(this);
            Admin = new AdminHelper(this, baseURL);
            API = new ApiHelper(this);
        }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.driver.Url = newInstance.baseURL + "/login_page.php";
                app.Value = newInstance;
            }
            return app.Value;
        }

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }

        public RegistrationHelper Registration { get; set; }
        public FtpHelper Ftp { get; set; }
        public JamesHelper James { get; set; }
        public MailHelper Mail { get; set; }
        public AdminHelper Admin { get; set; }
        public ApiHelper API { get; set; }

        public LoginHelper Auth
        {
            get
            {
                return loginHelper;
            }
        }

        public ProjectManagementHelper PM
        {
            get
            {
                return pmHelper;
            }
        }

        public ManagementMenuHelper Manage
        {
            get
            {
                return managamentHelper;
            }
        }
    }
}