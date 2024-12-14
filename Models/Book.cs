using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CodeFirstDBContextProject.Models
{
    public class Book : BaseModel
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;
        public int PublisherId { get; set; }
        [JsonIgnore]
        public virtual Publisher Publisher { get; set; } = new();
        [JsonIgnore]
        public virtual ICollection<Author> Authors { get; set; } = new List<Author>(); 
    }
}
