using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class Plan : BusinessEntity
    {
        private string _Descripcion;
        private int _IDEspecialidad;

        public string Descripcion { get; set; }

        public int IDEspecialidad { get; set; }
    }
}