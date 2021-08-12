using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class Materia : BusinessEntity
    {
        private string _Descripcion;
        private int _HSSemanales;
        private int _HSTotales;
        private int _IDPlan;

        public string Descripcion { get; set; }

        public int HSSemanales { get; set; }

        public int HSTotales { get; set; }

        public int IDPlan { get; set; }
    }
}