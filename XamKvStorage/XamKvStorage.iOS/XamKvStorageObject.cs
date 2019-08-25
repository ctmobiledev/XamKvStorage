using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using Foundation;
using UIKit;

using Xamarin.Forms;                                    // for Dependency
using XamKvStorageInterface;


[assembly: Dependency(typeof(XamKvStorage.iOS.XamKvStorageObject))]
namespace XamKvStorage.iOS
{
    public class XamKvStorageObject : IXamKvStorage
    {

        public NSUserDefaults localSettings = NSUserDefaults.StandardUserDefaults;

        public bool SetValue(string key, string value)
        {
            bool result = false;
            System.Diagnostics.Debug.WriteLine(">>> SetValue, key = " + key + ", value = " + value);

            try
            {
                localSettings.SetString(value, key);        // NOTE: It's value FIRST, THEN key!!!!
                localSettings.Synchronize();
                result = true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(">>> SetValue failed, exception:" + ex.ToString());
                result = false;
            }

            System.Diagnostics.Debug.WriteLine(">>> result = " + result.ToString());
            return result;
        }

        public string GetValue(string key)
        {
            bool result = false;
            String value = null;

            try
            {
                System.Diagnostics.Debug.WriteLine(">>> [iOS] GetValue, key = " + key);
                value = new String(localSettings.StringForKey(key));
                System.Diagnostics.Debug.WriteLine(">>> returning = " + value);
                result = true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(">>> GetValue failed, exception:" + ex.ToString());
                result = false;
            }

            System.Diagnostics.Debug.WriteLine(">>> result = " + result.ToString());

            return value;

        }

        public bool DeleteValue(string key)
        {
            bool result = false;
            System.Diagnostics.Debug.WriteLine(">>> DeleteValue, key = " + key);

            try
            {
                localSettings.RemoveObject(key);
                localSettings.Synchronize();
                result = true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(">>> DeleteValue failed, exception:" + ex.ToString());
                result = false;
            }

            System.Diagnostics.Debug.WriteLine(">>> result = " + result.ToString());
            return result;
        }

    }

}