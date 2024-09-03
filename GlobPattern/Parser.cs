namespace GlobPattern
{
    public class Parser
    {
        public static bool IsMatch(string input, string pattern)
        {
            IBase startState = Parse(pattern);
            int index = 0;
            return startState.Match(input, ref index);
        }

        public static IBase Parse(string pattern)
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
