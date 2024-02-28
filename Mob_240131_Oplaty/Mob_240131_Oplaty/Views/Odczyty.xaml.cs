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
  
    List<Dane> listDane = new List<Dane>();
    /*
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
    */


    List<DanePokaz> listDanePokaz=new List<DanePokaz> ();
    int nrTapped = 0;
    



    public Odczyty()
    {
      InitializeComponent();
      OdczytyDanePokaz();
    }


    private void OdczytyDanePokaz()
    {  
      Dane dane0 = new Dane();
      DanePokaz danePokaz0 = new DanePokaz();

      //wczytuje listę danych z poszczególnych miesięcy z pliku
      listDane = dane0.Wczytaj();

      //obrabiam listę danych na ekran
      listDanePokaz = danePokaz0.ListDanePokazObrob(listDane);
      listViewOdczytyDanePokaz.ItemsSource = listDanePokaz;
    }


    private void OdczytyDanePokazDodajEdytuj(bool takNaDopisz)
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
        dane0 = listDane[0];
        labelOdczytyGazStanBylo.Text=dane0.GazStan.ToString();        
        labelOdczytyPradStanBylo.Text = dane0.PradStan.ToString();        
        labelOdczytyZWStanBylo.Text = dane0.ZWStan.ToString();
        labelOdczytyCWStanBylo.Text = dane0.CWStan.ToString();
        entryOdczytyGazStan.Text = "";
        entryOdczytyPradStan.Text = "";
        entryOdczytyZWStan.Text = "";
        entryOdczytyCWStan.Text = "";
      }
      else
      {
        dane0 = listDane[nrTapped];
        datePickerOdczyty.Date = dane0.Data;
        pickerOdczytyMiesiac.Title = listPickerMiesiac.ElementAt(dane0.Miesiac);
        pickerOdczytyMiesiac.ItemsSource = listPickerMiesiac;
        labelOdczytyGazStanBylo.Text = "";
        labelOdczytyPradStanBylo.Text = "";
        labelOdczytyZWStanBylo.Text = "";
        labelOdczytyCWStanBylo.Text = "";
        entryOdczytyGazStan.Text = dane0.GazStan.ToString();
        entryOdczytyPradStan.Text = dane0.PradStan.ToString();
        entryOdczytyZWStan.Text = dane0.ZWStan.ToString();
        entryOdczytyCWStan.Text = dane0.CWStan.ToString();
      }          

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


    private void listViewOdczytyDanePokaz_ItemTapped(object sender, ItemTappedEventArgs e)
    {
      DanePokaz danePokazTapped = e.Item as DanePokaz;
      nrTapped = listDanePokaz.IndexOf(danePokazTapped);
      labelOdczytyUsun.Text = danePokazTapped.WierszDataMiesiac;
      labelOdczytyEdytuj.Text = danePokazTapped.WierszDataMiesiac;
    }

  


    //tu dodawanie-------------------------------------------------------------------------
    private void buttonOdczytyDodaj_Clicked(object sender, EventArgs e)
    {
      stackLayoutOdczytyDodajEdytujUsun.IsVisible = false;
      listViewOdczytyDanePokaz.IsVisible= false;
      stackLayoutOdczytyDodaj.IsVisible = true;
      OdczytyDanePokazDodajEdytuj(true);
      stackLayoutOdczytyDanePokazDodajEdytuj.IsVisible = true;
    }


    private void buttonOdczytyDodaj1_Clicked(object sender, EventArgs e)
    {
      Dane dane0 = new Dane();
      //odczytuje dane z formularza
      dane0.Data = datePickerOdczyty.Date;
      //jak nie wybrano miesiaca dostaje -1
      if (pickerOdczytyMiesiac.SelectedIndex==-1)
      {
        dane0.Miesiac = dane0.Data.Month;
      }
      else
      {
        dane0.Miesiac = pickerOdczytyMiesiac.SelectedIndex;
      }           

      dane0.ZWStan = int.Parse(entryOdczytyZWStan.Text);
      dane0.ZWCena = double.Parse(entryOdczytyZWCena.Text);
      dane0.CWStan = int.Parse(entryOdczytyCWStan.Text);
      dane0.CWCena = double.Parse(entryOdczytyCWCena.Text);

      dane0.Czynsz = double.Parse(entryOdczytyCzynsz.Text);
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
      listDane.Insert(0,dane0);
      dane0.Zapisz(listDane);
      //zamyka okna
      stackLayoutOdczytyDanePokazDodajEdytuj.IsVisible = false;
      stackLayoutOdczytyDodaj.IsVisible = false;
      //otwiera okna i przelicza dane
      OdczytyDanePokaz();
      stackLayoutOdczytyDodajEdytujUsun.IsVisible = true;
      listViewOdczytyDanePokaz.IsVisible = true;
    }


    private void buttonOdczytyDodajCancel_Clicked(object sender, EventArgs e)
    {
      stackLayoutOdczytyDanePokazDodajEdytuj.IsVisible = false;
      stackLayoutOdczytyDodaj.IsVisible = false;
      stackLayoutOdczytyDodajEdytujUsun.IsVisible = true;
      listViewOdczytyDanePokaz.IsVisible = true;
    }



    //tu edytowanie--------------------------------------------------------
    private void buttonOdczytyEdytuj_Clicked(object sender, EventArgs e)
    {
      stackLayoutOdczytyDodajEdytujUsun.IsVisible = false;
      stackLayoutOdczytyEdytuj1.IsVisible = true;
    }

    private void buttonOdczytyEdytujCancel_Clicked(object sender, EventArgs e)
    {
      stackLayoutOdczytyEdytuj1.IsVisible = false;
      stackLayoutOdczytyDodajEdytujUsun.IsVisible = true;
    }



    private void buttonOdczytyEdytuj1_Clicked(object sender, EventArgs e)
    {
      stackLayoutOdczytyEdytuj1.IsVisible = false;
      stackLayoutOdczytyEdytuj2.IsVisible = true;

      listViewOdczytyDanePokaz.IsVisible = false;

      OdczytyDanePokazDodajEdytuj(false);
      stackLayoutOdczytyDanePokazDodajEdytuj.IsVisible = true;

    }

    private void buttonOdczytyEdytuj2_Clicked(object sender, EventArgs e)
    {
      Dane dane0 = new Dane();
      //odczytuje dane z formularza
      dane0.Data = datePickerOdczyty.Date;
      //jak nie wybrano miesiaca dostaje -1
      if (pickerOdczytyMiesiac.SelectedIndex == -1)
      {
        dane0.Miesiac = dane0.Data.Month;
      }
      else
      {
        dane0.Miesiac = pickerOdczytyMiesiac.SelectedIndex;
      }

      dane0.ZWStan = int.Parse(entryOdczytyZWStan.Text);
      dane0.ZWCena = double.Parse(entryOdczytyZWCena.Text);
      dane0.CWStan = int.Parse(entryOdczytyCWStan.Text);
      dane0.CWCena = double.Parse(entryOdczytyCWCena.Text);

      dane0.Czynsz = double.Parse(entryOdczytyCzynsz.Text);
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
      listDane.Insert(nrTapped, dane0);
      listDane.RemoveAt(nrTapped+1);
      dane0.Zapisz(listDane);
      //zamyka okna
      stackLayoutOdczytyDanePokazDodajEdytuj.IsVisible = false;
      stackLayoutOdczytyEdytuj2.IsVisible = false;
      //otwiera okna i przelicza dane
      OdczytyDanePokaz();
      stackLayoutOdczytyDodajEdytujUsun.IsVisible = true;
      listViewOdczytyDanePokaz.IsVisible = true;

    }

    private void buttonOdczytyEdytujCancel2_Clicked(object sender, EventArgs e)
    {
      stackLayoutOdczytyEdytuj2.IsVisible = false;
      stackLayoutOdczytyDodajEdytujUsun.IsVisible = true;   
      listViewOdczytyDanePokaz.IsVisible=true;
    }



    //tu usuwanie----------------------------------------------------
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
      Dane dane0 = new Dane();
      listDane.RemoveAt(nrTapped);
      dane0.Zapisz(listDane);
      OdczytyDanePokaz();

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


  }
}