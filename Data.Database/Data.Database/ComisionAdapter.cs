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
    public class ComisionAdapter : Adapter
    {
        public List<Comision> GetAll()
        {
            List<Comision> comisiones = new List<Comision>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdComisiones = new SqlCommand("select * from comisiones", sqlConn);
                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();
                while (drComisiones.Read())
                {
                    Comision co = new Comision();
                    co.ID = (int)drComisiones["id_comision"];
                    co.Descripcion = (string)drComisiones["desc_comision"];
                    co.AnioEspecialidad = (int)drComisiones["anio_especialidad"];
                    co.IDPlan = (int)drComisiones["id_plan"];

                    comisiones.Add(co);
                }

                drComisiones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de comisiones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return comisiones;
        }

        public Comision GetOne(int ID)
        {
            Comision co = new Comision();
            try
            {
                this.OpenConnection();
                SqlCommand cmdComision = new SqlCommand("select * from comisiones where id_comision=@id", sqlConn);
                cmdComision.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drComisiones = cmdComision.ExecuteReader();
                if (drComisiones.Read())
                {
                    co.ID = (int)drComisiones["id_comision"];
                    co.Descripcion = (string)drComisiones["desc_comision"];
                    co.AnioEspecialidad = (int)drComisiones["anio_especialidad"];
                    co.IDPlan = (int)drComisiones["id_plan"];
                }
                drComisiones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de la comisión", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return co;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete comisiones where id_comision=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar la comisión", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Comision comision)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE comisiones SET desc_comision=@descripcion, anio_especialidad=@anio_e," +
                    " id_plan=@id_plan WHERE id_comision=@id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = comision.ID;
                cmdSave.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = comision.Descripcion;
                cmdSave.Parameters.Add("@anio_e", SqlDbType.Int).Value = comision.AnioEspecialidad;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = comision.IDPlan;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("Error al modificar datos de la comision", Ex);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Comision comision)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand("INSERT INTO comisiones(desc_comision, anio_especialidad, id_plan)" +
                    " VALUES(@desc_comision,@anio_esp, @id_plan) SELECT @@identity", sqlConn);
                // esta línea es para recuperar el ID que asignó el sql automáticamente

                cmdInsert.Parameters.Add("@desc_comision", SqlDbType.VarChar, 50).Value = comision.Descripcion;
                cmdInsert.Parameters.Add("@anio_esp", SqlDbType.Int).Value = comision.AnioEspecialidad;
                cmdInsert.Parameters.Add("@id_esp", SqlDbType.Int).Value = comision.IDPlan;
                comision.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("Error al crear la comisión", Ex);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Comision comision)
        {
            try
            {
                if (comision.State == BusinessEntity.States.Deleted)
                {
                    this.Delete(comision.ID);
                }
                else if (comision.State == BusinessEntity.States.New)
                {
                    this.Insert(comision);
                }
                else if (comision.State == BusinessEntity.States.Modified)
                {
                    this.Update(comision);
                }
                comision.State = BusinessEntity.States.Unmodified;
            }
            catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("Error al modificar datos de la comisión", Ex);
                throw ExceptionManejada;
            }
        }

    }
}
