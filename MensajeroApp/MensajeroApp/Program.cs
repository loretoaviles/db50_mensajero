using MensajeroModel.DAL;
using MensajeroModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensajeroApp
{
    class Program
    {
        

        //1. Crear menu
        //2. Dos metodos IngresarMensaje y MostrarMensajes
        //3. Al ingresar  un mensaje definir el tipo como app
        static void Main(string[] args)
        {
            while (Menu()) ;

        }

        static Boolean Menu()
        {
            bool continuar = true;
            Console.WriteLine("0-Salir");
            Console.WriteLine("1-Ingresar Mensaje");
            Console.WriteLine("2-Mostrar Mensaje");
            string r = Console.ReadLine().Trim();
            switch (r)
            {
                case "1": IngresarMensaje();
                    break;
                case "2": MostrarMensaje();
                    break;
                case "0": continuar = false;
                    break;
                default:
                    Console.WriteLine("Ingrese una respuesta valida");
                    break;
            }
            return continuar;


        }
        static IMensajesDAL dal = MensajesDALFactory.CreateDal();
        static void IngresarMensaje()
        {
            string nombre, detalle;
            do
            {
                Console.WriteLine("Ingrese nombre");
                nombre = Console.ReadLine().Trim();
            } while (nombre == string.Empty);
            do
            {
                Console.WriteLine("Ingrese mensaje");
                detalle = Console.ReadLine().Trim();

            } while (detalle == string.Empty || detalle.Length > 20);

            Mensaje mensaje = new Mensaje()
            {
                Nombre = nombre,
                Detalle = detalle,
                Tipo = "Aplicacion"
            };
            dal.Save(mensaje);
        }

        static void MostrarMensaje()
        {
            List<Mensaje> mensajes = dal.GetAll();
            foreach (Mensaje M in mensajes)
            {
                Console.WriteLine(M.Nombre + ";" + M.Detalle + ";" + M.Tipo);
                
            }
        }


    }

}
