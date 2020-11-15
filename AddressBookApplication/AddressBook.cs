using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookApplication
{
    class AddressBook
    {
        Nlog nlog = new Nlog();

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

        /// <summary>
        /// Edits the contact menu.
        /// </summary>
        public void EditContactMenu()
        {
            Console.WriteLine("Press 1 to Edit First Name");
            Console.WriteLine("Press 2 to Edit Last Name");
            Console.WriteLine("Press 3 to Edit Address");
            Console.WriteLine("Press 4 to Edit City");
            Console.WriteLine("Press 5 to Edit State");
            Console.WriteLine("Press 6 to Edit Zip Code");
            Console.WriteLine("Press 7 to Edit Mobile Number");
            Console.WriteLine("Press 8 to Edit Email");
            Console.WriteLine("Press 9 to Exit");
        }

        /// <summary>
        /// Displays the menu.
        /// </summary>
        public void DisplayMenu()
        {
            Console.WriteLine("Press 1 to Add Contact");
            Console.WriteLine("Press 2 to Edit Contact");
            Console.WriteLine("Press 3 to Exit");
        }

        /// <summary>
        /// Edits the contact.
        /// </summary>
        public void EditContact()
        {
            Console.WriteLine("Enter the first name you want to edit");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name you want to edit");
            string lastName = Console.ReadLine();
            for (int index = 0; index < contactList.Count; index++)
            {
                if (contactList[index].FirstName.Equals(firstName) && contactList[index].LastName.Equals(lastName))
                {
                    EditContactMenu();
                    EditContactList(contactList[index]);
                    nlog.LogDebug("Debug Successfull : EditContact()");
                    nlog.logInfo("EditContact() : Passed");
                }
                else
                {
                    Console.WriteLine("User Details not matched / User does not exist");
                    nlog.LogDebug("Debug Unsuccessfull : EditContact()");
                }
            }
        }

        /// <summary>
        /// Edits the contact list.
        /// </summary>
        /// <param name="contact">The contact.</param>
        public void EditContactList(Contact contact)
        {
            Console.WriteLine("Please enter your choice");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter the first name");
                    string firstName = Console.ReadLine();
                    contact.FirstName = firstName;
                    break;
                case 2:
                    Console.WriteLine("Enter the last name");
                    string lastName = Console.ReadLine();
                    contact.LastName = lastName;
                    break;
                case 3:
                    Console.WriteLine("Enter address");
                    string address = Console.ReadLine();
                    contact.Address = address;
                    break;
                case 4:
                    Console.WriteLine("Enter city");
                    string city = Console.ReadLine();
                    contact.City = city;
                    break;
                case 5:
                    Console.WriteLine("Enter state");
                    string state = Console.ReadLine();
                    contact.State = state;
                    break;
                case 6:
                    Console.WriteLine("Enter zip code");
                    int zip = Convert.ToInt32(Console.ReadLine());
                    contact.Zip = zip;
                    break;
                case 7:
                    Console.WriteLine("Enter mobile number");
                    long mobileNumber = Convert.ToInt64(Console.ReadLine());
                    contact.MobileNumber = mobileNumber;
                    break;
                case 8:
                    Console.WriteLine("Enter email");
                    string email = Console.ReadLine();
                    contact.Email = email;
                    break;
                case 9:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Please enter a valid choice");
                    break;
            }
        }

        /// <summary>
        /// Addresses the book menu.
        /// </summary>
        public void AddressBookMenu()
        {
            DisplayMenu();
            Console.WriteLine("Enter your choice");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    AddContact();
                    break;
                case 2:
                    EditContact();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}
