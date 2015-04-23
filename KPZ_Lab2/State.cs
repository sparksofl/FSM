namespace KPZ_Lab2
{
    internal class State
    {
        public int Number { get; set; }
        public bool IsFinal { get; set; }

        public State(int number, bool isFinal)
        {
            Number = number;
            IsFinal = isFinal;
        }

        public State(int number)
            : this(number, number != 0)
        {
        }
    }
}