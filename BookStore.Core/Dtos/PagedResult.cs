namespace BookStore.Core.Dtos
{
	public record PagedResult<TRecord>(TRecord[] Records, int TotalCount);
}
