using System;
using System.Net.Cache;
using System.Text.RegularExpressions;
using System.Xml.Linq;

// 23 AM - Ing. Software - Estructura Datos II

// Martin Tamay Johan Ivan              - 202200480
// Hernandez Catarino Marco Arturo      - 202200467

namespace Examen_EstructuraDatosII
{
    public class ArbolBinario_Examen
    {
        class Nodo
        {
            public int info, val;
            public Nodo izq, der;                         // ORDEN (izq = izquierda; der = derecha)
        }


        Nodo raiz;


        public ArbolBinario_Examen()
        {
            raiz = null;                                  // RAIZ se INICIA en NULL
        }


        #region ESTRUCTURA_BASICA

        public void Insertar(int info)                   // recibe un NUEVO DATO de tipo entero
        {
            Nodo nuevo = new();                          // nuevo objeto de Nodo
            nuevo.info = info;
            nuevo.val = info;                            // valor del nuevo nodo

            nuevo.izq = null;                            // creamos espacio de memoria (izquierda)
            nuevo.der = null;                            // creamos espacio de memoria (dercha)

            if (raiz == null)                            // comprobamos que este VACIA la RAIZ
            {
                raiz = nuevo;                            // VERDADERO = Se crea una NUEVA RAIZ
            }
            else                                         // si NO esta VACIA la RAIZ
            {
                Nodo anterior = null, reco;              // NUEVA varible NODO 
                reco = raiz;                             // RECO es lo mismo que RAIZ
                while (reco != null)                     // hasta NO LLEGAR al LIMITE                {
                {
                    anterior = reco;                     // se guarda el valor anterior en la nueva variable
                    if (info < reco.info)                // NUEVO DATO < DATO ANTERIOR
                    {
                        reco = reco.izq;                 // GUARDA NODO IZQUIERDA
                    }
                    else
                    {
                        reco = reco.der;                 // SI NO GUARDA DERECHA

                    }
                }

                if (info < anterior.info)               // SI EL NUEVO VALOR ES NEMOR
                {
                    anterior.izq = nuevo;               // NUEVO VALOR se GUARDA en la IZQUIERDA

                }
                else
                {
                    anterior.der = nuevo;               // SI NO se GUARDA en la DERECHA
                }
            }
        }

        public bool Existe(int info)                   // VERIFICA que NO EXISTA el valor ingresado (NO SE REPITA)
        {
            Nodo reco = raiz;                           // VARIABLE TEMPORAL de RAIZ
            while (reco != null)
            {
                if (info == reco.info)                  // si el NUEVO DATO es IGUAL al DATO ANTIGUO
                {
                    return true;                        // retorna VERDADERO
                }
                else
                {
                    if (info < reco.info)               // si la NUEVA INFO es MENOR a la ANTERIOR 
                    {
                        reco = reco.der;                // GUARDA el DATO en la DERECHA
                    }
                    else
                    {
                        reco = reco.izq;                // SI el DATO es MAYOR al ANTERIRO - GUARDA en la IZQUIERDA
                    }
                }
            }
            return false;                              // Si NO existe el DATO INGRESADO arroja FALSO
        }

        #endregion


        #region SUMA_NODOS

        private int CalcularSuma(Nodo nodo)
        {
            if (nodo == null || (nodo.izq == null && nodo.der == null))
            {
                return 0;
            }
            else
            {
                return nodo.info + CalcularSuma(nodo.izq) + CalcularSuma(nodo.der);
            }
        }
        #endregion


        #region IMPRIME_ORDEN

        private void ImprimirPre(Nodo reco)
        {
            if (reco != null)
            {
                Console.Write(reco.info + " ");
                ImprimirPre(reco.izq);
                ImprimirPre(reco.der);
            }
        }

        public void ImprimirPre()
        {
            ImprimirPre(raiz);
            Console.WriteLine();
        }

        private void ImprimirEntre(Nodo reco)
        {
            if (reco != null)
            {
                ImprimirEntre(reco.izq);
                Console.Write(reco.info + " ");
                ImprimirEntre(reco.der);
            }
        }

        public void ImprimirEntre()
        {
            ImprimirEntre(raiz);
            Console.WriteLine();
        }

        private void ImprimirPost(Nodo reco)
        {
            if (reco != null)
            {
                ImprimirPost(reco.izq);
                ImprimirPost(reco.der);
                Console.Write(reco.info + " ");
            }

        }

        public void ImprimirPost()
        {
            ImprimirPost(raiz);
            Console.WriteLine();
        }

        #endregion


        #region IMPRIME_SUMA
        public void ImprimirSumaLados()
        {
            int sumaIzquierda = CalcularSuma(raiz.izq);
            int sumaDerecha = CalcularSuma(raiz.der);
            int total = sumaIzquierda + sumaDerecha;

            Console.Write("SUMA NODOS IZQUIERDA  >     " + sumaIzquierda);

            Console.WriteLine("\n                         +");

            Console.Write("SUMA NODOS DERECHA    >    " + sumaDerecha);

            Console.WriteLine("\n                         ----");

            Console.Write("SUMA TOTAL            >    " + total);
        }

        #endregion


        static void Main(string[] args)
        {
            ArbolBinario_Examen arbol = new();
            
            // DATOS PROPORCIONADOS =

            arbol.Insertar(8);
            arbol.Insertar(3);
            arbol.Insertar(1);
            arbol.Insertar(6);
            arbol.Insertar(4);
            arbol.Insertar(7);
            arbol.Insertar(10);
            arbol.Insertar(14);
            arbol.Insertar(13);
            
            // IMPRESION =

            Console.Write("Impresion PreOrden   > ");
            arbol.ImprimirPre();

            Console.Write("\nImpresion EntreOrden > ");
            arbol.ImprimirEntre();
            
            Console.Write("\nImpresion PostOrden  > ");
            arbol.ImprimirPost();

            Console.WriteLine("\n--------------------------------------------\n");

            arbol.ImprimirSumaLados();

            Console.ReadKey();
        }
    }
}