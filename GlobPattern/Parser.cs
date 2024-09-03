namespace GlobPattern
{
    public class Parser
    {
        private readonly Func<string, IBase, bool> _auswerter;

        public Parser() 
        { }

        public Parser(Func<string, IBase, bool> auswerter)
        {
            _auswerter = auswerter;
        }

        public bool IsMatch(string input, string pattern)
        {
            IBase startState = Parse(pattern);
            int index = 0;
            var result = startState.Match(input, ref index);
            if (result)
            {
                if (_auswerter != null)
                {
                    string parsedInput = input.Substring(0, index);
                    return _auswerter(parsedInput, startState);
                }
                return true;
            }
            return false;
        }

        public IBase Parse(string pattern)
        {
            IBase currentState = new End();

            for (int i = pattern.Length - 1; i >= 0; i--)
            {
                char c = pattern[i];

                if (c == '*')
                {
                    currentState = new Stern(currentState);
                }
                else if (c == '?')
                {
                    currentState = new Fragezeichen(currentState);
                }
                else if (c == ']')
                {
                    int start = i;
                    while (i > 0 && pattern[i] != '[') i--;
                    bool isNegated = pattern[i + 1] == '!';
                    char[] characterClass = pattern.Substring(i + (isNegated ? 2 : 1), start - i - (isNegated ? 2 : 1)).ToCharArray();
                    currentState = new ZeichenKlasse(characterClass, isNegated, currentState);
                }
                else
                {
                    currentState = new Zeichen(c, currentState);
                }
            }

            return new Start(currentState);
        }
    }
}
