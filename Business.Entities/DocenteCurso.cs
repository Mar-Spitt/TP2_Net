using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class DocenteCurso : BusinessEntity
    {
        //private TiposCargos _Cargo;
        private int _IDCurso;
        private int _IDDocente;

        //public DocenteCurso()
        //{
        //    this.Cargo = TiposCargos.Profesor ;
        //}

        //public TiposCargos Cargo
        //{
        //    get { return _Cargo; }
        //    set { _Cargo = value; }
        //}

        public int IDCurso
        {
            get => default;
            set
            {
            }
        }

        public int IDDocente
        {
            get => default;
            set
            {
            }
        }

        //public enum TiposCargos
        //{
        //    Profesor
        //}
    }
}
