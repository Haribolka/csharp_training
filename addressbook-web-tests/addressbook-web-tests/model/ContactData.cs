using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string fullContactDetails;

        public ContactData(string name)
        {
            Name = name;
        }

        public ContactData(string name, string lastName)
        {
            Name = name;
            LastName = lastName;
        }

        public string Name { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Nickname { get; set; }
        public string Company { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string SecondaryPhone { get; set; }
        public string FaxPhone { get; set; }
        public string Homepage { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string Birthday { get; set; }
        public string Anniversary { get; set; }
        public string SecondaryAddress { get; set; }
        public string Notes { get; set; }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanUp(Email) + CleanUp(Email2) + CleanUp(Email3)).Trim();
                }
            }

            set
            {
                allEmails = value;
            }
        }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone) + CleanUp(SecondaryPhone)).Trim();
                }
            }

            set
            {
                allPhones = value;
            }
        }

        public string FullContactDetails
        {
            get
            {
                if (fullContactDetails != null)
                {
                    return fullContactDetails;
                }
                else
                {
                    return (Name + " " + MiddleName + " " + LastName + "\r\n" +
                        Nickname + "\r\n" + Title + "\r\n" + Company + "\r\n" +
                        Address + "\r\n\r\nH: " + HomePhone + "\r\nM: " + MobilePhone + "\r\nW: " +
                        WorkPhone + "\r\nF: " + FaxPhone + "\r\n\r\n" + Email + "\r\n" +
                        Email2 + "\r\n" + Email3 + "\r\nHomepage:\r\n" + Homepage + "\r\n\r\nBirthday " +
                        Birthday + "\r\nAnniversary " + Anniversary + "\r\n\r\n" + SecondaryAddress + "\r\n\r\nP: " +
                        SecondaryPhone + "\r\n\r\n" + Notes);
                }
            }

            set
            {
                fullContactDetails = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
        }

        public string Id { get; set; }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
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
            return (Name == other.Name) && (LastName == other.LastName);
            //return Name == other.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return "name=" + Name + "\nlastname= " + LastName;
        }
    }
}