using Microsoft.Win32;
using System.Diagnostics;

namespace text_works
{
    internal class FileOpener
    {
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
    }
}
