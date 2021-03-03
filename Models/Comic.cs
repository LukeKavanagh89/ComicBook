using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComicStore.Models
{
    public class Comic
    {
        private ICollection<Creator> _creators;
        public Comic()
        {
            _creators = new List<Creator>();
        }
        public int ComicId { get; set; }
        public string Name { get; set; }
        public int Shop { get; set; }
        public int Established { get; set; }

        public virtual ICollection<Creator> Creators

        {
            get { return _creators; }
            set { _creators = value; }
        }



    }
}