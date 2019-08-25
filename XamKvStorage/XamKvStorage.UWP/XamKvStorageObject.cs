using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using Xamarin.Forms;                                    // for Dependency
using XamKvStorageInterface;

[assembly: Dependency(typeof(XamKvStorage.UWP.XamKvStorageObject))]
namespace XamKvStorage.UWP
{
    public class XamKvStorageObject : IXamKvStorage
    {

        public Windows.Storage.ApplicationDataContainer localSettings =
            Windows.Storage.ApplicationData.Current.LocalSettings;

        public Windows.Storage.StorageFolder localFolder =
            Windows.Storage.ApplicationData.Current.LocalFolder;

        public bool SetValue(string key, string value)
        {
            bool result = false;
            Debug.WriteLine(">>> SetValue, key = " + key + ", value = " + value);

            try
            {
                localSettings.Values[key] = value;
                result = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>> SetValue failed, exception:" + ex.ToString());
                result = false;
            }

            Debug.WriteLine(">>> result = " + result.ToString());
            return result;
        }

        public string GetValue(string key)
        {
            bool result = false;
            String value = null;

            try
            {
                Debug.WriteLine(">>> GetValue, key = " + key);
                value = (String)localSettings.Values[key];
                Debug.WriteLine(">>> returning = " + value);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>> GetValue failed, exception:" + ex.ToString());
                result = false;
            }

            Debug.WriteLine(">>> result = " + result.ToString());

            return value;

        }

        public bool DeleteValue(string key)
        {
            bool result = false;
            Debug.WriteLine(">>> DeleteValue, key = " + key);

            try
            {
                localSettings.Values.Remove(key);
                result = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>> DeleteValue failed, exception:" + ex.ToString());
                result = false;
            }

            Debug.WriteLine(">>> result = " + result.ToString());
            return result;
        }

    }
}
