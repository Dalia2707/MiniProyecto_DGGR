using MiniProyecto_DGGR.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MiniProyecto_DGGR.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Listaejercicio : ContentPage
    {
        VMLista vM;
        public Listaejercicio()
        {
            InitializeComponent();
            //BindingContext = new VMLista(Navigation);
            vM = new VMLista(Navigation);
            BindingContext = vM;
            // Se usa una expresión lambda async para suscribirse al evento Appearing.
            this.Appearing += async (sender, e) => await ListarEjercicio_Appearing();
        }
        private async Task ListarEjercicio_Appearing()
        {
            // Se llama a MostrarEjercicio() para actualizar la lista al aparecer la página.
            await vM.MostrarEjercicio();
        }
    }
}