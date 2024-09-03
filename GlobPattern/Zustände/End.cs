namespace GlobPattern
{
    public class End : IBase
    {
        public bool Match(string input, ref int index)
        {
            if (index == input.Length) return true;

            return false;
        }

    }
}
