using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Business.Logic;
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
            return UsuarioData.GetOne(id);
        }

        public List<Usuario> GetAll()
        {
            return UsuarioData.GetAll();
        }

        public void Save(Usuario usu)
        {
            UsuarioData.Save(usu);
        }

        public void Delete(int id)
        {
            UsuarioData.Delete(id);
        }

    }
}
