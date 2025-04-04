
namespace dogMeet_adminSite.Model
{
    public class DogPictures
    {
        public int id { get; set; }
        public string url { get; set; }
        public int? dog_id { get; set; }

        public DogPictures() { }
    }
}
