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
  public partial class Odczyt : ContentPage
  {

    


    public Odczyt()
    {
      InitializeComponent();

      List<string> listPickerMiesiac = new List<string>
      {
        "styczeń","luty","marzec","kwiecień","maj","czerwiec",
        "lipiec","sierpień","wrzesień","październik","listopad","grudzień"
      };
      
      pickerOdczytDodajMiesiac.Title = listPickerMiesiac.ElementAt( DateTime.Today.Month -1 );
      pickerOdczytDodajMiesiac.ItemsSource = listPickerMiesiac;

      labelOdczytDodajPradStanBylo.Text = " stan było: "+ "0";

      

    }


    //----dodaj-----------------------------------------------------------
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