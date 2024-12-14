using System.ComponentModel.DataAnnotations;

namespace CodeFirstDBContextProject.Models
{
    public class Author : BaseModel
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
