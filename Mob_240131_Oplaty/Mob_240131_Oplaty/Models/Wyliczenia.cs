using System;
using System.Collections.Generic;
using System.Text;

namespace Mob_240131_Oplaty.Models
{
   class Wyliczenia
   {
      public DateTime Data { get; set; }
      public int Miesiac { get; set; }

      //opłaty stałe
      public double Czynsz { get; set; }
      public double Koba { get; set; }
      public double GazOplata { get; set; }
      public double PradOplata { get; set; }
      public double OplatyStale { get; set; }
      public double OplatyStale3 { get; set; }


      //oplaty zmienne
      public int ZWStanTeraz { get; set; }
      public int ZWStanBylo { get; set; }
      public double ZWCena { get; set; }
      public double ZWKoszt { get; set; }

      public int CWStanTeraz { get; set; }
      public int CWStanBylo { get; set; }
      public double CWCena { get; set; }
      public double CWKoszt { get; set; }

      public int GazStanTeraz { get; set; }
      public int GazStanBylo { get; set; }
      public double GazCena { get; set; }
      public double GazKoszt { get; set; }

      public int PradStanTeraz { get; set; }
      public int PradStanBylo { get; set; }
      public double PradCena { get; set; }
      public double PradKoszt { get; set; }

      public double OplatyZmienne { get; set; }
      public double OplatyZmienne3 { get; set; }

     //za pokoje
     public double PokojDuzyCena { get; set; }
     public double PokojSredniCena { get; set; }
     public double PokojMalyCena { get; set; }

    public double PokojDuzyKoszt { get; set; }
    public double PokojSredniKoszt { get; set; }
    public double PokojMalyKoszt { get; set; }

  } 
}
