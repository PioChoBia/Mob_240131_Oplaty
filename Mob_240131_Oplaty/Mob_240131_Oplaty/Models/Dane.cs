using System;
using System.Collections.Generic;
using System.Text;

namespace Mob_240131_Oplaty.Models
{
  public class Dane
  {
    public DateTime Data { get; set; }
    public int Miesiac { get; set; }

    //spoldzielnia
    public  double Czynsz  { get; set; }
    public int ZWStan   { get; set;}
    public double ZWCena { get; set;}
    public int CWStan { get; set; }
    public double CWCena { get; set; }

    //internet
    public double Internet { get; set; }

    //gaz
    public double GazOplata { get; set; }
    public double GazCena { get; set; }
    public int GazStan { get; set; }

    //prąd
    public double PradOplata { get; set; }
    public double PradCena { get; set; }
    public int PradStan { get; set; }

    //za pokoje
    public double PokojDuzyCena { get; set; }
    public double PokojSredniCena { get; set; }
    public double PokojMalyCena { get; set; }


  }
}
