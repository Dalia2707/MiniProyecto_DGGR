using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using MiniProyecto_DGGR.Datos;
using MiniProyecto_DGGR.Model;
using MiniProyecto_DGGR.Vista;
using System.Linq;

namespace MiniProyecto_DGGR.ViewModel
{
    public class VMIncertar : BaseViewModel
    {
        #region VARIABLES
        string _Txtidejercicio;
        string _Txtcalorias;
        string _Txtkilos;
        string _Txtdistancia;
        #endregion

        #region CONSTRUCTOR
        public VMIncertar(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion
        #region PROPIEDADES
        public string Txtidejercicio
        {
            get { return _Txtidejercicio; }
            set { SetValue(ref _Txtidejercicio, value); }
        }

        public string Txtcalorias
        {
            get { return _Txtcalorias; }
            set { SetValue(ref _Txtcalorias, value); }
        }

        public string Txtkilos
        {
            get { return _Txtkilos; }
            set { SetValue(ref _Txtkilos, value); }
        }

        public string Txtdistancia
        {
            get { return _Txtdistancia; }
            set { SetValue(ref _Txtdistancia, value); }
        }
        #endregion

        #region MÉTODOS
        public async Task CompararRegistros()
        {
            var funcion = new Dejercicio();
            var registros = await funcion.Mostrarejercicio();

            if (registros.Count >= 2)
            {
                var ultimoRegistro = registros.Last();
                var penultimoRegistro = registros[registros.Count - 2];

                // Convertir los valores de string a int
                int caloriasUltimo = int.Parse(ultimoRegistro.Calorias);
                int kilosUltimo = int.Parse(ultimoRegistro.Kilos);
                int distanciaUltimo = int.Parse(ultimoRegistro.Distancia);

                int caloriasPenultimo = int.Parse(penultimoRegistro.Calorias);
                int kilosPenultimo = int.Parse(penultimoRegistro.Kilos);
                int distanciaPenultimo = int.Parse(penultimoRegistro.Distancia);

                // Comparar campos
                bool felicitaciones = caloriasUltimo > caloriasPenultimo &&
                                      kilosUltimo > kilosPenultimo &&
                                      distanciaUltimo > distanciaPenultimo;

                bool bienHecho = (caloriasUltimo > caloriasPenultimo &&
                                  kilosUltimo > kilosPenultimo) ||
                                 (caloriasUltimo > caloriasPenultimo &&
                                  distanciaUltimo > distanciaPenultimo) ||
                                 (kilosUltimo > kilosPenultimo &&
                                  distanciaUltimo > distanciaPenultimo);

                if (felicitaciones)
                {
                    await MostrarMensaje("¡Felicitaciones! Has superado tus registros anteriores en calorías, kilos y distancia recorrida.");
                }
                else if (bienHecho)
                {
                    await MostrarMensaje("¡Bien hecho! Has mejorado en al menos dos campos con respecto a tus registros anteriores.");
                }
                else
                {
                    await MostrarMensaje("Puedes mejorar. Tus registros actuales no superan a los registros anteriores en ningún campo.");
                }
            }
            else
            {
                await MostrarMensaje("No hay suficientes registros para comparar.");
            }
        }
        private async Task MostrarMensaje(string mensaje)
        {
            await Application.Current.MainPage.DisplayAlert("Comparación de Registros", mensaje, "Aceptar");
        }

        public async Task Insertar()
        {
            var funcion = new Dejercicio();
            var parametros = new Mejercicio
            {
                Calorias = Txtcalorias,
                Kilos = Txtkilos,
                Distancia = Txtdistancia
            };
            await funcion.Insertarejercicio(parametros);
            await Volver();
            await CompararRegistros();
        }

        public async Task Volver()
        {
            // Envuelve la página en un NavigationPage
            var navigationPage = new NavigationPage(new Listaejercicio());
            await Navigation.PushModalAsync(navigationPage);
        }
        #endregion

        #region COMANDOS
        public ICommand Insertarcommand => new Command(async () => await Insertar());
        public ICommand Volvercommand => new Command(async () => await Volver());
        #endregion
    }
}
