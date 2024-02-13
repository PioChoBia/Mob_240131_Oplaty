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

    public List<string> listPickerMiesiac = new List<string>
      {
        "styczeń","luty","marzec","kwiecień","maj","czerwiec",
        "lipiec","sierpień","wrzesień","październik","listopad","grudzień"
      };


    public List<Dane> listDane1 = new List<Dane>();

    public List<Dane> listDane = new List<Dane>
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





    public Odczyt()
    {
      InitializeComponent();

      Zapisz(listDane);

      listDane1 = Wczytaj();

      

    }


    private List<Dane> Wczytaj()
    {
      string[] tabelaLinia; 
      List<Dane> listDane0 = new List<Dane>();

      NumberFormatInfo nfi = new NumberFormatInfo();
      nfi.NumberDecimalSeparator = ".";


      string basePath0 = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
      string fileName0 = Path.Combine(basePath0, "plik102.txt");

      tabelaLinia = File.ReadAllLines( fileName0 );

      foreach( string line in tabelaLinia)
      {
        Dane dane = new Dane();
        string[] splits = line.Split(' ');
        
        dane.Data = DateTime.Parse(splits[0], nfi);
        dane.Miesiac = int.Parse(splits[1],nfi);
        
        dane.Czynsz = double.Parse(splits[2],nfi);
        dane.ZWStan = int.Parse(splits[3], nfi);
        dane.ZWCena = double.Parse(splits[4], nfi);
        dane.CWStan = int.Parse(splits[5], nfi);
        dane.CWCena = double.Parse(splits[6], nfi);
        
        dane.Internet = double.Parse(splits[7], nfi);

        dane.GazStan = int.Parse(splits[8], nfi);
        dane.GazOplata = double.Parse(splits[9], nfi);
        dane.GazCena = double.Parse(splits[10], nfi);

        dane.PradStan = int.Parse(splits[11], nfi);
        dane.PradOplata = double.Parse(splits[12], nfi);
        dane.PradCena = double.Parse(splits[13], nfi);

        dane.PokojDuzyCena = double.Parse(splits[14], nfi);
        dane.PokojSredniCena = double.Parse(splits[15], nfi);
        dane.PokojMalyCena = double.Parse(splits[16], nfi);

        listDane0.Add(dane);
      }

      labelTest1.Text = listDane0[1].Data.ToLongDateString()+"=" + listDane0[0].Czynsz.ToString();


      return listDane0;
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
        linia += item.GazOplata.ToString(nfi) + " ";
        linia += item.GazCena.ToString(nfi) + " ";

        linia += item.PradStan.ToString(nfi) + " ";
        linia += item.PradOplata.ToString(nfi) + " ";
        linia += item.PradCena.ToString(nfi) + " ";

        linia += item.PokojDuzyCena.ToString(nfi) + " ";
        linia += item.PokojSredniCena.ToString(nfi) + " ";
        linia += item.PokojMalyCena.ToString(nfi);

        listLinia.Add(linia);
      }

      File.WriteAllLines(fileName0, listLinia);

      labelTest.Text = listLinia[1];

    }






    //----dodaj-----------------------------------------------------------

    private void WartosciPoczatkoweDodaj()
    {
      pickerOdczytDodajMiesiac.Title = listPickerMiesiac.ElementAt(DateTime.Today.Month - 1);
      pickerOdczytDodajMiesiac.ItemsSource = listPickerMiesiac;

      labelOdczytDodajPradStanBylo.Text = " stan było: " + "0";



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


        WartosciPoczatkoweDodaj();

      }
      else
      {
        //tu czyść pola domyślne
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

    }


    private void buttonOdczytDodajCancel_Clicked(object sender, EventArgs e)
    {
      //tu czyść pola domyślne
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