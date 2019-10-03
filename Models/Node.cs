using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ushinsvc.Models
{
    public class Node : TimestampEntity
    {
        public long Id { get; set; }
	[Required]
	[MaxLength(255)]
        public string Title { get; set; }
	[Required]
	[MaxLength(255)]
        public string Category { get; set; }
	public long? ParentNodeId { get; set; }
        public virtual Node ParentNode { get; set; }
        public virtual ICollection<Node> ChildNodes { get; set; }
	[Required]
	public long UserId { get; set; }
	public virtual User User { get; set; }
    }
}
