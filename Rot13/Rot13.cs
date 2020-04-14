using System;
using System.Linq;

namespace Rot13
{
    public class Rot13
    {
        public string Encode(string word)      
         => new string(word.ToCharArray().Select(x => Convert.ToInt32(x)).Select(x =>
                                                   ((Char.IsLetter(Char.ConvertFromUtf32(x).ToCharArray()[0])) ?
                                                   ((x >= 97) ?
                                                   ((x + 13 > 122) ? 96 + (x + 13 - 122) : x + 13) :
                                                   ((x + 13 > 90) ? 64 + (x + 13 - 90) : x + 13))
                                                   : x))
                                                   .Select(x => Char.ConvertFromUtf32(x).ToCharArray()[0]).ToArray());

    }
}
