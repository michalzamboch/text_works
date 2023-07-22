using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace text_works
{
    internal class FileManager
    {
        public static string GetOpenFilePath()
        {
            var dialog = new OpenFileDialog
            {
                FileName = "Document",
            };

            bool? result = dialog.ShowDialog();

            if (result == null)
            {
                Debug.Write("Loaded file is null.");
                return "";
            }
            if (result == false)
            {
                Debug.Write("Result of loaded file is false.");
                return "";
            }

            return dialog.FileName;
        }

        public static string LoadTextFromOpenedFile()
        {
            var filePath = GetOpenFilePath();
            Debug.Write(filePath);

            try
            {
                return File.ReadAllText(filePath);
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
                return "";
            }
        }

        public static List<string> LoadLinesFromOpenedFile()
        {
            var filePath = GetOpenFilePath();
            Debug.Write(filePath);

            try
            {
                return File.ReadAllLines(filePath).ToList();
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
                return new List<string>();
            }
        }

        public static void SaveText(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                Debug.Write("Input text is null.");
                return;
            }

            var fileName = GetSaveFilePath();
            if (string.IsNullOrEmpty(fileName))
            {
                Debug.Write("Incorrect save file name.");
                return;
            }

            try
            {
                File.WriteAllText(fileName, text);
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
            }
        }

        public static string GetSaveFilePath()
        {
            var dialog = new SaveFileDialog
            {
                FileName = "Result",
            };

            bool? result = dialog.ShowDialog();

            if (result == null)
            {
                Debug.Write("Save file is null.");
                return "";
            }
            if (result == false)
            {
                Debug.Write("Result of saved file is false.");
                return "";
            }
            return dialog.FileName;
        }
    }
}
