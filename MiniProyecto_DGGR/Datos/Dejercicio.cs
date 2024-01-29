using Firebase.Database.Query;
using MiniProyecto_DGGR.Conexion;
using MiniProyecto_DGGR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProyecto_DGGR.Datos
{
    public class Dejercicio
    {
        public async Task Insertarejercicio(Mejercicio parametros)
        {
            await Cconexion.firebase.Child("ejercicio").PostAsync(new Mejercicio
            {
                Idejercicio = parametros.Idejercicio,
                Calorias = parametros.Calorias,
                Kilos = parametros.Kilos,
                Distancia= parametros.Distancia
            });
        }
        public async Task<List<Mejercicio>> Mostrarejercicio()
        {
            return (await Cconexion.firebase.Child("ejercicio")
                .OnceAsync<Mejercicio>())
                .Select(item => new Mejercicio
                {
                    Idejercicio = item.Key,
                    Calorias = item.Object.Calorias,
                    Kilos = item.Object.Kilos,
                    Distancia= item.Object.Distancia   
                }).ToList();
        }
        public async Task Eliminarejercicio(Mejercicio mejercicio)
        {
            string id = mejercicio.Idejercicio;
            await Cconexion.firebase.Child("ejercicio").Child(id).DeleteAsync();
        }
        public async Task Actualizarejerciico(Mejercicio parametros)
        {
            await Cconexion.firebase.Child("ejercicio").Child(parametros.Idejercicio).PutAsync(new Mejercicio
            {
                Idejercicio = parametros.Idejercicio,
                Calorias = parametros.Calorias,
                Kilos = parametros.Kilos,
                Distancia = parametros.Distancia
            });
        }
    }
}
