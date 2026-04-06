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
            XmlDocument doc=new XmlDocument();
            doc.Load(ruta);

            //Drones
            XmlNodeList nodosDrones=doc.SelectNodes("//listaDrones/dron");
            if (nodosDrones !=null)
            {
                foreach (XmlNode nodo in nodosDrones)
                {
                    string nombre = nodo.InnerText.Trim();
                    if(!string.IsNullOrWhiteSpace(nombre) && gestor.Drones.Buscar(nombre) == null)
                    {
                        gestor.Drones.Agregar(new Dron(nombre));
                    }
                }
            }
            //Sistema Drones
            XmlNodeList nodosSistemas =doc.SelectNodes("//listaSistemasDrones/sistemaDrones");
            if (nodosSistemas!=null)
            {
                foreach (XmlNode nodoSis in nodosSistemas)
                {
                    string nombreSis = nodoSis.Attributes["nombre"]?.Value;
                    if (string.IsNullOrWhiteSpace(nombreSis))
                        continue;

                    XmlNode alturaMaxNode=nodoSis.SelectSingleNode("alturaMaxima");
                    int alturaMax = alturaMaxNode != null ? int.Parse(alturaMaxNode.InnerText) :100;

                    if (gestor.Sistemas.Buscar(nombreSis)== null)
                    {
                        SistemaDrones sistema =new SistemaDrones(nombreSis, alturaMax);


                        XmlNodeList contenidos=nodoSis.SelectNodes("contenido");
                        foreach (XmlNode contenido in contenidos)
                        {
                            string dron =contenido.SelectSingleNode("dron")?.InnerText.Trim();
                            if (string.IsNullOrWhiteSpace(dron)) 
                                continue;

                            XmlNodeList alturas = contenido.SelectNodes("alturas/altura");
                            foreach (XmlNode alturaNode in alturas)
                            {
                                string valorAltura =alturaNode.Attributes["valor"]?.Value;
                                if (string.IsNullOrWhiteSpace(valorAltura))
                                    continue;

                                int altura =int.Parse(valorAltura);
                                string letra=alturaNode.InnerText.Trim();
                                sistema.Tabla.Agregar(dron, altura, letra);
                            }
                        }
                        gestor.Sistemas.Agregar(sistema);
                    }
                }
            }
            //Mensajes
            XmlNodeList nodosMensajes=doc.SelectNodes("//listaMensajes/Mensaje");
            if (nodosMensajes !=null)
            {
                foreach (XmlNode nodoMsg in nodosMensajes)
                {
                    string nombreMsg=nodoMsg.Attributes["nombre"]?.Value;
                    if (string.IsNullOrWhiteSpace(nombreMsg))
                        continue;

                    string sistemaMsg=nodoMsg.SelectSingleNode("sistemaDrones")?.InnerText.Trim();
                    if (string.IsNullOrWhiteSpace(sistemaMsg))
                        continue;

                    if (gestor.Mensajes.Buscar(nombreMsg)==null)
                    {
                        Mensajes mensaje =new Mensajes(nombreMsg, "");
                        mensaje.NombreSistema=sistemaMsg;

                        XmlNodeList instruccionesNode=nodoMsg.SelectNodes("instrucciones/instruccion");
                        if (instruccionesNode != null)
                        {
                            foreach (XmlNode inst in instruccionesNode)
                            {
                                string dron =inst.Attributes["dron"]?.Value;
                                if (string.IsNullOrWhiteSpace(dron))
                                    continue;
                                int altura= int.Parse(inst.InnerText.Trim());
                                mensaje.Instrucciones.Agregar(new Instrucciones(dron, altura, ""));
                            }
                        }
                        gestor.Mensajes.Agregar(mensaje);
                    }
                }
            }
        }
    }
}