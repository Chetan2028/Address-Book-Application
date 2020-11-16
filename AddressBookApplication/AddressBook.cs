using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookApplication
{
    class AddressBook
    {
        Nlog nlog = new Nlog();

        ContactValidator contactValidator = new ContactValidator();

        /// To add contact in list
        List<Contact> contactList = new List<Contact>();

        /// <summary>
        /// Adds the contact.
        /// </summary>
        public void AddContact()
        {
            try
            {
                Console.WriteLine("Enter First Name");
                string firstName = Console.ReadLine();
                contactValidator.ValidateFirstName(firstName);

                Console.WriteLine("Enter Last Name");
                string lastName = Console.ReadLine();
                contactValidator.ValidateLastName(lastName);

                Console.WriteLine("Enter Address");
                string address = Console.ReadLine();
                contactValidator.ValidateAddress(address);

                Console.WriteLine("Enter City");
                string city = Console.ReadLine();
                contactValidator.ValidateCity(city);

                Console.WriteLine("Enter State");
                string state = Console.ReadLine();
                contactValidator.ValidateState(state);

                Console.WriteLine("Enter Zip Code");
                string zip = Console.ReadLine();
                contactValidator.ValidateZip(zip);

                Console.WriteLine("Enter Mobile Number");
                string mobileNumber = Console.ReadLine();
                contactValidator.ValidateMobileNumber(mobileNumber);

                Console.WriteLine("Enter Email");
                string email = Console.ReadLine();
                contactValidator.ValidateEmail(email);

                bool result = contactValidator.CheckForDuplicates(contactList, firstName, lastName);
                if (result)
                {
                    AddContact();
                }

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
                Console.WriteLine("Contact Added successfully");
                nlog.LogDebug("Debug Successfull : AddContact()");
                nlog.logInfo("AddContact() : Passed");
            }
            catch (AddressBookCustomException ex)
            {
                nlog.LogDebug("Debug Unsuccessfull : AddContact()");
                nlog.LogError("User Details Invalid");
                Console.WriteLine(ex.Message);
            }
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
            Console.WriteLine("Press 3 to Delete Contact");
            Console.WriteLine("Press 4 to View Contact");
            Console.WriteLine("Press 5 to Exit");
        }

        /// <summary>
        /// Edits the contact.
        /// </summary>
        public void EditContact()
        {
            Console.WriteLine("Enter the Contact's first name you want to edit");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter the Contact's Last Name you want to edit");
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
            }
        }

        /// <summary>
        /// Edits the contact list.
        /// </summary>
        /// <param name="contact">The contact.</param>
        public void EditContactList(Contact contact)
        {
            try
            {
                Console.WriteLine("Please enter your choice");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter the first name");
                        string firstName = Console.ReadLine();
                        contactValidator.ValidateFirstName(firstName);
                        contact.FirstName = firstName;
                        break;
                    case 2:
                        Console.WriteLine("Enter the last name");
                        string lastName = Console.ReadLine();
                        contactValidator.ValidateLastName(lastName);
                        contact.LastName = lastName;
                        break;
                    case 3:
                        Console.WriteLine("Enter address");
                        string address = Console.ReadLine();
                        contactValidator.ValidateAddress(address);
                        contact.Address = address;
                        break;
                    case 4:
                        Console.WriteLine("Enter city");
                        string city = Console.ReadLine();
                        contactValidator.ValidateCity(city);
                        contact.City = city;
                        break;
                    case 5:
                        Console.WriteLine("Enter state");
                        string state = Console.ReadLine();
                        contactValidator.ValidateState(state);
                        contact.State = state;
                        break;
                    case 6:
                        Console.WriteLine("Enter zip code");
                        string zip = Console.ReadLine();
                        contactValidator.ValidateZip(zip);
                        contact.Zip = zip;
                        break;
                    case 7:
                        Console.WriteLine("Enter mobile number");
                        string mobileNumber = Console.ReadLine();
                        contactValidator.ValidateMobileNumber(mobileNumber);
                        contact.MobileNumber = mobileNumber;
                        break;
                    case 8:
                        Console.WriteLine("Enter email");
                        string email = Console.ReadLine();
                        contactValidator.ValidateEmail(email);
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
            catch (AddressBookCustomException ex)
            {
                nlog.LogDebug("Debug Unsuccessfull : EditContact()");
                nlog.LogError("User Credentials are invalid");
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Deletes the contact.
        /// </summary>
        public void DeleteContact()
        {
            Console.WriteLine("Enter the Contact's First Name you want to delete");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter the Contact's Last Name you want to delete");
            string lastName = Console.ReadLine();
            for (int index = 0; index < contactList.Count; index++)
            {
                if (contactList[index].FirstName.Equals(firstName) && contactList[index].LastName.Equals(lastName))
                {
                    contactList.RemoveAt(index);
                    Console.WriteLine("Contact Deleted Successfully");
                    nlog.LogDebug("Debug Successfull : DeleteContact()");
                    nlog.logInfo("Delete Contact : Passed()");
                    return;
                }
            }
        }

        /// <summary>
        /// Views the contact.
        /// </summary>
        public void ViewContact()
        {
            if (contactList.Count != 0)
            {
                for (int index = 0; index < contactList.Count; index++)
                {
                    Console.WriteLine($"Contact FirstName        :    {contactList[index].FirstName}");
                    Console.WriteLine($"Contact LastName         :    {contactList[index].LastName}");
                    Console.WriteLine($"Contact Address          :    {contactList[index].Address}");
                    Console.WriteLine($"Contact City             :    {contactList[index].City}");
                    Console.WriteLine($"Contact State            :    {contactList[index].State}");
                    Console.WriteLine($"Contact Zip Code         :    {contactList[index].Zip}");
                    Console.WriteLine($"Contact Mobile Number    :    {contactList[index].MobileNumber}");
                    Console.WriteLine($"Contact Email Id         :    {contactList[index].Email}");
                    Console.WriteLine("-------------------------*****************-------------------------------");
                }
            }
            else
            {
                Console.WriteLine("No Contacts to display");
            }
        }

        /// <summary>
        /// Addresses the book menu.
        /// </summary>
        public void AddressBookMenu()
        {
            bool flag = true;
            while (flag)
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
                        DeleteContact();
                        break;
                    case 4:
                        ViewContact();
                        break;
                    case 5:
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }
}
