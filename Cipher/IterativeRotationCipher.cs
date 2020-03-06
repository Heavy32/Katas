using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace Cipher
{
    public class IterativeRotationCipher
    {
        private List<int> spacePositions = new List<int>();

        public string Encode(string inputText, int n)
        {
            for (int i = 0; i < n; i++)
            {
                WriteSpacePositions(inputText);
                inputText = Regex.Replace(inputText, @"\s+", "");
                ShiftTextByNumber(ref inputText, n);
                ReturnSpaces(ref inputText);
                ShiftLettersInSubstring(ref inputText, n);
            }

            return n + " " + inputText;
        }

        public void WriteSpacePositions(string inputText)
        {
            spacePositions = Enumerable.Range(0, inputText.Length)
                                       .Where(x => inputText[x] == ' ')
                                       .ToList();
        }

        public void ShiftTextByNumber(ref string inputText, int offset)
        {
            string offsetEnding = inputText.Substring(inputText.Length - offset, offset);
            inputText = offsetEnding + inputText.Remove(inputText.Length - offset, offset);
        }

        public void ReturnSpaces(ref string inputText)
        {
            for (int i = 0; i < spacePositions.Count; i++)
                inputText = inputText.Insert(spacePositions[i], " ");
        }

        public void ShiftLettersInSubstring(ref string inputText, int offset)
        {
            string[] words = inputText.Split(' ');

            for (int i = 0; i < words.Length; i++)
                LettersShift(ref words[i], offset);

            inputText = string.Join(" ", words);
        }

        public void LettersShift(ref string word, int offset)
        {
            int step = Math.Abs(offset);
            char[] newWord = new char[word.Length];

            for (int i = 0; i < word.Length; i++)
            {
                while (i + step >= word.Length)
                    step -= word.Length;

                if (offset > 0) // might be done better
                    newWord[i + step] = word[i];
                else
                    newWord[i] = word[i + step];
            }

            word = new string(newWord);
        }


        public string Decode(string inputText)
        {
            return "2";
            //int n = GetNumberFromBeginning(inputText);
            //inputText = RemoveFirstNumber(inputText);

            //for (int i = 0; i < n; i++)
            //{
            //    tempText = ShiftLettersInSubstring(inputText, -n);
            //    tempText = RemoveSpaces(tempText);
            //    spacePositions = WriteSpacePositions(inputText);
            //    tempText = LettersShift(tempText, -n);
            //    tempText = ReturnSpaces(tempText, spacePositions);
            //    inputText = tempText;
            //}

            //return tempText;
        }

        public int GetNumberFromBeginning(string inputText)
        {
            string[] words = inputText.Split(' ');
            return Convert.ToInt32(words[0]);
        }

        public string RemoveFirstNumber(string inputText)
        {
            string[] words = inputText.Split(' ');
            List<string> wordsList = new List<string>(words);
            wordsList.RemoveAt(0);
            return string.Join(" ", wordsList.ToArray());
        }
    }
}
