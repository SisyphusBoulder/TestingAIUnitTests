using System;
using System.Collections.Generic;
using System.Text;
using TestingAIUnitTests;
using Xunit;

namespace TestingAIUnitTestsTests.CustomerTests
{
    public class CustomerBirthdateValidationTests
    {
        private static readonly DateOnly Today =
       DateOnly.FromDateTime(DateTime.Today);

        [Fact]
        public void ValidateBirthdate_WhenExactly18YearsOld_DoesNotThrow()
        {
            // Arrange
            var birthdate = Today.AddYears(-18);

            // Act
            var exception = Record.Exception(() =>
                ValidationService.ValidateBirthdate(birthdate));

            // Assert
            Assert.Null(exception);
        }

        [Fact]
        public void ValidateBirthdate_WhenOlderThan18Years_DoesNotThrow()
        {
            var birthdate = Today.AddYears(-25);

            var exception = Record.Exception(() =>
                ValidationService.ValidateBirthdate(birthdate));

            Assert.Null(exception);
        }

        [Fact]
        public void ValidateBirthdate_WhenExactly120YearsOld_DoesNotThrow()
        {
            var birthdate = Today.AddYears(-120);

            var exception = Record.Exception(() =>
                ValidationService.ValidateBirthdate(birthdate));

            Assert.Null(exception);
        }

        [Fact]
        public void ValidateBirthdate_WhenYoungerThan18Years_ThrowsArgumentException()
        {
            var birthdate = Today.AddYears(-18).AddDays(1);

            Assert.Throws<ArgumentException>(() =>
                ValidationService.ValidateBirthdate(birthdate));
        }

        [Fact]
        public void ValidateBirthdate_WhenOlderThan120Years_ThrowsArgumentException()
        {
            var birthdate = Today.AddYears(-120).AddDays(-1);

            Assert.Throws<ArgumentException>(() =>
                ValidationService.ValidateBirthdate(birthdate));
        }

        [Fact]
        public void ValidateBirthdate_WhenInTheFuture_ThrowsArgumentException()
        {
            var birthdate = Today.AddDays(1);

            Assert.Throws<ArgumentException>(() =>
                ValidationService.ValidateBirthdate(birthdate));
        }
    }
}
