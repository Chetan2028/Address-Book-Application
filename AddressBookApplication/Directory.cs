using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookApplication
{
    public class Directory
    {
        //Dictionary to store address book
        Dictionary<string, AddressBook> addressBookDictionary = new Dictionary<string, AddressBook>();
        public Dictionary<string, List<Contact>> cityDetailsDictionary = new Dictionary<string, List<Contact>>();
        public Dictionary<string, List<Contact>> stateDetailsDictionary = new Dictionary<string, List<Contact>>();
        public HashSet<string> cityList = new HashSet<string>();
        public HashSet<string> stateList = new HashSet<string>();

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
        /// Viewings the city dictionary.
        /// </summary>
        public void ViewingCityDictionary()
        {
            foreach (KeyValuePair<string, List<Contact>> cityDetails in cityDetailsDictionary)
            {
                Console.WriteLine(cityDetails.Key);
                foreach (Contact contactPerson in cityDetails.Value)
                {
                    Console.WriteLine($"First Name : {contactPerson.FirstName} || Last Name: {contactPerson.LastName} || Address: {contactPerson.Address} || City: {contactPerson.City} || State: {contactPerson.State}|| zip: {contactPerson.Zip} || Phone No: {contactPerson.MobileNumber} || eMail: {contactPerson.Email}");

                }

            }
        }
        /// <summary>
        /// used to display list of state
        /// </summary>
        public void ViewingStateDictionary()
        {
            foreach (KeyValuePair<string, List<Contact>> stateDetails in stateDetailsDictionary)
            {
                Console.WriteLine(stateDetails.Key);
                foreach (Contact contactPerson in stateDetails.Value)
                {
                    Console.WriteLine($"First Name : {contactPerson.FirstName} || Last Name: {contactPerson.LastName} || Address: {contactPerson.Address} || City: {contactPerson.City} || State: {contactPerson.State}|| zip: {contactPerson.Zip} || Phone No: {contactPerson.MobileNumber} || eMail: {contactPerson.Email}");

                }

            }
        }
        public void GettingCityNames()
        {
            //calling each address book
            foreach (KeyValuePair<string, AddressBook> keyValuePair in addressBookDictionary)
            {
                AddressBook contactPersonInformation = keyValuePair.Value;
                //calling method Getting CityList from contactperson information
                //getting city list returns a hashset of cities in particular address book
                //the cities are then added in new hashmap called citylist defined in this class
                foreach (string city in contactPersonInformation.GettingCityList())
                {
                    cityList.Add(city);
                }
            }
        }
        /// <summary>
        /// calling method to create a city dictionary
        /// </summary>
        public void CreatingCityDictionary()
        {
            //foreach loop is used to iterate over city names in hashset citylist
            foreach (string cityName in cityList)
            {
                //list is defined of contact details for every new city
                List<Contact> cityDetailsList = new List<Contact>();
                //foreach loop is called to call each address book seperately
                //each address book is passed to a method addding contact details by city in contact person information
                //method returns a list of contact person details for particular city in particular address book
                //foreach loop iterates the method again by passing the same city and city details list, where more values are added for same city
                foreach (KeyValuePair<string, AddressBook> keyValuePair in addressBookDictionary)
                {
                    AddressBook contactPersonInformation = keyValuePair.Value;
                    cityDetailsList = contactPersonInformation.AddingContactDetailsByCity(cityName, cityDetailsList);
                }
                //after iterating over all address books, city and city details list are added in dictionary
                cityDetailsDictionary.Add(cityName, cityDetailsList);
            }
        }
        /// <summary>
        /// Getting city names is used to get all the names of city in all address books
        /// </summary>
        public void GettingStateNames()
        {
            //calling each address book
            foreach (KeyValuePair<string, AddressBook> keyValuePair in addressBookDictionary)
            {
                AddressBook contactPersonInformation = keyValuePair.Value;
                //calling method Getting StateList from contactperson information
                //getting state list returns a hashset of cities in particular address book
                //the cities are then added in new hashmap called statelist defined in this class
                foreach (string state in contactPersonInformation.GettingStateList())
                {
                    stateList.Add(state);
                }
            }
        }
        /// <summary>
        /// calling method to create a state dictionary
        /// </summary>
        public void CreatingStateDictionary()
        {
            //foreach loop is used to iterate over state names in hashset citylist
            foreach (string stateName in stateList)
            {
                //list is defined of contact details for every new city
                List<Contact> stateDetailsList = new List<Contact>();
                //foreach loop is called to call each address book seperately
                //each address book is passed to a method addding contact details by state in contact person information
                //method returns a list of contact person details for particular state in particular address book
                //foreach loop iterates the method again by passing the same state and state details list, where more values are added for same state
                foreach (KeyValuePair<string, AddressBook> keyValuePair in addressBookDictionary)
                {
                    AddressBook contactPersonInformation = keyValuePair.Value;
                    stateDetailsList = contactPersonInformation.AddingContactDetailsByState(stateName, stateDetailsList);
                }
                //after iterating over all address books, city and city details list are added in dictionary
                stateDetailsDictionary.Add(stateName, stateDetailsList);
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
            Console.WriteLine("Press 6 to Create dictionary for City");
            Console.WriteLine("Press 7 to Create dictionary for State");
            Console.WriteLine("Press 8 to exit");
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
                        SearchingByState();
                        break;
                    case 6:
                        GettingCityNames();
                        CreatingCityDictionary();
                        ViewingCityDictionary();
                        break;
                    case 7:
                        GettingStateNames();
                        CreatingStateDictionary();
                        ViewingStateDictionary();
                        break;
                    case 8:
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

