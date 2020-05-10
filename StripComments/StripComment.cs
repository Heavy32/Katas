using System.Linq;

namespace StripComments
{
    class StripComment
    {
        public static string StripComments(string text, string[] commentSymbols)
        {
            var lines = text.Split('\n');

            for (int i = 0; i < commentSymbols.Length; i++)
            {
                lines = lines.Select(x => x.Substring(0, (x.Contains(commentSymbols[i]) ? x.IndexOf(commentSymbols[i]) : x.Length)).TrimEnd()).ToArray();
            }

            return string.Join('\n', lines);
        }
    }
}
