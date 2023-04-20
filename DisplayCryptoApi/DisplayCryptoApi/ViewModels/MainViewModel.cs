using DisplayCryptoApi.Extensions;
using DisplayCryptoApi.Infrastructure;
using DisplayCryptoApiLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DisplayCryptoApi.ViewModels
{
    public class MainViewModel : BaseNotifyPropertyChanged
    {
        private CoinGeckoManager cgManager;

        private ObservableCollection<Coin> selectedCoins;
        public ObservableCollection<Coin> SelectedCoins
        {
            get
            {
                return selectedCoins;
            }
            set
            {
                selectedCoins = value;
                NotifyOfPropertyChanged();
            }
        }

        private Coin selectedCoin;
        public Coin SelectedCoin
        {
            get
            {
                return selectedCoin;
            }
            set
            {
                selectedCoin = value;
                NotifyOfPropertyChanged();
            }
        }

        private Coin selectedMoreDataCoin;
        public Coin SelectedMoreDataCoin
        {
            get
            {
                return selectedMoreDataCoin;
            }
            set
            {
                selectedMoreDataCoin = value;
                NotifyOfPropertyChanged();
            }
        }

        public MainViewModel()
        {
            cgManager = new CoinGeckoManager();

            //Coins = cgManager.GetCoins();
            SelectedCoins = cgManager.GetCoins();
            SelectedCoin = new Coin();

            InitCommands();
        }

        private void InitCommands()
        {
            SelectAllCointsCommand = new RelayCommand(param=>
            {
                Task.Run(() =>
                {
                    SelectedCoins = cgManager.GetCoins();
                });
            });
            SearchNameCommand = new RelayCommand(param =>
            {
                SelectedCoins = new ObservableCollection<Coin>();
                foreach (var coin in cgManager.GetCoins())
                {
                    if (coin.Name.StartsWith((string)param))
                    {
                        SelectedCoins.Add(coin);
                    }
                }
            });

            MoreDataCoinCommand = new RelayCommand(param =>
            {
                SelectedMoreDataCoin = cgManager.GetIdCoint(selectedCoin.Id);
                MessageBox.Show($"{selectedCoin.Id} = {SelectedMoreDataCoin.Id}");
            });

            SortPriceMaxToMinCommand = new RelayCommand(param =>
            {
                SelectedCoins = new ObservableCollection<Coin>();

                SelectedCoins = cgManager.GetCoins().OrderByDescending(c => c.Market_data.Current_price.Usd).ToObservableCollection();

            });
            SortPriceMinToMaxCommand = new RelayCommand(param =>
            {
                SelectedCoins = new ObservableCollection<Coin>();

                SelectedCoins = cgManager.GetCoins().OrderBy(c => c.Market_data.Current_price.Usd).ToObservableCollection();

            });

            SortVolumeMaxToMinCommand = new RelayCommand(param =>
            {
                SelectedCoins = new ObservableCollection<Coin>();

                SelectedCoins = cgManager.GetCoins().OrderByDescending(c => c.Market_data.Total_volume.Usd).ToObservableCollection();

            });
            SortVolumeMinToMaxCommand = new RelayCommand(param =>
            {
                SelectedCoins = new ObservableCollection<Coin>();

                SelectedCoins = cgManager.GetCoins().OrderBy(c => c.Market_data.Total_volume.Usd).ToObservableCollection();

            });
        }

        public ICommand SelectAllCointsCommand { get; private set; }

        public ICommand SearchNameCommand { get; private set; }
        public ICommand MoreDataCoinCommand { get; private set; }

        public ICommand SortPriceMaxToMinCommand { get; private set; }
        public ICommand SortPriceMinToMaxCommand { get; private set; }

        public ICommand SortVolumeMaxToMinCommand { get; private set; }
        public ICommand SortVolumeMinToMaxCommand { get; private set; }
    }
}
