using System;
using OutbackFiap.Mobile.Config;
using Xamarin.Forms;

namespace OutbackFiap.Mobile.Droid.Config
{
    public class DbPathConfig : IDbPathConfig
    {
        private string path;
        public string Path => path ??= Environment.GetFolderPath(Environment.SpecialFolder.Personal);
    }
}