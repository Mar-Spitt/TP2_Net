using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Business.Entities;

namespace Data.Database
{
    public class PersonaAdapter: Adapter
    {
        public List<Persona> GetAll()
        {
            List<Persona> personas = new List<Persona>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPersona = new SqlCommand("select id_persona, legajo from personas", sqlConn);
              
                SqlDataReader drPersona = cmdPersona.ExecuteReader();
                while (drPersona.Read())
                {
                    Persona per = new Persona();
                    per.ID = (int)drPersona["id_persona"];
                    per.Legajo = (int)drPersona["legajo"];

                    personas.Add(per);
                }

                drPersona.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de la persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return personas;
        }
    }
}
