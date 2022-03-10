using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        private List<ContactData> contactCache = null;

        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.GoToContactsPage();
            InitContactCreation();
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
            return this;
        }

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                //List<ContactData> contacts = new List<ContactData>();
                manager.Navigator.GoToContactsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
                foreach (IWebElement element in elements)
                {
                    contactCache.Add(new ContactData(element.FindElement(By.XPath("td[3]")).Text, element.FindElement(By.XPath("td[2]")).Text)
                    {
                        Id = element.FindElement(By.XPath("td[1]/input")).GetAttribute("value")
                    });
                }
            }
            return new List<ContactData>(contactCache);
        }

        public ContactHelper Remove(int item)
        {
            manager.Navigator.GoToContactsPage();
            SelectContact(item);
            DeleteContact();
            return this;
        }

        public ContactHelper Modify(int item, ContactData newData)
        {
            manager.Navigator.GoToContactsPage();
            SelectContact(item);
            EnterNameData(newData);
            SubmitContactModification();
            return this;
        }

        public ContactHelper CreateDefaultContact()
        {
            manager.Navigator.GoToContactsPage();
            if (!IsElementPresent(By.Name("selected[]")))
            {
                ContactData defaultContact = new ContactData("default");
                Create(defaultContact);
            }
            contactCache = null;
            return this;
        }

        public void SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//input[@value='Enter']")).Click();
            contactCache = null;
        }

        public void SubmitContactModification()
        {
            driver.FindElement(By.XPath("//input[@value='Update']")).Click();
            contactCache = null;
        }

        public void EnterNotes()
        {
            Type(By.Name("notes"), "note");
        }

        public void EnterSecondaryPhoneNumber()
        {
            Type(By.Name("phone2"), "77788899");
        }

        public void EnterSecondaryAddress()
        {
            Type(By.Name("address2"), "Sunshine Str. 67");
        }

        public void SelectAnniversary()
        {
            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText("8");
            driver.FindElement(By.Name("amonth")).Click();
            new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText("June");
            Type(By.Name("ayear"), "1995");
        }

        public void SelectBirthday()
        {
            driver.FindElement(By.Name("bday")).Click();
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText("2");
            driver.FindElement(By.Name("bmonth")).Click();
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText("October");
            Type(By.Name("byear"), "1991");
        }

        public void EnterHomepage()
        {
            Type(By.Name("homepage"), "www.site.com");
        }

        public void EnterEmail3()
        {
            Type(By.Name("email3"), "mail100@dd.com");
        }

        public void EnterEmail2()
        {
            Type(By.Name("email2"), "mail200@dd.com");
        }

        public void EnterEmail()
        {
            Type(By.Name("email"), "mail25@dd.com");
        }

        public void EnterFax()
        {
            Type(By.Name("fax"), "999888777654");
        }

        public void EnterWorkNumber()
        {
            Type(By.Name("work"), "600700800900");
        }

        public void EnterMobileNumber()
        {
            Type(By.Name("mobile"), "555666777888");
        }

        public void EnterHomeNumber()
        {
            Type(By.Name("home"), "333444555678");
        }

        public void EnterAddress()
        {
            Type(By.Name("address"), "Main Str. 88");
        }

        public void EnterCompany()
        {
            Type(By.Name("company"), "Apollo");
        }

        public void EnterTitle()
        {
            Type(By.Name("title"), "Title");
        }

        public void EnterNickname()
        {
            Type(By.Name("nickname"), "Bonnie");
        }

        public void EnterNameData(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Name);
            Type(By.Name("lastname"), contact.LastName);
        }

        public void EnterMiddleName()
        {
            Type(By.Name("middlename"), "W");
        }

        public void InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }

        public ContactHelper SelectContact(int item)
        {
            item = item + 1;
            driver.FindElement(By.XPath("//*[@id='maintable']/tbody/tr[" + item + "]/td[8]/a")).Click();
            return this;
        }

        public ContactHelper DeleteContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
            return this;
        }
    }
}