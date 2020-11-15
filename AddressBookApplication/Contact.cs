using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookApplication
{
    class Contact
    {
        private string firstName;
        private string lastName;
        private string address;
        private string city;
        private string state;
        private int zip;
        private long mobileNumber;
        private string email;

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Address { get => address; set => address = value; }
        public string City { get => city; set => city = value; }
        public string State { get => state; set => state = value; }
        public int Zip { get => zip; set => zip = value; }
        public long MobileNumber { get => mobileNumber; set => mobileNumber = value; }
        public string Email { get => email; set => email = value; }
    }
}
