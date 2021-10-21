using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRU
{
    public class Logica
    {
        public float[] generarVector(Random random, string tipo)
        {
            //Random rand = new Random();
            float[] vector = new float[300];
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
            float[,] peso = new float[300,300];
            for(int i = 0; i < 300; i++)
            {
                for(int j = 0; j < 300; j++)
                {
                    //peso[i, j] = random.Next(-2, 2);
                    peso[i, j] = (float)(random.Next(-1,1)*0.1);
                    //Console.WriteLine(j);
                }
            }
            return peso;
        }

        internal float[] funcionSigmoide(float[] suma)
        {
            float[] v = new float[300];
            for(int i = 0; i < suma.Length; i++)
            {
                v[i] =(float) (1 / (1 + Math.Exp(-suma[i])));
            }
            return v;
        }

        internal float[] productoHalamard(float[] h, float[] rt)
        {
            float[] v = new float[300];
            for (int i = 0; i < v.Length; i++)
            {
                v[i] = h[i] * rt[i];
            }
            return v;
        }

        internal float[] sumaVectores(float[] wx, float[] uh)
        {
            float[] vectorFinal = new float[300];
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
            float[] resta = new float[300];
            for(int i = 0; i < zt.Length; i++)
            {
                resta[i] = 1 - zt[i]; 
            }
            return resta;
        }

        internal float[] multiplcarMatrizVector(float[,] w, float[] x)
        {
            float[] vectorFinal = new float[300];
            for (int fila = 0; fila < 300; fila++)
            {
                //vectorFinal[fila] = 0;
                for (int col = 0; col < 300; col++)
                {
                    vectorFinal[fila] += w[fila,col] * x[col];
                }
            }
            return vectorFinal;
        }

        public float[] tangenteHiperbolica(float[] x)
        {
            float[] y = new float[300];
            for(int i = 0; i< x.Length; i++)
            {
                if (x[i] < -20.0)
                {
                    y[i] = -1;
                }
                else
                {
                    if(x[i] > 20){
                        y[i] = 1;
                    }else{
                        y[i] = (float)Math.Tanh(x[i]);
                    }
                }
            }
            return y;
            
            
        }


    }
}
