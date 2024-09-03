namespace GlobPattern
{
    public class Fragezeichen : IBase
    {
        private readonly IBase _nextState;

        public Fragezeichen(IBase nextState)
        {
            _nextState = nextState;
        }

        public bool Match(string input, ref int index)
        {
            if (index < input.Length)
            {
                index++;
                return _nextState.Match(input, ref index);
            }
            return false;
        }
    }
}
