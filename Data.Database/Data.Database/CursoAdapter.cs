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
    public class CursoAdapter : Adapter
    {
        public List<Curso> GetAll()
        {
            List<Curso> cursos = new List<Curso>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdCursos = new SqlCommand("select * from cursos", sqlConn);
                SqlDataReader drCursos = cmdCursos.ExecuteReader();
                while (drCursos.Read())
                {
                    Curso cur = new Curso();
                    cur.ID = (int)drCursos["id_curso"];
                    cur.IDMateria = (int)drCursos["id_materia"];
                    cur.IDComision = (int)drCursos["id_comision"];
                    cur.AnioCalendario = (int)drCursos["anio_calendario"];
                    cur.Cupo = (int)drCursos["cupo"];
                    cur.Descripcion = (string)drCursos["descripcion"];

                    cursos.Add(cur);
                }

                drCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de cursos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return cursos;
        }

        public Curso GetOne(int ID)
        {
            Curso cur = new Curso();
            try
            {
                this.OpenConnection();
                SqlCommand cmdCurso = new SqlCommand("select * from cursos where id_curso=@id", sqlConn);
                cmdCurso.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drCursos = cmdCurso.ExecuteReader();
                if (drCursos.Read())
                {
                    cur.ID = (int)drCursos["id_curso"];
                    cur.IDMateria = (int)drCursos["id_materia"];
                    cur.IDComision = (int)drCursos["id_comision"];
                    cur.AnioCalendario = (int)drCursos["anio_calendario"];
                    cur.Cupo = (int)drCursos["cupo"];
                    cur.Descripcion = (string)drCursos["descripcion"];

                }
                drCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return cur;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete cursos where id_curso=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar el curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Curso cur)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE cursos SET id_materia=@materia, id_comision=@comision, anio_calendario=@anio, cupo=@cupo, descripcion=@descripcion WHERE id_curso=@id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = cur.ID;
                cmdSave.Parameters.Add("@materia", SqlDbType.Int).Value = cur.IDMateria;
                cmdSave.Parameters.Add("@comision", SqlDbType.Int).Value = cur.IDComision;
                cmdSave.Parameters.Add("@anio", SqlDbType.Int).Value = cur.AnioCalendario;
                cmdSave.Parameters.Add("@cupo", SqlDbType.Int).Value = cur.Cupo;
                cmdSave.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = cur.Descripcion;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("Error al modificar datos del curso", Ex);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Curso cur)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand("INSERT INTO cursos(id_materia, id_comision, anio_calendario,cupo,descripcion) VALUES(@materia, @comision, @anio, @cupo, @descripcion) SELECT @@identity", sqlConn);
                // esta línea es para recuperar el ID que asignó el sql automáticamente
                cmdInsert.Parameters.Add("@materia", SqlDbType.Int).Value = cur.IDMateria;
                cmdInsert.Parameters.Add("@comision", SqlDbType.Int).Value = cur.IDComision;
                cmdInsert.Parameters.Add("@anio", SqlDbType.Int).Value = cur.AnioCalendario;
                cmdInsert.Parameters.Add("@cupo", SqlDbType.Int).Value = cur.Cupo;
                cmdInsert.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = cur.Descripcion;
                cur.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("Error al crear el curso", Ex);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Curso cur)
        {
            try
            {
                if (cur.State == BusinessEntity.States.Deleted)
                {
                    this.Delete(cur.ID);
                }
                else if (cur.State == BusinessEntity.States.New)
                {
                    this.Insert(cur);
                }
                else if (cur.State == BusinessEntity.States.Modified)
                {
                    this.Update(cur);
                }
                cur.State = BusinessEntity.States.Unmodified;
            }
            catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("Error al modificar datos del curso", Ex);
                throw ExceptionManejada;
            }
        }

    }
}
