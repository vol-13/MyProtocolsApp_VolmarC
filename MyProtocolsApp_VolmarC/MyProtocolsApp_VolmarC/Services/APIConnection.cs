using System;
using System.Collections.Generic;
using System.Text;

namespace MyProtocolsApp_VolmarC.Services
{
    public static class APIConnection
    {
        //Acá definimos la direccion url ip o nombre de domio a la cual la app debe apuntar
        //Por comodidad la URL completa para consumir los recursos del API se hará
        //en formato: "Prefijo" + "Sufijo"
        //Donde el prefijo será la parte del url que no cambia y el sufijo sera variable
        //(nombre del controlador y sus parametros)

        public static string ProductionPrefixUrl = "http://192.168.100.25:45455/api/";

        public static string TestingPrefixURL = "http://192.168.100.25:45455/api/";

        public static string ApiKeyName = "Progra6ApiKey";

        public static string ApiKeyValue = "VolmarProgra6Abcd1997";
    }
}
