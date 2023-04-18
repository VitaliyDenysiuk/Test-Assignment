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

        public MainViewModel()
        {
            cgManager = new CoinGeckoManager();
            InitCommands();
        }

        private void InitCommands()
        {
            SelectAllCointsCommand = new RelayCommand(param=>
            {
                Task.Run(() =>
                {
                    Coins = cgManager.GetCoins();
                });
            });
        }

        public ICommand SelectAllCointsCommand { get; private set; }
    }
}
