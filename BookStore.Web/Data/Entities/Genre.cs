using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Web.Data.Entities
{
	public class Genre
	{

        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50), Unicode(false)]
        public string Name { get; set; }

		[Required, MaxLength(100), Unicode(false)]
		public string Slug { get; set; }

        public bool IsTop { get; set; }

		public virtual ICollection<GenreBooks> GenreBooks { get; set; } = new List<GenreBooks>();
	}
}
