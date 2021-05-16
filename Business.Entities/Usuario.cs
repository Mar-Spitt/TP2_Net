using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Usuario : BusinessEntity
    {
        public string _Apellido;
        public string _Clave;
        public string _EMail;
        public bool _Habilitado;
        public string _Nombre;
        public string _NombreUsuario;

        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string EMail { get; set; }
        public string Apellido { get; set; }
        public bool Habilitado { get; set; }


    }
}
