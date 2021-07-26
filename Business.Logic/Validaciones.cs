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
        public static bool EsMailValido(string email)
        {
            String expresion;
            bool rta = false;
            expresion = @"\A(\w+.?\w*@\w+.)(com)\Z";


            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    rta = true;
                }
            }
            return rta;
        }
    }
}
