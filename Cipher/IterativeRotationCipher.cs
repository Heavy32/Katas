using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace Cipher
{
    public class IterativeRotationCipher
    {
        private List<int> spacePositions { get; set; }
        public string inputText;
        public int n;

        public IterativeRotationCipher(string inputText, int n)
        {
            spacePositions = new List<int>();
            this.inputText = inputText;
            this.n = n;
        }

        public string Encode()
        {
            for (int i = 0; i < n; i++)
            {
                WriteSpacePositions();
                inputText = Regex.Replace(inputText, @"\s+", "");
                ShiftStringByNumber(ref inputText, n);
                ReturnSpaces();
                ShiftLettersInSubstring(n);
            }

            return n + " " + inputText;
        }

        public void WriteSpacePositions()
        {
            spacePositions = Enumerable.Range(0, inputText.Length)
                                       .Where(x => inputText[x] == ' ')
                                       .ToList();
        }

        public void ShiftStringByNumber(ref string inputText, int offset)
        {
            offset %= inputText.Length;

            inputText = (offset >= 0) ? (inputText.Substring(inputText.Length - offset, offset) + inputText.Substring(0, inputText.Length - offset))
                                      : (inputText.Substring(-offset, inputText.Length + offset) + inputText.Substring(0, -offset));

        }

        public void ReturnSpaces()
        {
            int i = 0;
            string a = "123";
            inputText = inputText.Aggregate("", func: (a, b) => (inputText.IndexOf(b) + i != spacePositions[i]) ? a + b : a + " " + b + ((i < spacePositions.Count) ? "" + (null * i++) : ""));
        }

        public void ShiftLettersInSubstring(int offset)
        {
            string[] words = inputText.Split(' ');

            for (int i = 0; i < words.Length; i++)
                ShiftStringByNumber(ref words[i], offset);

            inputText = string.Join(" ", words);
        }

        public string Decode()
        {
            n = SplitStringToNumberAndText().number;
            inputText = SplitStringToNumberAndText().textToDecode;

            for (int i = 0; i < n; i++)
            {
                ShiftLettersInSubstring(-n);
                WriteSpacePositions();
                inputText = Regex.Replace(inputText, @"\s+", "");
                ShiftStringByNumber(ref inputText, -n);
                ReturnSpaces();
            }
            
            return inputText;
        }

        public (int number, string textToDecode) SplitStringToNumberAndText()
        {
            int number = Convert.ToInt32(inputText.Split(new char[] { ' ' }, 2)[0]);
            string textToDecode = inputText.Split(new char[] { ' ' }, 2)[1];
            return (number, textToDecode);
        }              
    }
}
