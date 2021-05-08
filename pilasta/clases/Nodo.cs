using System;
using System.Collections.Generic;
using System.Text;

namespace Pilasta.clases
{
    class Nodo
    {
        public Object dato;
        public Nodo enlace;


        
        public Nodo(Object x)
        {
            dato = x;
            enlace = null;
        }

        
        public Nodo(Object x, Nodo nuevo)
        { 
            dato = x;
            enlace = nuevo;
        }

        
        public Object getDato()
        { 
            return dato;
        }
        public Nodo getEnlace()
        { 
            return enlace;
        }
        public void setEnlace(Nodo enlace)
        {
            this.enlace = enlace;
        }

    }
}

