using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CodeFirstDBContextProject.Models
{
    /// <summary>
    /// Book Model
    /// </summary>
    public class Book : BaseModel
    {
        /// <summary>
        /// Title of the book
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;
        /// <summary>
        /// PublisherId which acts as Foreign Key
        /// </summary>
        public int PublisherId { get; set; }
        /// <summary>
        /// Indicates Publisher of the Book
        /// </summary>
        [JsonIgnore]
        public virtual Publisher Publisher { get; set; } = new();
        /// <summary>
        /// Indicates authors of the book
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<Author> Authors { get; set; } = new List<Author>(); 
    }
}
