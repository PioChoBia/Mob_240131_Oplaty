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
  public partial class Odczyty : ContentPage
  {
    List<Dane> listDane = new List<Dane>//();
    {
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
          Internet = 40,

          //gaz
          GazLicznik = 8.758,
          GazCena = 3.4686,
          GazStan = 321,

          //prad
          PradLicznik = 12.25,
          PradCena = .80043,
          PradStan = 10080,

          //pokoje
          PokojDuzyCena = 472.5,
          PokojSredniCena = 399,
          PokojMalyCena = 340,
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
          Internet=40,

          //gaz
          GazLicznik=8.758,
          GazCena=3.4686,
          GazStan=325,

          //prad
          PradLicznik=12.25,
          PradCena=.80043,
          PradStan=10150,

          //pokoje
          PokojDuzyCena=472.5,
          PokojSredniCena=399,
          PokojMalyCena=340,
        }

    };


    Plik plik = new Plik();
    int nrTapped = 0;
    List<Wyliczenia> listWyliczenia = new List<Wyliczenia>();



    public Odczyty()
    {
      InitializeComponent();
      Wyliczenia wyliczenia = new Wyliczenia();

      listWyliczenia.Add(wyliczenia.WyliczMiesiac(listDane[1], listDane[0]));
      listWyliczenia.Add(wyliczenia.WyliczMiesiac(listDane[1], listDane[0]));

      listWyliczenia=wyliczenia.SortujListWyliczenia(listWyliczenia);

      listViewOdczytyWyliczenia.ItemsSource = listWyliczenia;



 




    }









    private void DaneOdczytyDodajEdytuj(List<Dane> listDane,bool takNaDopisz)
    {
      List<string> listPickerMiesiac = new List<string>
      {
        "styczeń","luty","marzec","kwiecień","maj","czerwiec",
        "lipiec","sierpień","wrzesień","październik","listopad","grudzień"
      };

      Dane dane0 = new Dane();
      if (takNaDopisz)
      {
        dane0 = listDane[listDane.Count - 1];
        labelOdczytyGazStanBylo.Text=dane0.GazStan.ToString();
        dane0.GazStan = 0;
        labelOdczytyPradStanBylo.Text = dane0.PradStan.ToString();
        dane0.PradStan = 0;
        labelOdczytyZWStanBylo.Text = dane0.ZWStan.ToString();
        dane0.ZWStan = 0;
        labelOdczytyCWStanBylo.Text = dane0.CWStan.ToString();
        dane0.CWStan = 0;
      }
      else
      {
        dane0 = listDane[nrTapped - 1];
      }
            
      pickerOdczytyMiesiac.Title = listPickerMiesiac.ElementAt(DateTime.Today.Month - 1);
      pickerOdczytyMiesiac.ItemsSource = listPickerMiesiac;

      //w inne i czynszach wpisuje jako biezące
      entryOdczytyGazLicznik.Text = dane0.GazLicznik.ToString();
      entryOdczytyGazCena.Text = dane0.GazCena.ToString();
      entryOdczytyPradLicznik.Text = dane0.PradLicznik.ToString();
      entryOdczytyPradCena.Text = dane0.PradCena.ToString();
      entryOdczytyZWCena.Text = dane0.ZWCena.ToString();
      entryOdczytyCWCena.Text = dane0.CWCena.ToString();
      entryOdczytyInternet.Text = dane0.Internet.ToString();      
      entryOdczytyCzynsz.Text = dane0.Czynsz.ToString();
      entryOdczytyPokojDuzyCena.Text = dane0.PokojDuzyCena.ToString();
      entryOdczytyPokojSredniCena.Text = dane0.PokojSredniCena.ToString();
      entryOdczytyPokojMalyCena.Text = dane0.PokojMalyCena.ToString();      
    }


    private void listViewOdczytyWyliczenia_ItemTapped(object sender, ItemTappedEventArgs e)
    {
      Wyliczenia wyliczeniaTapped = e.Item as Wyliczenia;
      nrTapped = listWyliczenia.IndexOf(wyliczeniaTapped);
      labelOdczytyUsun.Text = nrTapped + " " + wyliczeniaTapped.WierszDataMiesiac;
      labelOdczytyEdytuj.Text = nrTapped + " " + wyliczeniaTapped.WierszDataMiesiac;
    }


    private void buttonOdczytyDodaj_Clicked(object sender, EventArgs e)
    {
      stackLayoutOdczytyDodajEdytujUsun.IsVisible = false;
      listViewOdczytyWyliczenia.IsVisible = false;
      stackLayoutOdczytyDodaj.IsVisible = true;
      DaneOdczytyDodajEdytuj(listDane, true);
      stackLayoutOdczytyDane.IsVisible = true;
    }

    private void buttonOdczytyDodajCancel_Clicked(object sender, EventArgs e)
    {
      stackLayoutOdczytyDane.IsVisible = false;
      stackLayoutOdczytyDodaj.IsVisible = false;
      stackLayoutOdczytyDodajEdytujUsun.IsVisible = true;
      listViewOdczytyWyliczenia.IsVisible = true;
    }




    private void buttonOdczytyEdytuj_Clicked(object sender, EventArgs e)
    {

    }

    private void buttonOdczytyUsun_Clicked(object sender, EventArgs e)
    {

    }

    private void buttonOdczytyDodaj1_Clicked(object sender, EventArgs e)
    {

    }



    private void buttonOdczytyEdytuj1_Clicked(object sender, EventArgs e)
    {

    }

    private void buttonOdczytyEdytujCancel_Clicked(object sender, EventArgs e)
    {

    }

    private void buttonOdczytyUsun1_Clicked(object sender, EventArgs e)
    {

    }

    private void buttonOdczytyUsunCancel_Clicked(object sender, EventArgs e)
    {

    }

    private void buttonOdczytyUsun2_Clicked(object sender, EventArgs e)
    {

    }

    private void buttonOdczytyUsunCancel2_Clicked(object sender, EventArgs e)
    {

    }
  }
}