using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class PersonaLogic: BusinessLogic
    {
        public PersonaLogic()
        {
            this.PersonaData = new PersonaAdapter();
        }

        public PersonaAdapter PersonaData {get; set;}

        public List<Persona> GetAll()
        {
            List<Persona> personas;
            try
            {
                personas = PersonaData.GetAll();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de personas", Ex);
                throw ExcepcionManejada;
            }
            return personas;
        }

    }
}
