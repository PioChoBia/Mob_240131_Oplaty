using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Mob_240131_Oplaty.Models
{
  public class Plik
  {

    public List<Dane> Wczytaj()
    {
      string[] tabelaLinia;
      List<Dane> listDane0 = new List<Dane>();

      NumberFormatInfo nfi = new NumberFormatInfo();
      nfi.NumberDecimalSeparator = ".";


      string basePath0 = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
      string fileName0 = Path.Combine(basePath0, "plik102.txt");

      tabelaLinia = File.ReadAllLines(fileName0);

      foreach (string line in tabelaLinia)
      {
        Dane dane = new Dane();
        string[] splits = line.Split(' ');

        dane.Data = DateTime.Parse(splits[0], nfi);
        dane.Miesiac = int.Parse(splits[1], nfi);

        dane.Czynsz = double.Parse(splits[2], nfi);
        dane.ZWStan = int.Parse(splits[3], nfi);
        dane.ZWCena = double.Parse(splits[4], nfi);
        dane.CWStan = int.Parse(splits[5], nfi);
        dane.CWCena = double.Parse(splits[6], nfi);

        dane.Internet = double.Parse(splits[7], nfi);

        dane.GazStan = int.Parse(splits[8], nfi);
        dane.GazLicznik = double.Parse(splits[9], nfi);
        dane.GazCena = double.Parse(splits[10], nfi);

        dane.PradStan = int.Parse(splits[11], nfi);
        dane.PradLicznik = double.Parse(splits[12], nfi);
        dane.PradCena = double.Parse(splits[13], nfi);

        dane.PokojDuzyCena = double.Parse(splits[14], nfi);
        dane.PokojSredniCena = double.Parse(splits[15], nfi);
        dane.PokojMalyCena = double.Parse(splits[16], nfi);

        listDane0.Add(dane);
      }

      return listDane0;
    }


    public void Zapisz(List<Dane> listDane0)
    {
      List<string> listLinia = new List<string>();

      NumberFormatInfo nfi = new NumberFormatInfo();
      nfi.NumberDecimalSeparator = ".";

      string basePath0 = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
      string fileName0 = Path.Combine(basePath0, "plik102.txt");

      foreach (var item in listDane0)
      {
        string linia = "";

        linia += item.Data.ToShortDateString() + " ";
        linia += item.Miesiac.ToString(nfi) + " ";

        linia += item.Czynsz.ToString(nfi) + " ";
        linia += item.ZWStan.ToString(nfi) + " ";
        linia += item.ZWCena.ToString(nfi) + " ";
        linia += item.CWStan.ToString(nfi) + " ";
        linia += item.CWCena.ToString(nfi) + " ";

        linia += item.Internet.ToString(nfi) + " ";

        linia += item.GazStan.ToString(nfi) + " ";
        linia += item.GazLicznik.ToString(nfi) + " ";
        linia += item.GazCena.ToString(nfi) + " ";

        linia += item.PradStan.ToString(nfi) + " ";
        linia += item.PradLicznik.ToString(nfi) + " ";
        linia += item.PradCena.ToString(nfi) + " ";

        linia += item.PokojDuzyCena.ToString(nfi) + " ";
        linia += item.PokojSredniCena.ToString(nfi) + " ";
        linia += item.PokojMalyCena.ToString(nfi);

        listLinia.Add(linia);
      }

      File.WriteAllLines(fileName0, listLinia);
    }





  }
}

