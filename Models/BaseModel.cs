using System.ComponentModel.DataAnnotations;

namespace CodeFirstDBContextProject.Models
{
    public abstract class BaseModel
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.UtcNow;
    }
}
