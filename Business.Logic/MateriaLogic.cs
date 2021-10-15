using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class MateriaLogic
    {
        public MateriaLogic()
        {
            this.MateriaData = new MateriaAdapter();
        }

        public MateriaAdapter MateriaData
        {
            get; set;
        }

        public Materia GetOne(int id)
        {
            Materia ma;
            try
            {
                ma = MateriaData.GetOne(id);

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la materia", Ex);
                throw ExcepcionManejada;
            }
            return ma;
        }

        public List<Materia> GetAll()
        {
            List<Materia> materias;
            try
            {
                materias = MateriaData.GetAll();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de materias", Ex);
                throw ExcepcionManejada;
            }
            return materias;

        }

        public void Save(Materia ma)
        {
            try
            {
                MateriaData.Save(ma);
            }
            catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("Error al modificar datos de la materia", Ex);
                throw ExceptionManejada;
            }
        }

        public void Delete(int id)
        {
            MateriaData.Delete(id);
        }
    }
}
