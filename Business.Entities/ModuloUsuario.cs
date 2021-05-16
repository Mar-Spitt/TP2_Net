using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class ModuloUsuario : BusinessEntity
    {
        private int _IDModulo;
        private int _IDUsuario;
        private bool _PermiteAlta;
        private bool _PermiteBaja;
        private bool _PermiteConsulta;
        private bool _PermiteModificacion;

        public int IdUsuario { get; set; }
        public int IdModulo { get; set; }
        public bool PermiteAlta { get; set; }
        public bool PermiteBaja { get; set; }
        public bool PermiteModificacion { get; set; }
        public bool PermiteConsulta { get; set; }
    }
}
