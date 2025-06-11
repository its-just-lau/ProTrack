using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTrack
{
    internal class Sesion
    {
        public static int IdUsuario { get; set; }
        public static string NombreUsuario { get; set; }
        public static string Rol { get; set; }

        public static bool EsAsesor => Rol == "ASESOR";
        public static bool EsEstudiante => Rol == "ESTUDIANTE";

    }
}
