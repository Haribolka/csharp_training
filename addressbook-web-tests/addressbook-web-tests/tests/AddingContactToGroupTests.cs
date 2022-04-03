using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            app.Groups.CreateDefaultGroup();
            app.Contacts.CreateDefaultContact();

            List<GroupData> groups = GroupData.GetAll();
            List<ContactData> contacts = ContactData.GetAll();
            bool flag = false;
            contacts.Sort();

            foreach (GroupData g in groups)
            {
                List<ContactData> groupContacts = g.GetContacts();
                if (groupContacts.Count == 0)
                {
                    app.Contacts.AddContactToGroup(contacts[0], g);
                    List<ContactData> newList = g.GetContacts();
                    groupContacts.Add(contacts[0]);
                    groupContacts.Sort();
                    newList.Sort();
                    Assert.AreEqual(groupContacts, newList);
                    flag = true;
                    return;
                }
                groupContacts.Sort();
                int i = 0;
                foreach (ContactData contactToAdd in groupContacts)
                {
                    if (!contacts[i].Equals(contactToAdd))
                    {
                        app.Contacts.AddContactToGroup(contactToAdd, g);
                        List<ContactData> newList = g.GetContacts();
                        groupContacts.Add(contactToAdd);
                        groupContacts.Sort();
                        newList.Sort();
                        Assert.AreEqual(groupContacts, newList);
                        flag = true;
                        return;
                    }
                    else
                    {
                        i++;
                    }
                }
            }

            if (flag == false)
            {
                GroupData additionalGroup = new GroupData("additional");
                app.Groups.Create(additionalGroup);
                app.Contacts.AddContactToGroup(contacts[0], additionalGroup);
            }
        }
    }
}