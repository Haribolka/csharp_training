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

        private ContactHelper Remove(int item)
        {
            SelectContact(item);
            DeleteContact();
            return this;
        }

        private ContactHelper Modify(int item, ContactData newData)
        {
            SelectContact(item);
            EnterNameData(newData);
            SubmitContactModification();
            return this;
        }

        public ContactHelper RemoveIfAccesible(int item)
        {
            manager.Navigator.GoToContactsPage();
            if (IsElementPresent(By.Name("selected[]")))
            {
                Remove(item);
            }
            else
            {
                ContactData defaultContact = new ContactData("default");
                Create(defaultContact);
            }
            return this;
        }

        public ContactHelper ModifyIfAccessible(int item, ContactData newData)
        {
            manager.Navigator.GoToContactsPage();
            if (IsElementPresent(By.Name("selected[]")))
            {
                Modify(item, newData);
            }
            else
            {
                Create(newData);
            }
            return this;
        }



        public void SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//input[@value='Enter']")).Click();
        }

        public void SubmitContactModification()
        {
            driver.FindElement(By.XPath("//input[@value='Update']")).Click();
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
            Type(By.Name("middlename"), contact.MiddleName);
            Type(By.Name("lastname"), contact.LastName);
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
            return this;
        }

    }
}
