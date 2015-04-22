using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPZ_Lab2
{
    internal class FSM
    {
        public List<State> AllStates { get; set; }
        public List<char> TermAlphabet { get; set; }
        public List<Transition> Transitions { get; set; }
        public State InitialState { get; set; }
        public List<State> FinalStates { get; set; }

        public FSM(List<State> allStates, List<char> termAlphabet, List<Transition> transitions, State initialState,
            List<State> finalStates)
        {
            AllStates = allStates;
            TermAlphabet = termAlphabet;
            Transitions = transitions;
            InitialState = initialState;
            FinalStates = finalStates;
        }

        public bool Check(string str)
        {
            var currentState = InitialState;
            var array = str.ToCharArray();
            var counter = 0;
            var found = false;

            foreach (var currentSymbol in array)
            {
                counter = 0;
                foreach (var transit in Transitions)
                {
                    counter++;
                    if (transit.InitialState == currentState && transit.IsEnabled(currentSymbol))
                    {
                        currentState = transit.EndState;
                        found = true;
                        break;
                    }
                    if (counter == Transitions.Count)
                        return false;
                    found = false;
                }
            }
            return found;
        }
    }
}
