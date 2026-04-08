using System;
using System.Collections.Generic;
using System.Text;
using TestingAIUnitTests;
using Xunit;

namespace TestingAIUnitTestsTests.CustomerTests
{
    public class CustomerNameValidationTests
    {
        [Theory]
        [InlineData("John")]
        [InlineData("Anne-Marie")]
        [InlineData("O'Connor")]
        [InlineData("Élodie")]
        [InlineData("Jean-Luc")]
        public void ValidateFirstName_WithValidNames_DoesNotThrow(string name)
        {
            // Act
            var exception = Record.Exception(() =>
                ValidationService.ValidateName(name));

            // Assert
            Assert.Null(exception);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("John1")]
        [InlineData("John!")]
        [InlineData("-John")]
        [InlineData("John-")]
        [InlineData("O''Connor")]
        [InlineData("--")]
        public void ValidateFirstName_WithInvalidNames_ThrowsArgumentException(string name)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
                ValidationService.ValidateName(name));
        }

        [Theory]
        [InlineData(null)]
        public void ValidateFirstName_WithNullNames_ThrowsArgumentNullException(string name)
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
                ValidationService.ValidateName(name));
        }
    }
}
