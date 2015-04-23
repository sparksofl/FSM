using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPZ_Lab2
{
    class Transition
    {
        public State InitialState { get; set; }
        public State EndState { get; set; }
        public List<char> SymbolsList { get; set; }
        public LexicalUnit.LexType Type { get; set; }

        public Transition(State iState, State eState, List<char> sList, LexicalUnit.LexType type)
        {
            InitialState = iState;
            EndState = eState;
            SymbolsList = sList;
            Type = type;
        }

        public Transition(State iState, State eState, char c, LexicalUnit.LexType type) : this(iState, eState, new List<char>() {c}, type)
        {
        }

        public bool IsEnabled(char c)
        {
            return this.SymbolsList.Contains(c);
        }
    }
}
