using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class Curso : BusinessEntity
    {
        private int _AnioCalendario;
        private int _Cupo;
        private string _Descripcion;
        private int _IDComision;
        private int _IDMateria;

        public int AnioCalendario { get; set; }

        public int Cupo { get; set; }

        public string Descripcion { get; set; }

        public int IDComision { get; set; }

        public int IDMateria { get; set; }
    }
}