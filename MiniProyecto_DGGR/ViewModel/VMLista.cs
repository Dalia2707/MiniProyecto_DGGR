using MiniProyecto_DGGR.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using MiniProyecto_DGGR.Datos;
using MiniProyecto_DGGR.Vista;

namespace MiniProyecto_DGGR.ViewModel
{
    public class VMLista : BaseViewModel
    {
        #region VARIABLES
        List<Mejercicio> _Listaejercicio;
        #endregion
        #region CONSTRUCTOR
        public VMLista(INavigation navigation)
        {
            Navigation = navigation;
            // Se ejecuta MostrarEjercicio() en un nuevo hilo para evitar bloquear la interfaz de usuario.
             MostrarEjercicio();
        }
        #endregion
        #region OBJETO
        public List<Mejercicio> ListaEjercicio
        {
            get { return _Listaejercicio; }
            set
            {
                _Listaejercicio = value;
                OnPropertyChanged(nameof(ListaEjercicio)); // Notificar a la vista sobre cambios en la lista.
            }
        }
        #endregion
        #region PROCESO
        public async Task MostrarEjercicio()
        {
            var funcion = new Dejercicio();
            ListaEjercicio = await funcion.Mostrarejercicio();
        }
        // Método para navegar a la página de registro de ejercicios.
        private async Task GoRegistrar()
        {
            // Envuelve la página en un NavigationPage
            var navigationPage = new NavigationPage(new Registrarejercicio());
            await Navigation.PushModalAsync(navigationPage);
        }

        // Método para navegar a la página de edición de ejercicios.
        private async Task GoEditar(Mejercicio ejercicio)
        {
            // Envuelve la página en un NavigationPage
            var navigationPage = new NavigationPage(new Editarejercicio(ejercicio));
            await Navigation.PushModalAsync(navigationPage);
        }
        #endregion
        #region COMANDO
        // Comandos para la navegación a las páginas de registro y edición.
        public ICommand IraRegistrocommand => new Command(async () => await GoRegistrar());
        public ICommand IraEditarcommand => new Command<Mejercicio>(async (n) => await GoEditar(n));
        #endregion
    }
}
