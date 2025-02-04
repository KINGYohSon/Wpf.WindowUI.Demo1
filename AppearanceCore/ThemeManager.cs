using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AppearanceCore
{
    public class ThemeManager
    {
        //主题字典
        private Dictionary<string, ResourceDictionary> _themeList = new();

        //主题注册方法
        public void RegisterTheme(string themeName, string resourcePath)
        {
            var resourceDictionary = new ResourceDictionary()
            {
                Source = new Uri($"/GuiResources;component/{resourcePath}", UriKind.Relative)
            };
            _themeList[themeName] = resourceDictionary;
        }

        //应用主题方法
        public void ApplyTheme(string themeName)
        {
            if (_themeList.ContainsKey(themeName))
            {
                ResourceDictionary newTheme = _themeList[themeName];
                foreach (var tc in _themeList)
                {
                    Application.Current.Resources.MergedDictionaries.Remove(tc.Value);
                }
                Application.Current.Resources.MergedDictionaries.Add(newTheme);
                UpdateConfig(themeName);
            }
        }

        //同步配置文件键值
        private void UpdateConfig(string themeName)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["CurrentTheme"].Value = themeName;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
