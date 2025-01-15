
namespace dogMeet_adminSite.Model
{
    public class Address
    {
        public int id { get; set; }
        public int? profile_id { get; set; }
        public string country { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public int zip { get; set; }
        public string street { get; set; }
        public int houseNumber { get; set; }

        public Address() { }
    }
}
