﻿using System;
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
        private int _Nota;

        public string Condicion
        {
            get => default;
            set
            {
            }
        }

        public int IDAlumno
        {
            get => default;
            set
            {
            }
        }

        public int IDCurso
        {
            get => default;
            set
            {
            }
        }

        public int Nota
        {
            get => default;
            set
            {
            }
        }
    }
}