using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CROSSOVER_API.Models
{
    public class CreateUsuarioModel
    {
        public class data
        {
            public string name { get; set; }
            public string email { get; set; }
            public string password { get; set; }
        }

        public class SAL_RESP
        {
            public int code { get; set; }
            public string message { get; set; }
            public SAL_RESP_CREATE data { get; set; }
        }

        public class SAL_RESP_CREATE
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Token { get; set; }
        }

    }
}