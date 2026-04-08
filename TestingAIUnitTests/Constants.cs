using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TestingAIUnitTests
{
    public static class Constants
    {

        //public static Regex EmailPattern = new("^[A-Za-z0-9.+_-]+@[A-Za-z0-9-]+(?:\\.[A-Za-z0-9-]+)+$");

        public static Regex EmailPattern = new("^[[A-Za-z0-9._-]+(?:\\+[A-Za-z0-9._-]*)?@[A-Za-z0-9-]+(?:\\.[A-Za-z0-9-]+){1,2}$");

        public static Regex NamePattern = new("^[A-Za-zÀ-ÿ]+([-' ][A-Za-zÀ-ÿ]+)*$");

        public static DateOnly LowerBoundDate = DateOnly.FromDateTime(DateTime.Now.AddYears(-120));

        public static DateOnly UpperBoundDate = DateOnly.FromDateTime(DateTime.Now.AddYears(-18));

        public static Regex PhonePattern = new("^(?:\\+44|0)\\d{9,10}$");
    }
}
