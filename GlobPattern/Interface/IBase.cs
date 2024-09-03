namespace GlobPattern
{
    public interface IBase
    {
        public bool Match(string input, ref int index);
    }
}
