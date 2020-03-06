using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Cipher
{
    public class IterativeRotationCipher
    {
        private string tempText;
        private List<int> spacePositions = new List<int>();

        public string Encode(string inputText, int n)
        {
            for (int i = 0; i < n; i++)
            {
                tempText = RemoveSpaces(inputText);
                spacePositions = WriteSpacePositions(inputText);
                tempText = ShiftTextByNumber(tempText, n);
                tempText = ReturnSpaces(tempText, spacePositions);
                tempText = ShiftLettersInSubstring(tempText, n);
                inputText = tempText;
            }

            return n + " " + tempText;
        }

        public string RemoveSpaces(string inputText)
        {
            for (int i = 0; i < inputText.Length; i++)
            {
                if (inputText[i] == ' ')
                {
                    inputText = inputText.Remove(i, 1);
                }
            }

            tempText = inputText;
            return tempText;
        }

        public List<int> WriteSpacePositions(string inputText)
        {
            for (int i = 0; i < inputText.Length; i++)
            {
                if (inputText[i] == ' ')
                {
                    spacePositions.Add(i);
                }
            }
            return spacePositions;
        }

        public string ShiftTextByNumber(string inputText, int offset)
        {
            string offsetEnding = inputText.Substring(inputText.Length - offset, offset);
            inputText = inputText.Remove(inputText.Length - offset, offset);
            return offsetEnding + inputText;
        }

        public string ReturnSpaces(string inputText, List<int> spacePositions)
        {
            string OutputText;
            this.spacePositions = spacePositions;
            int spaceIndex = 0;

            for (int i = 0; i < inputText.Length; i++) // брать сразу из массива 
            {
                if (spacePositions[spaceIndex] == i)
                {
                    inputText = inputText.Insert(spacePositions[spaceIndex], " ");
                    spaceIndex++;
                    if (spaceIndex == spacePositions.Count)
                        break;
                }
            }

            OutputText = inputText;
            return OutputText;
        }

        public string ShiftLettersInSubstring(string inputText, int offset)
        {
            string[] words;
            words = inputText.Split(' ');

            List<string> shiftedWords = new List<string>();
            foreach (var item in words)
            {
                shiftedWords.Add(LettersShift(item, offset));
            }

            return string.Join(" ", shiftedWords.ToArray());
        }

        public string LettersShift(string word, int offset)
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

            return new string(newWord);
        }


        public string Decode(string inputText)
        {
            int n = GetNumberFromBeginning(inputText);
            inputText = RemoveFirstNumber(inputText);

            for (int i = 0; i < n; i++)
            {
                tempText = ShiftLettersInSubstring(inputText, -n);
                //tempText = RemoveSpaces(tempText);
                spacePositions = WriteSpacePositions(inputText);
                tempText = LettersShift(tempText, -n);
                tempText = ReturnSpaces(tempText, spacePositions);
                inputText = tempText;
            }

            return tempText;
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
