using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LegitarsasagT1.Entity
{
    [Table("Flight")]
    public class Flight : AbstractEntityBase
    {
        [Column("Airline")]
        [Required]
        public Airline Airline { get; set; }

        [Column("DepartureCity")]
        [Required]
        public City DepartureCity { get; set; }

        [Column("DestinationCity")]
        [Required]
        public City DestinationCity { get; set; }

        [Column("Distance")]
        [Required]
        public int Distance { get; set; }

        [Column("FlightTime")]
        [Required]
        public int FlightTime { get; set; }

        public Flight()
        {

        }
        public Flight(Airline airline, City departureCity, City destinationCity, int distance, int flightTime)
        {
            Airline = airline;
            DepartureCity = departureCity;
            DestinationCity = destinationCity;
            Distance = distance;
            FlightTime = flightTime;
        }
    }
}
