using Mob_240131_Oplaty.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Mob_240131_Oplaty.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class Odczyt : ContentPage
  {
    Dane dane= new Dane();
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
    Wyliczenia wyliczenia = new Wyliczenia();
    List<Wyliczenia> listWyliczenia = new List<Wyliczenia>();
     





    public Odczyt()
    {
      InitializeComponent();

      //listDane = plik.Wczytaj();
      listViewDane.ItemsSource = listDane;


      listWyliczenia = WyliczDane(listDane);
      listViewWyliczenia.ItemsSource = listWyliczenia;




    }

    List<Wyliczenia> WyliczDane(List<Dane> listDane0)
    {
      List<Wyliczenia> listWyliczenia0 = new List<Wyliczenia>();
      
      if (listDane0.Count >=2 )
      {
        for (int i = 1; i < listDane0.Count; i++)
        {
          listWyliczenia0.Add( wyliczenia.WyliczMiesiac(listDane0[i] , listDane0[i - 1]) );
        }
      }

      return listWyliczenia0;
    }







    //----dodaj-----------------------------------------------------------

    private void OdczytDodajStart()
    {
      List<string> listPickerMiesiac = new List<string>
      {
        "styczeń","luty","marzec","kwiecień","maj","czerwiec",
        "lipiec","sierpień","wrzesień","październik","listopad","grudzień"
      };

      List<Dane> listDane0 = plik.Wczytaj();
      Dane dane0 = new Dane();
      dane0= listDane0[listDane0.Count-1];

      pickerOdczytDodajMiesiac.Title = listPickerMiesiac.ElementAt(DateTime.Today.Month - 1);
      pickerOdczytDodajMiesiac.ItemsSource = listPickerMiesiac;

      labelOdczytDodajGazStanBylo.Text = dane0.GazStan.ToString();
      labelOdczytDodajPradStanBylo.Text = dane0.PradStan.ToString();
      labelOdczytDodajCWStanBylo.Text = dane0.CWStan.ToString();
      labelOdczytDodajZWStanBylo.Text = dane0.ZWStan.ToString();

      //w inne i czynszach wpisuje jako biezące
      entryOdczytDodajGazLicznik.Text = dane0.GazLicznik.ToString();
      entryOdczytDodajGazCena.Text = dane0.GazCena.ToString();
      entryOdczytDodajPradLicznik.Text = dane0.PradLicznik.ToString();
      entryOdczytDodajPradCena.Text = dane0.PradCena.ToString();
      entryOdczytDodajZWCena.Text = dane0.ZWCena.ToString();
      entryOdczytDodajCWCena.Text = dane0.CWCena.ToString();
      entryOdczytDodajInternet.Text = dane0.Internet.ToString();

      //w czynsze wpisuje jako biezace
      entryOdczytDodajCzynsz.Text = dane0.Czynsz.ToString();
      entryOdczytDodajInternet.Text = dane0.Internet.ToString();
      entryOdczytDodajPokojDuzyCena.Text = dane0.PokojDuzyCena.ToString();
      entryOdczytDodajPokojSredniCena.Text = dane0.PokojSredniCena.ToString();
      entryOdczytDodajPokojMalyCena.Text = dane0.PokojMalyCena.ToString();
    }


    private void buttonOdczytDodaj_Clicked(object sender, EventArgs e)
    {
      if (stackLayoutOdczytDodaj.IsVisible == false)
      {
        stackLayoutOdczytDodajEdytujUsun.IsVisible = false;
        stackLayoutOdczytDodaj.IsVisible = true;

        buttonOdczytDodajLiczniki.IsVisible = false;
        stackLayoutOdczytDodajLiczniki.IsVisible=true;

        buttonOdczytDodajInne.IsVisible = true;
        stackLayoutOdczytDodajInne.IsVisible = false;

        buttonOdczytDodajCzynsze.IsVisible = true;
        stackLayoutOdczytDodajCzynsze.IsVisible = false;

        OdczytDodajStart();
      }
      else
      {
        stackLayoutOdczytDodaj.IsVisible = false;
        stackLayoutOdczytDodajEdytujUsun.IsVisible = true;
      }
    }


    private void buttonOdczytDodajLiczniki_Clicked(object sender, EventArgs e)
    {
      buttonOdczytDodajLiczniki.IsVisible = false;
      stackLayoutOdczytDodajLiczniki.IsVisible = true;

      buttonOdczytDodajInne.IsVisible = true;
      stackLayoutOdczytDodajInne.IsVisible = false;

      buttonOdczytDodajCzynsze.IsVisible = true;
      stackLayoutOdczytDodajCzynsze.IsVisible = false;
    }


    private void buttonOdczytDodajInne_Clicked(object sender, EventArgs e)
    {
      buttonOdczytDodajLiczniki.IsVisible = true;
      stackLayoutOdczytDodajLiczniki.IsVisible = false;

      buttonOdczytDodajInne.IsVisible = false;
      stackLayoutOdczytDodajInne.IsVisible = true;

      buttonOdczytDodajCzynsze.IsVisible = true;
      stackLayoutOdczytDodajCzynsze.IsVisible = false;
    }


    private void buttonOdczytDodajCzynsze_Clicked(object sender, EventArgs e)
    {
      buttonOdczytDodajLiczniki.IsVisible = true;
      stackLayoutOdczytDodajLiczniki.IsVisible = false;

      buttonOdczytDodajInne.IsVisible = true;
      stackLayoutOdczytDodajInne.IsVisible = false;

      buttonOdczytDodajCzynsze.IsVisible = false;
      stackLayoutOdczytDodajCzynsze.IsVisible = true;
    }









    private void entryOdczytDodajGazStan_Completed(object sender, EventArgs e)
    {


    }

    private void entryOdczytDodajZWStan_Completed(object sender, EventArgs e)
    {

    }


    private void entryOdczytDodajCWStan_Completed(object sender, EventArgs e)
    {

    }


    private void entryOdczytDodajPradLicznik_Completed(object sender, EventArgs e)
    {

    }

    private void entryOdczytDodajPradCena_Completed(object sender, EventArgs e)
    {

    }

    private void entryOdczytDodajGazLicznik_Completed(object sender, EventArgs e)
    {

    }

    private void entryOdczytDodajGazCena_Completed(object sender, EventArgs e)
    {

    }



    private void entryOdczytDodajCWCena_Completed(object sender, EventArgs e)
    {

    }

    private void entryOdczytDodajZWCena_Completed(object sender, EventArgs e)
    {

    }

    private void entryOdczytDodajInternet_Completed(object sender, EventArgs e)
    {

    }

    private void entryOdczytDodajCzynsz_Completed(object sender, EventArgs e)
    {

    }

    private void entryOdczytDodajPokojDuzyCena_Completed(object sender, EventArgs e)
    {

    }

    private void entryOdczytDodajPokojMalyCena_Completed(object sender, EventArgs e)
    {

    }

    private void entryOdczytDodajPokojSredniCena_Completed(object sender, EventArgs e)
    {

    }





    private void buttonOdczytDodajOK_Clicked(object sender, EventArgs e)
    {
      plik.Zapisz(listDane);

    }


    private void buttonOdczytDodajCancel_Clicked(object sender, EventArgs e)
    {
      stackLayoutOdczytDodaj.IsVisible = false;
      stackLayoutOdczytDodajEdytujUsun.IsVisible = true;
    }









    //-------------edytuj-------------------------------------------------

    private void buttonOdczytEdytuj_Clicked(object sender, EventArgs e)
    {

    }




    //-----------usuń----------------------------------------------
    private void buttonOdczytUsun_Clicked(object sender, EventArgs e)
    {

    }

    private void entryOdczytDodajGazStan_TextChanged(object sender, TextChangedEventArgs e)
    {

      int i = int.Parse(entryOdczytDodajGazStan.Text);
      if (i < listDane[listDane.Count - 1].GazStan)
      {
        entryOdczytDodajGazStan.BackgroundColor = Color.Red;
        DisplayAlert("bład",
         "wpisany stan: " + entryOdczytDodajGazStan.Text + " jest mniejszy niż był\npopraw",
         "OK");
      }
      else
      {
        dane.PradStan = i;
        entryOdczytDodajGazStan.BackgroundColor = Color.LightSteelBlue;
      }



    }

    private void listViewWyliczenia_ItemTapped(object sender, ItemTappedEventArgs e)
    {

        }
    }
}