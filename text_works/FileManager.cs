﻿using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;

namespace text_works
{
    internal class FileManager
    {
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

        public static string GetOpenFilePath()
        {
            var dialog = new OpenFileDialog
            {
                FileName = "Document",
                DefaultExt = ".txt",
                Filter = "Text documents (.txt)|*.txt"
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

        public static void SaveText(string text)
        {
            if (text == null)
            {
                Debug.Write("Input text is null.");
                return;
            }

            var fileName = GetSaveFilePath();
            if (fileName == null || fileName == "")
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
                DefaultExt = ".txt",
                Filter = "Text documents (.txt)|*.txt"
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