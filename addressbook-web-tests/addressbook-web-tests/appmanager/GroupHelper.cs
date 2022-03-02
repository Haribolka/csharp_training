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
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }


        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }



        public GroupHelper Create(GroupData group)
        {
          
            manager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this;
        }

        private GroupHelper Remove(int item)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(item);
            DeleteGroup();
            ReturnToGroupsPage();
            return this;
        }

        private GroupHelper Modify(int item, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(item);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;
        }

        

        public GroupHelper RemoveIfAccessible(int item)
        {
            manager.Navigator.GoToGroupsPage();
            if (!IsElementPresent(By.Name("selected[]")))
            {
                GroupData defaultGroup = new GroupData("default");
                Create(defaultGroup);
            }
            Remove(item);
            return this;
        }

        public GroupHelper ModifyIfAccessible(int item, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            if (!IsElementPresent(By.Name("selected[]")))
            {
                GroupData defaultGroup = new GroupData("default");
                Create(defaultGroup);
            }
            Modify(item, newData);
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int item)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span[" + item + "]/input")).Click();
            return this;
        }

        public GroupHelper DeleteGroup()
        {
            driver.FindElement(By.XPath("//input[@value='Delete group(s)']")).Click();
            return this;
        }
    }

}
