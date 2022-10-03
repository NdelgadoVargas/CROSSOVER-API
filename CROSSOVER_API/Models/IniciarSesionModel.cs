using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CROSSOVER_API.Models
{
    public class IniciarSesionModel
    {
        public class data
        {
            public string email { get; set; }
            public int password { get; set; }
            public string token { get; set; }

        }

        public class SAL_RESP
        {
            public string id { get; set; }
            public int code { get; set; }
            public string message { get; set; }
            public SAL_RESP_INICIOSESION data { get; set; }

        }

        public class SAL_RESP_INICIOSESION
        {
            public string id { get; set; }
            public  int  Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Token { get; set; }
        }

    }
}