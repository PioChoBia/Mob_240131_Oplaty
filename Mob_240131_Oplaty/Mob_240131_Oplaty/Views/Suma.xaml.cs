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

      w.WierszDataMiesiac= "dnia "+d1.Data.ToLocalTime().ToShortDateString()+"  za " + miesiace[d1.Miesiac];

      //opłaty stałe
      w.WierszOplatyStale1 = 
        "( czynsz= " + d1.Czynsz.ToString(".00") + " ) + ( Koba= " + d1.Koba.ToString(".00")+" ) +";
      w.WierszOplatyStale2 =
         "( licznikGaz= " + d1.GazOplata.ToString(".00") + 
         " ) + ( licznikPrąd= " + d1.PradOplata.ToString(".00")+" )";
      w.OplatyStale = d1.Czynsz + d1.Koba + d1.GazOplata + d1.PradOplata;
      w.OplatyStale3 = w.OplatyStale / 3;
      w.WierszOplatyStale3 = "suma= " + w.OplatyStale.ToString(".00") +
        "  1/3sumy= " + w.OplatyStale3.ToString(".00");



      //opłaty zmienne
      w.ZWKoszt = (d1.ZWStan - d0.ZWStan) * d1.ZWCena;
      w.WierszOplatyZmienne1 = "ZW= " + w.ZWKoszt.ToString(".00");
      w.WierszOplatyZmienne2 = "  teraz= " + d1.ZWStan.ToString() + "  było= " + d0.ZWStan + "  po= " + d1.ZWCena;


      w.CWKoszt = (d1.CWStan - d0.CWStan) * d1.CWCena;
      w.WierszOplatyZmienne3 = "CW= " + w.CWKoszt.ToString(".00");
      w.WierszOplatyZmienne4 = "  teraz= " + d1.CWStan.ToString() + "  było= " + d0.CWStan + "  po= " + d1.CWCena;

      w.GazKoszt = (d1.GazStan - d0.GazStan) * d1.GazCena;
      w.WierszOplatyZmienne5 = "gaz= " + w.GazKoszt.ToString(".00");
      w.WierszOplatyZmienne6 = "  teraz= " + d1.GazStan.ToString() + "  było= " + d0.GazStan + "  po= " + d1.GazCena;

      w.PradKoszt = (d1.PradStan - d0.PradStan) * d1.PradCena;
      w.WierszOplatyZmienne7 = "prąd= " + w.PradKoszt.ToString(".00");
      w.WierszOplatyZmienne8 = "  teraz= " + d1.PradStan.ToString() + "  było= " + d0.PradStan + "  po= " + d1.PradCena;

      w.OplatyZmienne = w.ZWKoszt + w.CWKoszt + w.GazKoszt + w.PradKoszt;
      w.OplatyZmienne3 = w.OplatyZmienne / 3;
      w.WierszOplatyZmienne9 =  "suma= " + w.OplatyZmienne.ToString(".00") +
        "  1/3sumy= " + w.OplatyZmienne3.ToString(".00");

      //za pokoje
      w.PokojDuzyKoszt = d1.PokojDuzyCena + w.OplatyStale3 + w.OplatyZmienne3;
      w.WierszPokojDuzy1 = "pokój duży= " + w.PokojDuzyKoszt.ToString(".00");
      w.WierszPokojDuzy2="czynsz= "+d1.PokojDuzyCena.ToString(".00")+
        " + OS/3= "+w.OplatyStale3.ToString(".00")+" + OZ/3= " + w.OplatyZmienne3.ToString(".00");

      w.PokojSredniKoszt = d1.PokojSredniCena + w.OplatyStale3 + w.OplatyZmienne3;
      w.WierszPokojSredni1 = "pokój średni= " + w.PokojSredniKoszt.ToString(".00");
      w.WierszPokojSredni2 = "czynsz= " + d1.PokojSredniCena.ToString(".00") +
        " + OS/3= " + w.OplatyStale3.ToString(".00") + " + OZ/3= " + w.OplatyZmienne3.ToString(".00");

      w.PokojMalyKoszt = d1.PokojMalyCena + w.OplatyStale3 + w.OplatyZmienne3;
      w.WierszPokojMaly1 = "pokój maly= " + w.PokojMalyKoszt.ToString(".00");
      w.WierszPokojMaly2 = "czynsz= " + d1.PokojMalyCena.ToString(".00") +
        " + OS/3= " + w.OplatyStale3.ToString(".00") + " + OZ/3= " + w.OplatyZmienne3.ToString(".00");

      return w;
    }

   


    private void buttonSumaNowy_Clicked(object sender, EventArgs e)
    {

    }
  }
}