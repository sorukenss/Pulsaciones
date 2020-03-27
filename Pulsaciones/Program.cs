using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using BLL;

namespace Pulsaciones
{
    public class Program
    {
        public static List<Persona> personas= new List<Persona>();
        static Persona persona;
        static PersonaService personaService = new PersonaService();
        static void Main(string[] args)
        {
            int Opcion = 1;
            while (Opcion==1)
            {
              
                switch (Menu())
                {
                    case 1:
                        CalcularPulsaciones();
                        break;
                    case 2:
                        Modificar();
                        break;
                    case 3:
                        ConsultarPersonas();
                        break;
                    case 4:
                        Eliminar();
                        break;
                    case 5: Opcion = 2;
                        break;
                    default: Console.WriteLine("no tomo ninguna de las opciones disponibles por favor intentar de nuevo");
                        break;
                }
                if (Opcion != 2)
                {
                    Console.WriteLine("desea seguir 1 para si , 2 para no");
                    Opcion = int.Parse(Console.ReadLine());
                }
            }

        }
        
        public static void CalcularPulsaciones() {
            Console.Clear();
            persona = new Persona();
            Console.Write("Ingrese su identificación : ");
            persona.Identificacion = Console.ReadLine();
            Console.Write("Ingrese su Nombre : ");
            persona.Nombre = Console.ReadLine();
            Console.Write("Ingrese su Edad : ");
            persona.Edad = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ingrese su Sexo m para masculino , f para femenino : ");
            persona.Sexo = Console.ReadLine();
            personaService.CalcularPulsacion(persona);
            personaService.Guardar(persona);

            Console.WriteLine($"Su pulsación es {persona.Pulsacion}");
            Console.ReadKey();
        }

        public static void Modificar() {
            persona = new Persona();
            Console.Clear();
            string identificacion;
            Console.WriteLine("Identificacion que quiera modificar");
            identificacion = Console.ReadLine();
            persona=personaService.BuscarPersona(identificacion);
            if (persona != null)
            {
                Console.WriteLine("Ingrese nueva identificacion");
                identificacion = Console.ReadLine();
                personaService.Modificar(persona, identificacion);
            } else
            {
                Console.WriteLine("No se encontró la identificación que busca");
            }
        }

        public static void Eliminar()
        {
            persona = new Persona();
            Console.Clear();
            string identificacion;
            Console.WriteLine("Identificacion de la persona que quiera eliminar");
            identificacion = Console.ReadLine();
            persona = personaService.BuscarPersona(identificacion);
            if (persona != null)
            {
                personaService.Eliminar(persona);
                Console.WriteLine("Persona eliminada correctamente");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("No se encontró la identificación que busca");
                Console.ReadKey();
            }

        }

        public static void ConsultarPersonas()
        {
            Console.Clear();
            personas=personaService.ConsultarPersonas();
            foreach (var item in personas)
            {
                Console.WriteLine($"{item.Nombre} - {item.Identificacion} - {item.Edad} - {item.Sexo} - {item.Pulsacion}");
            }
            Console.ReadKey();
        }


        public static int Menu()
        { 
             int OpcionTomada;
            Console.Clear();
            Console.WriteLine("digite 1 para Ingresar al menu de registrar sus datos ");
            Console.WriteLine("digite 2 modificar los datos de una persona");
            Console.WriteLine("digite 3 consultar la lista de personas guardadas");
            Console.WriteLine("digite 4  eliminar una persona");
            Console.WriteLine("digite 5 para salir");
            Console.Write("Opcion a tomar: ");
            OpcionTomada = int.Parse(Console.ReadLine());
            
            return OpcionTomada;
        }
    }
}
