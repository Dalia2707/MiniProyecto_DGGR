using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MiniProyecto_DGGR.Vista;

namespace MiniProyecto_DGGR
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Listaejercicio();
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
