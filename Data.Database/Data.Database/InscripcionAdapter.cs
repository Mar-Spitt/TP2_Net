using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class InscripcionAdapter : Adapter
    {
        public void Save(AlumnoInscripcion nuevaIns)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand("insert into  alumnos_inscripciones(id_alumno, id_curso, " +
                    "condicion) values (@id_alu, @id_curso, @condicion) select @@identity", sqlConn);

                cmdInsert.Parameters.Add("@id_alu", SqlDbType.Int).Value = nuevaIns.IDAlumno;
                cmdInsert.Parameters.Add("@id_curso", SqlDbType.Int).Value = nuevaIns.IDCurso;
                cmdInsert.Parameters.Add("@condicion", SqlDbType.VarChar,50).Value = nuevaIns.Condicion;

                nuevaIns.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch(Exception Ex)
            {
                Exception ExcpcionManejada = new Exception("Error al registrar inscripción", Ex);
                throw ExcpcionManejada;
            }
            finally 
            {
                this.CloseConnection();
            }
        }

        public bool Existe(AlumnoInscripcion ins)
        {
            bool rta = false;
            try
            {
                this.OpenConnection();
                SqlCommand cmdFind = new SqlCommand("select * from alumnos_inscripciones where id_alumno=@alumno and id_curso=@curso", sqlConn);
                cmdFind.Parameters.Add("@alumno", SqlDbType.Int).Value = ins.IDAlumno;
                cmdFind.Parameters.Add("@curso", SqlDbType.Int).Value = ins.IDCurso;
                SqlDataReader drInscripcion = cmdFind.ExecuteReader();
                if (drInscripcion.Read())
                {
                    rta = true;
                }
            }
            catch (Exception Ex)
            {
                Exception ExcpcionManejada = new Exception("Error al buscar inscripción", Ex);
                throw ExcpcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return rta;
        }

    }
}
