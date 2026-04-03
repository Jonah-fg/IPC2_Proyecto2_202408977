using proyecto_2_IPC2.Estructuras;
using proyecto_2_IPC2.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace proyecto_2_IPC2.Servicios
{
    public class ReporteGraphviz
    {
        public void GenerarReporteSistemas(ListaSistemas sistemas)
        {
            if (sistemas.Cantidad() ==0) 
                return;

            using (StreamWriter sw=new StreamWriter("sistemas.dot"))
            {
                sw.WriteLine("digraph G {");
                sw.WriteLine("rankdir=TB;");
                sw.WriteLine("node [shape=box, style=filled, fillcolor=lightblue];");
                sw.WriteLine("edge [color=gray];");

                NodoSistema actual=sistemas.ObtenerPrimero();
                while (actual !=null)
                {
                    SistemaDrones s=actual.Dato;
                    sw.WriteLine($"\"{s.Nombre}\" [label=\"Sistema: {s.Nombre}\\nAltura máxima: {s.AlturaMaxima} m\"];");
                    actual =actual.Siguiente;
                }
                sw.WriteLine("}");
            }
        }

        public void GenerarDotMensaje(Mensajes mensaje, string nombreArchivo)
        {
            if (mensaje.AccionesPorSegundo ==null || mensaje.AccionesPorSegundo.Cantidad()==0)
            {
                Console.WriteLine("El mensaje no tiene acciones simuladas.");
                return;
            }

            using (StreamWriter sw= new StreamWriter(nombreArchivo))
            {
                sw.WriteLine("digraph G {");
                sw.WriteLine("rankdir=LR;");
                sw.WriteLine("node [shape=box];");
                sw.WriteLine($"label=\"Mensaje: {mensaje.Nombre}\\nTexto: {mensaje.TextoOriginal}\\nTiempo óptimo: {mensaje.TiempoOptimo} s\";");
                sw.WriteLine("labelloc=t;");
                sw.WriteLine("fontsize=12;");

                NodoAccion actual=mensaje.AccionesPorSegundo.primero;
                int segundoActual =-1;
                string nodoAnterior =null;

                while (actual!= null)
                {
                    int seg=actual.Dato.Segundo;
                    string dron=actual.Dato.NombreDron;
                    string accion=actual.Dato.TipoAccion;

                    string nodoTiempo =$"t{seg}";
                    string nodoAccion =$"{nodoTiempo}_{dron}";

                    if (seg !=segundoActual)
                    {
                        sw.WriteLine($"{nodoTiempo} [label=\"Segundo {seg}\", shape=ellipse];");
                        segundoActual=seg;
                        nodoAnterior=null;
                    }
                    sw.WriteLine($"{nodoAccion} [label=\"{dron}\\n{accion}\", shape=box];");
                    sw.WriteLine($"{nodoTiempo} -> {nodoAccion};");
                    actual=actual.Siguiente;
                }
                sw.WriteLine("}");
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

                actual=actual.Siguiente;
            }
            sw.WriteLine("}");
            sw.Close();
        }

    }

}
    

