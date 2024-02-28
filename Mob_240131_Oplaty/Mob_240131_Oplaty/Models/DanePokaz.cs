using System;
using System.Collections.Generic;
using System.Text;

namespace Mob_240131_Oplaty.Models
{
  public class DanePokaz
  {
    public string WierszDataMiesiac {  get; set; }

    public string WierszGaz { get; set; }

    public string WierszPrad { get; set; }

    public string WierszZW { get; set; }

    public string WierszCW { get; set; }

    public string WierszInternet { get; set; }

    public string WierszSpoldzielnia { get; set; }

    public string WierszPokoje { get; set; }


    public List<DanePokaz> ListDanePokazObrob( List<Dane> ld0)
    {
      List<DanePokaz> ldp0 = new List<DanePokaz>();
      string[] miesiace = {
        "pusty",//bo miesiace w Date zapisane są od 1 do 12
        "styczeń","luty","marzec",
        "kwiecień","maj","czerwiec",
        "lipiec","sierpień","wrzesień",
        "październik","listopad","grudzień"};

      for (int i = 0; i < ld0.Count; i++)                       
      {
        Dane d0 = ld0[i];
        DanePokaz dp0 = new DanePokaz();        
        //$ łaczy w jeden string
        dp0.WierszDataMiesiac = i+" "+$"dnia {d0.Data.Day}.{miesiace[d0.Data.Month]}.{d0.Data.Year}" +
          "  za " + miesiace[d0.Miesiac];
        dp0.WierszGaz = "gaz= " + d0.GazStan + "  1m3= " + d0.GazCena + "  licznik= " + d0.GazLicznik;
        dp0.WierszPrad = "prąd= " + d0.PradStan + "  1kWh= " + d0.PradCena + "  licznik= " + d0.PradLicznik;
        dp0.WierszZW = "ZW= " + d0.ZWStan + "  1m3= " + d0.ZWCena;
        dp0.WierszCW = "CW= " + d0.CWStan + "  1m3= " + d0.CWCena;
        dp0.WierszInternet = "internet= " + d0.Internet;
        dp0.WierszSpoldzielnia = "spoldzielnia= " + d0.Czynsz;
        dp0.WierszPokoje = "duży= " + d0.PokojDuzyCena + " średni= " + d0.PokojSredniCena + " mały= " + d0.PokojMalyCena;        
        ldp0.Add(dp0);
      }

      return ldp0; 
    }
    

        


  }
}
