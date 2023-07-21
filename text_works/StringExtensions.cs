using System;
using System.Collections.Generic;

namespace text_works
{
    public static class StringExtensions
    {
        private static readonly Dictionary<char, char> specialChars = new()
        {
            { 'ě', 'e' },
            { 'č', 'c' },
            { 'ř', 'r' },
            { 'ž', 'z' },
            { 'á', 'a' },
            { 'í', 'i' },
            { 'é', 'e' },
            { 'ó', 'o' },
            { 'ú', 'u' },
            { 'ů', 'u' },
            { 'ť', 't' },
            { 'ď', 'd' },
            { 'ň', 'n' },
            { 'š', 's' },
            { 'ý', 'y' },
            { 'Ě', 'E' },
            { 'Č', 'C' },
            { 'Ř', 'R' },
            { 'Ž', 'Z' },
            { 'Á', 'A' },
            { 'Í', 'I' },
            { 'É', 'E' },
            { 'Ó', 'O' },
            { 'Ú', 'U' },
            { 'Ů', 'U' },
            { 'Ť', 'T' },
            { 'Ď', 'D' },
            { 'Ň', 'N' },
            { 'Š', 'S' },
            { 'Ý', 'Y' },
        };

        public static IReadOnlyDictionary<char, char> SpecialCharecters => specialChars;

        public static string RemoveDiacritics(this string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }

            string output = "";
            foreach (var c in input)
            {
                if (specialChars.ContainsKey(c))
                {
                    output += specialChars[c];
                }
                else
                {
                    output += c;
                }
            }

            return output;
        }
    }
}
