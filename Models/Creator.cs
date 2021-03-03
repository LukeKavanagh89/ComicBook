using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComicStore.Models
{
    public class Creator
    {
        private ICollection<Comic> _comics;
        public Creator()
        {
            _comics = new List<Comic>();

        }
        public int CreatorId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Established { get; set; }

        public virtual ICollection<Comic> Comics
        {
            get { return _comics; }
            set { _comics = value; }
        }
    }
}