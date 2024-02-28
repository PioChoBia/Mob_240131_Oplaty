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
      var odczyty = new NavigationPage(new Odczyty()) { Title = "odczyty" };
      var miesiace = new NavigationPage(new Miesiace()) { Title = "miesiące" };
      var bilanse = new NavigationPage(new Bilans()) { Title = "bilanse" };
      var suma = new NavigationPage(new Suma()) { Title = "suma" };

      Children.Add(odczyty);
      Children.Add(miesiace);
      Children.Add(bilanse);
      Children.Add(suma);
 


      InitializeComponent();
    }
  }
}