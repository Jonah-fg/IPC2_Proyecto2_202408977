using System;
using System.Collections.Generic;
using System.Text;

namespace proyecto_2_IPC2.Modelos
{
    public class Dron
    {
        public string Nombre { get; set; }
        public int AlturaActual { get; set; }
        public bool EstaEmitiendoLuz { get; set; }

        public Dron(string nombre)
        {
            Nombre =nombre;
            AlturaActual=1; 
            EstaEmitiendoLuz=false;
        }

        public void Subir()
        {
            if (AlturaActual<100) 
            {
                AlturaActual++;
                Console.WriteLine($"{Nombre} subió a {AlturaActual} metros");
            }
        }

        public void Bajar()
        {
            if (AlturaActual>1) 
            {
                AlturaActual--;
            }
        }

        public void EmitirLuz()
        {
            EstaEmitiendoLuz=true;
            Console.WriteLine($"{Nombre} emitiendo luz a {AlturaActual} metros");
        }

        public void ApagarLuz()
        {
            EstaEmitiendoLuz=false;
            Console.WriteLine($"{Nombre} apagó luz");
        }

        public void Esperar()
        {
            Console.WriteLine($"{Nombre} esperando...");
        }

        public override string ToString()
        {
            return $"Dron: {Nombre} | Altura: {AlturaActual}m | Emitiendo: {(EstaEmitiendoLuz ? "SÍ" : "NO")}";
        }
    }
}

