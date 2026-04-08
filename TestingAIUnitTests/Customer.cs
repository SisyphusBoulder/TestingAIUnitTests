using System;
using System.Collections.Generic;
using System.Text;
using static TestingAIUnitTests.ValidationService;

namespace TestingAIUnitTests
{
    public class Customer
    {
        public Customer(string customerFirstname, string customerSurname, string? customerEmail, DateOnly customerBirthdate, string? customerPhone)
        {
            ValidateName(customerFirstname);
            ValidateName(customerSurname);
            if (customerEmail is not null)
                ValidateEmail(customerEmail);
            ValidateBirthdate(customerBirthdate);
            if (customerPhone is not null)
                ValidatePhoneNumber(customerPhone);

            CustomerID = Guid.NewGuid();
            CustomerFirstname = customerFirstname;
            CustomerSurname = customerSurname;
            CustomerEmail = customerEmail;
            CustomerBirthdate = customerBirthdate;
            CustomerPhone = customerPhone;
        }

        public Guid CustomerID { get; init; }
        public  string CustomerFirstname { get; set; }
        public  string CustomerSurname { get; set; }

        public string? CustomerEmail { get; set; }

        public DateOnly CustomerBirthdate { get; set; }

        public string? CustomerPhone { get; set; }
    }
}
