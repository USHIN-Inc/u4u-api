using System;
namespace ushinsvc.Models
{
    public class User
    {
        public long id { get; set; }
        public string email { get; set; }
      
        public string password { get; set; }
        public DateTime created { get; set; }
        public DateTime modified { get; set; }
    }
}
