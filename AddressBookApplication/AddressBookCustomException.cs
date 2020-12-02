using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookApplication
{
    class AddressBookCustomException : Exception
    {
        public enum ExceptionType
        {
            INVALID_FIRST_NAME,
            INVALID_LAST_NAME,
            INVALID_ADDRESS,
            INVALID_CITY,
            INVALID_STATE,
            INVALID_ZIP,
            INVALID_MOBILENUMBER,
            INVALID_EMAIL,
            DUPLICATE_ADDRESS_BOOK,
            WRONG_CITY_NAME
        }

        public ExceptionType type;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressBookCustomException"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        public AddressBookCustomException(ExceptionType type , string message) : base(message)
        {
            this.type = type;
        }
    }
}
