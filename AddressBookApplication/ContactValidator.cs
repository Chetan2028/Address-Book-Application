using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AddressBookApplication
{
    class ContactValidator
    {
        public const string REGEX_FIRST_NAME = "^[A-Z]{1}[A-Za-z]{3,}$";
        public const string REGEX_LAST_NAME = "^[A-Z]{1}[A-Za-z]{3,}$";
        public const string REGEX_ADDRESS = "^[A-Z]{1}[A-Za-z0-9]{5,}$";
        public const string REGEX_CITY = "^[A-Z]{1}[A-Za-z]{3,}$";
        public const string REGEX_STATE = "^[A-Z]{1}[A-Za-z]{3,}$";
        public const string REGEX_ZIP = "^[0-9]{6}$";
        public const string REGEX_MOBILE_NUMBER = "^[0-9]{10}$";
        public const string REGEX_EMAIL = "^[a-zA-Z]{1}[A-Za-z0-9]{3,}[@][a-z]{5,}[.][a-z]{2,}$";

        /// <summary>
        /// Validates the first name.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <exception cref="AddressBookApplication.AddressBookCustomException">Invalid First Name</exception>
        public void ValidateFirstName(string firstName)
        {
            if (Regex.IsMatch(firstName, REGEX_FIRST_NAME))
            {
                return;
            }
            else
            {
                throw new AddressBookCustomException(AddressBookCustomException.ExceptionType.INVALID_FIRST_NAME, "Invalid First Name");
            }
        }

        /// <summary>
        /// Validates the last name.
        /// </summary>
        /// <param name="lastName">The last name.</param>
        /// <exception cref="AddressBookApplication.AddressBookCustomException">Invalid Last Name</exception>
        public void ValidateLastName(string lastName)
        {
            if (Regex.IsMatch(lastName, REGEX_LAST_NAME))
            {
                return;
            }
            else
            {
                throw new AddressBookCustomException(AddressBookCustomException.ExceptionType.INVALID_LAST_NAME, "Invalid Last Name");
            }
        }

        /// <summary>
        /// Validates the address.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <exception cref="AddressBookApplication.AddressBookCustomException">Invalid Address</exception>
        public void ValidateAddress(string address)
        {
            if (Regex.IsMatch(address, REGEX_ADDRESS))
            {
                return;
            }
            else
            {
                throw new AddressBookCustomException(AddressBookCustomException.ExceptionType.INVALID_ADDRESS, "Invalid Address");
            }
        }

        /// <summary>
        /// Validates the city.
        /// </summary>
        /// <param name="city">The city.</param>
        /// <exception cref="AddressBookApplication.AddressBookCustomException">Invalid city</exception>
        public void ValidateCity(string city)
        {
            if (Regex.IsMatch(city, REGEX_CITY))
            {
                return;
            }
            else
            {
                throw new AddressBookCustomException(AddressBookCustomException.ExceptionType.INVALID_CITY, "Invalid city");
            }
        }

        /// <summary>
        /// Validates the state.
        /// </summary>
        /// <param name="state">The state.</param>
        /// <exception cref="AddressBookApplication.AddressBookCustomException">Invalid state</exception>
        public void ValidateState(string state)
        {
            if (Regex.IsMatch(state, REGEX_FIRST_NAME))
            {
                return;
            }
            else
            {
                throw new AddressBookCustomException(AddressBookCustomException.ExceptionType.INVALID_STATE, "Invalid state");
            }
        }

        /// <summary>
        /// Validates the zip.
        /// </summary>
        /// <param name="zip">The zip.</param>
        /// <exception cref="AddressBookApplication.AddressBookCustomException">Invalid Zip</exception>
        public void ValidateZip(string zip)
        {
            if (Regex.IsMatch(zip, REGEX_ZIP))
            {
                return;
            }
            else
            {
                throw new AddressBookCustomException(AddressBookCustomException.ExceptionType.INVALID_ZIP, "Invalid Zip");
            }
        }

        /// <summary>
        /// Validates the mobile number.
        /// </summary>
        /// <param name="mobileNumber">The mobile number.</param>
        /// <exception cref="AddressBookApplication.AddressBookCustomException">Invalid Mobile Number</exception>
        public void ValidateMobileNumber(string mobileNumber)
        {
            if (Regex.IsMatch(mobileNumber, REGEX_MOBILE_NUMBER))
            {
                return;
            }
            else
            {
                throw new AddressBookCustomException(AddressBookCustomException.ExceptionType.INVALID_MOBILENUMBER, "Invalid Mobile Number");
            }
        }

        /// <summary>
        /// Validates the email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <exception cref="AddressBookApplication.AddressBookCustomException">Invalid Email</exception>
        public void ValidateEmail(string email)
        {
            if (Regex.IsMatch(email, REGEX_EMAIL))
            {
                return;
            }
            else
            {
                throw new AddressBookCustomException(AddressBookCustomException.ExceptionType.INVALID_EMAIL, "Invalid Email");
            }
        }

        /// <summary>
        /// Checks for duplicates.
        /// </summary>
        /// <param name="contactList">The contact list.</param>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <returns></returns>
        public bool CheckForDuplicates(List<Contact> contactList, string firstName, string lastName)
        {
            for (int index = 0; index < contactList.Count; index++)
            {
                if (contactList[index].FirstName.Equals(firstName) && contactList[index].LastName.Equals(lastName))
                {
                    Console.WriteLine("Contact name already exists!! \nPlease enter your details once again");
                    return true;
                }
                else
                {
                    continue;
                }
            }
            return false;
        }
    }
}
