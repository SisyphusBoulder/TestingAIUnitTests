using System;
using System.Collections.Generic;
using System.Text;
using static TestingAIUnitTests.Constants;

namespace TestingAIUnitTests
{
       public static class ValidationService
    {
        public static void ValidateName(string name)
        {
            if (!NamePattern.IsMatch(name))
                throw new ArgumentException("{name} is not a valid name!", name);
        }

        public static void ValidateBirthdate(DateOnly date)
        {
            if(date < LowerBoundDate || date > UpperBoundDate)
                throw new ArgumentException("Birth date is out of bounds!");
        }

        public static void ValidateEmail(string email)
        {
            if (!EmailPattern.IsMatch(email))
                throw new ArgumentException("{emai} is not a valid e-mail address!", email);
        }

        public static void ValidatePhoneNumber(string phone)
        {
            if (!PhonePattern.IsMatch(phone))
                throw new ArgumentException("{phone} is not a valid UK mobile number!", phone);
        }
    }
}
