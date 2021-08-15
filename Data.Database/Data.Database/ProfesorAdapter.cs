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
    public class ProfesorAdapter : Adapter
    {
        public List<Persona> GetAll()
        {
            List<Persona> profesores = new List<Persona>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdProfesor = new SqlCommand("select * from personas where tipo_persona=@tipoP", sqlConn);
                // 2 indica tipo de persona Profesor

                cmdProfesor.Parameters.Add("@tipoP", SqlDbType.Int).Value = 2;
                SqlDataReader drProfesor = cmdProfesor.ExecuteReader();
                while (drProfesor.Read())
                {
                    Persona profe = new Persona();
                    profe.ID = (int)drProfesor["id_persona"];
                    profe.Nombre = (string)drProfesor["nombre"];
                    profe.Apellido = (string)drProfesor["apellido"];
                    profe.Direccion = (string)drProfesor["direccion"];
                    profe.Email = (string)drProfesor["email"];
                    profe.Telefono = (string)drProfesor["telefono"];
                    profe.FechaNacimiento = (DateTime)drProfesor["fecha_nac"];
                    profe.Legajo = (int)drProfesor["legajo"];
                    profe.IDPlan = (int)drProfesor["id_plan"];

                    profesores.Add(profe);
                }

                drProfesor.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de profesores", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return profesores;
        }

        public Persona GetOne(int ID)
        {
            Persona profe = new Persona();
            try
            {
                this.OpenConnection();
                SqlCommand cmdProfesor = new SqlCommand("select * from personas where id_persona=@id", sqlConn);
                cmdProfesor.Parameters.Add("@id", SqlDbType.Int).Value = ID; // 2
                SqlDataReader drProfesor = cmdProfesor.ExecuteReader();
                if (drProfesor.Read())
                {
                    profe.ID = (int)drProfesor["id_persona"];
                    profe.Nombre = (string)drProfesor["nombre"];
                    profe.Apellido = (string)drProfesor["apellido"];
                    profe.Direccion = (string)drProfesor["direccion"];
                    profe.Email = (string)drProfesor["email"];
                    profe.Telefono = (string)drProfesor["telefono"];
                    profe.FechaNacimiento = (DateTime)drProfesor["fecha_nac"];
                    profe.Legajo = (int)drProfesor["legajo"];
                    profe.IDPlan = (int)drProfesor["id_plan"];

                }
                drProfesor.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del profesor", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return profe;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete personas where id_persona=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID; // 2
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar el profesor", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Persona profesor)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand("UPDATE personas SET nombre=@nombre,apellido=@apellido," +
                    "direccion=@direccion,email=@email,telefono=@telefono,fecha_nac=@fecha_nac,legajo=@legajo," +
                    "id_plan=@id_plan WHERE id_persona=@id", sqlConn);
                cmdInsert.Parameters.Add("@id", SqlDbType.Int).Value = profesor.ID;
                cmdInsert.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = profesor.Nombre;
                cmdInsert.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = profesor.Apellido;
                cmdInsert.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = profesor.Direccion;
                cmdInsert.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = profesor.Email;
                cmdInsert.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = profesor.Telefono;
                cmdInsert.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = profesor.FechaNacimiento;
                cmdInsert.Parameters.Add("@legajo", SqlDbType.Int).Value = profesor.Legajo;
                cmdInsert.Parameters.Add("@id_plan", SqlDbType.Int).Value = profesor.IDPlan;
                cmdInsert.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("Error al modificar datos del profesor", Ex);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Persona profesor)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand("INSERT INTO personas (nombre,apellido,direccion,email,telefono,fecha_nac,legajo,id_plan,tipo_persona)" +
                    "VALUES (@nombre,@apellido,@direccion,@email,@telefono,@fecha_nac,@legajo,@id_plan,@tipoP)" +
                    "SELECT @@identity", sqlConn);
                //cmdInsert.Parameters.Add("@id", SqlDbType.Int).Value = profesor.ID;
                cmdInsert.Parameters.Add("@tipoP", SqlDbType.Int).Value = 2;
                cmdInsert.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = profesor.Nombre;
                cmdInsert.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = profesor.Apellido;
                cmdInsert.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = profesor.Direccion;
                cmdInsert.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = profesor.Email;
                cmdInsert.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = profesor.Telefono;
                cmdInsert.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = profesor.FechaNacimiento;
                cmdInsert.Parameters.Add("@legajo", SqlDbType.Int).Value = profesor.Legajo;
                cmdInsert.Parameters.Add("@id_plan", SqlDbType.Int).Value = profesor.IDPlan;
                profesor.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("Error al crear el profesor", Ex);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Persona profesor)
        {
            if (profesor.State == BusinessEntity.States.Deleted)
            {
                this.Delete(profesor.ID);
            }
            else if (profesor.State == BusinessEntity.States.New)
            {
                this.Insert(profesor);
            }
            else if (profesor.State == BusinessEntity.States.Modified)
            {
                this.Update(profesor);
            }
            profesor.State = BusinessEntity.States.Unmodified;
        }
    }
}
