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
