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
  public partial class Suma : TabbedPage
  {
    public Suma()
    {
      var prad = new NavigationPage(new Prad()) { Title = "prad" };
      var gaz = new NavigationPage(new Gaz()) { Title = "gaz" };
      var zw = new NavigationPage(new ZimnaWoda()) { Title = "zw" };
      var cw = new NavigationPage(new CieplaWoda()) { Title = "cw" };
      Children.Add(prad);
      Children.Add(gaz);
      Children.Add(zw);
      Children.Add(cw);

      InitializeComponent();
    }
  }
}