using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniProyecto_DGGR.Conexion
{
    public class Cconexion
    {
        public static FirebaseClient firebase = new FirebaseClient("https://ejerciciodggr-default-rtdb.firebaseio.com/");
    }
}
