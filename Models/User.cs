using System;
using System.Collections.Generic;

namespace ushinsvc.Models
{
    #region Entities
    public class User
    {
        public User()
        {
            Nodes = new HashSet<Node>();
        }

        public long Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Created { get; set; }
        public string Modified { get; set; }
        public string Username { get; set; }

        public virtual ICollection<Node> Nodes { get; set; }
    }
    #endregion
}
