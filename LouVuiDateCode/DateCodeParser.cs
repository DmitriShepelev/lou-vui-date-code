using System;

namespace LouVuiDateCode
{
    public static class DateCodeParser
    {
        /// <summary>
        /// Parses a date code and returns a <see cref="manufacturingYear"/> and <see cref="manufacturingMonth"/>.
        /// </summary>
        /// <param name="dateCode">A three or four number date code.</param>
        /// <param name="manufacturingYear">A manufacturing year to return.</param>
        /// <param name="manufacturingMonth">A manufacturing month to return.</param>
        public static void ParseEarly1980Code(string dateCode, out uint manufacturingYear, out uint manufacturingMonth)
        {
            // #6. Analyze unit tests for the method, and add the method implementation.
            if (string.IsNullOrEmpty(dateCode))
            {
                throw new ArgumentNullException(nameof(dateCode));
            }

            if (dateCode.Length < 3 || dateCode.Length > 4)
            {
                throw new ArgumentException($"{dateCode} is incorrect");
            }

            manufacturingYear = 1900 + uint.Parse(dateCode[..2], null);
            manufacturingMonth = uint.Parse(dateCode[2..], null);
        }

        /// <summary>
        /// Parses a date code and returns a <paramref name="factoryLocationCode"/>, <paramref name="manufacturingYear"/>, <paramref name="manufacturingMonth"/> and <paramref name="factoryLocationCountry"/> array.
        /// </summary>
        /// <param name="dateCode">A three or four number date code.</param>
        /// <param name="factoryLocationCountry">A factory location country array.</param>
        /// <param name="factoryLocationCode">A factory location code.</param>
        /// <param name="manufacturingYear">A manufacturing year to return.</param>
        /// <param name="manufacturingMonth">A manufacturing month to return.</param>
        public static void ParseLate1980Code(string dateCode, out Country[] factoryLocationCountry, out string factoryLocationCode, out uint manufacturingYear, out uint manufacturingMonth)
        {
            // #7. Analyze unit tests for the method, and add the method implementation.
            // Use CountryParser.GetCountry method to get a list of countries by a factory code.
            if (string.IsNullOrEmpty(dateCode))
            {
                throw new ArgumentNullException(nameof(dateCode));
            }

            if (dateCode.Length < 5 || dateCode.Length > 6)
            {
                throw new ArgumentException($"{dateCode} is incorrect");
            }

            factoryLocationCode = dateCode[^2..];
            factoryLocationCountry = CountryParser.GetCountry(factoryLocationCode);
            manufacturingYear = 1900 + uint.Parse(dateCode[..2], null);
            manufacturingMonth = uint.Parse(dateCode[2..^2], null);
        }

        /// <summary>
        /// Parses a date code and returns a <paramref name="factoryLocationCode"/>, <paramref name="manufacturingYear"/>, <paramref name="manufacturingMonth"/> and <paramref name="factoryLocationCountry"/> array.
        /// </summary>
        /// <param name="dateCode">A three or four number date code.</param>
        /// <param name="factoryLocationCountry">A factory location country array.</param>
        /// <param name="factoryLocationCode">A factory location code.</param>
        /// <param name="manufacturingYear">A manufacturing year to return.</param>
        /// <param name="manufacturingMonth">A manufacturing month to return.</param>
        public static void Parse1990Code(string dateCode, out Country[] factoryLocationCountry, out string factoryLocationCode, out uint manufacturingYear, out uint manufacturingMonth)
        {
            // #8. Analyze unit tests for the method, and add the method implementation.
            // Use CountryParser.GetCountry method to get a list of countries by a factory code.
            if (string.IsNullOrEmpty(dateCode))
            {
                throw new ArgumentNullException(nameof(dateCode));
            }

            if (dateCode.Length != 6)
            {
                throw new ArgumentException($"{dateCode} is incorrect");
            }

            factoryLocationCode = dateCode[..2];
            factoryLocationCountry = CountryParser.GetCountry(factoryLocationCode);
            if (dateCode[^3] == '0')
            {
                manufacturingYear = 2000 + uint.Parse(dateCode[^1..], null);
            }
            else
            {
                manufacturingYear = 1900 + (uint.Parse(dateCode[^3..^2], null) * 10) + uint.Parse(dateCode[^1..], null);
            }

            manufacturingMonth = (uint.Parse(dateCode[^4..^3], null) * 10) + uint.Parse(dateCode[^2..^1], null);
        }

        /// <summary>
        /// Parses a date code and returns a <paramref name="factoryLocationCode"/>, <paramref name="manufacturingYear"/>, <paramref name="manufacturingWeek"/> and <paramref name="factoryLocationCountry"/> array.
        /// </summary>
        /// <param name="dateCode">A three or four number date code.</param>
        /// <param name="factoryLocationCountry">A factory location country array.</param>
        /// <param name="factoryLocationCode">A factory location code.</param>
        /// <param name="manufacturingYear">A manufacturing year to return.</param>
        /// <param name="manufacturingWeek">A manufacturing week to return.</param>
        public static void Parse2007Code(string dateCode, out Country[] factoryLocationCountry, out string factoryLocationCode, out uint manufacturingYear, out uint manufacturingWeek)
        {
            // #9. Analyze unit tests for the method, and add the method implementation.
            // Use CountryParser.GetCountry method to get a list of countries by a factory code.
            if (string.IsNullOrEmpty(dateCode))
            {
                throw new ArgumentNullException(nameof(dateCode));
            }

            if (dateCode.Length != 6)
            {
                throw new ArgumentException($"{dateCode} is incorrect");
            }

            factoryLocationCode = dateCode[..2];
            factoryLocationCountry = CountryParser.GetCountry(factoryLocationCode);
            manufacturingYear = 2000 + (uint.Parse(dateCode[^3..^2], null) * 10) + uint.Parse(dateCode[^1..], null);
            manufacturingWeek = (uint.Parse(dateCode[^4..^3], null) * 10) + uint.Parse(dateCode[^2..^1], null);
        }
    }
}
