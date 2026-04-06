namespace Proyecto_2_IPC2_Interfaz.Estructuras
{
    public class ListaInt
    {
        private NodoInt primero;
        private int cantidad;

        public void Agregar(int valor)
        {
            if (Contiene(valor))
                return;

            NodoInt nuevo= new NodoInt(valor);
            if (primero== null) { 
                primero=nuevo;
            }
            else
            {
                NodoInt actual =primero;
                while (actual.Siguiente != null) actual = actual.Siguiente;
                actual.Siguiente=nuevo;
            }
            cantidad++;
        }

        public bool Contiene(int valor)
        {
            NodoInt actual =primero;
            while (actual != null)
            {
                if (actual.Dato==valor)
                    return true;

                actual=actual.Siguiente;
            }
            return false;
        }

        public int Obtener(int indice)
        {
            if (indice <0 || indice >= cantidad) 
                return -1;

            NodoInt actual=primero;
            for (int i =0; i<indice; i++)
            {
                actual =actual.Siguiente;
            }
            return actual.Dato;
        }

        public int Cantidad() => cantidad;

        public void OrdenarAscendente()
        {
            if (cantidad <= 1) 
                return;

            bool intercambio;
            do
            {
                intercambio=false;
                NodoInt actual = primero;
                while (actual != null && actual.Siguiente != null)
                {
                    if (actual.Dato>actual.Siguiente.Dato)
                    {
                        int temp=actual.Dato;
                        actual.Dato =actual.Siguiente.Dato;
                        actual.Siguiente.Dato= temp;
                        intercambio =true;
                    }
                    actual =actual.Siguiente;
                }
            }
            while (intercambio);
        }
    }
}

