using proyecto_2_IPC2.Modelos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace proyecto_2_IPC2.Servicios
{
    public class LectorXML
    {
        public SistemaDrones CargarSistema(string ruta)
        {
            XmlDocument doc=new XmlDocument();
            doc.Load(ruta);
            XmlNode sistemaNode=doc.SelectSingleNode("//sistemaDrones");

            string nombre = sistemaNode.Attributes["nombre"].Value;
            int alturaMaxima = int.Parse(sistemaNode.Attributes["alturaMaxima"].Value);
            SistemaDrones sistema=new SistemaDrones(nombre, alturaMaxima);

            XmlNodeList drones = doc.SelectNodes("//drones/dron");
            foreach (XmlNode dronNode in drones)
            {
                string nombreDron = dronNode.Attributes["nombre"].Value;
                sistema.Drones.Agregar(new Dron(nombreDron));
            }

            XmlNodeList tabla=doc.SelectNodes("//tablaCorrespondencia/letra");
            foreach (XmlNode nodo in tabla)
            {
                string nombreDron = nodo.Attributes["dron"].Value;
                int altura =int.Parse(nodo.Attributes["altura"].Value);
                string letra= nodo.InnerText;

                sistema.Tabla.Agregar(nombreDron, altura, letra);
            }

            XmlNodeList mensajesXML=doc.SelectNodes("//mensajes/mensaje");
            foreach (XmlNode mensajeNode in mensajesXML)
            {
                string nombreMensaje = mensajeNode.Attributes["nombre"].Value;
                Mensajes mensaje = new Mensajes(nombreMensaje, "");

                XmlNodeList instruccionesXML= mensajeNode.SelectNodes("instruccion");
                foreach (XmlNode instNode in instruccionesXML)
                {
                    string nombreDron =instNode.Attributes["dron"].Value;
                    int altura=int.Parse(instNode.Attributes["altura"].Value);
                    mensaje.Instrucciones.Agregar(new Instrucciones(nombreDron, altura, ""));
                }
                sistema.Mensajes.Agregar(mensaje);
            }
            return sistema;
        }
    }
}
