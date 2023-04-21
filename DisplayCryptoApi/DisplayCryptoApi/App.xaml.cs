using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace DisplayCryptoApi
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static event EventHandler LanguageChanged;
        private static List<CultureInfo> languages = new List<CultureInfo>();
        public static List<CultureInfo> Languages => languages;

        public static CultureInfo Language
        {
            get
            {
                return System.Threading.Thread.CurrentThread.CurrentUICulture;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                if (value == System.Threading.Thread.CurrentThread.CurrentUICulture)
                {
                    return;
                }
                System.Threading.Thread.CurrentThread.CurrentUICulture = value;

                ResourceDictionary dict = new ResourceDictionary();
                switch (value.Name)
                {
                    case "ru-RU":
                        dict.Source = new Uri($"Resources/lang.{value.Name}.xaml", UriKind.Relative);
                        break;
                    case "ua-UA":
                        dict.Source = new Uri($"Resources/lang.{value.Name}.xaml", UriKind.Relative);
                        break;
                    default:
                        dict.Source = new Uri($"Resources/lang.en-US.xaml", UriKind.Relative);
                        break;
                }

                ResourceDictionary resource = (from d in Application.Current.Resources.MergedDictionaries
                                               where d.Source != null && d.Source.OriginalString.StartsWith("Resources/lang.")
                                               select d).FirstOrDefault();
                if (resource != null)
                {
                    int ind = Application.Current.Resources.MergedDictionaries.IndexOf(resource);
                    Application.Current.Resources.MergedDictionaries.Remove(resource);
                    Application.Current.Resources.MergedDictionaries.Insert(ind, dict);
                }
                else
                {
                    Application.Current.Resources.MergedDictionaries.Add(dict);
                }

                LanguageChanged?.Invoke(Application.Current, new EventArgs());
            }
        }

        public App()
        {
            App.LanguageChanged += App_LanguageChanged;

            languages.Clear();
            languages.Add(new CultureInfo("en-US"));
            languages.Add(new CultureInfo("ru-RU"));
            languages.Add(new CultureInfo("ua-UA"));

            Language = DisplayCryptoApi.Properties.Settings.Default.DefaultLanguage;
        }

        private void App_LanguageChanged(object sender, EventArgs e)
        {
            DisplayCryptoApi.Properties.Settings.Default.DefaultLanguage = Language;
        }

        private void Application_LoadCompleted(object sender, NavigationEventArgs e)
        {
            Language = DisplayCryptoApi.Properties.Settings.Default.DefaultLanguage;
        }
    }
}
