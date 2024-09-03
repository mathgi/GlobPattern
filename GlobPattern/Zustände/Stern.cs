namespace GlobPattern
{
    internal class Stern : IBase
    {
        private readonly IBase _nextState;

        public Stern(IBase nextState)
        {
            _nextState = nextState;
        }

        public bool Match(string input, ref int index)
        {
            for (int i = index; i <= input.Length; i++)
            {
                int tempIndex = i;
                if (_nextState.Match(input, ref tempIndex))
                {
                    index = tempIndex;
                    return true;
                }
            }
            return false;
        }
    }
}
