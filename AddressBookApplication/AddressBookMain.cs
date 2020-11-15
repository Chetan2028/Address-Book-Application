using System;

namespace AddressBookApplication
{
    class AddressBookMain
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Implementation");
            AddressBook addressBook = new AddressBook();
            addressBook.AddressBookMenu();
        }
    }
}
