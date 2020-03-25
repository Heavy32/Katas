using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace Cipher
{
    public class IterativeRotationCipher
    {
        private List<int> spacePositions { get; set; }
        private string inputText;
        public int n; // поменять

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
                inputText = Regex.Replace(inputText, @"\s+", ""); // string replace
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

        public void ReturnSpaces() // соединить в линк
        {
            //Enumerable.Range(0, spacePositions.Count).Select(x => inputText = inputText.Insert(spacePositions[x], " ")).ToString(); //????

            for (int i = 0; i < spacePositions.Count; i++)
                inputText = inputText.Insert(spacePositions[i], " ");
        }

        public void ShiftLettersInSubstring(int offset)/// в линк сплит.точка 
        {
            //var a = Enumerable.Range(0, inputText.Length).Select(x => inputText.Split(' ').Select(word => word[x]));

            string[] words = inputText.Split(' ');

            for (int i = 0; i < words.Length; i++)
                ShiftStringByNumber(ref words[i], offset);

            inputText = string.Join(" ", words);
        }

        public string Decode()
        {        
            n = SplitStringToNumberAndText().Item1;
            inputText = SplitStringToNumberAndText().Item2;

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

        public Tuple<int, string> SplitStringToNumberAndText()        
                 => new Tuple<int, string>(Convert.ToInt32(inputText.Split(new char[] { ' ' }, 2)[0]), inputText.Split(new char[] { ' ' }, 2)[1]);        
    }
}
