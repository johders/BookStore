﻿using BookStore.Core.Dtos;
using Refit;

namespace BookStore.Mobile.Services
{
    public interface IBookApi
    {
        [Get("/api/books/{bookId}")]
        Task<BookDetailsDto> GetBookAsync(int bookId);

        [Get("/api/books")]
        Task<PagedResult<BookListDto>> GetBooksAsync(int pageNo, int pageSize, string? genreSlug = null);

        [Get("/api/authors/{authorSlug}/books")]
        Task<PagedResult<BookListDto>> GetBooksByAuthorAsync(int pageNo, int pageSize, string authorSlug);

        [Get("/api/genres")]
        Task<GenreDto[]> GetGenresAsync(bool topOnly);

        [Get("/api/books/popular")]
        Task<BookListDto[]> GetPopularBooksAsync(int count, string? genreSlug = null);

        [Get("/api/books/{bookId}/similar")]
        Task<BookListDto[]> GetSimilarBooksAsync(int bookId, int count);
    }
}
