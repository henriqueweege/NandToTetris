using System.Text;

namespace JackAnalyzer
{
    public static class StringBuilderExtensions
    {
        public static void NewLine(this StringBuilder sB)
        {
            sB.AppendLine();
        }

        public static void Append(this StringBuilder sB, string value)
        {
            sB.Append($"{value}");
        }
        public static void AddOpenTag(this StringBuilder sB, string token, string identation)
        {
            sB.Append($"{identation}<{token}>");
        }

        public static void AddCloseTag(this StringBuilder sB,string token, string identation)
        {
            sB.Append($"{identation}</{token}>");
        }
    }
}
