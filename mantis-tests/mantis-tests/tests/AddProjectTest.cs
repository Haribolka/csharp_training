using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace mantis_tests
{
    [TestFixture]
    public class AddProjectTest : TestBase
    {
        [Test]
        public void AddProject()
        {
            ProjectData project = new ProjectData()
            {
                Name = "Project" + DateTime.Now.ToString(),
                Description = "Project Description " + DateTime.Now.ToString()
            };
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };

            app.API.CreateNewProject(account, project);
            /*app.Auth.Login(account);
            app.Manage.OpenManagePage();
            app.PM.OpenManageProjectsTab();
            app.PM.ClickCreateProject();
            app.PM.SubmitProjectData(project);
            Assert.IsTrue(app.PM.CheckProjectInTable(project));
            app.Auth.Logout();*/
        }
    }
}