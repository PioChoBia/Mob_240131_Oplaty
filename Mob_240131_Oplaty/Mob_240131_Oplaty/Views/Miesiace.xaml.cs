﻿using Mob_240131_Oplaty.Models;
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
  public partial class Miesiace : ContentPage
  {
    public Miesiace()
    {
      InitializeComponent();





    }



    private void listViewMiesiaceWyliczeniaPokaz_ItemTapped(object sender, ItemTappedEventArgs e)
    {

    }

    private void ContentPage_PropertyChanging(object sender, PropertyChangingEventArgs e)
    {
      Obliczenia obliczenia = new Obliczenia();
      var v = obliczenia.ListMiesiacePokazWylicz();
      if (v.Count > 0)
      {
        labelMiesiace.IsVisible = false;
        listViewMiesiaceWyliczeniaPokaz.ItemsSource = v;
      }
      else
      {
        labelMiesiace.IsVisible = true;
      }

    }


    /*

    private void OdczytyDanePokaz()
    {  
      Dane dane0 = new Dane();
      List<Dane> listDane0 = new List<Dane>();
      DanePokaz danePokaz0 = new DanePokaz();
      List<DanePokaz> listDanePokaz0 = new List<DanePokaz>();

      //wczytuje listę danych z poszczególnych miesięcy z pliku
      listDane0 = dane0.Wczytaj();

      //obrabiam listę danych na ekran
      listDanePokaz0 = danePokaz0.ListDanePokazObrob(listDane0);
      listViewOdczytyDanePokaz.ItemsSource = listDanePokaz0;

    }





    private void OdczytyWyliczeniaPokaz()
    {
      Wyliczenia wyliczenia0 = new Wyliczenia();

      listDane.Clear();
      listDane = plik.Wczytaj();

      listWyliczenia.Clear();
      for (int i = 0; i < listDane.Count-1; i++)
      {
        listWyliczenia.Add(wyliczenia0.WyliczMiesiac(listDane[i+1], listDane[i]));
      }

      listWyliczenia = wyliczenia0.SortujListWyliczenia(listWyliczenia);
      listViewOdczytyWyliczenia.ItemsSource = listWyliczenia;
    }




    private void OdczytyPokazDaneDodajEdytuj(List<Dane> listDane,bool takNaDopisz)
    {
      List<string> listPickerMiesiac = new List<string>
      {
        "styczeń","luty","marzec","kwiecień","maj","czerwiec",
        "lipiec","sierpień","wrzesień","październik","listopad","grudzień"
      };

      Dane dane0 = new Dane();
      if (takNaDopisz)
      {           

        pickerOdczytyMiesiac.Title = listPickerMiesiac.ElementAt(DateTime.Today.Month - 1);
        pickerOdczytyMiesiac.ItemsSource = listPickerMiesiac;

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

        datePickerOdczyty.Date = dane0.Data;

        pickerOdczytyMiesiac.Title = listPickerMiesiac.ElementAt(dane0.Miesiac);
        pickerOdczytyMiesiac.ItemsSource = listPickerMiesiac;

        labelOdczytyGazStanBylo.Text = "";
        labelOdczytyPradStanBylo.Text = "";
        labelOdczytyZWStanBylo.Text = "";
        labelOdczytyCWStanBylo.Text = "";
      }

      entryOdczytyGazStan.Text = dane0.GazStan.ToString() ;
      entryOdczytyPradStan.Text = dane0.PradStan.ToString();
      entryOdczytyZWStan.Text = dane0.ZWStan.ToString();
      entryOdczytyCWStan.Text = dane0.CWStan.ToString();

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
      labelOdczytyUsun.Text = wyliczeniaTapped.WierszDataMiesiac;
      labelOdczytyEdytuj.Text = wyliczeniaTapped.WierszDataMiesiac;
    }


    private void buttonOdczytyDodaj_Clicked(object sender, EventArgs e)
    {
      stackLayoutOdczytyDodajEdytujUsun.IsVisible = false;
      listViewOdczytyWyliczenia.IsVisible = false;
      stackLayoutOdczytyDodaj.IsVisible = true;
      OdczytyPokazDaneDodajEdytuj(listDane, true);
      stackLayoutOdczytyDane.IsVisible = true;
    }


    private void buttonOdczytyDodaj1_Clicked(object sender, EventArgs e)
    {
      Dane dane0 = new Dane();

      //odczytuje dane z formularza
      dane0.Data = datePickerOdczyty.Date;
      //jak nie wybrano miesiaca daje -1
      if (pickerOdczytyMiesiac.SelectedIndex==-1)
      {
        dane0.Miesiac = dane0.Data.Month;
      }
      else
      {
        dane0.Miesiac = pickerOdczytyMiesiac.SelectedIndex;
      }           
      dane0.Czynsz = double.Parse(entryOdczytyCzynsz.Text);
      dane0.ZWStan = int.Parse(entryOdczytyZWStan.Text);
      dane0.ZWCena = double.Parse(entryOdczytyZWCena.Text);
      dane0.CWStan = int.Parse(entryOdczytyCWStan.Text);
      dane0.CWCena = double.Parse(entryOdczytyCWCena.Text);
      dane0.Internet = double.Parse(entryOdczytyInternet.Text);
      dane0.GazStan = int.Parse(entryOdczytyGazStan.Text);
      dane0.GazLicznik = double.Parse(entryOdczytyGazLicznik.Text);
      dane0.GazCena = double.Parse(entryOdczytyGazCena.Text);
      dane0.PradStan = int.Parse(entryOdczytyPradStan.Text);
      dane0.PradLicznik = double.Parse(entryOdczytyPradLicznik.Text);
      dane0.PradCena = double.Parse(entryOdczytyPradCena.Text);
      dane0.PokojDuzyCena = double.Parse(entryOdczytyPokojDuzyCena.Text);
      dane0.PokojSredniCena = double.Parse(entryOdczytyPokojSredniCena.Text);
      dane0.PokojMalyCena = double.Parse(entryOdczytyPokojMalyCena.Text);

      //zapisuje do pliku
      listDane.Add(dane0);
      plik.Zapisz(listDane);

      //zamyka okna
      stackLayoutOdczytyDane.IsVisible = false;
      stackLayoutOdczytyDodaj.IsVisible = false;

      //otwiera okna i przelicza dane
      OdczytyWyliczeniaPokaz();
      stackLayoutOdczytyDodajEdytujUsun.IsVisible = true;
      listViewOdczytyWyliczenia.IsVisible = true;
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

    private void buttonOdczytyEdytuj1_Clicked(object sender, EventArgs e)
    {

    }

    private void buttonOdczytyEdytujCancel_Clicked(object sender, EventArgs e)
    {

    }


    //usuń dane z miesiąca
    private void buttonOdczytyUsun_Clicked(object sender, EventArgs e)
    {
      stackLayoutOdczytyDodajEdytujUsun.IsVisible = false;
      stackLayoutOdczytyUsun.IsVisible = true;
    }


    private void buttonOdczytyUsunCancel_Clicked(object sender, EventArgs e)
    {
      stackLayoutOdczytyDodajEdytujUsun.IsVisible = true;
      stackLayoutOdczytyUsun.IsVisible = false;
    }


    private void buttonOdczytyUsun1_Clicked(object sender, EventArgs e)
    {
      stackLayoutOdczytyUsun1.IsVisible = false;
      stackLayoutOdczytyUsun2.IsVisible = true;
    }


    private void buttonOdczytyUsun2_Clicked(object sender, EventArgs e)
    {
      listDane.RemoveAt(nrTapped);
      plik.Zapisz(listDane);
      OdczytyWyliczeniaPokaz();

      stackLayoutOdczytyUsun1.IsVisible = true;
      stackLayoutOdczytyUsun2.IsVisible = false;
      stackLayoutOdczytyUsun.IsVisible = false;
      stackLayoutOdczytyDodajEdytujUsun.IsVisible = true;
    }

    private void buttonOdczytyUsunCancel2_Clicked(object sender, EventArgs e)
    {
      stackLayoutOdczytyUsun1.IsVisible = true;
      stackLayoutOdczytyUsun2.IsVisible = false;
      stackLayoutOdczytyUsun.IsVisible = false;
      stackLayoutOdczytyDodajEdytujUsun.IsVisible = true;
    }

    private void listViewOdczytyDanePokaz_ItemTapped(object sender, ItemTappedEventArgs e)
    {

    }

    */


  }
}