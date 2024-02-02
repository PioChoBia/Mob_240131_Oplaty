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
          Miesiac=(DateTime.Now.Month)-1,
          
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
          PradStan=10080
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
        }
       };
         
      List<Wyliczenia>  listWyliczenia = new List<Wyliczenia>();

      listWyliczenia[0] = Wylicz(listDane[1], listDane[0]);
         

    }

    private Wyliczenia  Wylicz(Dane d1,Dane d0) { 
      Wyliczenia w = new Wyliczenia();

      w.Data= d1.Data;
      w.Miesiac= d1.Miesiac;

      //opłaty stałe
      w.Czynsz = d1.Czynsz;
      w.Koba = d1.Koba;
      w.GazOplata = d1.GazOplata;
      w.PradOplata = d1.PradOplata;
      
      w.OplatyStale = w.Czynsz + w.Koba + w.GazOplata + w.PradOplata;
      w.OplatyStale3 = w.OplatyStale / 3;


      //opłaty zmienne
      w.ZWStanTeraz = d1.ZWStan;
      w.ZWStanBylo = d0.ZWStan;
      w.ZWCena = d1.ZWCena;
      w.ZWKoszt = (w.ZWStanTeraz - w.ZWStanBylo) * w.ZWCena;

      w.CWStanTeraz = d1.CWStan;
      w.CWStanBylo = d0.CWStan;
      w.CWCena = d1.CWCena;
      w.CWKoszt = (w.CWStanTeraz - w.CWStanBylo) * w.CWCena;

      w.GazStanTeraz = d1.GazStan;
      w.GazStanBylo = d0.GazStan;
      w.GazCena = d1.GazCena;
      w.GazKoszt = (w.GazStanTeraz - w.GazStanBylo) * w.GazCena;

      w.PradStanTeraz = d1.PradStan;
      w.PradStanBylo = d0.PradStan;
      w.PradCena = d1.PradCena;
      w.PradKoszt = (w.PradStanTeraz - w.PradStanBylo) * w.PradCena;

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