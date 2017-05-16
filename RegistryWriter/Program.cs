using System;
using Microsoft.Win32;

class RegGetDef
{
    public static void Main()
    {
       
        Console.WriteLine("Co chcesz zrobić?  1- czytanie wartosci wpisu, 2- edycja wpisu, 3- usuniecie wartosci, 4 -usuniecie ");
        var opcja = Convert.ToInt32(Console.ReadLine());


        
        switch (opcja)
        {
            case 1:
                {
                    Console.WriteLine("Podaj ścieżkę do wpisu");
                    string keyName = Console.ReadLine();
                    Console.WriteLine("Podaj wartość");
                    string keyValue = Console.ReadLine();

                    RegistryWriter.ReadWrite.ShowValue(keyName, keyValue);
                }
                
                break;
            case 2:
                {
                    Console.WriteLine("Podaj ścieżkę do wpisu");
                    string keyName = Console.ReadLine();
                    Console.WriteLine("Podaj wartość");
                    string keyValue = Console.ReadLine();
                    Console.WriteLine("Podaj nowa wartosc");
                    string newVal = Console.ReadLine();
                    RegistryWriter.ReadWrite.ChangeValue(keyName, keyValue, newVal);
                }
                break;

            case 3:
                {
                    Console.WriteLine("Podaj ścieżkę do wpisu");
                    string keyName = Console.ReadLine();
                    Console.WriteLine("Podaj wartość");
                    string keyValue = Console.ReadLine();
                    RegistryWriter.ReadWrite.DeleteValue(keyName, keyValue);
                }
                break;



            default:
                break;
        }


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
