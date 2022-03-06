﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string name;
        private string lastName = "";


        public ContactData(string name)
        {
            this.name = name;
        }

        public ContactData(string name, string lastName)
        {
            this.name = name;
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

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return name.CompareTo(other.name);
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return (Name == other.Name)&&(LastName == other.LastName);
            //return Name == other.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
