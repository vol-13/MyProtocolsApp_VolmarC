﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MyProtocolsApp_VolmarC.Models
{
    public class ProtocolCategory
    {
        public ProtocolCategory()
        {
            //Protocols = new HashSet<Protocol>();
        }

        public int ProtocolCategory1 { get; set; }
        public string Description { get; set; } = null!;
        public int UserId { get; set; }

        //public virtual User? User { get; set; } = null!;
        //public virtual ICollection<Protocol>? Protocols { get; set; }
    }
}

