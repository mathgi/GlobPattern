namespace GlobPattern
{
    public class Start : IBase
    {
        private readonly IBase nextState;

        public Start(IBase state)
        {
            nextState = state;
        }

        public bool Match(string input, ref int index)
        {
            return nextState.Match(input, ref index);
        }
    }
}