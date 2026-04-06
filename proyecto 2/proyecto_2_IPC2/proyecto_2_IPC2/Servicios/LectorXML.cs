using proyecto_2_IPC2.Estructuras;
using proyecto_2_IPC2.Modelos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace proyecto_2_IPC2.Servicios
{
    public class LectorXML
    {
        public void CargarConfiguracion(string ruta, GestorDatos gestor)
        {
            XmlDocument doc= new XmlDocument();
            doc.Load(ruta);

            // Drones
            XmlNodeList nodosDrones=doc.SelectNodes("//drones/dron");
            if (nodosDrones != null)
            {
                foreach (XmlNode nodo in nodosDrones)
                {
                    string nombre = nodo.Attributes["nombre"].Value;
                    if (gestor.Drones.Buscar(nombre) == null)
                    {
                        gestor.Drones.Agregar(new Dron(nombre));
                    }
                }
            }
            // Sistemas de drones
            XmlNodeList nodosSistemas = doc.SelectNodes("//sistemasDrones/sistema");
            if (nodosSistemas != null)
            {
                foreach (XmlNode nodoSis in nodosSistemas)
                {
                    string nombreSis =nodoSis.Attributes["nombre"].Value;
                    int alturaMax =int.Parse(nodoSis.Attributes["alturaMaxima"].Value);

                    if (gestor.Sistemas.Buscar(nombreSis)==null)
                    {
                        SistemaDrones sistema =new SistemaDrones(nombreSis, alturaMax);

                        XmlNodeList filas =nodoSis.SelectNodes("tabla/fila");
                        if (filas != null)
                        {
                            foreach (XmlNode fila in filas)
                            {
                                string dron =fila.Attributes["dron"].Value;
                                int altura = int.Parse(fila.Attributes["altura"].Value);
                                string letra=fila.Attributes["letra"].Value;
                                sistema.Tabla.Agregar(dron, altura, letra);
                            }
                        }
                        gestor.Sistemas.Agregar(sistema);
                    }
                }
            }
            // Mensajes
            XmlNodeList nodosMensajes= doc.SelectNodes("//mensajes/mensaje");
            if (nodosMensajes !=null)
            {
                foreach (XmlNode nodoMsg in nodosMensajes)
                {
                    string nombreMsg = nodoMsg.Attributes["nombre"].Value;
                    string texto = nodoMsg.Attributes["texto"].Value;
                    string nombreSistema = nodoMsg.Attributes["sistema"].Value;

                    if (gestor.Mensajes.Buscar(nombreMsg) == null)
                    {
                        Mensajes mensaje=new Mensajes(nombreMsg, texto);
                        mensaje.NombreSistema = nombreSistema;

                        XmlNodeList instruccionesNode = nodoMsg.SelectNodes("instrucciones/instruccion");
                        if (instruccionesNode != null)
                        {
                            foreach (XmlNode inst in instruccionesNode)
                            {
                                string dron= inst.Attributes["dron"].Value;
                                int altura =int.Parse(inst.Attributes["altura"].Value);
                                string letra =inst.Attributes["letra"].Value;
                                mensaje.Instrucciones.Agregar(new Instrucciones(dron, altura, letra));
                            }
                        }
                        gestor.Mensajes.Agregar(mensaje);
                    }
                }
            }
        }
    }
}
