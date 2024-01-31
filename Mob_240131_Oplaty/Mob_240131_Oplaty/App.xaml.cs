using Mob_240131_Oplaty.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mob_240131_Oplaty
{
  public partial class App : Application
  {
    public App()
    {
      InitializeComponent();

      MainPage = new Suma();
    }

    protected override void OnStart()
    {
    }

    protected override void OnSleep()
    {
    }

    protected override void OnResume()
    {
    }
  }
}
