using PubApp.Commands;
using PubApp.Models;
using PubApp.Repository;
using PubApp.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PubApp.ViewModel
{
    public class MainViewModel:BaseViewModel
    {
        public MainWindow MainWindow { get; set; }
        public FakeRepo PubRepository { get; set; }
        private Pub pub;
        public ObservableCollection<Pub> PubCopy { get; set; }
        public Pub Pub
        {
            get { return pub; }
            set { pub = value; OnPropertyChanged(); }
        }

        private int count;

        public int Count
        {
            get { return count; }
            set { count = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Pub> Pubs { get; set; }
        public RelayCommand ShowHistoryCommand { get; set; }
        public RelayCommand BuyCommand { get; set; }
        public RelayCommand ResetCommand { get; set; }
        public RelayCommand SelectedItemChangedCommand { get; set; }
        public RelayCommand plusButtonClick { get; set; }
        public RelayCommand minusButtonClick { get; set; }

        public BuyViewModel BuyViewModel { get; set; }
        public ShowHistoryViewModel showhistory { get; set; }
        public MainViewModel()
        {
            PubRepository = new FakeRepo();
            Pubs = new ObservableCollection<Pub>(PubRepository.GetAll());
            PubCopy = new ObservableCollection<Pub>();

            SelectedItemChangedCommand = new RelayCommand((SelectedItem) =>
            {
                var item = SelectedItem as Pub;
                Pub = item;
                Count = 1;
                //MainWindow.Mimage.Source = new BitmapImage(new Uri(
                // Pub.ImagePath, UriKind.RelativeOrAbsolute));

            });

            BuyCommand = new RelayCommand((c) =>
              {
                  if (Count != 0)
                  {
                      var view = new BuyWindow();
                      
                      BuyViewModel = new BuyViewModel();
                      Pub.Count = Count;
                      BuyViewModel.Pub = Pub;
                        PubCopy.Add(Pub);

                      view.listbox.Items.Add(Pub);
                      view.DataContext = BuyViewModel;
                      view.ShowDialog();
                  }
                  
              }

            );
            plusButtonClick = new RelayCommand((p) =>
              {
                  if (Count!=0)
                  {
                      ++Count;
                  }
              }
            );
            minusButtonClick = new RelayCommand((m) =>
              {
                  if (Count != 0)
                  {
                      --Count;
                  }
              }
            );
            ResetCommand = new RelayCommand((r) =>
              {
                  Count = 0;
              }
            );
            ShowHistoryCommand = new RelayCommand((s) =>
              {
                  var view = new ShowHistoryVindow();
                  showhistory = new ShowHistoryViewModel();
                  showhistory.Pubb = PubCopy;
                  view.DataContext = showhistory;
                  view.ShowDialog();
              }
            );
           
        }
        

    }
}