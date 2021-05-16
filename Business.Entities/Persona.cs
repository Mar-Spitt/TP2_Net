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
        //private TiposPersonas _TipoPersona;

        public string Apellido
        {
            get => default;
            set
            {
            }
        }

        public string Direccion
        {
            get => default;
            set
            {
            }
        }

        public string Email
        {
            get => default;
            set
            {
            }
        }

        public DateTime FechaNacimiento
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

        public string Nombre
        {
            get => default;
            set
            {
            }
        }

        public int Legajo
        {
            get => default;
            set
            {
            }
        }

        public string Telefono
        {
            get => default;
            set
            {
            }
        }

        //public TiposPersonas TipoPersona
        //{
        //    get => default;
        //    set
        //    {
        //    }
        //}
       /*
        private TiposPersonas _TipoPersona;
        public TiposPersonas State
        {
            get { return _State; }
            set { _State = value; }
        }

        public enum TiposPersonas
        {
            
        }
       */
    }
}