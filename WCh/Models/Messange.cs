using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCh.Models
{
    public class Messange
    {
        public int ID { get; set; }
        public int IdUser { get; set; }
        public string Content { get; set; }
        public DateTime Moment { get; set; }
    }
}