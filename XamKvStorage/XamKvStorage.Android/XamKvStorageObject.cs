using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Xamarin.Forms;                                    // for Dependency
using XamKvStorageInterface;
using Android.Preferences;


[assembly: Dependency(typeof(XamKvStorage.Droid.XamKvStorageObject))]
namespace XamKvStorage.Droid
{
    public class XamKvStorageObject : IXamKvStorage
    {

        ISharedPreferences localSettings = 
            Android.App.Application.Context.GetSharedPreferences("XamKvStorage", FileCreationMode.Private);

        //PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);

        public bool SetValue(string key, string value)
        {
            bool result = false;
            System.Diagnostics.Debug.WriteLine(">>> SetValue, key = " + key + ", value = " + value);

            try
            {
                ISharedPreferencesEditor editor = localSettings.Edit();
                editor.PutString(key, value);
                editor.Apply();
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
                System.Diagnostics.Debug.WriteLine(">>> GetValue, key = " + key);
                value = (String)localSettings.GetString(key, "");
                System.Diagnostics.Debug.WriteLine(">>> returning = " + value);
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
                ISharedPreferencesEditor editor = localSettings.Edit();
                editor.Remove(key);
                editor.Apply();
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