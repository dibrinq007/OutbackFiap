using System;
using OutbackFiap.Mobile.Config;
using Xamarin.Forms;

namespace OutbackFiap.Mobile.iOS.Config
{
    public class DbPathConfig : IDbPathConfig
    {
        private string path;
        public string Path
        {
            get
            {
                if (string.IsNullOrEmpty(path))
                {
                    path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    path = System.IO.Path.Combine(path, "..", "Library");
                }
                return path;
            }
        }
    }
}