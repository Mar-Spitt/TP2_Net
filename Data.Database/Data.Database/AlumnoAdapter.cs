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
    public class AlumnoAdapter : Adapter
    {
        public List<Persona> GetAll()
        {
            List<Persona> alumnos = new List<Persona>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdAlumno = new SqlCommand("select * from personas where tipo_persona=@tipoP", sqlConn);
                // 1 indica tipo de persona Alumno

                cmdAlumno.Parameters.Add("@tipoP", SqlDbType.Int).Value = 1;
                SqlDataReader drAlumno = cmdAlumno.ExecuteReader();
                while (drAlumno.Read())
                {
                    Persona alu = new Persona();
                    alu.ID = (int)drAlumno["id_persona"];
                    alu.Nombre = (string)drAlumno["nombre"];
                    alu.Apellido = (string)drAlumno["apellido"];
                    alu.Direccion = (string)drAlumno["direccion"];
                    alu.Email = (string)drAlumno["email"];
                    alu.Telefono = (string)drAlumno["telefono"];
                    alu.FechaNacimiento = (DateTime)drAlumno["fecha_nac"];
                    alu.Legajo = (int)drAlumno["legajo"];
                    alu.IDPlan = (int)drAlumno["id_plan"];

                    alumnos.Add(alu);
                }

                drAlumno.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de alumnos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return alumnos;
        }

        public Persona GetOne(int ID)
        {
            Persona alu = new Persona();
            try
            {
                this.OpenConnection();
                SqlCommand cmdAlumno = new SqlCommand("select * from personas where id_persona=@id", sqlConn);
                cmdAlumno.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drAlumno = cmdAlumno.ExecuteReader();
                if (drAlumno.Read())
                {
                    alu.ID = (int)drAlumno["id_persona"];
                    alu.Nombre = (string)drAlumno["nombre"];
                    alu.Apellido = (string)drAlumno["apellido"];
                    alu.Direccion = (string)drAlumno["direccion"];
                    alu.Email = (string)drAlumno["email"];
                    alu.Telefono = (string)drAlumno["telefono"];
                    alu.FechaNacimiento = (DateTime)drAlumno["fecha_nac"];
                    alu.Legajo = (int)drAlumno["legajo"];
                    alu.IDPlan = (int)drAlumno["id_plan"];

                }
                drAlumno.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del alumno", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return alu;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete personas where id_persona=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar el alumno", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Persona alumno)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand("UPDATE personas SET nombre=@nombre,apellido=@apellido," +
                    "direccion=@direccion,email=@email,telefono=@telefono,fecha_nac=@fecha_nac,legajo=@legajo," +
                    "id_plan=@id_plan WHERE id_persona=@id", sqlConn);
                cmdInsert.Parameters.Add("@id", SqlDbType.Int).Value = alumno.ID;
                cmdInsert.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = alumno.Nombre;
                cmdInsert.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = alumno.Apellido;
                cmdInsert.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = alumno.Direccion;
                cmdInsert.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = alumno.Email;
                cmdInsert.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = alumno.Telefono;
                cmdInsert.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = alumno.FechaNacimiento;
                cmdInsert.Parameters.Add("@legajo", SqlDbType.Int).Value = alumno.Legajo;
                cmdInsert.Parameters.Add("@id_plan", SqlDbType.Int).Value = alumno.IDPlan;
                cmdInsert.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("Error al modificar datos del alumno", Ex);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Persona alumno)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand("INSERT INTO personas (nombre,apellido,direccion,email,telefono,fecha_nac,legajo,id_plan,tipo_persona)" +
                    "VALUES (@nombre,@apellido,@direccion,@email,@telefono,@fecha_nac,@legajo,@id_plan,@tipoP)" +
                    "SELECT @@identity", sqlConn);
                cmdInsert.Parameters.Add("@id", SqlDbType.Int).Value = alumno.ID;
                cmdInsert.Parameters.Add("@tipoP", SqlDbType.Int).Value = 1;
                cmdInsert.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = alumno.Nombre;
                cmdInsert.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = alumno.Apellido;
                cmdInsert.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = alumno.Direccion;
                cmdInsert.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = alumno.Email;
                cmdInsert.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = alumno.Telefono;
                cmdInsert.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = alumno.FechaNacimiento;
                cmdInsert.Parameters.Add("@legajo", SqlDbType.Int).Value = alumno.Legajo;
                cmdInsert.Parameters.Add("@id_plan", SqlDbType.Int).Value = alumno.IDPlan;
                alumno.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("Error al crear el alumno", Ex);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Persona alumno)
        {
            if (alumno.State == BusinessEntity.States.Deleted)
            {
                this.Delete(alumno.ID);
            }
            else if (alumno.State == BusinessEntity.States.New)
            {
                this.Insert(alumno);
            }
            else if (alumno.State == BusinessEntity.States.Modified)
            {
                this.Update(alumno);
            }
            alumno.State = BusinessEntity.States.Unmodified;
        }
    }
}
