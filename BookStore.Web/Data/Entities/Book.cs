﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Web.Data.Entities
{
	public class Book
	{
		[Key]
        public int Id { get; set; }

		[Required, MaxLength(120)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required, MaxLength(30), Unicode(false)]
        public string Format { get; set; }

        [Required, Range(1, int.MaxValue)]
        public int NumberOfPages { get; set; }

        [Required, MaxLength(150), Unicode(false)]
        public string Image { get; set; }

        [MaxLength(250)]
        public string? BuyLink { get; set; }

        public int AuthorId { get; set; }

        [ForeignKey(nameof(AuthorId))]
        public virtual Author Author { get; set; }

        public virtual ICollection<GenreBooks> BookGenres { get; set; } = new List<GenreBooks>();
    }
}
