namespace BookStore.Core.Dtos
{
	public record BookListDto(int Id, string Title, string Image, AuthorDto Author);

}
