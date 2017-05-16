using System;
using Microsoft.Win32;

class RegGetDef
{
    public static void Main()
    {
        Console.WriteLine("Podaj ścieżkę do wpisu");
        string keyName = Console.ReadLine();
        Console.WriteLine("Podaj wartość");
        string keyValue = Console.ReadLine();

        RegistryWriter.ReadWrite.ShowValue(keyName, keyValue);


        Console.ReadKey();
    }
}
/*
Output:
Retrieving registry value ...

Object Type = System.String

Value = testData

The default to return
*/
