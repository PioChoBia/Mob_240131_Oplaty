using System;
using System.Collections.Generic;
using System.Text;

namespace Mob_240131_Oplaty.Models
{
   class Wyliczenia
   {
      public string DataMiesiac { get; set; }
  
      //opłaty stałe
      public string WierszOplatyStale1 {  get; set; }
      public string WierszOplatyStale2 { get; set; }
      public string WierszOplatyStale3 { get; set; }

      public double OplatyStale { get; set; }
      public double OplatyStale3 { get; set; }


      //oplaty zmienne
      public string WierszOplatyZmienne1 { get; set; }
      public string WierszOplatyZmienne2 { get; set; }
      public string WierszOplatyZmienne3 { get; set; }
      public string WierszOplatyZmienne4 { get; set; }
      public string WierszOplatyZmienne5 { get; set; }
      public string WierszOplatyZmienne6 { get; set; }
      public string WierszOplatyZmienne7 { get; set; }
      public string WierszOplatyZmienne8 { get; set; }
      public string WierszOplatyZmienne9 { get; set; }

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
