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
            newData.MiddleName = "W";
            newData.LastName = "Bush";

            app.Contacts.ModifyIfAccessible(1, newData);
        }
    }
}
