using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookApplication
{
    class AddressBook
    {
        /// To add contact in list
        List<Contact> contactList = new List<Contact>();

        /// <summary>
        /// Adds the contact.
        /// </summary>
        public void AddContact()
        {
            Console.WriteLine("Enter First Name");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter Address");
            string address = Console.ReadLine();
            Console.WriteLine("Enter City");
            string city = Console.ReadLine();
            Console.WriteLine("Enter State");
            string state = Console.ReadLine();
            Console.WriteLine("Enter Zip Code");
            int zip = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Mobile Number");
            long mobileNumber = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter Email");
            string email = Console.ReadLine();

            Contact contact = new Contact()
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address,
                City = city,
                State = state,
                Zip = zip,
                MobileNumber = mobileNumber,
                Email = email
            };

            contactList.Add(contact);
        }
    }
}
