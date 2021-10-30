using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class AlumnoInscripcion : BusinessEntity
    {

        public string Condicion { get; set; }
        public int IDAlumno { get; set; }
        public int IDCurso { get; set; }
        public string DescripcionMateria { get; set; }
        public string DescripcionComision { get; set; }
        public int AnioCalendario { get; set; }

        public Nullable<int> Nota { get; set; }
    }
}