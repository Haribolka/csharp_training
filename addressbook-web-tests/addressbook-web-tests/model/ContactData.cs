using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string fullContactDetails;

        public ContactData()
        {
        }

        public ContactData(string name)
        {
            Name = name;
        }

        public ContactData(string name, string lastName)
        {
            Name = name;
            LastName = lastName;
        }

        [Column(Name = "firstname")]
        public string Name { get; set; }

        [Column(Name = "lastname")]
        public string LastName { get; set; }

        [Column(Name = "middlename")]
        public string MiddleName { get; set; }

        [Column(Name = "nickname")]
        public string Nickname { get; set; }

        [Column(Name = "company")]
        public string Company { get; set; }

        [Column(Name = "title")]
        public string Title { get; set; }

        [Column(Name = "address")]
        public string Address { get; set; }

        [Column(Name = "home")]
        public string HomePhone { get; set; }

        [Column(Name = "mobile")]
        public string MobilePhone { get; set; }

        [Column(Name = "work")]
        public string WorkPhone { get; set; }

        [Column(Name = "phone2")]
        public string SecondaryPhone { get; set; }

        [Column(Name = "fax")]
        public string FaxPhone { get; set; }

        [Column(Name = "homepage")]
        public string Homepage { get; set; }

        [Column(Name = "email")]
        public string Email { get; set; }

        [Column(Name = "email2")]
        public string Email2 { get; set; }

        [Column(Name = "email3")]
        public string Email3 { get; set; }

        public string Birthday { get; set; }
        public string Anniversary { get; set; }

        [Column(Name = "address2")]
        public string SecondaryAddress { get; set; }

        [Column(Name = "notes")]
        public string Notes { get; set; }

        [Column(Name = "id"), PrimaryKey, Identity]
        public string ContactId { get; set; }

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
                    /*return (Name + " " + MiddleName + " " + LastName + "\r\n" +
                        Nickname + "\r\n" + Title + "\r\n" + Company + "\r\n" +
                        Address + "\r\n\r\nH: " + HomePhone + "\r\nM: " + MobilePhone + "\r\nW: " +
                        WorkPhone + "\r\nF: " + FaxPhone + "\r\n\r\n" + Email + "\r\n" +
                        Email2 + "\r\n" + Email3 + "\r\nHomepage:\r\n" + Homepage + "\r\n\r\nBirthday " +
                        Birthday + "\r\nAnniversary " + Anniversary + "\r\n\r\n" + SecondaryAddress + "\r\n\r\nP: " +
                        SecondaryPhone + "\r\n\r\n" + Notes);*/
                    string details = "";
                    if (Name != "")
                    {
                        details = details + Name;
                    }
                    if ((LastName != "") && (LastName != ""))
                    {
                        details = details + " " + LastName;
                    }
                    if ((LastName != "") && (LastName == ""))
                    {
                        details = details + LastName;
                    }
                    if ((Name != "") || (LastName != ""))
                    {
                        details = details + "\r\n";
                    }
                    if (Address != "")
                    {
                        details = details + Address + "\r\n";
                    }
                    if (HomePhone != "")
                    {
                        details = details + "\r\nH: " + HomePhone;
                    }
                    if (MobilePhone != "")
                    {
                        details = details + "\r\nM: " + MobilePhone;
                    }
                    if (WorkPhone != "")
                    {
                        details = details + "\r\nW: " + WorkPhone;
                    }
                    if ((HomePhone != "") || (MobilePhone != "") || (WorkPhone != ""))
                    {
                        details = details + "\r\n";
                    }
                    if (Email != "")
                    {
                        details = details + "\r\n" + Email;
                    }
                    if (Email2 != "")
                    {
                        details = details + "\r\n" + Email2;
                    }
                    if (Email3 != "")
                    {
                        details = details + "\r\n" + Email3;
                    }
                    return details;
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

        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from g in db.Contacts select g).ToList();
            }
        }

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