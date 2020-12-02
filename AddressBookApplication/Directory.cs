using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookApplication
{
    public class Directory
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
        /// UC8
        /// Searches the contacts by city.
        /// </summary>
        public void SearchingByCity()
        {
            try
            {
                Console.WriteLine("Please enter the city");
                string searchCity = Console.ReadLine();
                //foreach loop to print name of address book and pass address book value to contact person information class
                foreach (KeyValuePair<string, AddressBook> keyValuePair in addressBookDictionary)
                {
                    Console.WriteLine("Name of the address book: " + keyValuePair.Key);
                    AddressBook addressBook = keyValuePair.Value;
                    bool checkForException = addressBook.SearchingContactDetailsByCity(searchCity);
                }
            }
            //catches exception if city name does not exist
            catch (AddressBookCustomException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Do you want to enter city again, press y for yes");
                string checkInput = Console.ReadLine();
                if (checkInput.ToLower() == "y")
                {
                    SearchingByCity();
                }
                else
                {
                    Console.WriteLine("No city entered");

                }
            }
        }

        /// <summary>
        /// Searchings the state of the by.
        /// </summary>
        public void SearchingByState()
        {
            try
            {
                Console.WriteLine("Please enter the city");
                string searchState = Console.ReadLine();

                //foreach loop to print name of address book and pass address book value to contact person information class
                foreach (KeyValuePair<string, AddressBook> keyValuePair in addressBookDictionary)
                {
                    Console.WriteLine("Name of the address book: " + keyValuePair.Key);
                    AddressBook addressBook = keyValuePair.Value;
                    bool checkForException = addressBook.SearchingContactDetailsByState(searchState);
                }
            }
            //catches exception if state name does not exist
            catch (AddressBookCustomException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Do you want to enter city again, press y for yes");
                string checkInput = Console.ReadLine();
                if (checkInput.ToLower() == "y")
                {
                    SearchingByState();
                }
                else
                {
                    Console.WriteLine("No city entered");

                }
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
            Console.WriteLine("Press 4 to Search Contacts by City");
            Console.WriteLine("Press 5 to Search Contacts by State");
            Console.WriteLine("Press 6 to exit");
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
                        SearchingByCity();
                        break;
                    case 5:
                        SearchingByCity();
                        break;
                    case 6:
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

