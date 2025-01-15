
namespace dogMeet_adminSite.Model
{
    public class Profile
    {
        public int id { get; set; }
        public int? user_id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phoneNumber { get; set; }

        public Profile() { }
    }
}
