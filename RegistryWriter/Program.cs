using System;
using Microsoft.Win32;

class RegGetDef
{
    public static void Main()
    {
       
        Console.WriteLine("Co chcesz zrobić?  1- czytanie wartosci wpisu, 2- edycja wpisu, 3- usuniecie wartosci, 4 -usuniecie gałęzi i potomków");
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

                    //to dziala
                    Console.WriteLine("Podaj SUBścieżkę do wpisu");
                    string keyName = Console.ReadLine();
                    Console.WriteLine("Podaj wartość");
                    string keyValue = Console.ReadLine();
                    RegistryWriter.ReadWrite.DeleteValue(keyName, keyValue);
                }
                break;

            case 4:
                {

                    //nietestowane
                    Console.WriteLine("Podaj SUBścieżkę do wpisu");
                    string keyName = Console.ReadLine();
                    Console.WriteLine("Podaj wartość");
                    string keyValue = Console.ReadLine();
                    RegistryWriter.ReadWrite.DeleteSubKeyTree(keyName, keyValue);
                }
                break;


            default:
                break;
        }


        Console.ReadKey();
    }
}

