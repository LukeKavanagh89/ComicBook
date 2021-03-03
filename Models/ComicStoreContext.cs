using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace ComicStore.Models
{
    public class ComicStoreContext : DbContext
    {
        public ComicStoreContext() : base("ComicStoreContex")
        {

        }

        public DbSet<Comic> Comics { get; set; }
        public DbSet<Designer> Designers { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Creator> Creators { get; set; }
      
    }
}