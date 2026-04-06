using proyecto_2_IPC2.Estructuras;
using proyecto_2_IPC2.Modelos;
using Proyecto_2_IPC2_Interfaz.Estructuras;
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

        public void GenerarDotSistema(SistemaDrones sistema, string nombreArchivo)
        {
            using (StreamWriter sw=new StreamWriter(nombreArchivo))
            {
                sw.WriteLine("digraph G {");
                sw.WriteLine("rankdir=TB;");
                sw.WriteLine("node [shape=plaintext];");
                sw.WriteLine($"label=\"Sistema: {sistema.Nombre}\\nAltura máxima: {sistema.AlturaMaxima} m\";");
                sw.WriteLine("labelloc=t;");
                sw.WriteLine("fontsize=20;");

                ListaString drones =new ListaString();
                NodoTabla actual=sistema.Tabla.primero;
                while (actual !=null)
                {
                    drones.Agregar(actual.NombreDron);
                    actual =actual.Siguiente;
                }
                drones.OrdenarAlfabeticamente();

                ListaInt alturas= new ListaInt();
                actual =sistema.Tabla.primero;
                while (actual !=null)
                {
                    alturas.Agregar(actual.Altura);
                    actual=actual.Siguiente;
                }
                alturas.OrdenarAscendente();

                sw.WriteLine("\"tabla\" [");
                sw.WriteLine("  label=<");
                sw.WriteLine("    <table border=\"1\" cellborder=\"1\" cellspacing=\"0\">");

                sw.WriteLine("       <tr>");
                sw.WriteLine("        <td bgcolor=\"lightgray\"><b>Altura</b></td>");
                for (int i=0; i<drones.Cantidad(); i++)
                {
                    string dron=drones.Obtener(i);
                    sw.WriteLine($"      <td bgcolor=\"lightgray\"><b>{dron}</b></td>");
                }
                sw.WriteLine("     </tr>");

                for (int a=0; a<alturas.Cantidad(); a++)
                {
                    int altura =alturas.Obtener(a);
                    sw.WriteLine("    <tr>");
                    sw.WriteLine($"      <td><b>{altura}</b></td>");
                    for (int d =0; d<drones.Cantidad(); d++)
                    {
                        string dron =drones.Obtener(d);
                        string letra ="-";
                        NodoTabla buscar= sistema.Tabla.primero;
                        while (buscar != null)
                        {
                            if (buscar.NombreDron==dron && buscar.Altura== altura)
                            {
                                letra=buscar.Letra;
                                break;
                            }
                            buscar =buscar.Siguiente;
                        }
                        sw.WriteLine($"     <td>{letra}</td>");
                    }
                    sw.WriteLine("    </tr>");
                }
                sw.WriteLine("   </table>");
                sw.WriteLine("  >];");
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
    

