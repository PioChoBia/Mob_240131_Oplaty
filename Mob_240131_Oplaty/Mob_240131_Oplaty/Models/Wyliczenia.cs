using System;
using System.Collections.Generic;
using System.Text;

namespace Mob_240131_Oplaty.Models
{
  public class Wyliczenia
  {
      public string WierszDataMiesiac { get; set; }
  
      //opłaty stałe
      public string WierszOplatyStale0 {  get; set; }
      public string WierszOplatyStale1 { get; set; }
      public string WierszOplatyStale2 { get; set; }

      public double OplatyStale { get; set; }
      public double OplatyStale3 { get; set; }


    //oplaty zmienne
      public string WierszOplatyZmienne0 { get; set; }
      public string WierszZW { get; set; }
      public string WierszCW { get; set; }
      public string WierszGaz { get; set; }
      public string WierszPrad { get; set; }

      public double ZWKoszt { get; set; }
      public double CWKoszt { get; set; }
      public double GazKoszt { get; set; }
      public double PradKoszt { get; set; }

      public double OplatyZmienne { get; set; }
      public double OplatyZmienne3 { get; set; }


    //za pokoje
      public string WierszPokojDuzy0 { get; set; }
      public string WierszPokojDuzy1 { get; set; }
      public string WierszPokojSredni0 { get; set; }
      public string WierszPokojSredni1 { get; set; }
      public string WierszPokojMaly0 { get; set; }
      public string WierszPokojMaly1 { get; set; }

      public double PokojDuzyKoszt { get; set; }
      public double PokojSredniKoszt { get; set; }
      public double PokojMalyKoszt { get; set; }


    public Wyliczenia WyliczMiesiac(Dane d1, Dane d0)
    {
      Wyliczenia w = new Wyliczenia();
      string[] miesiace = {
        "pusty","styczeń","luty","marzec",
        "kwiecień","maj","czerwiec",
        "lipiec","sierpień","wrzesień",
        "październik","listopad","grudzień"};

      //$ łaczy w jeden string
      w.WierszDataMiesiac = $"dnia {d1.Data.Day}.{miesiace[d1.Data.Month]}.{d1.Data.Year}" +
        "  za " + miesiace[d1.Miesiac];
      //opłaty stałe
      w.WierszOplatyStale1 =
        "czynszSpółdzielni " + d1.Czynsz.ToString(".00") + " + Koba " + d1.Internet.ToString(".00") + " +";
      w.WierszOplatyStale2 =
         "licznikGaz " + d1.GazLicznik.ToString(".000") +
         " + licznikPrąd " + d1.PradLicznik.ToString(".000");
      w.OplatyStale = d1.Czynsz + d1.Internet + d1.GazLicznik + d1.PradLicznik;
      w.OplatyStale3 = w.OplatyStale / 3;
      w.WierszOplatyStale0 = "OplatyStale= " + w.OplatyStale.ToString(".00") +
        "   OS/3= " + w.OplatyStale3.ToString(".00");
      //opłaty zmienne
      w.ZWKoszt = (d1.ZWStan - d0.ZWStan) * d1.ZWCena;
      w.WierszZW = "ZW= " + w.ZWKoszt.ToString(".00") +
                   "  = ( " + d1.ZWStan + " - " + d0.ZWStan + " ) * " + d1.ZWCena.ToString(".00");
      w.CWKoszt = (d1.CWStan - d0.CWStan) * d1.CWCena;
      w.WierszCW = "CW= " + w.CWKoszt.ToString(".00") +
                   "  = ( " + d1.CWStan + " - " + d0.CWStan + " ) * " + d1.CWCena.ToString(".00");
      w.GazKoszt = (d1.GazStan - d0.GazStan) * d1.GazCena;
      w.WierszGaz = "gaz= " + w.GazKoszt.ToString(".00") +
                    "  = ( " + d1.GazStan + " - " + d0.GazStan + " ) * " + d1.GazCena.ToString(".00000");
      w.PradKoszt = (d1.PradStan - d0.PradStan) * d1.PradCena;
      w.WierszPrad = "prad= " + w.PradKoszt.ToString(".00") +
                     "  = ( " + d1.PradStan + " - " + d0.PradStan + " ) * " + d1.PradCena.ToString(".00000");
      w.OplatyZmienne = w.ZWKoszt + w.CWKoszt + w.GazKoszt + w.PradKoszt;
      w.OplatyZmienne3 = w.OplatyZmienne / 3;
      w.WierszOplatyZmienne0 = "OpłatyZmienne= " + w.OplatyZmienne.ToString(".00") +
        "    OZ/3= " + w.OplatyZmienne3.ToString(".00");
      //za pokoje
      w.PokojDuzyKoszt = d1.PokojDuzyCena + w.OplatyStale3 + w.OplatyZmienne3;
      w.WierszPokojDuzy0 = "pokój duży= " + w.PokojDuzyKoszt.ToString(".00");
      w.WierszPokojDuzy1 = "czynsz " + d1.PokojDuzyCena.ToString(".00") +
        " + OS/3 " + w.OplatyStale3.ToString(".00") + " + OZ/3 " + w.OplatyZmienne3.ToString(".00");
      w.PokojSredniKoszt = d1.PokojSredniCena + w.OplatyStale3 + w.OplatyZmienne3;
      w.WierszPokojSredni0 = "pokój średni= " + w.PokojSredniKoszt.ToString(".00");
      w.WierszPokojSredni1 = "czynsz " + d1.PokojSredniCena.ToString(".00") +
        " + OS/3 " + w.OplatyStale3.ToString(".00") + " + OZ/3 " + w.OplatyZmienne3.ToString(".00");
      w.PokojMalyKoszt = d1.PokojMalyCena + w.OplatyStale3 + w.OplatyZmienne3;
      w.WierszPokojMaly0 = "pokój maly= " + w.PokojMalyKoszt.ToString(".00");
      w.WierszPokojMaly1 = "czynsz " + d1.PokojMalyCena.ToString(".00") +
        " + OS/3 " + w.OplatyStale3.ToString(".00") + " + OZ/3 " + w.OplatyZmienne3.ToString(".00");
      return w;
    }


    public List<Wyliczenia> SortujListWyliczenia(List<Wyliczenia> lw0)
    {
      List<Wyliczenia> lw1 = new List<Wyliczenia>();
 
      //sortuje, układa od ostatniego jako pierwszy do pierwszego
      for (int i = 0; i < lw0.Count; i++)
      {
        lw1.Add(lw0[lw0.Count - 1 - i]);
      }
 
      return lw1;
    }




  } 
}
