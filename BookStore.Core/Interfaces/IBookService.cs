﻿using BookStore.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Interfaces
{
	public interface IBookService
	{
		Task<BookDetailsDto> GetBookAsync(int bookId);
		Task<PagedResult<BookListDto>> GetBooksAsync(int pageNo, int pageSize, string? genreSlug = null);
		Task<PagedResult<BookListDto>> GetBooksByAuthorAsync(int pageNo, int pageSize, string authorSlug);
		Task<GenreDto[]> GetGenresAsync(bool topOnly);
		Task<BookListDto[]> GetPopularBooksAsync(int count, string? genreSlug = null);
		Task<BookListDto[]> GetSimilarBooksAsync(int bookId, int count);
	}
}
