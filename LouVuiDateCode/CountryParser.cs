using System;
using System.Collections.Generic;

namespace LouVuiDateCode
{
    public static class CountryParser
    {
        /// <summary>
        /// Gets a an array of <see cref="Country"/> enumeration values for a specified factory location code. One location code can belong to many countries.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <returns>An array of <see cref="Country"/> enumeration values.</returns>
        public static Country[] GetCountry(string factoryLocationCode)
        {
            // #5. Analyze unit tests for the method, and add the method implementation.
            if (string.IsNullOrEmpty(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            string[][] lettersArray =
            {
            new string[]
            {
                "A0", "A1", "A2", "AA", "AAS", "AH", "AN", "AR", "AS", "BA", "BJ", "BU", "DR", "DU", "DR", "DT", "CO", "CT",
                "CX", "ET", "FL", "LW", "MB", "MI", "NO", "RA", "RI", "SD", "SF", "SL", "SN", "SP", "SR", "TJ", "TH", "TR", "TS", "VI", "VX",
            },
            new string[]
            {
                "LP", "OL",
            },
            new string[]
            {
                "BC", "BO", "CE", "FO", "MA", "OB", "RC", "RE", "SA", "TD",
            },
            new string[]
            {
                "CA", "LO", "LB", "LM", "LW", "GI",
            },
            new string[]
            {
                "DI", "FA",
            },
            new string[]
            {
                "FC", "FH", "LA", "OS", "SD", "FL",
            },
            };

            var list = new List<Country>();
            for (int i = 0; i < lettersArray.Length; i++)
            {
                for (int j = 0; j < lettersArray[i].Length; j++)
                {
                    if (factoryLocationCode == lettersArray[i][j])
                    {
                        list.Add((Country)i);
                    }
                }
            }

            return list.ToArray();
        }
    }
}
