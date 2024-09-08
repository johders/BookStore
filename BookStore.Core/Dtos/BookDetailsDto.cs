namespace BookStore.Core.Dtos
{
	public record BookDetailsDto(int Id, string Title, string Image, AuthorDto Author, int NumPages, string Format,
		string Description, GenreDto[] Genres, string? BuyLink)
	{
		public string BookLink => string.IsNullOrWhiteSpace(BuyLink) 
			? $"https://www.google.com/search?q={Title.Replace(" ", "+")}+by+{Author.Name.Replace(" ", "+")}" : BuyLink;

	}


}
