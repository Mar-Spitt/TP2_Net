using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class UsuarioLogic : BusinessLogic
    {
        public UsuarioLogic()
        {
            this.UsuarioData = new UsuarioAdapter();
        }

        public UsuarioAdapter UsuarioData
        {
            get; set;
        }

        public Usuario GetOne(int id)
        {
            Usuario usu;
            try
            {
                usu = UsuarioData.GetOne(id);

            }
            catch (Exception Ex)
            {   
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de usuarios", Ex);
                throw ExcepcionManejada;
            }
            return usu;
        }

        public List<Usuario> GetAll()
        { List<Usuario> usuarios;
            try 
            {
                usuarios= UsuarioData.GetAll(); 
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de usuarios", Ex);
                throw ExcepcionManejada;
            }
            return usuarios;

        }

        public void Save(Usuario usu)
        {
            UsuarioData.Save(usu);
        }

        public void Delete(int id)
        {
            UsuarioData.Delete(id);
        }

        public Usuario ValidarUsuario(string usuario)
        {
            return UsuarioData.ValidarUsuario(usuario);
        }


        public bool ValidarContraseña(string usuario, string pass, Usuario usu)
        {
            return UsuarioData.ValidarContraseña(usuario, pass, usu);
        }

    }
}
