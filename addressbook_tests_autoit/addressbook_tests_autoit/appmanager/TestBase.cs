﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace addressbook_tests_autoit
{
    public class TestBase
    {
        ApplicationManager app;

        [SetUpFixture]
        public void initApplication()
        {
            app = new ApplicationManager();        
        }

        [TestFixtureTearDown]
        public void stopApplication()
        {
            app.Stop();
        }

    }
}
