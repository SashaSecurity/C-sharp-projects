namespace TextLab
{
    public interface Token
    {
        string Value { get; set; }
        int LineNumber { get;set }
    }
}