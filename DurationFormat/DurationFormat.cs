using System.Collections.Generic;
using System.Linq;

namespace DurationFormat
{
    public class DurationFormat
    {
        public int Seconds { get; set; }
        public List<string> Answer { get; set; }

        public DurationFormat(int seconds)
        {
            Seconds = seconds;
            Answer = new List<string>();
        }

        public string FormatDuration()
        {
            if (Seconds == 0)
                return "now";

            ConvertSecondsToDurationElement("year", 31536000);
            ConvertSecondsToDurationElement("day", 86400);
            ConvertSecondsToDurationElement("hour", 3600);
            ConvertSecondsToDurationElement("minute", 60);
            ConvertSecondsToDurationElement("second", 1);

            FormatLastElement();

            return Answer.Aggregate("", (a, b) => a + b);
        }

        private void FormatLastElement()
        {
            if (Answer.Count > 1)
            {
                Answer[Answer.Count - 2] = Answer[Answer.Count - 2].Replace(",", "");
                Answer[Answer.Count - 1] = "and " + Answer[Answer.Count - 1];
            }

            string lastFormation = Answer[Answer.Count - 1];
            lastFormation = lastFormation.Remove(lastFormation.Length - 2, 2);
            Answer[Answer.Count - 1] = lastFormation;
        }

        private void ConvertSecondsToDurationElement(string elementName, int secondsInElement)
        {
            if (Seconds / secondsInElement > 0)
            {
                if (Seconds / secondsInElement > 1)
                {
                    Answer.Add($"{Seconds / secondsInElement} {elementName}s, ");
                }
                else
                {
                    Answer.Add($"{Seconds / secondsInElement} {elementName}, ");
                }

                Seconds -= secondsInElement * (Seconds / secondsInElement);
            }
        }
    }
}
