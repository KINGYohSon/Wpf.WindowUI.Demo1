using AppearanceCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Wpf.WindowUI.Demo1.Utilities;

namespace Wpf.WindowUI.Demo1.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ThemeManager _themeManager;
        private string _currentTheme;
        public ICommand ChangeThemeCommand { get; }

        private Dictionary<string, bool> _themeCheckedStates;

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Dictionary<string, bool> ThemeCheckedStates
        {
            get { return _themeCheckedStates; }
            set
            {
                _themeCheckedStates = value;
                OnPropertyChanged(nameof(ThemeCheckedStates));
            }
        }

        public MainViewModel()
        {
            _themeManager = new ThemeManager();
            _themeManager.RegisterTheme("LightColor", "ThemeColors/LightColor.xaml");
            _themeManager.RegisterTheme("DarkColor", "ThemeColors/DarkColor.xaml");
            _themeManager.RegisterTheme("FreshBlue", "ThemeColors/FreshBlueColor.xaml");
            _themeManager.RegisterTheme("HoneyPink", "ThemeColors/HoneyPinkColor.xaml");

            _themeCheckedStates = new Dictionary<string, bool>()
            { { "LightColor", false }, { "DarkColor", false }, { "FreshBlue", false }, { "HoneyPink", false } };

            ChangeThemeCommand = new RelayCommand(param => ChangeTheme((string)param));

            LoadTheme();
        }

        private void LoadTheme()
        {
            _currentTheme = ConfigurationManager.AppSettings["CurrentTheme"];
            _themeManager.ApplyTheme(_currentTheme);
            UpdateRadioButtonState();
        }

        private void ChangeTheme(string theme)
        {
            _themeManager.ApplyTheme(theme);
        }

        private void UpdateRadioButtonState()
        {
            foreach(var theme in _themeCheckedStates.Keys.ToList())
            {
                _themeCheckedStates[theme] = _currentTheme == theme;
            }
            OnPropertyChanged(nameof(ThemeCheckedStates));
        }


    }
}
