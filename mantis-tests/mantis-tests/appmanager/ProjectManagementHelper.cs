using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class ProjectManagementHelper : HelperBase
    {
        public ProjectManagementHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void OpenManageProjectsTab()
        {
            //driver.FindElement(By.XPath("//a[text()='Manage Projects']")).Click();
            driver.FindElement(By.XPath("//a[@href='/mantisbt-2.25.2/manage_proj_page.php']")).Click();
        }

        public void ClickCreateProject()
        {
            driver.FindElement(By.XPath("//div/div/div/form/button[@type='submit']")).Click();
        }

        public void SubmitProjectData(ProjectData project)
        {
            Type(By.Id("project-name"), project.Name);
            Type(By.Id("project-description"), project.Description);
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
        }

        public bool CheckProjectInTable(ProjectData project)
        {
            return IsElementPresent(By.XPath("//a[text()='" + project.Name + "']"));
        }
    }
}