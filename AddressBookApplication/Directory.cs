using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookApplication
{
    class Directory
    {
        //Dictionary to store address book
        Dictionary<string, AddressBook> addressBookDictionary = new Dictionary<string, AddressBook>();

        //create a reference of address book
        AddressBook addressBook = new AddressBook();

        //create a reference of nlog
        Nlog nlog = new Nlog();

        /// <summary>
        /// Gets the name of the address book.
        /// </summary>
        /// <returns></returns>
        public string GetAddressBookName()
        {
            Console.WriteLine("Enter the name of address book which you want to create");
            string name = Console.ReadLine();
            return name;
        }

        /// <summary>
        /// Gets the name of the existing address book.
        /// </summary>
        /// <returns></returns>
        public string GetExistingAddressBookName()
        {
            Console.WriteLine("Enter the name of address book which you want to access");
            string name = Console.ReadLine();
            return name;
        }

        /// <summary>
        /// Adds the address book.
        /// </summary>
        public void AddAddressBook()
        {
            try
            {
                string bookName = GetAddressBookName();
                if (!addressBookDictionary.ContainsKey(bookName))
                {
                    addressBookDictionary.Add(bookName, addressBook);
                    Console.WriteLine("Address Book {0} is created", bookName);
                    nlog.LogDebug("Debug Successfull : AddAddressBook()");
                    nlog.logInfo("AddAddressBook() : passed");
                    addressBook.AddressBookMenu();
                }
                else
                {
                    nlog.LogDebug("Debug unsuccessfull : AddAddressBook()");
                    nlog.LogError("Cannot add another address book , address book already exists");
                    throw new AddressBookCustomException(AddressBookCustomException.ExceptionType.DUPLICATE_ADDRESS_BOOK, $"{bookName} Address Book already exists");
                }
            }
            catch (AddressBookCustomException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Accesses the existing address book.
        /// </summary>
        public void AccessExistingAddressBook()
        {
            string existingBook = GetExistingAddressBookName();
            if (addressBookDictionary.ContainsKey(existingBook))
            {
                Console.WriteLine($"Welcome to {existingBook} Address Book");
                addressBookDictionary[existingBook].AddressBookMenu();
            }
            else
            {
                Console.WriteLine($"{existingBook} not found");
            }
        }

        /// <summary>
        /// Views the address book.
        /// </summary>
        public void ViewAddressBook()
        {
            if (addressBookDictionary.Count != 0)
            {
                foreach (var item in addressBookDictionary.Keys)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("No address book to display");
            }
        }

        /// <summary>
        /// Directories the display menu.
        /// </summary>
        public void DirectoryDisplayMenu()
        {
            Console.WriteLine("Press 1 to Add Address Book");
            Console.WriteLine("Press 2 to Access Address Book");
            Console.WriteLine("Press 3 to View Address Book");
            Console.WriteLine("Press 4 to Exit");
        }

        /// <summary>
        /// Directories the menu.
        /// </summary>
        public void DirectoryMenu()
        {
            bool flag = true;
            while (flag)
            {
                DirectoryDisplayMenu();
                Repeat: int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddAddressBook();
                        break;
                    case 2:
                        AccessExistingAddressBook();
                        break;
                    case 3:
                        ViewAddressBook();
                        break;
                    case 4:
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid choice");
                        goto Repeat;
                }
            }
        }
    }
}

