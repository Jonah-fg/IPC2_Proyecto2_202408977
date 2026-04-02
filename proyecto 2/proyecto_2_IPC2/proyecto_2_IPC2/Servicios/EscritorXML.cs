using proyecto_2_IPC2.Estructuras;
using proyecto_2_IPC2.Modelos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace proyecto_2_IPC2.Servicios
{
    public class EscritorXML
    {
        public void GenerarSalida(GestorDatos gestor, string ruta)
        {
            XmlDocument doc =new XmlDocument();
            XmlElement respuesta = doc.CreateElement("respuesta");
            doc.AppendChild(respuesta);

            XmlElement listaMensajes = doc.CreateElement("listaMensajes");
            respuesta.AppendChild(listaMensajes);

            for (int i =0; i<gestor.Mensajes.Cantidad(); i++)
            {
                Mensajes mens=gestor.Mensajes.Obtener(i);

                XmlElement mensajeXML = doc.CreateElement("mensaje");
                mensajeXML.SetAttribute("nombre", mens.Nombre);
                listaMensajes.AppendChild(mensajeXML);

                XmlElement sistemaTag = doc.CreateElement("sistemaDrones");
                sistemaTag.InnerText = mens.NombreSistema;
                mensajeXML.AppendChild(sistemaTag);

                XmlElement tiempoOptimo = doc.CreateElement("tiempoOptimo");
                tiempoOptimo.InnerText = mens.TiempoOptimo.ToString();
                mensajeXML.AppendChild(tiempoOptimo);

                XmlElement mensajeRecibido=doc.CreateElement("mensajeRecibido");
                mensajeRecibido.InnerText =mens.TextoOriginal;
                mensajeXML.AppendChild(mensajeRecibido);

                XmlElement instrucciones = doc.CreateElement("instrucciones");
                mensajeXML.AppendChild(instrucciones);

                if (mens.AccionesPorSegundo != null)
                {
                    NodoAccion actual=mens.AccionesPorSegundo.primero;
                    int tiempoActual= -1;
                    XmlElement tiempoXML=null;
                    XmlElement accionesXML= null;

                    while (actual !=null)
                    {
                        if (actual.Dato.Segundo != tiempoActual)
                        {
                            tiempoActual=actual.Dato.Segundo;
                            tiempoXML =doc.CreateElement("tiempo");
                            tiempoXML.SetAttribute("valor", tiempoActual.ToString());
                            instrucciones.AppendChild(tiempoXML);
                            accionesXML= doc.CreateElement("acciones");
                            tiempoXML.AppendChild(accionesXML);
                        }

                        XmlElement dronXML = doc.CreateElement("dron");
                        dronXML.SetAttribute("nombre", actual.Dato.NombreDron);
                        dronXML.InnerText = actual.Dato.TipoAccion;
                        accionesXML.AppendChild(dronXML);

                        actual =actual.Siguiente;
                    }
                }
            }

            doc.Save(ruta);
        }
    }
}

