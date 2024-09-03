namespace GlobPattern
{
    public class Zeichen : IBase
    {
        private readonly IBase nextState;
        private readonly char _zeichen;

        public Zeichen(char zeichen, IBase state)
        {
            _zeichen = zeichen;
            nextState = state;
        }

        public bool Match(string input, ref int index)
        {
            if (index < input.Length && input[index] == _zeichen)
            {
                index++;
                return nextState.Match(input, ref index);
            }
            else
                return false;
        }
    }
}