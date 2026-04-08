using System;
using System.Collections.Generic;
using System.Text;
using TestingAIUnitTests;
using Xunit;

namespace TestingAIUnitTestsTests.CustomerTests
{
    public class CustomerEmailValidationTests
    {
        [Theory]
        [InlineData("test@example.com")]
        [InlineData("user.name@example.com")]
        [InlineData("user+tag@example.co.uk")]
        [InlineData("user_name@example-domain.com")]
        [InlineData("user.name+tag@example-domain.co.uk")]
        public void ValidateEmail_WithValidEmailAddresses_DoesNotThrow(string email)
        {
            // Act
            var exception = Record.Exception(() =>
                ValidationService.ValidateEmail(email));

            // Assert
            Assert.Null(exception);
        }

        [Theory]
        [InlineData("")]                         // empty
        [InlineData(" ")]                        // whitespace
        [InlineData("plainaddress")]             // missing @ and domain
        [InlineData("@example.com")]              // missing local-part
        [InlineData("user@")]                    // missing domain
        [InlineData("user@example")]             // missing dot in domain
        [InlineData("user@example.")]             // trailing dot
        [InlineData("user@.example.com")]         // leading dot in domain
        [InlineData("user@example..com")]         // consecutive dots
        [InlineData("user@@example.com")]         // multiple @
        [InlineData("user example@example.com")]  // space in local-part
        [InlineData("user!@example.com")]         // invalid character
        public void ValidateEmail_WithInvalidEmailAddresses_ThrowsArgumentException(string email)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
                ValidationService.ValidateEmail(email));
        }

        [Theory]
        [InlineData(null)]                       // null
        public void ValidateEmail_WithNullEmailAddresses_ThrowsArgumentNullException(string email)
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
                ValidationService.ValidateEmail(email));
        }
    }
}
