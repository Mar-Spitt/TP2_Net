using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class CursoLogic : BusinessLogic
    {
        public CursoAdapter CursoData { get; set; }

        public CursoLogic()
        {
            this.CursoData = new CursoAdapter();
        }

        public Curso GetOne(int id)
        {
            Curso cur;
            try
            {
                cur = CursoData.GetOne(id);

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar el curso", Ex);
                throw ExcepcionManejada;
            }
            return cur;
        }

        public List<Curso> GetAll()
        {
            List<Curso> cursos;
            try
            {
                cursos = CursoData.GetAll();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de cursos", Ex);
                throw ExcepcionManejada;
            }
            return cursos;
        }

        public void Save(Curso cur)
        {
            try
            {
                CursoData.Save(cur);
            }
            catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("Error al modificar datos del curso", Ex);
                throw ExceptionManejada;
            }
        }

        public void Delete(int id)
        {
            CursoData.Delete(id);
        }

        public List<Curso> GetAllAnioActual()
        {
            List<Curso> cursos;
            try
            {
                cursos = CursoData.GetAllAnioActual();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de cursos", Ex);
                throw ExcepcionManejada;
            }
            return cursos;
        }

    }
}
