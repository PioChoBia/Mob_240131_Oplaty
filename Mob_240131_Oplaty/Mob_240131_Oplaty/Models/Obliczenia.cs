using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Mob_240131_Oplaty.Models
{
  public class Obliczenia
  {

    



    //miesiace obliczenia-------------------------------------------------------------------------------
    public List<MiesiacePokaz> ListMiesiacePokazWylicz()
    {
      List<MiesiacePokaz> lmp0=new List<MiesiacePokaz>();
      List<Dane> ld0 = new List<Dane>();
      //wczytuje z pliku
      ld0 = ListDaneWczytaj();
      //jak lista co najmniej z dwóch odczytów, liczymy
      if (ld0.Count > 1)
      {
        for (int i = 0; i < ld0.Count - 1; i++)
        {
          lmp0.Add(MiesiacePokazWylicz(i, ld0[i + 1], ld0[i]));
        }
      }
      return lmp0;
    }



    MiesiacePokaz MiesiacePokazWylicz(int nr0, Dane d1, Dane d0)
    {
      MiesiacePokaz mp0 = new MiesiacePokaz();
      string[] miesiace = {
        "pusty","styczeń","luty","marzec",
        "kwiecień","maj","czerwiec",
        "lipiec","sierpień","wrzesień",
        "październik","listopad","grudzień"};

      //$ łaczy w jeden string
      mp0.WierszDataMiesiac = nr0+" "+$"dnia {d1.Data.Day}.{miesiace[d1.Data.Month]}.{d1.Data.Year}" +
        "  za " + miesiace[d1.Miesiac];
      //opłaty stałe
      mp0.WierszOplatyStale1 =
        "czynszSpółdzielni " + d1.Czynsz.ToString(".00") + " + Koba " + d1.Internet.ToString(".00") + " +";
      mp0.WierszOplatyStale2 =
         "licznikGaz " + d1.GazLicznik.ToString(".000") +
         " + licznikPrąd " + d1.PradLicznik.ToString(".000");
      mp0.OplatyStale = d1.Czynsz + d1.Internet + d1.GazLicznik + d1.PradLicznik;
      mp0.OplatyStale3 = mp0.OplatyStale / 3;
      mp0.WierszOplatyStale0 = "OplatyStale= " + mp0.OplatyStale.ToString(".00") +
        "   OS/3= " + mp0.OplatyStale3.ToString(".00");
      //opłaty zmienne
      mp0.ZWKoszt = (d1.ZWStan - d0.ZWStan) * d1.ZWCena;
      mp0.WierszZW = "ZW= " + mp0.ZWKoszt.ToString(".00") +
                   "  = ( " + d1.ZWStan + " - " + d0.ZWStan + " ) * " + d1.ZWCena.ToString(".00");
      mp0.CWKoszt = (d1.CWStan - d0.CWStan) * d1.CWCena;
      mp0.WierszCW = "CW= " + mp0.CWKoszt.ToString(".00") +
                   "  = ( " + d1.CWStan + " - " + d0.CWStan + " ) * " + d1.CWCena.ToString(".00");
      mp0.GazKoszt = (d1.GazStan - d0.GazStan) * d1.GazCena;
      mp0.WierszGaz = "gaz= " + mp0.GazKoszt.ToString(".00") +
                    "  = ( " + d1.GazStan + " - " + d0.GazStan + " ) * " + d1.GazCena.ToString(".00000");
      mp0.PradKoszt = (d1.PradStan - d0.PradStan) * d1.PradCena;
      mp0.WierszPrad = "prad= " + mp0.PradKoszt.ToString(".00") +
                     "  = ( " + d1.PradStan + " - " + d0.PradStan + " ) * " + d1.PradCena.ToString(".00000");
      mp0.OplatyZmienne = mp0.ZWKoszt + mp0.CWKoszt + mp0.GazKoszt + mp0.PradKoszt;
      mp0.OplatyZmienne3 = mp0.OplatyZmienne / 3;
      mp0.WierszOplatyZmienne0 = "OpłatyZmienne= " + mp0.OplatyZmienne.ToString(".00") +
        "    OZ/3= " + mp0.OplatyZmienne3.ToString(".00");
      //za pokoje
      mp0.PokojDuzyKoszt = d1.PokojDuzyCena + mp0.OplatyStale3 + mp0.OplatyZmienne3;
      mp0.WierszPokojDuzy0 = "pokój duży= " + mp0.PokojDuzyKoszt.ToString(".00");
      mp0.WierszPokojDuzy1 = "czynsz " + d1.PokojDuzyCena.ToString(".00") +
        " + OS/3 " + mp0.OplatyStale3.ToString(".00") + " + OZ/3 " + mp0.OplatyZmienne3.ToString(".00");
      mp0.PokojSredniKoszt = d1.PokojSredniCena + mp0.OplatyStale3 + mp0.OplatyZmienne3;
      mp0.WierszPokojSredni0 = "pokój średni= " + mp0.PokojSredniKoszt.ToString(".00");
      mp0.WierszPokojSredni1 = "czynsz " + d1.PokojSredniCena.ToString(".00") +
        " + OS/3 " + mp0.OplatyStale3.ToString(".00") + " + OZ/3 " + mp0.OplatyZmienne3.ToString(".00");
      mp0.PokojMalyKoszt = d1.PokojMalyCena + mp0.OplatyStale3 + mp0.OplatyZmienne3;
      mp0.WierszPokojMaly0 = "pokój maly= " + mp0.PokojMalyKoszt.ToString(".00");
      mp0.WierszPokojMaly1 = "czynsz " + d1.PokojMalyCena.ToString(".00") +
        " + OS/3 " + mp0.OplatyStale3.ToString(".00") + " + OZ/3 " + mp0.OplatyZmienne3.ToString(".00");

      return mp0;
    }






//zabawa z plikiem--------------------------------------------------------------------
    public List<Dane> ListDaneWczytaj()
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


    public void ListDaneZapisz(List<Dane> listDane0)
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
