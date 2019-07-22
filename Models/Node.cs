using System;
namespace ushinsvc.Models
{
    public class Node
    {
        public long id { get; set; }
        public string title { get; set; }
        public string category { get; set; }
        public long parent_id { get; set; }

        public DateTime created { get; set; }
        public DateTime modified { get; set; }
        public long user_id { get; set; }
    }
}