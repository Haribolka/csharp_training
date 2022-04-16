using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace mantis_tests
{
    [TestFixture]
    public class RemoveProjectTest : TestBase
    {
        [Test]
        public void RemoveProject()
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

            List<ProjectData> projects = new List<ProjectData>();

            projects = app.API.GetAllProjects(account);
            if (projects.Count == 0)
            {
                app.API.CreateNewProject(account, project);
                projects = app.API.GetAllProjects(account);
            }

            app.Auth.Login(account);
            app.Manage.OpenManagePage();
            app.PM.OpenManageProjectsTab();
            app.PM.OpenProject(projects[0].Name);
            app.PM.DeleteProject();
            Assert.IsFalse(app.PM.CheckProjectInTable(projects[0]));
            app.Auth.Logout();
        }
    }
}