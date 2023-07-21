using System.Windows.Controls;

namespace text_works
{
    public class Status : IStatus
    {
        private readonly TextBlock? textBlock;

        public Status(TextBlock block)
        {
            textBlock = block ?? new();
        }

        public void Clear()
        {
            textBlock!.Text = string.Empty;
        }

        public void Set(string text)
        {
            textBlock!.Text = text;
        }
    }
}
