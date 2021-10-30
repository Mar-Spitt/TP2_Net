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

        public List<AlumnoInscripcion> GetAll()
        {
            List<AlumnoInscripcion> inscripciones = new List<AlumnoInscripcion>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdInscripcion = new SqlCommand("select id_inscripcion, id_alumno, ai.id_curso, ai.condicion, ai.nota," +
                    " c.anio_calendario, m.desc_materia, com.desc_comision" +
                    " from alumnos_inscripciones ai" +
                    " inner join cursos c on c.id_curso = ai.id_curso" +
                    " inner join materias m on c.id_materia = m.id_materia" +
                    " inner join comisiones com on com.id_comision = c.id_comision", sqlConn);
                SqlDataReader drInscripcion = cmdInscripcion.ExecuteReader();
                while (drInscripcion.Read())
                {
                    AlumnoInscripcion ins = new AlumnoInscripcion();
                    ins.ID = (int)drInscripcion["id_inscripcion"];
                    ins.IDAlumno = (int)drInscripcion["id_alumno"];
                    ins.IDCurso = (int)drInscripcion["id_curso"];
                    ins.Condicion = (string)drInscripcion["condicion"];
                    ins.AnioCalendario = (int)drInscripcion["anio_calendario"];
                    ins.DescripcionMateria = (string)drInscripcion["desc_materia"];
                    ins.DescripcionComision = (string)drInscripcion["desc_comision"];
                    if(drInscripcion["nota"] is DBNull)
                    { ins.Nota = null; }
                    else
                    {
                        ins.Nota = (Nullable<int>)drInscripcion["nota"];
                    }
                    

                    inscripciones.Add(ins);
                }

                drInscripcion.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de inscripciones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return inscripciones;
        }

        public void GuardarNota(AlumnoInscripcion RegIns)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand("update alumnos_inscripciones set condicion=@condicion, nota=@nota where id_inscripcion=@id", sqlConn);

                cmdUpdate.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = RegIns.Condicion;
                cmdUpdate.Parameters.Add("@nota", SqlDbType.Int).Value = RegIns.Nota;
                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = RegIns.ID;

                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcpcionManejada = new Exception("Error al registrar nota", Ex);
                throw ExcpcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


    }
}
