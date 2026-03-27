using proyecto_2_IPC2.Estructuras;
using System;
using System.Collections.Generic;
using System.Text;

namespace proyecto_2_IPC2.Modelos
{
    public class ResultadoSimulacion
    {
        public int TiempoOptimo { get; set; }
        public ListaAcciones Acciones { get; set; }

        public ResultadoSimulacion()
        {
            TiempoOptimo=0; 
            Acciones=new ListaAcciones();
        }
    }
}
