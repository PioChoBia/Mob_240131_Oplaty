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

    Dane dane1=new Dane();
    int nrTapped = 0;
    List<Wyliczenia> listWyliczenia = new List<Wyliczenia>();

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
    


    public Suma()
    {
      InitializeComponent();

      Wyliczenia wyliczenia = new Wyliczenia();


      listWyliczenia.Add( wyliczenia.WyliczMiesiac( listDane[1], listDane[0] ) );
      listWyliczenia.Add( wyliczenia.WyliczMiesiac( listDane[1], listDane[0] ) );

      listWyliczenia = SortujListWyliczenia( listWyliczenia );

      listViewWyliczenia.ItemsSource = listWyliczenia;
      


    }




    List<Wyliczenia> SortujListWyliczenia(List<Wyliczenia> lw0)
    {
      List<Wyliczenia> lw1 = new List<Wyliczenia>();
      List<Dane> ld1 = new List<Dane>();

      //sortuje, układa od ostatniego jako pierwszy do pierwszego
      for (int i = 0; i<lw0.Count; i++)
      {
        lw1.Add( lw0[lw0.Count-1-i] );
      }
      return lw1;
    }





    private void listViewWyliczenia_ItemTapped(object sender, ItemTappedEventArgs e)
    {
      Wyliczenia wyliczeniaTapped = e.Item as Wyliczenia;
      nrTapped = listWyliczenia.IndexOf( wyliczeniaTapped );
      labelSumaUsun.Text = nrTapped+ " "+  wyliczeniaTapped.WierszDataMiesiac;
      labelSumaEdytuj.Text = nrTapped + " " + wyliczeniaTapped.WierszDataMiesiac;

    }




    //---dodaj----------------------------------------------------------------
    private void buttonSumaDodaj_Clicked(object sender, EventArgs e)
    {
      if (stackLayoutSumaDodaj.IsVisible == false 
          && stackLayoutSumaEdytuj.IsVisible == false 
          && stackLayoutSumaUsun.IsVisible == false)
      {
        stackLayoutSumaDodaj.IsVisible = true;




      }
      else
      {
        stackLayoutSumaDodaj.IsVisible = false;
      }



    }

    private void buttonSumaDodaj1_Clicked(object sender, EventArgs e)
    {

    }

    private void buttonSumaDodajCancel_Clicked(object sender, EventArgs e)
    {
      stackLayoutSumaEdytuj.IsVisible = false;
    }






    //---edytuj-------------------------------------------------------
    private void buttonSumaEdytuj_Clicked(object sender, EventArgs e)
    {
      if (stackLayoutSumaDodaj.IsVisible == false
           && stackLayoutSumaEdytuj.IsVisible == false
           && stackLayoutSumaUsun.IsVisible == false)
      {
        stackLayoutSumaEdytuj.IsVisible = true;




      }
      else
      {
        labelSumaEdytuj.Text = "";
        stackLayoutSumaEdytuj.IsVisible = false;
      }

    }


    private void buttonSumaEdytuj1_Clicked(object sender, EventArgs e)
    {

    }

    private void buttonSumaEdytujCancel_Clicked(object sender, EventArgs e)
    {
      labelSumaEdytuj.Text = "";
      stackLayoutSumaEdytuj.IsVisible = false;
    }




    //---usuń--------------------------------------------------------
    private void buttonSumaUsun_Clicked(object sender, EventArgs e)
    {
      if (stackLayoutSumaDodaj.IsVisible == false)
      {
        stackLayoutSumaDodajEdytujUsun.IsVisible = false;
        stackLayoutSumaUsun.IsVisible = true;


      }
      else
      {
        labelSumaUsun.Text = "";
        stackLayoutSumaUsun.IsVisible = false;
        stackLayoutSumaDodajEdytujUsun.IsVisible = true;
      }
    }



    private void buttonSumaUsun1_Clicked(object sender, EventArgs e)
    {
      stackLayoutSumaUsun1.IsVisible = false;
      stackLayoutSumaUsun2.IsVisible= true;


    }

    private void buttonSumaUsunCancel_Clicked(object sender, EventArgs e)
    {
      labelSumaUsun.Text = "";
      stackLayoutSumaUsun.IsVisible = false;
      stackLayoutSumaDodajEdytujUsun.IsVisible = true;
    }

    private void buttonSumaUsun2_Clicked(object sender, EventArgs e)
    {
      listDane.RemoveAt(nrTapped);
      listWyliczenia.RemoveAt(nrTapped);



      labelSumaUsun.Text = " - usunięto - ";
      stackLayoutSumaUsun1.IsVisible = true;
      stackLayoutSumaUsun2.IsVisible = false;
    }

    private void buttonSumaUsunCancel2_Clicked(object sender, EventArgs e)
    {
      stackLayoutSumaUsun1.IsVisible = true;
      stackLayoutSumaUsun2.IsVisible = false;
    }
  
  
  }
}