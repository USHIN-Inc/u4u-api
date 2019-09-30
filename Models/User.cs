using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ushinsvc.Models
{
    public class User
    {
        public long Id { get; set; }
	[Required]
	[MaxLength(255)]
        public string Username { get; set; }
	[Required]
	[MaxLength(255)]
        public string Password { get; set; }
	[MaxLength(255)]
        public string Email { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public virtual ICollection<Node> Nodes { get; set; }
    }
}
