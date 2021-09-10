using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class ProfesorLogic
    {
        public ProfesorLogic()
        {
            this.ProfesorData = new ProfesorAdapter();
        }

        public ProfesorAdapter ProfesorData { get; set; }

        public Persona GetOne(int id)
        {
            Persona profe;
            try
            {
                profe = ProfesorData.GetOne(id);

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar al profesor", Ex);
                throw ExcepcionManejada;
            }
            return profe;
        }

        public List<Persona> GetAll()
        {
            List<Persona> profesores;
            try
            {
                profesores = ProfesorData.GetAll();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de profesores", Ex);
                throw ExcepcionManejada;
            }
            return profesores;

        }

        public void Save(Persona profe)
        {
            ProfesorData.Save(profe);
        }

        public void Delete(int id)
        {
            ProfesorData.Delete(id);
        }
    }
}
