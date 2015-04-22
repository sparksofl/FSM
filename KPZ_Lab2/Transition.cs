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

        public Transition(State iState, State eState, List<char> sList)
        {
            InitialState = iState;
            EndState = eState;
            SymbolsList = sList;
        }

        public Transition(State iState, State eState, char c)
        {
            InitialState = iState;
            EndState = eState;
            SymbolsList = new List<char>() {c};
        }

        public bool IsEnabled(char c)
        {
            return this.SymbolsList.Contains(c);
        }
    }
}
