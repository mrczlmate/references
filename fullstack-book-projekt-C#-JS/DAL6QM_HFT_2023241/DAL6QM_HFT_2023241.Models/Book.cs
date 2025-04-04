using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DAL6QM_HFT_2023241.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }
        [Required]
        [StringLength(240)]
        public string Title { get; set; }
        [JsonIgnore]
        public int CategoryId { get; set; }
        [JsonIgnore]
        public int AuthorId { get; set; }
        [JsonIgnore]
        public int PublisherId { get; set; }
        public int Price { get; set; }

        public virtual Author Author { get; set; }
        public virtual Category Category { get; set; }
        public virtual Publisher Publisher { get; set; }

        public Book()
        {

        }

        public Book(string line)
        {
            string[] split = line.Split('#');
            BookId = int.Parse(split[0]);
            Title = split[1];
            CategoryId = int.Parse(split[2]);
            AuthorId = int.Parse(split[3]);
            PublisherId = int.Parse(split[4]);
            Price = int.Parse(split[5]);
        }
    }
}
