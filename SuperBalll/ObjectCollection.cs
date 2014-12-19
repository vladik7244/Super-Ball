using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperBalll
{
    class ObjectCollection
    {
        public List<GameObject> Items;
        public List<IAnimation> Animated;
        public ObjectCollection()
        {
            Items = new List<GameObject>();
            Animated = new List<IAnimation>();
        }
        
    }
}
