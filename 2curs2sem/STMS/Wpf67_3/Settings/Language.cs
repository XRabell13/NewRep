using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Wpf67.Settings
{
  /*  
    public class Language
    {
        private List<CultureInfo> languages = new List<CultureInfo>();
        public List<CultureInfo> Languages
        {
            get => languages;
        }

        public Language()
        {
            LanguageChanged += AppLanguageChanged;

            languages.Add(new CultureInfo("ru-RU"));
            languages.Add(new CultureInfo("by-BY"));

            Name = Properties.Settings.Default.DefaultLanguage;
        }

        public event EventHandler LanguageChanged;

        public CultureInfo Name
        {
            get => System.Threading.Thread.CurrentThread.CurrentUICulture;
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                if (value == System.Threading.Thread.CurrentThread.CurrentUICulture) return;

                System.Threading.Thread.CurrentThread.CurrentUICulture = value;

                ResourceDictionary dict = new ResourceDictionary();
                switch (value.Name)
                {
                    case "by-BY":
                        dict.Source = new Uri(String.Format("Resources/lang.{0}.xaml", value.Name), UriKind.Relative);
                        break;
                    default:
                        dict.Source = new Uri("Resources/lang.xaml", UriKind.Relative);
                        break;
                }

                Application.Current.Resources.MergedDictionaries.Add(dict);
                LanguageChanged(Application.Current, new EventArgs());
            }
        }


        private void AppLanguageChanged(Object sender, EventArgs e)
        {
            Wpf67.Properties.Settings.Default.DefaultLanguage = Name;
            Wpf67.Properties.Settings.Default.Save();
        }
    }*/
}
