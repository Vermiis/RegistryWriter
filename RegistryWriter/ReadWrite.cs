using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.IO;

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
                                Console.WriteLine("Wpis nie istnieje, albo podales zla sciezke (ma byc bez HKEY...)");
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
                                Console.WriteLine("Wpis nie istnieje, albo podales zla sciezke (ma byc bez HKEY...)");
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
                                key.DeleteSubKeyTree(subkey);
                                
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

    public class InstalledProgramInfo
    {
        public string name;
        public string path;

        public static InstalledProgramInfo FindInstalledApp(string findname, bool dump = false)
        {
            if (String.IsNullOrEmpty(findname)) return null;

            string uninstallKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";

            RegistryHive[] keys = new RegistryHive[] { RegistryHive.CurrentUser, RegistryHive.LocalMachine };
            RegistryView[] views = new RegistryView[] { RegistryView.Registry32, RegistryView.Registry64 };

            foreach (var hive in keys)
            {
                foreach (var view in views)
                {
                    RegistryKey rk = null,
                        basekey = null;

                    try
                    {
                        basekey = RegistryKey.OpenBaseKey(hive, view);
                        rk = basekey.OpenSubKey(uninstallKey);
                    }
                    catch (Exception ex) { continue; }

                    if (basekey == null || rk == null)
                        continue;

                    if (rk == null)
                    {
                        if (dump) Console.WriteLine("ERROR: failed to open subkey '{0}'", uninstallKey);
                        return null;
                    }

                    if (dump) Console.WriteLine("Reading registry at {0}", rk.ToString());

                    foreach (string skName in rk.GetSubKeyNames())
                    {
                        try
                        {
                            RegistryKey sk = rk.OpenSubKey(skName);
                            if (sk == null) continue;

                            object skname = sk.GetValue("DisplayName");

                            object skpath = sk.GetValue("InstallLocation");
                            if (skpath == null)
                            {
                                skpath = sk.GetValue("UninstallString");
                                if (skpath == null) continue;
                                FileInfo fi = new FileInfo(skpath.ToString());
                                skpath = fi.Directory.FullName;
                            }

                            if (skname == null || skpath == null) continue;

                            string thisname = skname.ToString();
                            string thispath = skpath.ToString();

                            if (dump) Console.WriteLine("{0}: {1}", thisname, thispath);

                            if (!thisname.Equals(findname, StringComparison.CurrentCultureIgnoreCase))
                                continue;

                            InstalledProgramInfo inf = new InstalledProgramInfo();
                            inf.name = thisname;
                            inf.path = thispath;

                            return inf;
                        }
                        catch (Exception ex)
                        {
                            // todo
                        }
                    }
                } // view
            } // hive

            return null;
        }


    }

}
