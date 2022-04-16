using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace mantis_tests
{
    [TestFixture]
    public class AccountCreationTests : TestBase
    {
        [OneTimeSetUp]
        public void SetUpConfig()
        {
            app.Ftp.BackupFile("/config_inc.php");
            using (Stream localFile = File.Open(TestContext.CurrentContext.TestDirectory + "/config_inc.php", FileMode.Open))
            {
                app.Ftp.Upload("/config_inc.php", localFile);
            }
        }

        [Test]
        public void TestAccountRegistration()
        {
            string time = DateTime.Now.ToString("MMddyyHHmmss");
            AccountData account = new AccountData()
            {
                Name = "testuser" + time,
                Password = "password",
                Email = "testuser" + time + "@localhost.localdomain"
            };

            List<AccountData> accounts = app.Admin.GetAllAccounts();
            AccountData existingAccount = accounts.Find(x => x.Name == account.Name);

            if (existingAccount != null)
            {
                app.Admin.DeleteAccount(existingAccount);
            }

            app.James.Delete(account);
            app.James.Add(account);

            app.Registration.Register(account);
        }

        [OneTimeTearDown]
        public void RestoreConfig()
        {
            app.Ftp.RestoreBackupFile("/config_inc.php");
        }
    }
}