using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DrpBnd.Models
{
    
        public class stclass
        {
            public int sId { get; set; }
            public string sName { get; set; }
        }
    public class Dclass
    {
        public int DId { get; set; }
        public string DName { get; set; }
    }

    public class Insert
    {
        public int sId { get; set; }
        public string sName { get; set; }
        public int DId { get; set; }
        public string DName { get; set; }
        [Required(ErrorMessage ="Enter Your Name")]
        public string Name { get; set; }
        [Range(18,50,ErrorMessage ="Enter Valid Age")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Enter Your Address")]
        public string Address { get; set; }
        public string Msg { get; set; }
    }

}