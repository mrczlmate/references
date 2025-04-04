using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DAL6QM_HFT_2023241.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }
        [Required]
        [StringLength(240)]
        public string CategoryName { get; set; }

        [JsonIgnore]
        public virtual ICollection<Book> Books { get; set; }
        public Category()
        {

        }

        public Category(string line)
        {
            string[] split = line.Split('#');
            CategoryId = int.Parse(split[0]);
            CategoryName = split[1];
        }
    }
}
