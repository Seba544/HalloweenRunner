namespace Events
{
    public record CollectCandyEvent(int Amount)
    {
        public int Amount { get; } = Amount;
    }
}