using System;
using System.Data;
using System.Data.SqlClient;
using Business.Entities;

namespace Data.Database
{
    public class PersonaAdapter: Adapter
    {
        public Persona GetOne(int legajo)
        {
            Persona per = new Persona();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPer = new SqlCommand("select id_persona from personas where legajo=@legajo", sqlConn);
                cmdPer.Parameters.Add("@legajo", SqlDbType.Int).Value = legajo;
                SqlDataReader drPer = cmdPer.ExecuteReader();
                if (drPer.Read())
                {
                    per.ID = (int)drPer["id_persona"];

                }
                else
                {
                    per = null;
                }
                drPer.Close();
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
            return per;
        }

       

    }
}
