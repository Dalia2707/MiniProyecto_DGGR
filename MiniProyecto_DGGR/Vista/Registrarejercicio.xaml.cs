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
    public partial class Registrarejercicio : ContentPage
    {
        public Registrarejercicio()
        {
            InitializeComponent();
            BindingContext = new VMIncertar(Navigation);
        }
    }
}