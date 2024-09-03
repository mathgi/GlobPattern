namespace GlobPattern
{
    public class ZeichenKlasse : IBase
    {
        private readonly char[] _characterClass;
        private readonly bool _isNegated;
        private readonly IBase _nextState;

        public ZeichenKlasse(char[] characterClass, bool isNegated, IBase nextState)
        {
            _characterClass = characterClass;
            _isNegated = isNegated;
            _nextState = nextState;
        }

        public bool Match(string input, ref int index)
        {
            if (index < input.Length)
            {
                bool match = Array.IndexOf(_characterClass, input[index]) >= 0;

                if (_isNegated)
                    match = !match;

                if (match)
                {
                    index++;
                    return _nextState.Match(input, ref index);
                }
            }
            return false;
        }
    }
}