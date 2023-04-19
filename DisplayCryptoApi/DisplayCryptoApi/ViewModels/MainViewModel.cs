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
        private ObservableCollection<Coin> coins;
        public ObservableCollection<Coin> Coins
        {
            get
            {
                return coins;
            }
            set
            {
                coins = value;
                NotifyOfPropertyChanged();
            }
        }

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

        public MainViewModel()
        {
            cgManager = new CoinGeckoManager();

            Coins = cgManager.GetCoins();
            SelectedCoins = cgManager.GetCoins();

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
                foreach (var coin in Coins)
                {
                    if (coin.Name.StartsWith((string)param))
                    {
                        SelectedCoins.Add(coin);
                    }
                }
            });

            SortPriceMaxToMinCommand = new RelayCommand(param =>
            {
                SelectedCoins = new ObservableCollection<Coin>();

                SelectedCoins = Coins.OrderByDescending(c => c.Market_data.Current_price.Usd).ToObservableCollection();

            });
            SortPriceMinToMaxCommand = new RelayCommand(param =>
            {
                SelectedCoins = new ObservableCollection<Coin>();

                SelectedCoins = Coins.OrderBy(c => c.Market_data.Current_price.Usd).ToObservableCollection();

            });

            SortVolumeMaxToMinCommand = new RelayCommand(param =>
            {
                SelectedCoins = new ObservableCollection<Coin>();

                SelectedCoins = Coins.OrderByDescending(c => c.Market_data.Total_volume.Usd).ToObservableCollection();

            });
            SortVolumeMinToMaxCommand = new RelayCommand(param =>
            {
                SelectedCoins = new ObservableCollection<Coin>();

                SelectedCoins = Coins.OrderBy(c => c.Market_data.Total_volume.Usd).ToObservableCollection();

            });
        }

        public ICommand SelectAllCointsCommand { get; private set; }

        public ICommand SearchNameCommand { get; private set; }

        public ICommand SortPriceMaxToMinCommand { get; private set; }
        public ICommand SortPriceMinToMaxCommand { get; private set; }

        public ICommand SortVolumeMaxToMinCommand { get; private set; }
        public ICommand SortVolumeMinToMaxCommand { get; private set; }
    }
}
