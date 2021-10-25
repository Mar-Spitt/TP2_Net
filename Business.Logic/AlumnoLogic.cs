using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class AlumnoLogic
    {
        public AlumnoLogic()
        {
            this.AlumnoData = new AlumnoAdapter();
        }

        public AlumnoAdapter AlumnoData { get; set; }

        public Persona GetOne(int id)
        {
            Persona alu;
            try
            {
                alu = AlumnoData.GetOne(id);

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar al alumno", Ex);
                throw ExcepcionManejada;
            }
            return alu;
        }

        public List<Persona> GetAll()
        {
            List<Persona> alumnos;
            try
            {
                alumnos = AlumnoData.GetAll();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de alumnos", Ex);
                throw ExcepcionManejada;
            }
            return alumnos;

        }

        public void Save(Persona alu)
        {
            AlumnoData.Save(alu);
        }

        public void Delete(int id)
        {
            AlumnoData.Delete(id);
        }
    }
}
