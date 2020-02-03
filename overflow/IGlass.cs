namespace overflow
{
    public interface IGlass
    {
        uint Index { get; }
        uint Row { get; }
        decimal Spill { get; }
        decimal Fill { get; }
    }
}