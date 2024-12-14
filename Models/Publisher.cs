using System.ComponentModel.DataAnnotations;

namespace CodeFirstDBContextProject.Models
{
    public class Publisher : BaseModel
    {
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        public virtual ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
