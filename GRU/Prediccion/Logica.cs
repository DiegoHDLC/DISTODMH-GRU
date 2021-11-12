using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRU
{
    public class Logica
    {

        private int longitud_Xt = 300;

        public float[] generarVector(Random random, string tipo)
        {
            //Random rand = new Random();
            float[] vector = new float[longitud_Xt];
            for (int i = 0; i < vector.Length; i++)
            {
                // vector[i] = rand.Next(-2, 2);
                switch (tipo)
                {
                    case "inicial": vector[i] = 0; break;
                    case "noInicial": vector[i] = (float)(random.Next(-4,4)*0.1);break;
                    case "bias": vector[i] = 0; break;
                }
            }
            return vector;
        }

        public float[,] generarPeso(Random random)
        {
            //Random random = new Random();
            float[,] peso = new float[longitud_Xt,longitud_Xt];
            for(int i = 0; i < longitud_Xt; i++)
            {
                for(int j = 0; j < longitud_Xt; j++)
                {
                    //peso[i, j] = random.Next(-2, 2);
                    peso[i, j] = (float)(random.Next(-1,1)*0.1);
                    //Console.WriteLine(j);
                }
            }
            return peso;
        }

        internal float productoPuntoVector(float[] vector)
        {
            float[] v1 = vector;
            float[] v2 = vector;
            float suma = 0;
            for (int i = 0; i < v1.Length; i++)
            { 
                suma = suma + (v1[i] * v2[i]);
            }
            return suma;
        }

        internal float[,] matrizTraspuesta(float[,] matriz)
        {
            float[,] mt = new float[matriz.GetLength(0), matriz.GetLength(1)];
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    mt[j, i] = matriz[i, j];
                }
            }
            return mt;
        }

        public float[,] multiplicarVectores(float[] vec1, float[] vec2)
        {
            float[,] matriz = inicializarMatriz();

            for (int i = 0; i < vec1.Length; i++)
            {
                for (int j = 0; j < vec2.Length; j++)
                {
                    matriz[i,j] = vec1[i] * vec2[j];
                }
            }
            return matriz;
        }

        public float[,] inicializarMatriz()
        {
            float[,] unaMatriz = new float[300,300];
            for (int x = 0; x < unaMatriz.GetLength(0); x++)
            {
                for(int y = 0; y < unaMatriz.GetLength(1); y++)
                {
                    unaMatriz[x, y] = 0;
                }

            }
            return unaMatriz;
        }

        public float[] productoPuntoMatrizVector(float[,] matriz, float[] vector)
        {
            float[] vectorFinal = new float[vector.Length];
            for (int fila = 0; fila < matriz.GetLength(0); fila++)
            {
                vectorFinal[fila] = 0;
                for (int col = 0; col < matriz.GetLength(1); col++)
                {
                    vectorFinal[fila] += matriz[fila,col] * vector[col];
                }
            }
            return vectorFinal;
        }

        internal float[] sumaVectores(float[] wx, float[] uh)
        {
            float[] vectorFinal = new float[longitud_Xt];
            for (int i = 0; i < wx.Length; i++)
            {
                vectorFinal[i] = wx[i] + uh[i];
            }
            return vectorFinal;
        }

        internal void imprimirVector(float[] vector)
        {
            foreach(float n in vector)
            {
                Console.WriteLine(n);
            }
        }

        internal float[] resta(float[] zt)
        {
            float[] resta = new float[longitud_Xt];
            for(int i = 0; i < zt.Length; i++)
            {
                resta[i] = 1 - zt[i]; 
            }
            return resta;
        }

        internal float[] multiplcarMatrizVector(float[,] w, float[] x)
        {
            float[] vectorFinal = new float[longitud_Xt];
            for (int fila = 0; fila < longitud_Xt; fila++)
            {
                //vectorFinal[fila] = 0;
                for (int col = 0; col < longitud_Xt; col++)
                {
                    vectorFinal[fila] += w[fila,col] * x[col];
                }
            }
            return vectorFinal;
        }

       


    }
}
