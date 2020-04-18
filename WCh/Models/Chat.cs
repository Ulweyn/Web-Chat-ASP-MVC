using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WCh.Models
{
    public class Chat : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Messange> Messanges { get; set; }
        public Chat() : base("WCh5") { }

    }
}