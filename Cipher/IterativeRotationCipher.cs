using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace Cipher
{
    public class IterativeRotationCipher
    {
        private List<int> spacePositions = new List<int>();
        public string inputText;
        public int n;

        public IterativeRotationCipher(string inputText, int n)
        {
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
            while (Math.Abs(offset) > inputText.Length)
                offset -= (inputText.Length * Math.Sign(offset));

            if (offset > 0)
            {
                inputText = inputText.Substring(inputText.Length - offset, offset)
                          + inputText.Remove(inputText.Length - offset, offset);
            }
            else
            {
                inputText = inputText.Remove(0, Math.Abs(offset))
                          + inputText.Substring(0, Math.Abs(offset));
            }
        }

        public void ReturnSpaces()
        {
            for (int i = 0; i < spacePositions.Count; i++)
                inputText = inputText.Insert(spacePositions[i], " ");
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
            n = GetNumberFromBeginning();
            RemoveFirstNumber();

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

        public int GetNumberFromBeginning() =>
            Convert.ToInt32(inputText.Substring(0, inputText.IndexOf(' ') + 1));

        public void RemoveFirstNumber() =>
            inputText = inputText.Remove(0, inputText.IndexOf(' ') + 1);
    }
}
