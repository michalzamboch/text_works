using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;

namespace Model
{
    public sealed class Resx
    {
        public static List<string> FindDuplicatesFromFile()
        {
            var loadedText = FileManager.GetOpenFilePath();
            return TryFindDuplicateKeys(loadedText);
        }

        public static List<string> TryFindDuplicateKeys(string path)
        {
            try
            {
                return FindDuplicateKeys(path);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return new List<string>();
            }
        }

        private static List<string> FindDuplicateKeys(string path)
        {
            var duplicates = new List<string>();
            var keysSet = new HashSet<string>();
            var reader = new XmlTextReader(path);

            while (reader.Read())
            {
                string? key = reader.GetAttribute("name");

                if (!string.IsNullOrEmpty(key) && keysSet.Contains(key))
                {
                    duplicates.Add(key);
                }

                if (!string.IsNullOrEmpty(key))
                {
                    keysSet.Add(key);
                }
            }

            return duplicates;
        }
    }
}
