using proyecto_2_IPC2.Estructuras;
using System;
using System.Collections.Generic;
using System.Text;

namespace proyecto_2_IPC2.Modelos
{
    public class SimuladorTiempo
    {
        public ResultadoSimulacion Simular(ListaDrones drones, ListaInstrucciones instrucciones)
        {
            ResultadoSimulacion resultado = new ResultadoSimulacion();
            int segundo=1;

            for (int i=0; i<instrucciones.Cantidad(); i++)
            {
                Instrucciones inst=instrucciones.Obtener(i);

                bool termino=false;
                while (!termino)
                {
                    termino=true;

                    NodoDron nododron =drones.ObtenerPrimero();
                    while (nododron !=null)
                    {
                        Dron dron=nododron.Dato;
                        string accion="Esperar";

                        if (dron.Nombre== inst.NombreDron)
                        {
                            if (dron.AlturaActual< inst.AlturaObjetivo)
                            {
                                dron.Subir();
                                accion ="Subir";
                                termino=false;
                            }
                            else if (dron.AlturaActual > inst.AlturaObjetivo)
                            {
                                dron.Bajar();
                                accion="Bajar";
                                termino= false;
                            }
                            else
                            {
                                accion="Emitir luz";
                            }
                        }
                        else
                        {
                            int alturaObjetivo=BuscarAlturaObjetivoFutura(dron.Nombre, instrucciones, i);

                            if (alturaObjetivo!=-1)
                            {
                                if (dron.AlturaActual< alturaObjetivo)
                                {
                                    dron.Subir();
                                    accion ="Subir";
                                }
                                else if (dron.AlturaActual > alturaObjetivo)
                                {
                                    dron.Bajar();
                                    accion ="Bajar";
                                }
                            }
                        }

                        resultado.Acciones.Agregar(
                            new AccionPorSegundo(segundo, dron.Nombre, accion));

                        nododron= nododron.Siguiente;
                    }
                    segundo++;
                    if (termino)
                    {
                        break;
                    }
                }
            }
            resultado.TiempoOptimo=segundo- 1;
            return resultado;
        }


        private int BuscarAlturaObjetivoFutura(string nombreDron, ListaInstrucciones instrucciones, int posicionActual)
        {
            for (int i=posicionActual+1; i<instrucciones.Cantidad(); i++)
            {
                Instrucciones futura=instrucciones.Obtener(i);

                if (futura.NombreDron==nombreDron)
                {
                    return futura.AlturaObjetivo;
                }
            }
            return -1;
        }
    }
}
    

     












