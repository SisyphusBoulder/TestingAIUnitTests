using System;
using System.Collections.Generic;
using System.Text;
using TestingAIUnitTests;
using Xunit;

namespace TestingAIUnitTestsTests.CustomerTests
{
    public class CustomerPhoneNumberValidationTests
    {


        [Theory]
        [InlineData("07123456789")]        // 0 + 10 digits
        [InlineData("0712345678")]         // 0 + 9 digits
        [InlineData("+447123456789")]      // +44 + 10 digits
        [InlineData("+44712345678")]       // +44 + 9 digits
        public void ValidatePhoneNumber_WithValidPhoneNumbers_DoesNotThrow(string phoneNumber)
        {
            // Act
            var exception = Record.Exception(() =>
                ValidationService.ValidatePhoneNumber(phoneNumber));

            // Assert
            Assert.Null(exception);
        }

        [Theory]
        [InlineData("")]                   // empty
        [InlineData(" ")]                  // whitespace
        [InlineData("7123456789")]          // missing prefix
        [InlineData("447123456789")]        // missing +
        [InlineData("+441234")]             // too short
        [InlineData("071234567")]            // too short
        [InlineData("0712345678901")]        // too long
        [InlineData("+44712345678901")]      // too long
        [InlineData("07 1234 56789")]        // spaces
        [InlineData("07-1234-56789")]        // dashes
        [InlineData("(07123)456789")]        // parentheses
        [InlineData("+1 7123456789")]        // wrong country code
        public void ValidatePhoneNumber_WithInvalidPhoneNumbers_ThrowsArgumentException(string phoneNumber)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
                ValidationService.ValidatePhoneNumber(phoneNumber));
        }

        [Theory]
        [InlineData(null)]                 // null
        public void ValidatePhoneNumber_WithNullPhoneNumbers_ThrowsArgumentNullException(string phoneNumber)
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
                ValidationService.ValidatePhoneNumber(phoneNumber));
        }
    }
}
