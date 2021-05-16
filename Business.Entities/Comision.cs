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

        public int AnioEspecialidad
        {
            get => default;
            set
            {
            }
        }

        public string Descripcion
        {
            get => default;
            set
            {
            }
        }

        public int IDPlan
        {
            get => default;
            set
            {
            }
        }
    }
}