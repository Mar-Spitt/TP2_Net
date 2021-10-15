using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class ComisionLogic
    {
        public ComisionLogic()
        {
            this.ComisionData = new ComisionAdapter();
        }

        public ComisionAdapter ComisionData
        {
            get; set;
        }

        public Comision GetOne(int id)
        {
            Comision co;
            try
            {
                co = ComisionData.GetOne(id);

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la comisión", Ex);
                throw ExcepcionManejada;
            }
            return co;
        }

        public List<Comision> GetAll()
        {
            List<Comision> comisiones;
            try
            {
                comisiones = ComisionData.GetAll();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de comisiones", Ex);
                throw ExcepcionManejada;
            }
            return comisiones;

        }

        public void Save(Comision co)
        {
            try
            {
                ComisionData.Save(co);
            }
            catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("Error al modificar datos de la comisión", Ex);
                throw ExceptionManejada;
            }
        }

        public void Delete(int id)
        {
            ComisionData.Delete(id);
        }
    }
}
