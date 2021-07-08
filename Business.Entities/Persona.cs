using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class Persona : BusinessEntity
    {
        private string _Apellido;
        private string _Direccion;
        private string _Email;
        private DateTime _FechaNacimiento;
        private int _IDPlan;
        private int _Legajo;
        private string _Nombre;
        private string _Telefono;
        private TiposPersonas _TipoPersona;

        public Persona()
        {
            this.TipoPersona = TiposPersonas.Alumno;
        }

        public string Apellido { get; set;  }

        public string Direccion { get; set; }

        public string Email { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public int IDPlan { get; set; }

        public string Nombre { get; set; }

        public int Legajo { get; set; }

        public string Telefono { get; set; }
        public TiposPersonas TipoPersona
        {
            get { return _TipoPersona; }
            set { _TipoPersona = value; }
        }
        public enum TiposPersonas
        {
            Alumno,
            Docente
        }

    }
}