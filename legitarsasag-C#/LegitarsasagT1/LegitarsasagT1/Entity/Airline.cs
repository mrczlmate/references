using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LegitarsasagT1.Entity
{
    [Table("Airline")]
    public class Airline : AbstractEntityBase
    {
        [Column("Airlines")]
        [Required]
        [MaxLength(100)]
        public string AirlineName { get; set; }

        public Airline()
        {

        }
        public Airline(string airlineName)
        {
            AirlineName = airlineName;
        }
    }
}
