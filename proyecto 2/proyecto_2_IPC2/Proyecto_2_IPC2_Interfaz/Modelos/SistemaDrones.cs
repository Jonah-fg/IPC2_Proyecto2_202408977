using proyecto_2_IPC2.Estructuras;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace proyecto_2_IPC2.Modelos
{
    public class SistemaDrones
    {
        public string Nombre { get; set; }
        public int AlturaMaxima { get; set; }
        public TablaCorrespondencia Tabla { get; set; }

        public SistemaDrones(string nombre, int alturaMaxima)
        {
            Nombre = nombre;
            AlturaMaxima = alturaMaxima;
            Tabla = new TablaCorrespondencia();
        }

        public string ObtenerLetra(string dron, int altura)
        {
            return Tabla.BuscarLetra(dron, altura);
        }


        public string ReconstruirMensaje(ListaInstrucciones instrucciones)
        {
            string resultado ="";
            for (int i = 0; i<instrucciones.Cantidad(); i++)
            {
                Instrucciones inst=instrucciones.Obtener(i);
                string letra =Tabla.BuscarLetra(inst.NombreDron, inst.AlturaObjetivo);
                resultado +=letra;
            }
            return resultado;
        }
    }
}

