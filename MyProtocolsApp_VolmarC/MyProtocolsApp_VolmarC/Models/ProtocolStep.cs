using System;
using System.Collections.Generic;
using System.Text;

namespace MyProtocolsApp_VolmarC.Models
{
    public class ProtocolStep
    {
        public int ProtocolStepsId { get; set; }
        public string Step { get; set; } = null!;
        public string? Description { get; set; }
        public int UserId { get; set; }
    }
}
