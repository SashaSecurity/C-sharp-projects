namespace TextLab
{
    public interface Token
    {
        string Value { get; set; }
        int Linenumber { get; set; }
    }
}