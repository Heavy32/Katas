using System;
using System.Linq;

namespace Rot13
{
    public class Rot13
    {
        public string Encode(string word)
         => new string(word.Select(x => char.IsLetter(x) ? (x >= 65 && x <= 77) || (x >= 97 && x <= 109) ? (char)(x + 13) : (char)(x - 13) : x).ToArray());
    }
}
