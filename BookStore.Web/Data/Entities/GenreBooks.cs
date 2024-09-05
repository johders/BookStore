using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Web.Data.Entities
{
	public class GenreBooks
	{
        public int GenreId { get; set; }
        public int BookId { get; set; }

        [ForeignKey(nameof(BookId))]
        public virtual Book Book { get; set; }

        [ForeignKey(nameof(GenreId))]
        public virtual Genre Genre { get; set; }
    }
}
