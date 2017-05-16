using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace RegistryWriter
{
    public class ReadWrite
    {
        public static void ShowValue(string key, string valname)
        {          
            Console.WriteLine(Registry.GetValue(key, valname, "NotFound"));
        }

        public static void ChangeValue (string key, string valname, string val )
        {
            Registry.SetValue(key, valname, val);
        }

    }
}
