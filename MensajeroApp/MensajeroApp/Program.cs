﻿using MensajeroApp.Hilos;
using MensajeroModel.DAL;
using MensajeroModel.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MensajeroApp
{
    public partial class Program
    {


        
        static void Main(string[] args)
        {
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);
            Console.WriteLine("Iniciando Hilo del server socket");
            HiloServer hiloServer = new HiloServer(puerto);
            Thread t = new Thread(new ThreadStart(hiloServer.Ejecutar));
            t.IsBackground = true;
            t.Start();

            while (Menu()) ;

        }
    }

}
