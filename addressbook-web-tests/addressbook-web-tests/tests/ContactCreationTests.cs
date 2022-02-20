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
            app.Contacts.InitContactCreation();
            ContactData contact = new ContactData("John");
            contact.MiddleName = "F";
            contact.LastName = "Kennedy";
            app.Contacts.EnterNameData(contact);
            app.Contacts.EnterNickname();
            app.Contacts.EnterTitle();
            app.Contacts.EnterCompany();
            app.Contacts.EnterAddress();
            app.Contacts.EnterHomeNumber();
            app.Contacts.EnterMobileNumber();
            app.Contacts.EnterWorkNumber();
            app.Contacts.EnterFax();
            app.Contacts.EnterEmail();
            app.Contacts.EnterEmail2();
            app.Contacts.EnterEmail3();
            app.Contacts.EnterHomepage();
            app.Contacts.SelectBirthday();
            app.Contacts.SelectAnniversary();
            app.Contacts.EnterSecondaryAddress();
            app.Contacts.EnterSecondaryPhoneNumber();
            app.Contacts.EnterNotes();
            app.Contacts.SubmitContactCreation();
        }

 

     
    }
}

