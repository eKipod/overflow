namespace overflow
{
    public interface IGlassFactory
    {
        IGlass CreateGlass(uint row, uint index, decimal poured);
    }
}