using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class UsuarioAdapter: Adapter
    {
        #region DatosEnMemoria
        // Esta región solo se usa en esta etapa donde los datos se mantienen en memoria.
        // Al modificar este proyecto para que acceda a la base de datos esta será eliminada
        private static List<Usuario> _Usuarios;

        //private static List<Usuario> Usuarios
        //{
        //    get
        //    {
        //        if (_Usuarios == null)
        //        {
        //            _Usuarios = new List<Business.Entities.Usuario>();
        //            Business.Entities.Usuario usr;
        //            usr = new Business.Entities.Usuario();
        //            usr.ID = 1;
        //            usr.State = Business.Entities.BusinessEntity.States.Unmodified;
        //            usr.Nombre = "Casimiro";
        //            usr.Apellido = "Cegado";
        //            usr.NombreUsuario = "casicegado";
        //            usr.Clave = "miro";
        //            usr.EMail = "casimirocegado@gmail.com";
        //            usr.Habilitado = true;
        //            _Usuarios.Add(usr);

        //            usr = new Business.Entities.Usuario();
        //            usr.ID = 2;
        //            usr.State = Business.Entities.BusinessEntity.States.Unmodified;
        //            usr.Nombre = "Armando Esteban";
        //            usr.Apellido = "Quito";
        //            usr.NombreUsuario = "aequito";
        //            usr.Clave = "carpintero";
        //            usr.EMail = "armandoquito@gmail.com";
        //            usr.Habilitado = true;
        //            _Usuarios.Add(usr);

        //            usr = new Business.Entities.Usuario();
        //            usr.ID = 3;
        //            usr.State = Business.Entities.BusinessEntity.States.Unmodified;
        //            usr.Nombre = "Alan";
        //            usr.Apellido = "Brado";
        //            usr.NombreUsuario = "alanbrado";
        //            usr.Clave = "abrete sesamo";
        //            usr.EMail = "alanbrado@gmail.com";
        //            usr.Habilitado = true;
        //            _Usuarios.Add(usr);

        //        }
        //        return _Usuarios;
        //    }
        //}
        #endregion

        public List<Usuario> GetAll()
        {
            //return new List<Usuario>(Usuarios);
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("select u.id_usuario, u.nombre_usuario, u.clave, u.habilitado, p.nombre, p.apellido, p.email, " +
                    "p.legajo from usuarios u inner join personas p on p.id_persona=u.id_persona", sqlConn);
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                while (drUsuarios.Read())
                {
                    Usuario usr = new Usuario();

                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Nombre = (string)drUsuarios["nombre"];
                    usr.Apellido = (string)drUsuarios["apellido"];
                    usr.Email = (string)drUsuarios["email"];
                    usr.Legajo = (int)drUsuarios["legajo"];

                    usuarios.Add(usr);
                }

                drUsuarios.Close();
            }
            catch (Exception Ex)
            {   
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return usuarios;
        }

        public Business.Entities.Usuario GetOne(int ID)
        {
            //return Usuarios.Find(delegate(Usuario u) { return u.ID == ID; });
            Usuario usr = new Usuario();
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("select u.id_usuario,u.nombre_usuario,u.clave,u.habilitado," +
                    "p.legajo, p.tipo_persona, u.id_persona, p.nombre, p.apellido, p.email from usuarios u inner join personas p on u.id_persona=p.id_persona where id_usuario=@id", sqlConn);
                cmdUsuarios.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                if (drUsuarios.Read())
                {
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.Nombre = (string)drUsuarios["nombre"];
                    usr.Apellido = (string)drUsuarios["apellido"];
                    usr.Email = (string)drUsuarios["email"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Legajo = (int)drUsuarios["legajo"];
                    usr.IdPersona = (int)drUsuarios["id_persona"];
                    int nro = (int)drUsuarios["tipo_persona"];
                    if (nro == (int)Persona.TiposPersonas.Alumno)
                    {
                        usr.TipoPersona = Persona.TiposPersonas.Alumno;
                    }
                    else
                    {
                        usr.TipoPersona = Persona.TiposPersonas.Profesor;
                    }
                }
                drUsuarios.Close();
            }
            catch (Exception Ex)
            {   
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return usr;
        }

        public void Delete(int ID)
        {
            //Usuarios.Remove(this.GetOne(ID));
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete usuarios where id_usuario=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar un usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE u " +
                    "SET u.nombre_usuario=@nombre_usuario,u.clave=@clave, u.habilitado=@habilitado " +
                    "FROM usuarios u  WHERE u.id_usuario=@id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = usuario.ID;
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("Error al modificar datos del usuario", Ex);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Usuario usuario)
        {
            try
            {
            this.OpenConnection();
            SqlCommand cmdInsert = new SqlCommand("INSERT INTO usuarios(nombre_usuario,clave,habilitado,id_persona) " +
            "VALUES (@nombre_usuario,@clave,@habilitado, @id_per) SELECT @@identity", sqlConn);
                // esta línea es para recuperar el ID que asignó el sql automáticamente

            cmdInsert.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
            cmdInsert.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
            cmdInsert.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
            cmdInsert.Parameters.Add("@id_per", SqlDbType.Int).Value = usuario.IdPersona;
            usuario.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("Error al crear el usuario", Ex);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            
        }

        public void Save(Usuario usuario)
        {
            
            #region CódigoViejo
            //if (usuario.State == BusinessEntity.States.New)
            //{
            //    int NextID = 0;
            //    foreach (Usuario usr in Usuarios)
            //    {
            //        if (usr.ID > NextID)
            //        {
            //            NextID = usr.ID;
            //        }
            //    }
            //    usuario.ID = NextID + 1;
            //    Usuarios.Add(usuario);
            //}
            //else if (usuario.State == BusinessEntity.States.Deleted)
            //{
            //    this.Delete(usuario.ID);
            //}
            //else if (usuario.State == BusinessEntity.States.Modified)
            //{
            //    Usuarios[Usuarios.FindIndex(delegate(Usuario u) { return u.ID == usuario.ID; })]=usuario;
            //}
            //usuario.State = BusinessEntity.States.Unmodified;
            //

            #endregion

            if (usuario.State==BusinessEntity.States.Deleted)
            {
                this.Delete(usuario.ID);
            }
            else if (usuario.State == BusinessEntity.States.New)
            {
                this.Insert(usuario);
            }
            else if (usuario.State == BusinessEntity.States.Modified)
            {
                this.Update(usuario);
            }
            usuario.State = BusinessEntity.States.Unmodified;
        }


        //Esta búsqueda es para el login:

        private Business.Entities.Usuario GetOne(string nombreusu)
        {
            //return Usuarios.Find(delegate(Usuario u) { return u.ID == ID; });
            Usuario usr = new Usuario();
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("select u.nombre_usuario, u.clave,p.tipo_persona, p.id_persona from usuarios u " +
                    "inner join personas p on u.id_persona=p.id_persona where u.nombre_usuario=@nombreusu", sqlConn);
                cmdUsuarios.Parameters.Add("@nombreusu", SqlDbType.VarChar, 50).Value = nombreusu;
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                if (drUsuarios.Read())
                {
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.IdPersona = (int)drUsuarios["id_persona"];

                    switch ((int)drUsuarios["tipo_persona"])
                    {
                        case 1:
                            usr.TipoPersona = Persona.TiposPersonas.Alumno;
                            break;
                        case 2:
                            usr.TipoPersona = Persona.TiposPersonas.Profesor;
                            break;
                        case 3:
                            usr.TipoPersona = Persona.TiposPersonas.Administrador;
                            break;
                    }

                }

                drUsuarios.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return usr;
        }

        public Usuario ValidarUsuario(string usuario)
        {
            //return Usuarios.Find(delegate (Usuario u) { return u.NombreUsuario == usuario; });
            
            return GetOne(usuario);
        }

        public bool ValidarContraseña(string usuario,string pass, Usuario usu)
        {
            bool rta = false;
            //var usu = Usuarios.Find(delegate (Usuario u) { return u.NombreUsuario == usuario && u.Clave== pass; });
            
            if (usu.NombreUsuario==usuario && usu.Clave==pass)
            {
                rta = true;
            }
            return rta;

        }

    }
}
