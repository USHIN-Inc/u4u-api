using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ushinsvc.Models
{
    public class TimestampEntity
    {
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
