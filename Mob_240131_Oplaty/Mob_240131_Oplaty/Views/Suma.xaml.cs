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

    public List<Dane> listDane = new List<Dane>();
    List<Wyliczenia> listWyliczenia = new List<Wyliczenia>();

    public Suma()
    {
      InitializeComponent();

      listDane.Add(
        new Dane {
          Data = DateTime.Now,
          Miesiac = DateTime.Now.Month,

          //spoldzielnia
          Czynsz = 534.56,
          ZWCena = 8.2,
          ZWStan = 106,
          CWCena = 48.98,
          CWStan = 57,

          //internet
          Koba = 40,

          //gaz
          GazOplata = 8.758,
          GazCena = 3.4686,
          GazStan = 321,

          //prad
          PradOplata = 12.25,
          PradCena = .80043,
          PradStan = 10080,

          //pokoje
          PokojDuzyCena = 472.5,
          PokojSredniCena = 399,
          PokojMalyCena = 340,
        });

      listDane.Add(
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
       );
         
      

      listWyliczenia.Add( Wylicz(listDane[1], listDane[0]) );
      listWyliczenia.Add(Wylicz(listDane[1], listDane[0]));

      listViewWyliczenia.ItemsSource = listWyliczenia; 

    }

     Wyliczenia  Wylicz(Dane d1,Dane d0) { 
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
        "czynszSpółdzielni " + d1.Czynsz.ToString(".00") + " + Koba " + d1.Koba.ToString(".00")+" +";
      w.WierszOplatyStale2 =
         "licznikGaz " + d1.GazOplata.ToString(".000") + 
         " + licznikPrąd " + d1.PradOplata.ToString(".000");
      w.OplatyStale = d1.Czynsz + d1.Koba + d1.GazOplata + d1.PradOplata;
      w.OplatyStale3 = w.OplatyStale / 3;
      w.WierszOplatyStale0 = "OplatyStale= " + w.OplatyStale.ToString(".00") +
        "   OP/3= " + w.OplatyStale3.ToString(".00");



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
      w.WierszOplatyZmienne0 =  "OpłatyZmienne= " + w.OplatyZmienne.ToString(".00") +
        "    OZ/3= " + w.OplatyZmienne3.ToString(".00");

      //za pokoje
      w.PokojDuzyKoszt = d1.PokojDuzyCena + w.OplatyStale3 + w.OplatyZmienne3;
      w.WierszPokojDuzy0 = "pokój duży= " + w.PokojDuzyKoszt.ToString(".00");
      w.WierszPokojDuzy1="czynsz "+d1.PokojDuzyCena.ToString(".00")+
        " + OS/3 "+w.OplatyStale3.ToString(".00") + " + OZ/3 " + w.OplatyZmienne3.ToString(".00");

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

   



    private void buttonSumaDodaj_Clicked(object sender, EventArgs e)
    {

    }

    private void buttonSumaEdytuj_Clicked(object sender, EventArgs e)
    {

    }

    private void buttonSumaUsun_Clicked(object sender, EventArgs e)
    {
      if ( stackLayoutSumaUsun.IsVisible==false)
      {
        stackLayoutSumaUsun.IsVisible = true;

        

        var wybrano = listViewWyliczenia. as Wyliczenia;

      

      } else
      {
        stackLayoutSumaUsun.IsVisible = false;
        labelSumaUsun.Text = "";
      }
        

    }


    private void listViewWyliczenia_ItemTapped(object sender, ItemTappedEventArgs e)
    {
      var wiersz = e.Item as Wyliczenia;
      labelSumaUsun.Text = wiersz.WierszDataMiesiac;
    }


    private void buttonSumaUsun1_Clicked(object sender, EventArgs e)
    {

    }




  }
}