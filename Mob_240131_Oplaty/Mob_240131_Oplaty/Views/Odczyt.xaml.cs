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
    List<Dane> listDane = new List<Dane>();
    Plik plik = new Plik();


    public Odczyt()
    {
      InitializeComponent();
          

      listDane = plik.Wczytaj();

      listViewDane1.ItemsSource= listDane;

    }






    private void Zapisz(List<Dane> listDane0)
    {
      List<string> listLinia= new List<string>();

      NumberFormatInfo nfi = new NumberFormatInfo();
      nfi.NumberDecimalSeparator = ".";

      string basePath0 = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
      string fileName0 = Path.Combine(basePath0, "plik102.txt");

      foreach (var item in listDane0)
      {
        string linia = "";              

        linia += item.Data.ToShortDateString()+" ";
        linia += item.Miesiac.ToString(nfi) + " ";


        linia += item.Czynsz.ToString(nfi) + " ";
        linia += item.ZWStan.ToString(nfi) + " ";
        linia += item.ZWCena.ToString(nfi) + " ";
        linia += item.CWStan.ToString(nfi) + " ";
        linia += item.CWCena.ToString(nfi) + " ";

        linia += item.Internet.ToString(nfi) + " ";

        linia += item.GazStan.ToString(nfi) + " ";
        linia += item.GazLicznik.ToString(nfi) + " ";
        linia += item.GazCena.ToString(nfi) + " ";

        linia += item.PradStan.ToString(nfi) + " ";
        linia += item.PradLicznik.ToString(nfi) + " ";
        linia += item.PradCena.ToString(nfi) + " ";

        linia += item.PokojDuzyCena.ToString(nfi) + " ";
        linia += item.PokojSredniCena.ToString(nfi) + " ";
        linia += item.PokojMalyCena.ToString(nfi);

        listLinia.Add(linia);
      }

      File.WriteAllLines(fileName0, listLinia);
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


    private void entryOdczytDodajPradStan_Completed(object sender, EventArgs e)
    {
      int i = int.Parse(entryOdczytDodajPradStan.Text);
      if (i < listDane[listDane.Count - 1].PradStan)
      {
        entryOdczytDodajPradStan.BackgroundColor = Color.Red;
        DisplayAlert("bład",
         "wpisany stan: "+ entryOdczytDodajPradStan.Text+" jest mniejszy niż był\npopraw",
         "OK");
      }
      else
      {
        dane.PradStan = i;
        entryOdczytDodajPradStan.BackgroundColor = Color.LightSteelBlue;
      }




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
      //Zapisz
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


  }
}