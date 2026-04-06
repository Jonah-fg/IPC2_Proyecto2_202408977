namespace Proyecto_2_IPC2_Interfaz.Estructuras
{
    public class NodoString
    {
         
        public string Dato { get; set; }
        public NodoString Siguiente { get; set; }
        public NodoString(string dato) {

            Dato = dato;
            Siguiente = null;
        }          
    }
}

