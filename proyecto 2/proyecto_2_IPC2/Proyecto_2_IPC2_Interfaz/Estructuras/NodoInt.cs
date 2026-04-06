namespace Proyecto_2_IPC2_Interfaz.Estructuras
{
    public class NodoInt
    {
        public int Dato { get; set; }
        public NodoInt Siguiente { get; set; }
        public NodoInt(int dato)
        {
            Dato= dato;
            Siguiente=null;
        }
    }
}
