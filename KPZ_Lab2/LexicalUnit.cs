using System.Collections.Generic;

namespace KPZ_Lab2
{
    class LexicalUnit
    {
        public enum LexType { Identifier = 1, Const = 2, Operation = 3, Bracket = 4, KeyWord = 5, Separator = 6, None = 0 };

        public LexType Type { get; set; }
        public string Item { get; set; }
        public static List<string> IdList = new List<string>();
        public static List<string> CList = new List<string>();
        public static List<string> BList = new List<string>();
        public static List<string> OList = new List<string>();
        public static List<string> SList = new List<string>();
        public static List<string> KeyList = new List<string>();

        public LexicalUnit(string item, LexType type)
        {
            Item = item;

            if (item == "for")
            {
                Type = LexType.KeyWord;
                KeyList.Add(item);
            }
            else
            {
                Type = type;

                switch (type)
                {
                    case (LexType.Identifier):
                        if (!IdList.Contains(item))
                            IdList.Add(item);
                        break;
                    case (LexType.Const):
                        if (!CList.Contains(item)) 
                            CList.Add(item);
                        break;
                    case (LexType.Bracket):
                        if (!BList.Contains(item))
                            BList.Add(item);
                        break;
                    case (LexType.Operation):
                        if (!OList.Contains(item))
                            OList.Add(item);
                        break;
                    case (LexType.Separator):
                        if (!SList.Contains(item))
                            SList.Add(item);
                        break;
                }
            }
        }
    }
}
