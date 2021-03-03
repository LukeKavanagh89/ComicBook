using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComicStore.Models
{
    public class Publisher
    {
        private ICollection<Comic> _comics;
        public Publisher()
        {
            _comics = new List<Comic>();

        }
        public int PublisherId { get; set; }
        public String Name { get; set; }
        public int Established { get; set; }
        
        public virtual ICollection<Comic> Comics
        {
            get { return _comics; }
            set { _comics = value; }
        }
    }
}