using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    public class EspecialidadLogic :  BusinessLogic
    {
        public EspecialidadLogic()
        {
            this.EspecialidadData = new EspecialidadAdapter();
        }

        public EspecialidadAdapter EspecialidadData
        {
            get; set;
        }

        public Especialidad GetOne(int id)
        {
            Especialidad esp;
            try
            {
                esp = EspecialidadData.GetOne(id);

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la especiadad", Ex);
                throw ExcepcionManejada;
            }
            return esp;
        }

        public List<Especialidad> GetAll()
        {
            List<Especialidad> especialidades;
            try
            {
                especialidades = EspecialidadData.GetAll();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de especialidades", Ex);
                throw ExcepcionManejada;
            }
            return especialidades;

        }

        public void Save(Especialidad esp)
        {
            EspecialidadData.Save(esp);
        }

        public void Delete(int id)
        {
            EspecialidadData.Delete(id);
        }
    }
}
