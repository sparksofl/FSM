using System.Collections.Generic;
using System.Linq;

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

        public string GetLexUnits(string str)
        {
            var result = "";
            var type = LexicalUnit.LexType.None;
            var currentState = InitialState;
            str += ' ';
            var array = str.ToCharArray();
            var temp = "";

            for (var i = 0; i < array.Length; i++)
            {
                var counter = 0;
                foreach (var transit in Transitions)
                {
                    if (!TermAlphabet.Contains(array[i]))
                        return "ERROR. Entered symbols does not match terminal alphabet.";
                    counter++;
                    if (transit.InitialState == currentState && transit.IsEnabled(array[i]))
                    {
                        temp += array[i];
                        currentState = transit.EndState;
                        type = transit.Type;
                        break;
                    }
                    if (counter != Transitions.Count) continue;
                    if (temp == "for")
                        type = LexicalUnit.LexType.KeyWord;

                    if (!temp.Contains(' '))
                    {
                        var l = new LexicalUnit(temp, type);
                        var s = "";

                        switch (type)
                        {
                            case (LexicalUnit.LexType.Identifier):
                                s = LexicalUnit.IdList.IndexOf(temp).ToString();
                                break;
                            case (LexicalUnit.LexType.Const):
                                s = LexicalUnit.CList.IndexOf(temp).ToString();
                                break;
                            case (LexicalUnit.LexType.Bracket):
                                s = temp;
                                break;
                            case (LexicalUnit.LexType.Operation):
                                s = temp;
                                break;
                            case (LexicalUnit.LexType.Separator):
                                s = temp;
                                break;
                            case (LexicalUnit.LexType.KeyWord):
                                s = LexicalUnit.KeyList.IndexOf(temp).ToString();
                                break;
                        }
                        result += "(" + (int) l.Type + "," + s + ")";
                    }
                    temp = "";
                    i--;
                    currentState = InitialState;
                }
            }
            return result;
        }
    }
}
