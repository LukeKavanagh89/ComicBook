using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComicStore.Models
{
    public class Designer
    {
        private ICollection<Comic> _comics;
        public Designer()
        {
            _comics = new List<Comic>();

        }
        public int DesignerId { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public int Established { get; set; }

        public virtual ICollection<Comic> Comics
        {
            get { return _comics; }
            set { _comics = value; }
        }
    }
}