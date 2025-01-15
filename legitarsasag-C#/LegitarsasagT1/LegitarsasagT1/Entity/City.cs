using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LegitarsasagT1.Entity
{
    [Table("City")]
    public class City : AbstractEntityBase
    {
        [Column("Cities")]
        [Required]
        [MaxLength(100)]
        public string CityName { get; set; }

        [Column("Population")]
        [Required]
        public int Population { get; set; }

        public City()
        {

        }
        public City(string cityName, int population)
        {
            CityName = cityName;
            Population = population;
        }
    }
}