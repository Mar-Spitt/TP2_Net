using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class Comision : BusinessEntity
    {
        private int _AnioEspecialidad;
        private string _Descripcion;
        private int _IDPlan;

        public int AnioEspecialidad { get; set; }
        public string Descripcion { get; set; }
        public int IDPlan { get; set; }
    }
}