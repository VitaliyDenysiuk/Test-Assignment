using DisplayCryptoApi.Extensions;
using DisplayCryptoApi.Infrastructure;
using DisplayCryptoApiLib;
using DisplayCryptoApiLib.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

        private string isEnabledGrid;
        public string IsEnabledGrid
        {
            get
            {
                return isEnabledGrid;
            }
            set
            {
                isEnabledGrid = value;
                NotifyOfPropertyChanged();
            }
        }
        private string visibilityListCoin;
        public string VisibilityListCoin
        {
            get
            {
                return visibilityListCoin;
            }
            set
            {
                visibilityListCoin = value;
                NotifyOfPropertyChanged();
            }
        }
        private string visibilityListMarket;
        public string VisibilityListMarket
        {
            get
            {
                return visibilityListMarket;
            }
            set
            {
                visibilityListMarket = value;
                NotifyOfPropertyChanged();
            }
        }


        private Ticker selectedTicker;
        public Ticker SelectedTicker
        {
            get
            {
                return selectedTicker;
            }
            set
            {
                selectedTicker = value;
                NotifyOfPropertyChanged();
            }
        }

        public MainViewModel()
        {
            cgManager = new CoinGeckoManager();

            
            SelectedCoins = cgManager.GetCoins();
            SelectedCoin = new Coin();

            IsEnabledGrid = "true";
            VisibilityListCoin = "Visible";
            VisibilityListMarket = "Hidden";

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
                VisibilityListCoin = "Hidden";
                VisibilityListMarket = "Visible";
                IsEnabledGrid = "false";
            });
            LinkMarketCommand = new RelayCommand(param =>
            {
                try
                {
                    Process.Start(SelectedTicker.Trade_url);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });
            BackCommand = new RelayCommand(param =>
            {
                VisibilityListCoin = "Visible";
                VisibilityListMarket = "Hidden";
                IsEnabledGrid = "true";
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
        public ICommand LinkMarketCommand { get; private set; }
        public ICommand BackCommand { get; private set; }

        public ICommand SortPriceMaxToMinCommand { get; private set; }
        public ICommand SortPriceMinToMaxCommand { get; private set; }

        public ICommand SortVolumeMaxToMinCommand { get; private set; }
        public ICommand SortVolumeMinToMaxCommand { get; private set; }
    }
}
