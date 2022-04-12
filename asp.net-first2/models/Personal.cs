using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace asp.net_first2.models
{
    public class Personal
    {
            public string name { get; set; }
            public string surname { get; set; }
            public string Tc { get; set; }
            public string telnum { get; set; }
            public string adress { get; set; }
            public DateTime Birthdate { get; set; }
            public int bloodid{ get; set; }
            public int Sex{ get; set; }
            public int poli_id { get; set;  }
            public int d_Id { get; set;  }
            public int user_Id{ get; set; }
            public int Title_Id{ get; set; }
    }
}