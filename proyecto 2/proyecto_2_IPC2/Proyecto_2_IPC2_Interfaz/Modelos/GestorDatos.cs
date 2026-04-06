using proyecto_2_IPC2.Estructuras;
using System;
using System.Collections.Generic;
using System.Text;

namespace proyecto_2_IPC2.Modelos
{
    public class GestorDatos
    {
        public ListaDrones Drones { get; set; }
        public ListaSistemas Sistemas { get; set; }
        public ListaMensajes Mensajes { get; set; }

        public GestorDatos()
        {
            Drones = new ListaDrones();
            Sistemas = new ListaSistemas();
            Mensajes = new ListaMensajes();
        }

        public void ProcesarTodosMensajes()
        {
            SimuladorTiempo simulador = new SimuladorTiempo();
            for (int i = 0; i<Mensajes.Cantidad(); i++)
            {
                Drones.Reiniciar();
                Mensajes msg=Mensajes.Obtener(i);

                ResultadoSimulacion resultado =simulador.Simular(Drones, msg.Instrucciones);
                msg.TiempoOptimo =resultado.TiempoOptimo;
                msg.AccionesPorSegundo=resultado.Acciones;

                SistemaDrones sistema= Sistemas.Buscar(msg.NombreSistema);
                if (sistema !=null)
                {
                    msg.TextoOriginal =sistema.ReconstruirMensaje(msg.Instrucciones);
                }
                else
                {
                    Console.WriteLine($"Advertencia: El sistema '{msg.NombreSistema}' no se encontró para el mensaje '{msg.Nombre}'. No se pudo reconstruir el mensaje original.");
                }
            }
        }
    }
}
