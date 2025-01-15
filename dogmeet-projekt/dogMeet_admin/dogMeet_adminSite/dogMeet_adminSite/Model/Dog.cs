
namespace dogMeet_adminSite.Model
{
    public class Dog
    {
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string type { get; set; }
        public string gender { get; set; }
        public string description { get; set; }
        public int? owner_id { get; set; }

        public Dog() { }
    }
}
