using System.Collections.Generic;
using System.Linq;

namespace KPZ_Lab2
{
    public static class Alphabet
    {
        private static readonly List<char> Numbers = new List<char>()
        {
            '0',
            '1',
            '2',
            '3',
            '4',
            '5',
            '6',
            '7',
            '8',
            '9'
        };

        private static readonly List<char> Letters = new List<char>()
        {
            'q',
            'w',
            'e',
            'r',
            't',
            'y',
            'u',
            'i',
            'o',
            'p',
            'a',
            's',
            'd',
            'f',
            'g',
            'h',
            'j',
            'k',
            'l',
            'z',
            'x',
            'c',
            'v',
            'b',
            'n',
            'm'
        };

        private static readonly List<char> Operations = new List<char>()
        {
            '+',
            '-',
            '*',
            '/',
            '<',
            '>',
            '='
        };

        private static readonly List<char> Brackets = new List<char>()
        {
            '(',
            ')',
            '[',
            ']',
            '{',
            '}'
        };

        private static readonly List<char> Separators = new List<char>()
        {
            ';',
            ' '
        };

        public static List<char> GetNumbers()
        {
            return Numbers;
        }

        public static List<char> GetLowerLetters()
        {
            return Letters;
        }

        public static List<char> GetUpperLetters()
        {
            var upper = Letters.Select(symbol => symbol.ToString().ToUpper().ToCharArray()[0]).ToList();
            return upper;
        }

        public static List<char> GetAllLetters()
        {
            var all = new List<char>(); 
            all.AddRange(GetLowerLetters());
            all.AddRange(GetUpperLetters());

            return all;
        } 
        public static List<char> GetOperations()
        {
            return Operations;
        }

        public static List<char> GetBrackets()
        {
            return Brackets;
        }

        public static List<char> GetSeparators()
        {
            return Separators;
        }

        public static List<char> GetW()
        {
            var w = new List<char>();
            w.AddRange(GetAllLetters());
            w.AddRange(GetNumbers());

            return w;
        }

        public static List<char> GetFullAlphabet()
        {
            var full = GetW();
            full.AddRange(GetOperations());
            full.AddRange(GetBrackets());
            full.AddRange(GetSeparators());

            return full;
        }
    }
}
