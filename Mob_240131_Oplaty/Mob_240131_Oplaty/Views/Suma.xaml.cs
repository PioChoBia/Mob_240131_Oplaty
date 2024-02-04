using Mob_240131_Oplaty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mob_240131_Oplaty.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class Suma : ContentPage
  {
    public Suma()
    {
      InitializeComponent();

      List<Dane> listDane = new List<Dane>
      {
        new Dane{
          Data=DateTime.Now,
          Miesiac=(DateTime.Now.Month),
          
          //spoldzielnia
          Czynsz=534.56,
          ZWCena=8.2,
          ZWStan=106,
          CWCena=48.98,
          CWStan=57,

          //internet
          Koba=40,

          //gaz
          GazOplata=8.758,
          GazCena=3.4686,
          GazStan=321,

          //prad
          PradOplata=12.25,
          PradCena=.80043,
          PradStan=10080,

          //pokoje
          PokojDuzyCena=472.5,
          PokojSredniCena=399,
          PokojMalyCena=340,
        },

        new Dane{
          Data=DateTime.Now,
          Miesiac=DateTime.Now.Month,
          
          //spoldzielnia
          Czynsz=534.56,
          ZWCena=8.2,
          ZWStan=111,
          CWCena=48.98,
          CWStan=61,

          //internet
          Koba=40,

          //gaz
          GazOplata=8.758,
          GazCena=3.4686,
          GazStan=325,

          //prad
          PradOplata=12.25,
          PradCena=.80043,
          PradStan=10150,

          //pokoje
          PokojDuzyCena=472.5,
          PokojSredniCena=399,
          PokojMalyCena=340,
        }
       };
         
      List<Wyliczenia>  listWyliczenia = new List<Wyliczenia>();

      listWyliczenia.Add( Wylicz(listDane[1], listDane[0]) );
      listWyliczenia.Add(Wylicz(listDane[1], listDane[0]));

      listViewWyliczenia.ItemsSource = listWyliczenia; 

    }

    private Wyliczenia  Wylicz(Dane d1,Dane d0) { 
      Wyliczenia w = new Wyliczenia();
      string[] miesiace = {
        "styczeń","luty","marzec",
        "kwiecień","maj","czerwiec",
        "lipiec","sierpień","wrzesień",
        "październik","listopad","grudzień"};

      w.DataMiesiac= "dnia "+d1.Data.ToLocalTime().ToShortDateString()+"  za " + miesiace[d1.Miesiac];

      //opłaty stałe
      w.WierszOplatyStale1 = 
        "( czynsz= " + d1.Czynsz.ToString(".00") + " ) + ( Koba= " + d1.Koba.ToString(".00")+" ) +";
      w.WierszOplatyStale2 =
         "( licznikGaz= " + d1.GazOplata.ToString(".00") + 
         " ) + ( licznikPrąd= " + d1.PradOplata.ToString(".00")+" )";
      w.OplatyStale = d1.Czynsz + d1.Koba + d1.GazOplata + d1.PradOplata;
      w.OplatyStale3 = w.OplatyStale / 3;
      w.WierszOplatyStale3 =
        "suma= " + w.OplatyStale.ToString(".00") +
        "  1/3sumy= " + w.OplatyStale3.ToString(".00");



      //opłaty zmienne
      w.WierszOplatyZmienne1 = "ZW= " + ((d1.ZWStan - d0.ZWStan) * d1.ZWCena).ToString(".00");
      w.WierszOplatyZmienne2 = "  teraz= " + d1.ZWStan.ToString() + "  było= " + d0.ZWStan + "  po= " + d1.ZWCena;
      
      w.WierszOplatyZmienne3 = "CW= " + ((d1.CWStan - d0.CWStan) * d1.CWCena).ToString(".00");
      w.WierszOplatyZmienne4 = "  teraz= " + d1.CWStan.ToString() + "  było= " + d0.CWStan + "  po= " + d1.CWCena;

      w.WierszOplatyZmienne5 = "gaz= " + ((d1.GazStan - d0.GazStan) * d1.GazCena).ToString(".00");
      w.WierszOplatyZmienne6 = "  teraz= " + d1.GazStan.ToString() + "  było= " + d0.GazStan + "  po= " + d1.GazCena;

      w.WierszOplatyZmienne7 = "prąd= " + ((d1.PradStan - d0.PradStan) * d1.PradCena).ToString(".00");
      w.WierszOplatyZmienne8 = "  teraz= " + d1.PradStan.ToString() + "  było= " + d0.PradStan + "  po= " + d1.PradCena;

      w.OplatyZmienne = w.ZWKoszt + w.CWKoszt + w.GazKoszt + w.PradKoszt;
      w.OplatyZmienne3 = w.OplatyZmienne / 3;

      //za pokoj
      w.PokojDuzyCena = d1.PokojDuzyCena;
      w.PokojSredniCena = d1.PokojSredniCena;
      w.PokojMalyCena = d1.PokojMalyCena;

      w.PokojDuzyKoszt = w.PokojDuzyCena + w.OplatyStale3 + w.OplatyZmienne3;
      w.PokojSredniKoszt = w.PokojSredniCena + w.OplatyStale3 + w.OplatyZmienne3;
      w.PokojMalyKoszt = w.PokojMalyCena + w.OplatyStale3 + w.OplatyZmienne3;

      return w;
    }

   


    private void buttonSumaNowy_Clicked(object sender, EventArgs e)
    {

    }
  }
}