using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubApp.Models
{
   public class Pub:Entity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public double Volume { get; set; }
    }
}
