using MiniProyecto_DGGR.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniProyecto_DGGR.Model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MiniProyecto_DGGR.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Editarejercicio : ContentPage
    {
        public Editarejercicio(Mejercicio ejercicio)
        {
            InitializeComponent();
            BindingContext = new VMEditar(Navigation, ejercicio);
        }
    }
}