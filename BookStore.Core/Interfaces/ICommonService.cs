namespace BookStore.Core.Interfaces
{
    public interface ICommonService
    {
        bool IsWeb { get; }
        bool ISMobile { get; }
    }
}
