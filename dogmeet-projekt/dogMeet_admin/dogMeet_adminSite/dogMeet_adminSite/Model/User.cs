﻿
namespace dogMeet_adminSite.Model
{
    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        public User() { }
    }
}
