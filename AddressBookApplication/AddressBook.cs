using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace AddressBookApplication
{
    public class AddressBook
    {
        Nlog nlog = new Nlog();

        ContactValidator contactValidator = new ContactValidator();

        /// To add contact in list
        List<Contact> contactList = new List<Contact>();
        HashSet<string> cityList = new HashSet<string>();
        HashSet<string> stateList = new HashSet<string>();

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
            Console.WriteLine("Press 5 to Sort the data");
            Console.WriteLine("Press 6 to Write Data into Text File");
            Console.WriteLine("Press 7 to Write Data into CSV File");
            Console.WriteLine("Press 8 to Read Data from CSV File");
            Console.WriteLine("Press 9 to Write Data into JSON File");
            Console.WriteLine("Press 10 to Exit");
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
                        SortData();
                        break;
                    case 6:
                        WriteDataIntoTextFile();
                        break;
                    case 7:
                        WriteDataIntoCSVFile(contactList);
                        break;
                    case 8:
                        ReadDataFromCSV();
                        break;
                    case 9:
                        WriteDataIntoJSONFile();
                        break;
                    case 10:
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }

        /// <summary>
        /// Searchings the contact details by city.
        /// </summary>
        /// <param name="searchCity">The search city.</param>
        /// <returns></returns>
        /// <exception cref="AddressBookCustomException">City name is not in list</exception>
        public bool SearchingContactDetailsByCity(string searchCity)
        {
            //used to check if city exist and increments the index. If index=0, exception is thrown
            int index = 0;
            foreach (Contact contactPerson in contactList)
            {
                //checks if city is there in list
                if (contactPerson.City.Equals(searchCity))
                {
                    Console.WriteLine($"First Name : {contactPerson.FirstName} || Last Name: {contactPerson.LastName} || Address: {contactPerson.Address} || City: {contactPerson.City} || State: {contactPerson.State}|| zip: {contactPerson.Zip} || Phone No: {contactPerson.MobileNumber} || eMail: {contactPerson.Email}");
                    index++;
                }
            }
            if (index == 0)
            {
                //custom exception is thrown when city is not in list
                throw new AddressBookCustomException(AddressBookCustomException.ExceptionType.WRONG_CITY_NAME, "City name is not in list");
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Searchings the state of the contact details by.
        /// </summary>
        /// <param name="searchState">State of the search.</param>
        /// <returns></returns>
        /// <exception cref="AddressBookCustomException">State name is not in list</exception>
        public bool SearchingContactDetailsByState(string searchState)
        {
            //used to check if city exist and increments the index. If index=0, exception is thrown
            int index = 0;
            foreach (Contact contactPerson in contactList)
            {
                //checks if city is there in list
                if (contactPerson.City.Equals(searchState))
                {
                    Console.WriteLine($"First Name : {contactPerson.FirstName} || Last Name: {contactPerson.LastName} || Address: {contactPerson.Address} || City: {contactPerson.City} || State: {contactPerson.State}|| zip: {contactPerson.Zip} || Phone No: {contactPerson.MobileNumber} || eMail: {contactPerson.Email}");
                    index++;
                }
            }
            if (index == 0)
            {
                //custom exception is thrown when city is not in list
                throw new AddressBookCustomException(AddressBookCustomException.ExceptionType.WRONG_STATE_NAME, "State name is not in list");
            }
            else
            {
                return true;
            }
        }

        public List<Contact> AddingContactDetailsByCity(string cityName, List<Contact> cityDetailsList)
        {
            //foreach loop iterates over each contact person details, and if city matches, contact details are added in list
            //loop runs until all the values are searched in one addressbook, contact detail list.
            //returns the citydetail list from one addressbook
            //same city detail list is received as a parameter for other address book
            foreach (Contact contactPerson in contactList)
            {
                //checks if city is there in list
                if (contactPerson.City.Equals(cityName))
                {
                    cityDetailsList.Add(contactPerson);
                }
            }
            return cityDetailsList;
        }
        /// <summary>
        /// Gets hashset of all the cities in particular contact list
        /// </summary>
        /// <returns></returns>
        public HashSet<string> GettingCityList()
        {
            //foreach loop is used to get each entry in contact list in address book
            //each city is taken out and added in cityList which is hashset
            //hashset is returned
            foreach (Contact contactPerson in contactList)
            {
                cityList.Add(contactPerson.City);
            }
            return cityList;
        }

        /// <summary>
        /// Adding contact details by state in list
        /// </summary>
        /// <param name="stateName"></param>
        /// <param name="stateDetailsList">city details list obtained from other address books</param>
        /// <returns>list of contact details from one address book</returns>
        public List<Contact> AddingContactDetailsByState(string stateName, List<Contact> stateDetailsList)
        {
            //foreach loop iterates over each contact person details, and if state matches, contact details are added in list
            //loop runs until all the values are searched in one addressbook, contact detail list.
            //returns the statedetail list from one addressbook
            //same state detail list is received as a parameter for other address book
            foreach (Contact contactPerson in contactList)
            {
                //checks if state is there in list
                if (contactPerson.State.Equals(stateName))
                {
                    stateDetailsList.Add(contactPerson);
                }
            }
            return stateDetailsList;
        }

        /// <summary>
        /// Gets hashset of all the states in particular contact list
        /// </summary>
        /// <returns></returns>
        public HashSet<string> GettingStateList()
        {
            //foreach loop is used to get each entry in contact list in address book
            //each state is taken out and added in stateList which is hashset
            //hashset is returned
            foreach (Contact contactPerson in contactList)
            {
                stateList.Add(contactPerson.State);
            }
            return stateList;
        }

        public List<Contact> SortingContactDetails()
        {
            Console.WriteLine("Please press 1 to sort the data by name");
            Console.WriteLine("Please press 2 to sort the data by city");
            Console.WriteLine("Please press 3 to sort the data by state");
            Console.WriteLine("Please press 4 to sort the data by zip");
            Console.WriteLine("Please press any other to return the unsorted contacts");
            int sortingContacts = Convert.ToInt32(Console.ReadLine());
            switch (sortingContacts)
            {
                case 1:
                    contactList.Sort((emp1, emp2) => emp1.FirstName.CompareTo(emp2.FirstName));
                    contactList.Sort((emp1, emp2) => emp1.LastName.CompareTo(emp2.LastName));
                    return contactList;
                case 2:
                    contactList.Sort((emp1, emp2) => emp1.City.CompareTo(emp2.City));
                    return contactList;
                case 3:
                    contactList.Sort((emp1, emp2) => emp1.State.CompareTo(emp2.State));
                    return contactList;
                case 4:
                    contactList.Sort((emp1, emp2) => emp1.Zip.CompareTo(emp2.Zip));
                    return contactList;
                default:
                    return contactList;
            }

        }

        public void SortData()
        {
            List<Contact> sortingContactList = SortingContactDetails();
            foreach (var contactPerson in sortingContactList)
            {
                Console.WriteLine($"First Name : {contactPerson.FirstName} || Last Name: {contactPerson.LastName} || Address: {contactPerson.Address} || City: {contactPerson.City} || State: {contactPerson.State}|| zip: {contactPerson.Zip} || Phone No: {contactPerson.MobileNumber} || eMail: {contactPerson.Email}");

            }
        }

        public void WriteDataIntoTextFile()
        {
            try
            {
                Contact c;
                string line;
                string filePath = @"D:\C# Programs\AddressBookApplication\AddressBookApplication\ContactFile.txt";
                using (StreamWriter streamWriter = File.AppendText(filePath))
                {
                    for (int i = 0; i < contactList.Count; i++)
                    {
                        c = contactList[i];
                        line = c.FirstName + " " + c.LastName + " " + c.MobileNumber + " " + c.Zip + " " + c.State + " " + c.City;
                        streamWriter.WriteLine(line);
                    }
                }
            }
            catch (IOException)
            {
                Console.WriteLine("File not found");
            }
        }

        public void WriteDataIntoCSVFile(List<Contact> record)
        {
            string filePath = @"D:\C# Programs\AddressBookApplication\AddressBookApplication\contacts.csv";
            using (var writer = new StreamWriter(filePath))
            using (var csvWrite = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csvWrite.WriteRecords(record);
            }
        }

        public void ReadDataFromCSV()
        {
            string filePath = @"D:\C# Programs\AddressBookApplication\AddressBookApplication\contacts.csv";
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<Contact>();
                foreach (Contact contact in records)
                {
                    Console.WriteLine("\t" + contact.FirstName);
                    Console.WriteLine("\t" + contact.LastName);
                    Console.WriteLine("\t" + contact.Address);
                    Console.WriteLine("\t" + contact.City);
                    Console.WriteLine("\t" + contact.State);
                    Console.WriteLine("\t" + contact.Zip);
                    Console.WriteLine("\t" + contact.MobileNumber);
                    Console.WriteLine("\t" + contact.Email);
                    Console.WriteLine("\n");
                }
            }
        }

        public void WriteDataIntoJSONFile()
        {
            string importFilePath = @"D:\C# Programs\AddressBookApplication\AddressBookApplication\contacts.csv";
            string exportFilePath = @"D:\C# Programs\AddressBookApplication\AddressBookApplication\contacts.json";

            using (var reader = new StreamReader(importFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<Contact>().ToList();

                JsonSerializer jsonSeriallize = new JsonSerializer();
                using (var writer = new StreamWriter(exportFilePath))
                using (JsonWriter jsonwriter = new JsonTextWriter(writer))
                {
                    jsonSeriallize.Serialize(jsonwriter, records);
                }
            }
        }

    }
}

