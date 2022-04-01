using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class RemovingContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void TestRemovingContactFromGroup()
        {
            /*GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = ContactData.GetAll().First();

            app.Contacts.RemoveContactFromGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.RemoveAt(0);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);*/

            List<GroupData> groups = GroupData.GetAll();

            foreach (GroupData g in groups)
            {
                List<ContactData> groupContacts = g.GetContacts();
                if (groupContacts.Count > 0)
                {
                    app.Contacts.RemoveContactFromGroup(groupContacts[0], g);
                    List<ContactData> newList = g.GetContacts();
                    groupContacts.RemoveAt(0);
                    groupContacts.Sort();
                    newList.Sort();
                    Assert.AreEqual(groupContacts, newList);
                    return;
                }
            }
        }
    }
}