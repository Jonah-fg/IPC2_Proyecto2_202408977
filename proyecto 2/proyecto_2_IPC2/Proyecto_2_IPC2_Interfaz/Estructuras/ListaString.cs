namespace Proyecto_2_IPC2_Interfaz.Estructuras
{
    public class ListaString
    {
        private NodoString primero;
        private int cantidad;

        public void Agregar(string valor)
        {
            if (Contiene(valor))
                return;

            NodoString nuevo=new NodoString(valor);
            if (primero==null)
            {
                primero =nuevo;
            }

            else
            {
                NodoString actual=primero;
                while (actual.Siguiente!= null)
                {
                    actual =actual.Siguiente;
                }
                actual.Siguiente= nuevo;
            }
            cantidad++;
        }

        public bool Contiene(string valor)
        {
            NodoString actual =primero;
            while (actual != null)
            {
                if (actual.Dato == valor)
                    return true;

                actual=actual.Siguiente;
            }
            return false;
        }

        public string Obtener(int indice)
        {
            if (indice < 0 || indice>=cantidad) 
                return null;

            NodoString actual=primero;
            for (int i =0; i<indice; i++)
            {
                actual =actual.Siguiente;
            }
            return actual.Dato;
        }

        public int Cantidad() =>cantidad;

        public void OrdenarAlfabeticamente()
        {
            if (cantidad <= 1) 
                return;

            bool intercambio;
            do
            {
                intercambio = false;
                NodoString actual = primero;
                while (actual != null && actual.Siguiente != null)
                {
                    if (string.Compare(actual.Dato, actual.Siguiente.Dato) > 0)
                    {
                        string temp =actual.Dato;
                        actual.Dato= actual.Siguiente.Dato;
                        actual.Siguiente.Dato = temp;
                        intercambio =true;
                    }
                    actual=actual.Siguiente;
                }
            } 
            while (intercambio);
        }
    }
}
   
