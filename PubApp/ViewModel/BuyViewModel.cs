using PubApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubApp.ViewModel
{
   public class BuyViewModel:BaseViewModel
    {
        private Pub pub;

        public Pub Pub
        {
            get { return pub; }
            set { pub = value; OnPropertyChanged(); }
        }

    }
}
