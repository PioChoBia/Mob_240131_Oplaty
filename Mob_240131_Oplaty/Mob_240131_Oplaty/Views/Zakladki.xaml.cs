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
  public partial class Zakladki : TabbedPage
  {

    public List<Dane> listDane1= new List<Dane>();

    public Zakladki()
    {
      var odczyt = new NavigationPage(new Odczyt()) { Title = "odczyty" };
      var miesiac = new NavigationPage(new Miesiac()) { Title = "miesiące" };
      var bilans = new NavigationPage(new Bilans()) { Title = "bilanse" };

      var suma = new NavigationPage(new Suma()) { Title = "suma" };

      Children.Add(odczyt);
      Children.Add(miesiac);
      Children.Add(bilans);

      Children.Add(suma);

   



      InitializeComponent();
    }
  }
}