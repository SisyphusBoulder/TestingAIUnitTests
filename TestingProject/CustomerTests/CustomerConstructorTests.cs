using System;
using System.Collections.Generic;
using System.Text;
using TestingAIUnitTests;
using Xunit;

namespace TestingAIUnitTestsTests.CustomerTests
{
    public class CustomerConstructorTests
    {
        private static Customer CreateValidCustomer()
        {
            return new Customer(
                "Anne-Marie",
                "O'Connor",
                "anne.oconnor@example.com",
                DateOnly.FromDateTime(DateTime.Today.AddYears(-30)),
                "07123456789");
        }

        [Fact]
        public void Constructor_WithValidArguments_CreatesCustomerSuccessfully()
        {
            // Act
            var customer = CreateValidCustomer();

            // Assert
            Assert.NotNull(customer);
            Assert.NotEqual(Guid.Empty, customer.CustomerID);
            Assert.Equal("Anne-Marie", customer.CustomerFirstname);
            Assert.Equal("O'Connor", customer.CustomerSurname);
            Assert.Equal(DateOnly.FromDateTime(DateTime.Today.AddYears(-30)), customer.CustomerBirthdate);
            Assert.Equal("anne.oconnor@example.com", customer.CustomerEmail);
            Assert.Equal("07123456789", customer.CustomerPhone);
        }

        [Fact]
        public void Constructor_GeneratesNewGuid_ForEachCustomer()
        {
            // Act
            var customer1 = CreateValidCustomer();
            var customer2 = CreateValidCustomer();

            // Assert
            Assert.NotEqual(customer1.CustomerID, customer2.CustomerID);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void Constructor_WithMissingFirstName_ThrowsArgumentException(string firstName)
        {
            Assert.Throws<ArgumentException>(() =>
                new Customer(
                    firstName,
                    "Smith",
                    "smith@example.com",
                    DateOnly.FromDateTime(DateTime.Today.AddYears(-25)),
                    "07123456789"));
        }

        [Theory]
        [InlineData(null)]
        public void Constructor_WithNullFirstName_ThrowsArgumentNullException(string firstName)
        {
            Assert.Throws<ArgumentNullException>(() =>
                new Customer(
                    firstName,
                    "Smith",
                    "smith@example.com",
                    DateOnly.FromDateTime(DateTime.Today.AddYears(-25)),
                    "07123456789"));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void Constructor_WithMissingSurname_ThrowsArgumentException(string surname)
        {
            Assert.Throws<ArgumentException>(() =>
                new Customer(
                    "John",
                    surname,
                    "john.smith@example.com",
                    DateOnly.FromDateTime(DateTime.Today.AddYears(-25)),
                    "07123456789"));
        }

        [Theory]
        [InlineData(null)]
        public void Constructor_WithNullSurname_ThrowsArgumentNullException(string surname)
        {
            Assert.Throws<ArgumentNullException>(() =>
                new Customer(
                    "John",
                    surname,
                    "john.smith@example.com",
                    DateOnly.FromDateTime(DateTime.Today.AddYears(-25)),
                    "07123456789"));
        }

        [Fact]
        public void Constructor_WithInvalidEmail_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
                new Customer(
                    "John",
                    "Smith",
                    "invalid-email",
                    DateOnly.FromDateTime(DateTime.Today.AddYears(-25)),
                    "07123456789"));
        }

        [Fact]
        public void Constructor_WithInvalidPhoneNumber_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
                new Customer(
                    "John",
                    "Smith",
                    "john.smith@example.com",
                    DateOnly.FromDateTime(DateTime.Today.AddYears(-25)),
                    "12345"));
        }

        [Fact]
        public void Constructor_WithFutureBirthdate_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
                new Customer(
                    "John",
                    "Smith",
                    "john.smith@example.com",
                    DateOnly.FromDateTime(DateTime.Today.AddDays(1)),
                    "07123456789"));
        }
    }
}
