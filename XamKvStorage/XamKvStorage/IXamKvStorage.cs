using System;
using System.Collections.Generic;
using System.Text;

namespace XamKvStorageInterface
{
    public interface IXamKvStorage
    {
        bool SetValue(string key, string value);
        string GetValue(string key);
        bool DeleteValue(string key);
    }
}
