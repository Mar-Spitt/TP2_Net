using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Logic;
using Business.Entities;

namespace UI.Consola
{
    public class Usuarios
    {
        public Usuarios()
        {
            this.UsuarioNegocio = new UsuarioLogic();
        }
        public UsuarioLogic UsuarioNegocio
        {
            get; set;
        }

        public void Menu()
        {

            Console.WriteLine("----------BIENVENIDO AL MENÚ----------");
            Console.WriteLine(" Elija una opcion");
            Console.WriteLine("  ");
            Console.WriteLine(" 1 – Listado General \n 2 – Consulta \n 3 – Agregar \n 4 - Modificar \n 5 - Eliminar \n 6 - Salir \n");
            ConsoleKeyInfo rta = Console.ReadKey();

            do
            {

                switch (rta.Key)
                {
                    case ConsoleKey.D1:
                        ListadoGeneral();
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D2:
                        Consultar();
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D3:
                        Agregar();
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D4:
                        Modificar();
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D5:
                        Eliminar();
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D6:

                        break;
                }

                if (rta.Key != ConsoleKey.D6)
                    {
                    Console.Clear();
                    Console.WriteLine("--------------------MENÚ PRINCIPAL--------------------");
                    Console.WriteLine(" Elija una opcion");
                    Console.WriteLine("  ");
                    Console.WriteLine(" 1 – Listado General \n 2 – Consulta \n 3 – Agregar \n 4 - Modificar \n 5 - Eliminar \n 6 - Salir \n");
                    rta = Console.ReadKey();
                }
                

            } while ((rta.Key == ConsoleKey.D1 || rta.Key == ConsoleKey.D2 || rta.Key == ConsoleKey.D3 || rta.Key == ConsoleKey.D4 || rta.Key == ConsoleKey.D5) && rta.Key != ConsoleKey.D6);

        }

        public void ListadoGeneral()
        {
            Console.Clear();
            foreach (Usuario usr in UsuarioNegocio.GetAll())
            {
                MostrarDatos(usr);
            }
        }

        public void MostrarDatos(Usuario usr)
        {
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Usuario: {0}", usr.ID);
            Console.WriteLine("\t\tNombre: {0}", usr.Nombre);
            Console.WriteLine("\t\tApellido: {0}", usr.Apellido);
            Console.WriteLine("\t\tNombre de Usuario: {0}", usr.NombreUsuario);
            Console.WriteLine("\t\tClave: {0}", usr.Clave);
            //Console.WriteLine("\t\tEmail: {0}", usr.EMail);
            Console.WriteLine("\t\tHabilitado: {0}", usr.Habilitado);
            // \t dentro de un string representa un TAB
            Console.WriteLine();
        }

        public void Consultar()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese el ID del usuario a consultar: ");
                int ID = int.Parse(Console.ReadLine());
                this.MostrarDatos(UsuarioNegocio.GetOne(ID));
            }
            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un número entero");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }

        }

        public void Modificar()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese el ID del usuario a modificar:  ");
                int ID = int.Parse(Console.ReadLine());
                Usuario usuario = UsuarioNegocio.GetOne(ID);
                Console.Write("Ingrese Nombre: ");
                usuario.Nombre = Console.ReadLine();
                Console.Write("Ingrese Apellido: ");
                usuario.Apellido = Console.ReadLine();
                Console.Write("Ingrese Nombre de Usuario: ");
                usuario.NombreUsuario = Console.ReadLine();
                Console.Write("Ingrese  Clave: ");
                usuario.Clave = Console.ReadLine();
                Console.Write("Ingrese  Email: ");
                usuario.EMail = Console.ReadLine();
                Console.Write("Ingrese  Habilitación de Usuario(1 - Si / otro - No):  ");
                usuario.Habilitado = (Console.ReadLine() == "1");
                usuario.State = BusinessEntity.States.Modified;
                UsuarioNegocio.Save(usuario);
            }
            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un número entero");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }

        }

        public void Agregar()
        {
            Usuario usuario = new Usuario();

            Console.Clear();
            Console.Write("Ingrese Nombre: ");
            usuario.Nombre = Console.ReadLine();
            Console.Write("Ingrese Apellido: ");
            usuario.Apellido = Console.ReadLine();
            Console.Write("Ingrese Nombre de Usuario: ");
            usuario.NombreUsuario = Console.ReadLine();
            Console.Write("Ingrese Clave: ");
            usuario.Clave = Console.ReadLine();
            Console.Write("Ingrese Email: ");
            usuario.EMail = Console.ReadLine();
            Console.Write("Ingrese Habilitación de Usuario (1-Si/otro-No): ");
            usuario.Habilitado = (Console.ReadLine() == "1");
            usuario.State = BusinessEntity.States.New;
            UsuarioNegocio.Save(usuario);
            Console.WriteLine();
            Console.WriteLine("ID: {0}", usuario.ID);
        }

        public void Eliminar()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese el ID del usuario a eliminar: ");
                int ID = int.Parse(Console.ReadLine());
                UsuarioNegocio.Delete(ID);
            }
            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un número entero");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
        }

    }
}
