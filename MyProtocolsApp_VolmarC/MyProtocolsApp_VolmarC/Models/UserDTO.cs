using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;

namespace MyProtocolsApp_VolmarC.Models
{
    public class UserDTO
    {
        [JsonIgnore]
        public RestRequest Request { get; set; }

        public int IDUsuario { get; set; }
        public string Correo { get; set; } = null!;
        public string Contrasennia { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string CorreoRespaldo { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Direccion { get; set; }
        public bool? Activo { get; set; }
        public bool? EstaBloqueado { get; set; }
        public int IDRol { get; set; }
        public string DescripcionRol { get; set; } = null!;

        //FUNCIONES+
        public async Task<UserDTO> GetUserInfo(string PEmail)
        {

            try
            {
                string RouteSufix = string.Format("Users/GetUserInfoByEmail?Pemail={0}", PEmail);
                //armamos la ruta completa al endpoint en el API 
                string URL = Services.APIConnection.ProductionPrefixUrl + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Get);

                //agregamos mecanismo de seguridad, en este caso API key
                Request.AddHeader(Services.APIConnection.ApiKeyName, Services.APIConnection.ApiKeyValue);
                Request.AddHeader(GlobalObjects.ContentType, GlobalObjects.MimeType);

                //ejecutar la llamada al API 
                RestResponse response = await client.ExecuteAsync(Request);

                //saber si las cosas salieron bien 
                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    //en el api diseñamos el end point de forma que retorne un list<UserDTO>
                    //pero esta función retorna solo UN objeto de UserDTO, por lo tanto 
                    //debemos seleccionar de la lista el item con el index 0. 

                    //esto puede llegar a servir para muchos propósitos donde un api retorna uno o muchos registro
                    //pero necesitamos solo uno de ellos 

                    var list = JsonConvert.DeserializeObject<List<UserDTO>>(response.Content);

                    var item = list[0];

                    return item;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }

        }

        public async Task<bool> UpdateUserAsync()
        {
            try
            {
                string RouteSufix = string.Format("Users/{0}", IDUsuario);
                //armamos la ruta completa al endpoint en el API 
                string URL = Services.APIConnection.ProductionPrefixUrl + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Put);

                //agregamos mecanismo de seguridad, en este caso API key
                Request.AddHeader(Services.APIConnection.ApiKeyName, Services.APIConnection.ApiKeyValue);

                Request.AddHeader(GlobalObjects.ContentType, GlobalObjects.MimeType);

                //en el caso de una operación POST debemos serializar el objeto para pasarlo como 
                //json al API

                string SerializedModel = JsonConvert.SerializeObject(this);
                //agregamos el objeto serializado el el cuuerpo del request. 
                Request.AddBody(SerializedModel, GlobalObjects.MimeType);

                //ejecutar la llamada al API 
                RestResponse response = await client.ExecuteAsync(Request);

                //saber si las cosas salieron bien 
                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }

        }


    }
}
