using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DAL6QM_HFT_2023241.Models
{
    public class Publisher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PublisherId { get; set; }
        [Required]
        [StringLength(240)]
        public string PublisherName { get; set; }

        [JsonIgnore]
        public virtual ICollection<Book> Books { get; set; }
        public Publisher()
        {

        }

        public Publisher(string line)
        {
            string[] split = line.Split('#');
            PublisherId = int.Parse(split[0]);
            PublisherName = split[1];
        }
    }
}
