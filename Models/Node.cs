using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ushinsvc.Controllers;

namespace ushinsvc.Models
{
    public class Node
    {
        public Node()
        {
            InverseParent = new HashSet<Node>();
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public long? ParentId { get; set; }
        public string Created { get; set; }
        public string Modified { get; set; }
        public long UserId { get; set; }

        public virtual Node Parent { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Node> InverseParent { get; set; }
    }
}