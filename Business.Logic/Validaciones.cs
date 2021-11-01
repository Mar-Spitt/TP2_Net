using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.Logic
{
    public class Validaciones
    {
        public static bool EsMailValido(string mail)
        {
            bool rta = false;
            string expression = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(mail, expression))
            {
                rta = true;
            }
            return rta;
        }

        public static bool EsFechaNacimientoValida(DateTime fecha)
        {
            bool rta = false;
            try
            {
                int edad = DateTime.Today.AddTicks(-fecha.Ticks).Year - 1;
                if (edad < 110 & edad > 0)
                {
                    rta = true;
                }
            }
            catch (Exception)
            {
                
            }
            
            return rta;
        }
    }
}
