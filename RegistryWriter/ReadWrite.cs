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

        public static void DeleteValue( string SubKeyName, string valname)
        {

            Console.WriteLine("1-HKEY_Current User, 2- Local machine");
            var o = Convert.ToInt32(Console.ReadLine());
            switch (o)
            {
                case 1:
            {
                        using (RegistryKey key = Registry.CurrentUser.OpenSubKey(SubKeyName, true))
                        {
                            if (key == null)
                            {
                                Console.WriteLine("Wpis nie istnieje");
                            }
                            else
                            {
                                key.DeleteValue(valname);
                            }
                        }


                    }
                    break;
                case 2:
                    {
                        using (RegistryKey key = Registry.LocalMachine.OpenSubKey(SubKeyName, true))
                        {
                            if (key == null)
                            {
                                Console.WriteLine("Wpis nie istnieje");
                            }
                            else
                            {
                                key.DeleteValue(valname);
                            }
                        }

                    }
                    break;
                default:
                    break;
            }

           
        }

        public static void DeleteSubKeyTree(string SubKeyName, string subkey)
        {
            Console.WriteLine("1-Current User, 2- Local machine");
            var o = Convert.ToInt32(Console.ReadLine());
            switch (o)
            {
                case 1:
                    {
                        using (RegistryKey key = Registry.CurrentUser.OpenSubKey(SubKeyName, true))
                        {
                            if (key == null)
                            {
                                Console.WriteLine("Wpis nie istnieje");
                            }
                            else
                            {
                                key.DeleteSubKeyTree(SubKeyName);
                                
                            }
                        }


                    }
                    break;
                case 2:
                    {
                        using (RegistryKey key = Registry.LocalMachine.OpenSubKey(SubKeyName, true))
                        {
                            if (key == null)
                            {
                                Console.WriteLine("Wpis nie istnieje");
                            }
                            else
                            {
                                key.DeleteSubKeyTree(SubKeyName);
                            }
                        }

                    }
                    break;
                default:
                    break;
            }
        }

    }
}
