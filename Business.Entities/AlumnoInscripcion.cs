using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class AlumnoInscripcion : BusinessEntity
    {
        private string _Condicion;
        private int _IDAlumno;
        private int _IDCurso;
        private Nullable<int> _Nota;

        public string Condicion { get; set; }

        public int IDAlumno { get; set; }

        public int IDCurso { get; set; }

        public Nullable<int> Nota { get; set; }
    }
}