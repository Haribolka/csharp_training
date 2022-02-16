using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    internal class ContactData
    {
        private string name;
        private string middleName = "";
        private string lastName = "";


        public ContactData(string name)
        {
            this.name = name;
        }
        public ContactData(string name, string middleName, string lastName)
        {
            this.name = name;
            this.middleName = middleName;
            this.lastName = lastName;
        }

        public string Name 
        { 
            get 
            { 
                return name; 
            }
            set
            {
                name = value;
            }
        }

        public string MiddleName
        { 
            get 
            { 
                return middleName; 
            }
            set 
            { 
                middleName = value; 
            }
        }

        public string LastName
        {
            get 
            { 
                return lastName; 
            }
            set 
            { 
                lastName = value;  
            }
        }
    }
}
