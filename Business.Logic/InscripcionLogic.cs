using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class InscripcionLogic 
    { 
        public InscripcionLogic()
        {
            this.InscripcionData = new InscripcionAdapter();
        }
        public InscripcionAdapter InscripcionData { get; set; }

        public AlumnoInscripcion GetOne(int id)
        {
            AlumnoInscripcion ai;
            try
            {
                ai = InscripcionData.GetOne(id);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la Inscripcio del Alumno", Ex);
                throw ExcepcionManejada;
            }
            return ai;
        }

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

        public bool Existe(AlumnoInscripcion ins)
        {
            bool rta = false;
            try
            {
                rta= InscripcionData.Existe(ins);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al verificar inscripción", Ex);
                throw ExcepcionManejada;
            }
            return rta;
        }

        public List<AlumnoInscripcion> GetAll()
        {
            List<AlumnoInscripcion> inscripciones;
            try
            {
                inscripciones = InscripcionData.GetAll();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de inscripciones", Ex);
                throw ExcepcionManejada;
            }
            return inscripciones;
        }

        public void GuardarNota(AlumnoInscripcion updateIns)
        {
            try
            {
                InscripcionData.GuardarNota(updateIns);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al registrar nota", Ex);
                throw ExcepcionManejada;
            }
        }
    }
}
