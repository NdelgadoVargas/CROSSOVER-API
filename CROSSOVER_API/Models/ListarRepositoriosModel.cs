using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CROSSOVER_API.Models
{
    public class ListarRepositoriosModel
    {
        public class Header
        {
            public string id { get; set; }
            public string node_id { get; set; }
            public string name { get; set; }
            public string full_name { get; set; }

            public bool privado { get; set; }
            public body_obj owner { get; set; }
        }

        public class body_obj
        {
            public string repos_url { get; set; }
        }
    }
}