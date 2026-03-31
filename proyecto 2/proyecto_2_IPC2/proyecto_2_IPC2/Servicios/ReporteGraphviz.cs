using proyecto_2_IPC2.Estructuras;
using proyecto_2_IPC2.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace proyecto_2_IPC2.Servicios
{
    public class ReporteGraphviz
    {
        public void GenerarDot(
           SistemaDrones sistema)
        {

            for (int i =0; i <sistema.Mensajes.Cantidad(); i++)
            {
                Mensajes mensaje =sistema.Mensajes.Obtener(i);
                string nombreArchivo ="mensaje_" + mensaje.Nombre + ".dot";

                StreamWriter writer = new StreamWriter(nombreArchivo);

                writer.WriteLine("digraph G {");
                writer.WriteLine("rankdir=LR;");
                writer.WriteLine( "node [shape=box];");

                NodoAccion actual = mensaje.AccionesPorSegundo.primero;
                while (actual!= null)
                {
                    string nodoTiempo = "t" + actual.Dato.Segundo;
                    string nodoAccion =nodoTiempo +"_" + actual.Dato.NombreDron;
                    writer.WriteLine(nodoTiempo +" [label=\"Segundo " + actual.Dato.Segundo +"\"];");
                    writer.WriteLine(nodoAccion +" [label=\"" + actual.Dato.NombreDron + "\\n" + actual.Dato.TipoAccion + "\"];");
                    writer.WriteLine(nodoTiempo + " -> " + nodoAccion + ";");

                    actual =actual.Siguiente;
                }
                writer.WriteLine("}");
                writer.Close();
            }

        }

        public void GenerarTablaCorrespondencia(SistemaDrones sistema)
        {
            StreamWriter sw =new StreamWriter("tabla.dot");
            sw.WriteLine("digraph G {");
            sw.WriteLine("node [shape=box];");
            var actual =sistema.Tabla.primero;

            while (actual != null)
            {
                sw.WriteLine($"\"Altura {actual.Altura}\" -> \"{actual.Letra}\";");

                actual =actual.Siguiente;
            }
            sw.WriteLine("}");
            sw.Close();
        }

    }

}
    

