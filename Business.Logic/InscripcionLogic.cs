using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class InscripcionLogic : BusinessLogic
    { 
        public InscripcionLogic()
        {
            this.InscripcionData = new InscripcionAdapter();
        }
         public InscripcionAdapter InscripcionData { get; set; }

        public void Save(AlumnoInscripcion nuevaI)
        {
            try
            {
                InscripcionData.Save(nuevaI);
            }
            catch(Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al registrar inscripción", Ex);
                throw ExcepcionManejada;
            }
        }

    }
}
