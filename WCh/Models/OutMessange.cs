using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCh.Models
{
    public class OutMessange
    {
        public int ID { get; set; }
        public string Nik { get; set; }
        public string Content { get; set; }
        public DateTime Moment { get; set; }
    }
}