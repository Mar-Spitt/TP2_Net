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
    public class MateriaAdapter : Adapter
    {
        public List<Materia> GetAll()
        {
            List<Materia> materias = new List<Materia>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdMaterias = new SqlCommand("select id_materia,desc_materia, hs_semanales, hs_totales, id_plan "+
                    "from materias", sqlConn);
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();
                while (drMaterias.Read())
                {
                    Materia ml = new Materia();
                    ml.ID = (int)drMaterias["id_materia"];
                    ml.Descripcion = (string)drMaterias["desc_materia"];
                    ml.HSSemanales = (int)drMaterias["hs_semanales"];
                    ml.HSTotales = (int)drMaterias["hs_totales"];
                    ml.IDPlan = (int)drMaterias["id_plan"];

                    materias.Add(ml);
                }

                drMaterias.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de materias", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return materias;
        }

        public Business.Entities.Materia GetOne(int ID)
        {
            Materia ml = new Materia();
            try
            {
                this.OpenConnection();
                SqlCommand cmdMateria = new SqlCommand("select * from materias where id_materia=@id", sqlConn);
                cmdMateria.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drMaterias = cmdMateria.ExecuteReader();
                if (drMaterias.Read())
                {
                    ml.ID = (int)drMaterias["id_materia"];
                    ml.Descripcion = (string)drMaterias["desc_materia"];
                    ml.HSSemanales = (int)drMaterias["hs_semanales"];
                    ml.IDPlan = (int)drMaterias["id_plan"];
                    ml.HSTotales = (int)drMaterias["hs_totales"];

                }
                drMaterias.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de la materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return ml;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete materias where id_materia=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar la materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Materia materia)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE materias SET desc_materia=@descripcion," +
                    "id_plan=@id_plan, hs_totales=@hs_totales, hs_semanales=@hs_semanales WHERE id_materia=@id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = materia.ID;
                cmdSave.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = materia.Descripcion;
                cmdSave.Parameters.Add("@hs_totales", SqlDbType.Int).Value = materia.HSTotales;
                cmdSave.Parameters.Add("@hs_semanales", SqlDbType.Int).Value = materia.HSSemanales;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = materia.IDPlan;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("Error al modificar datos de la materia", Ex);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Materia materia)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand("INSERT INTO materias(desc_materia, hs_semanales, hs_totales, id_plan) " +
                    "VALUES(@descripcion,@hs_semanales, @hs_totales, @id_plan) SELECT @@identity", sqlConn);
                // esta línea es para recuperar el ID que asignó el sql automáticamente

                cmdInsert.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = materia.Descripcion;
                cmdInsert.Parameters.Add("@hs_totales", SqlDbType.Int).Value = materia.HSTotales;
                cmdInsert.Parameters.Add("@hs_semanales", SqlDbType.Int).Value = materia.HSSemanales;
                cmdInsert.Parameters.Add("@id_plan", SqlDbType.Int).Value = materia.IDPlan;
            }
            catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("Error al crear la materia", Ex);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Materia materia)
        {
            try
            {
                if (materia.State == BusinessEntity.States.Deleted)
                {
                    this.Delete(materia.ID);
                }
                else if (materia.State == BusinessEntity.States.New)
                {
                    this.Insert(materia);
                }
                else if (materia.State == BusinessEntity.States.Modified)
                {
                    this.Update(materia);
                }
                materia.State = BusinessEntity.States.Unmodified;
            }
            catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("Error al modificar datos de la materia", Ex);
                throw ExceptionManejada;
            }
        }
    }
}
