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

   } 
}
