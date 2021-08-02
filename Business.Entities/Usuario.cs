using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Usuario : Persona
    {
        public string _Clave;
        public bool _Habilitado;
        public string _NombreUsuario;
        public int _IdPersona;


        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public bool Habilitado { get; set; }
        public int IdPersona { get; set; }


    }
}
