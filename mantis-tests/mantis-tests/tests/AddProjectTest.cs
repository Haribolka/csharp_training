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
                Name = "Project" + DateTime.UtcNow.ToString(),
                Description = "Project Description " + DateTime.UtcNow.ToString()
            };
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };

            app.Auth.Login(account);
            app.Manage.OpenManagePage();
            app.PM.OpenManageProjectsTab();
            app.PM.ClickCreateProject();
            app.PM.SubmitProjectData(project);
            Assert.IsTrue(app.PM.CheckProjectInTable(project));
            app.Auth.Logout();
        }
    }
}