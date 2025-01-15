using System;

namespace dogMeet_adminSite.Model
{
    public class DogHistory
    {
        public int id { get; set; }
        public string breededWith_Type { get; set; }
        public int kidsBorn { get; set; }
        public DateTime date { get; set; }
        public int? dog_id { get; set; }

        public DogHistory() { }
    }
}
