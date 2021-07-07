using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class PlanLogic : BusinessLogic
    {
        public PlanLogic()
        {
            this.PlanData = new PlanAdapter();
        }

        public PlanAdapter PlanData
        {
            get; set;
        }

        public Plan GetOne(int id)
        {
            Plan pl;
            try
            {
                pl = PlanData.GetOne(id);

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar el plan", Ex);
                throw ExcepcionManejada;
            }
            return pl;
        }

        public List<Plan> GetAll()
        {
            List<Plan> planes;
            try
            {
                planes = PlanData.GetAll();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de planes", Ex);
                throw ExcepcionManejada;
            }
            return planes;

        }

        public void Save(Plan pl)
        {
            try
            { 
                PlanData.Save(pl);
            }
            catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("Error al modificar datos del plan", Ex);
                throw ExceptionManejada;
            }
        }

        public void Delete(int id)
        {
            PlanData.Delete(id);
        }
    }
}
