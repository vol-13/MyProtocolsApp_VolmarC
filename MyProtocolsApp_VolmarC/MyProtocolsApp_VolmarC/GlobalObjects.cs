using MyProtocolsApp_VolmarC.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProtocolsApp_VolmarC
{
    public static class GlobalObjects
    {
        //definimos las propiedades de codifición del los json 
        //que usaremos en los modelos 
        public static string MimeType = "application/json";
        public static string ContentType = "Content-Type";

        //crear el objeto local (global) de usuario 
        public static UserDTO MyLocalUser = new UserDTO();

    }
}
