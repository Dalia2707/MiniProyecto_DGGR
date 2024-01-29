using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using MiniProyecto_DGGR.Model;
using MiniProyecto_DGGR.Datos;
using MiniProyecto_DGGR.Vista;

namespace MiniProyecto_DGGR.ViewModel
{
    public class VMEditar : BaseViewModel
    {
        #region VARIABLES
        public Mejercicio _Ejercicio { get; set; }
        #endregion

        #region CONSTRUCTOR
        public VMEditar(INavigation navigation, Mejercicio ejercicio)
        {
            Navigation = navigation;
            _Ejercicio = ejercicio;
        }
        #endregion

        #region MÉTODOS
        public async Task Editar()
        {
            var funcion = new Dejercicio();
            var parametros = new Mejercicio
            {
                Idejercicio = _Ejercicio.Idejercicio,
                Calorias = _Ejercicio.Calorias,
                Kilos = _Ejercicio.Kilos,
                Distancia = _Ejercicio.Distancia
            };

            await funcion.Actualizarejerciico(parametros);
            await Volver();
        }

        public async Task Eliminar()
        {
            var funcion = new Dejercicio();
            await funcion.Eliminarejercicio(_Ejercicio);
            await Volver();
        }

        public async Task Volver()
        {
            // Envuelve la página en un NavigationPage
            var navigationPage = new NavigationPage(new Listaejercicio());
            await Navigation.PushModalAsync(navigationPage);
        }
        #endregion

        #region COMANDOS
        public ICommand Editarcommand => new Command(async () => await Editar());
        public ICommand Eliminarcommand => new Command(async () => await Eliminar());
        public ICommand Volvercommand => new Command(async () => await Volver());
        #endregion
    }
}
