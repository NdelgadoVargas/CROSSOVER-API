using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CROSSOVER_API.Models
{
    public class ListarRepositoriosModel
    {
        public class SAL_RESP
        {
            public int id { get; set; }
            public string name { get; set; }

            public SAL_RESP_REPOSITORI owner { get; set; }
        }

        public class SAL_RESP_REPOSITORI
        {
            public string repos_url { get; set; }
        }
    }
}