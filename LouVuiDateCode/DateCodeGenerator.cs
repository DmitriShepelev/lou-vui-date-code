using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace LouVuiDateCode
{
    public static class DateCodeGenerator
    {
        /// <summary>
        /// Generates a date code using rules from early 1980s.
        /// </summary>
        /// <param name="manufacturingYear">A manufacturing year.</param>
        /// <param name="manufacturingMonth">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string GenerateEarly1980Code(uint manufacturingYear, uint manufacturingMonth)
        {
            // #1-1. Analyze unit tests for the method, and add the method implementation.
            var invariant = System.Globalization.CultureInfo.InvariantCulture;
            if (manufacturingYear < 1980 || manufacturingYear >= 1990)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingYear));
            }

            if (manufacturingMonth < 1 || manufacturingMonth > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingMonth));
            }

            return (manufacturingYear % 100).ToString(invariant) + manufacturingMonth.ToString(invariant);
        }

        /// <summary>
        /// Generates a date code using rules from early 1980s.
        /// </summary>
        /// <param name="manufacturingDate">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string GenerateEarly1980Code(DateTime manufacturingDate)
        {
            // #1-2. Analyze unit tests for the method, and add the method implementation.
            return GenerateEarly1980Code((uint)manufacturingDate.Year, (uint)manufacturingDate.Month);
        }

        /// <summary>
        /// Generates a date code using rules from early 1980s.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <param name="manufacturingYear">A manufacturing year.</param>
        /// <param name="manufacturingMonth">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string GenerateLate1980Code(string factoryLocationCode, uint manufacturingYear, uint manufacturingMonth)
        {
            // #2-1. Analyze unit tests for the method, and add the method implementation.
            if (string.IsNullOrEmpty(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            if (!Regex.IsMatch(factoryLocationCode, @"^[a-zA-Z]+$"))
            {
                throw new ArgumentException($"Incorrect location factory");
            }

            return GenerateEarly1980Code(manufacturingYear, manufacturingMonth) + factoryLocationCode.ToUpperInvariant();
        }

        /// <summary>
        /// Generates a date code using rules from late 1980s.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <param name="manufacturingDate">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string GenerateLate1980Code(string factoryLocationCode, DateTime manufacturingDate)
        {
            // #2-2. Analyze unit tests for the method, and add the method implementation.
            if (string.IsNullOrEmpty(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            if (!Regex.IsMatch(factoryLocationCode, @"^[a-zA-Z]+$"))
            {
                throw new ArgumentException($"Incorrect location factory");
            }

            return GenerateEarly1980Code(manufacturingDate) + factoryLocationCode.ToUpperInvariant();
        }

        /// <summary>
        /// Generates a date code using rules from 1990 to 2006 period.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <param name="manufacturingYear">A manufacturing year.</param>
        /// <param name="manufacturingMonth">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string Generate1990Code(string factoryLocationCode, uint manufacturingYear, uint manufacturingMonth)
        {
            // #3-1. Analyze unit tests for the method, and add the method implementation.
            if (string.IsNullOrEmpty(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            if (!Regex.IsMatch(factoryLocationCode, @"^[a-zA-Z]+$"))
            {
                throw new ArgumentException($"Incorrect location factory");
            }

            if (manufacturingYear < 1990 || manufacturingYear >= 2007)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingYear));
            }

            if (manufacturingMonth < 1 || manufacturingMonth > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingMonth));
            }

            var year = $"{manufacturingYear % 100:00}";
            var month = $"{manufacturingMonth:00}";
            return $"{factoryLocationCode.ToUpperInvariant()}{month[0]}{year[0]}{month[1]}{year[1]}";
        }

        /// <summary>
        /// Generates a date code using rules from 1990 to 2006 period.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <param name="manufacturingDate">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string Generate1990Code(string factoryLocationCode, DateTime manufacturingDate)
        {
            // #3-2. Analyze unit tests for the method, and add the method implementation.
            return Generate1990Code(factoryLocationCode, (uint)manufacturingDate.Year, (uint)manufacturingDate.Month);
        }

        /// <summary>
        /// Generates a date code using rules from post 2007 period.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <param name="manufacturingYear">A manufacturing year.</param>
        /// <param name="manufacturingWeek">A manufacturing week number.</param>
        /// <returns>A generated date code.</returns>
        public static string Generate2007Code(string factoryLocationCode, uint manufacturingYear, uint manufacturingWeek)
        {
            // #4-1. Analyze unit tests for the method, and add the method implementation.
            if (string.IsNullOrEmpty(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            if (!Regex.IsMatch(factoryLocationCode, @"^[a-zA-Z]+$"))
            {
                throw new ArgumentException($"Incorrect location factory");
            }

            if (manufacturingYear < 2007)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingYear));
            }

            if (manufacturingWeek < 1 || manufacturingWeek > 53)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingWeek));
            }

            var year = $"{manufacturingYear % 100:00}";
            var week = $"{manufacturingWeek:00}";
            return $"{factoryLocationCode.ToUpperInvariant()}{week[0]}{year[0]}{week[1]}{year[1]}";
        }

        /// <summary>
        /// Generates a date code using rules from post 2007 period.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <param name="manufacturingDate">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string Generate2007Code(string factoryLocationCode, DateTime manufacturingDate)
        {
            // #4-2. Analyze unit tests for the method, and add the method implementation.
            var cal = new GregorianCalendar();
            var weekNumber = cal.GetWeekOfYear(manufacturingDate, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            return Generate2007Code(factoryLocationCode, (uint)manufacturingDate.Year, (uint)weekNumber);
        }
    }
}
