﻿using BookStore.Core.Dtos;
using BookStore.Core.Interfaces;
using System.Runtime.CompilerServices;

namespace BookStore.Web
{
    public static class BookEndPoints
    {
        public static IEndpointRouteBuilder MapBookEndpoints(this IEndpointRouteBuilder app)
        {

            app.MapGet("/api/books/{bookId:int}", async (int bookId, IBookService bookService) =>
            TypedResults.Ok(await bookService.GetBookAsync(bookId)));

            app.MapGet("/api/books", async (IBookService bookService, int pageNo, int pageSize, string? genreSlug = null) =>
            TypedResults.Ok(await bookService.GetBooksAsync(pageNo, pageSize, genreSlug)));

            app.MapGet("/api/authors/{authorSlug}/books", async (IBookService bookService, int pageNo, int pageSize, string authorSlug) =>
            TypedResults.Ok(await bookService.GetBooksByAuthorAsync(pageNo, pageSize, authorSlug)));

            app.MapGet("/api/genres", async (IBookService bookService, bool topOnly) =>
            TypedResults.Ok(await bookService.GetGenresAsync(topOnly)));

            app.MapGet("/api/books/popular", async (IBookService bookService, int count , string? genreSlug = null) =>
            TypedResults.Ok(await bookService.GetPopularBooksAsync(count, genreSlug)));

            app.MapGet("/api/books/{bookId:int}/similar", async (IBookService bookService, int bookId, int count) =>
            TypedResults.Ok(await bookService.GetSimilarBooksAsync(bookId, count)));

            return app;
        }
    } 
}
