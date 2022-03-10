using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("George");
            newData.LastName = "Bush";

            app.Contacts.CreateDefaultContact();
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Modify(1, newData);
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].Name = newData.Name;
            oldContacts[0].LastName = newData.LastName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}