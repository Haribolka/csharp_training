using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            InitContactCreation();
            ContactData contact = new ContactData("John");
            contact.MiddleName = "F";
            contact.LastName = "Kennedy";
            EnterNameData(contact);
            EnterNickname();
            EnterTitle();
            EnterCompany();
            EnterAddress();
            EnterHomeNumber();
            EnterMobileNumber();
            EnterWorkNumber();
            EnterFax();
            EnterEmail();
            EnterEmail2();
            EnterEmail3();
            EnterHomepage();
            SelectBirthday();
            SelectAnniversary();
            EnterSecondaryAddress();
            EnterSecondaryPhoneNumber();
            EnterNotes();
            SubmitContactCreation();
            Logout();
        }

 

     
    }
}

