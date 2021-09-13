using System;
using System.Collections.Generic;
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

        public Persona GetOne(int legajo)
        {
            Persona per;
            try
            {
                per = PersonaData.GetOne(legajo);

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar al persona", Ex);
                throw ExcepcionManejada;
            }
            return per;
        }
    }
}
