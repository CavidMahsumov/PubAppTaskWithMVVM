using PubApp.Models;
using PubApp.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubApp.ViewModel
{
    public class MainViewModel
    {
        public MainWindow MainWindow { get; set; }
        public FakeRepo  PubRepository { get; set; }
        public ObservableCollection<Pub>  Pubs { get; set; }

        public MainViewModel()
        {
            PubRepository = new FakeRepo();
            Pubs = new ObservableCollection<Pub>(PubRepository.GetAll());
            
        }
    }
}
