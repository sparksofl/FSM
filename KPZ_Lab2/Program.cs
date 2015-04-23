using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace KPZ_Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            var s0 = new State(0);
            var s1 = new State(1);
            var s2 = new State(2);
            var s3 = new State(3);
            var s4 = new State(4);
            var s5 = new State(5);
            var s6 = new State(6);
            var s7 = new State(7);
            var s8 = new State(8);

            var states = new List<State> {s0, s1, s2, s3, s4, s5, s6, s7, s8};
            var finalStates = states;
            finalStates.Remove(s0);

            var list11 = Alphabet.GetW();
            list11.Remove('o');
            var list22 = Alphabet.GetW();
            list11.Remove('r');
            var listW = Alphabet.GetW();
            var listN = Alphabet.GetNumbers();
            var list05 = Alphabet.GetW();
            list05.Remove('f');
            var listS = Alphabet.GetSeparators();
            var listB = Alphabet.GetBrackets();
            var listO = Alphabet.GetOperations();

            var t01 = new Transition(s0, s1, 'f', LexicalUnit.LexType.None);
            var t04 = new Transition(s0, s4, listN, LexicalUnit.LexType.Const);
            var t05 = new Transition(s0, s5, list05, LexicalUnit.LexType.Identifier);
            var t06 = new Transition(s0, s6, listS, LexicalUnit.LexType.Separator);
            var t07 = new Transition(s0, s7, listB, LexicalUnit.LexType.Bracket);
            var t08 = new Transition(s0, s8, listO, LexicalUnit.LexType.Operation);
            var t11 = new Transition(s1, s1, list11, LexicalUnit.LexType.Identifier);
            var t12 = new Transition(s1, s2, 'o', LexicalUnit.LexType.Identifier);
            var t22 = new Transition(s2, s2, list22, LexicalUnit.LexType.Identifier);
            var t23 = new Transition(s2, s3, 'r', LexicalUnit.LexType.Identifier);
            var t33 = new Transition(s3, s3, listW, LexicalUnit.LexType.Identifier);
            var t44 = new Transition(s4, s4, listN, LexicalUnit.LexType.Const);
            var t55 = new Transition(s5, s5, listW, LexicalUnit.LexType.Identifier);
            var t66 = new Transition(s6, s6, listS, LexicalUnit.LexType.Separator);

            var transitions = new List<Transition>()
            {
                t01,
                t04,
                t05,
                t06,
                t07,
                t08,
                t11,
                t12,
                t22,
                t23,
                t33,
                t44,
                t55,
                t66
            };

            string expression = "for(i=0;i<10;i=i+1){a[i]=i;}";
            Console.WriteLine("Unparsed expression: \n" + expression);
            var m = new FSM(states, Alphabet.GetFullAlphabet(), transitions, s0, finalStates);
            Console.WriteLine("\nLexical units: ");
            Console.WriteLine(m.GetLexUnits("for(i=0;i<10;i=i+1){a[i]=i;}"));

            Console.WriteLine("\nIdentifiers (1):");
            foreach (var item in LexicalUnit.IdList)
            {
                Console.WriteLine(LexicalUnit.IdList.IndexOf(item) + " " + item);
            }
            
            Console.WriteLine("\nConst (2):");
            foreach (var item in LexicalUnit.CList)
            {
                Console.WriteLine(LexicalUnit.CList.IndexOf(item) + " " + item);
            }

            Console.WriteLine("\nOperations (3):");
            foreach (var item in LexicalUnit.OList)
            {
                Console.WriteLine(LexicalUnit.OList.IndexOf(item) + " " + item);
            }

            Console.WriteLine("\nBrackets (4):");
            foreach (var item in LexicalUnit.BList)
            {
                Console.WriteLine(LexicalUnit.BList.IndexOf(item) + " " + item);
            }

            Console.WriteLine("\nKey words (5):");
            foreach (var item in LexicalUnit.KeyList)
            {
                Console.WriteLine(LexicalUnit.KeyList.IndexOf(item) + " " + item);
            }

            Console.WriteLine("\nSeparators (6):");
            foreach (var item in LexicalUnit.SList)
            {
                Console.WriteLine(LexicalUnit.SList.IndexOf(item) + " " + item);
            }

            Console.WriteLine();
        }
    }
}