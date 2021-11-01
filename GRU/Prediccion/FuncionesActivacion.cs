using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRU.GRU.prediccion
{
    internal class FuncionesActivacion
    {
        private int longitud_Xt = 300;
        internal float[] funcionSigmoide(float[] suma)
        {
            float[] v = new float[suma.Length];
            for (int i = 0; i < suma.Length; i++)
            {
                v[i] = (float)(1 / (1 + Math.Exp(-suma[i])));
            }
            return v;
        }

        internal float[] productoHalamard(float[] h, float[] rt)
        {
            float[] v = new float[longitud_Xt];
            for (int i = 0; i < v.Length; i++)
            {
                v[i] = h[i] * rt[i];
            }
            return v;
        }

        public float[] tangenteHiperbolica(float[] x)
        {
            float[] y = new float[longitud_Xt];
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] < -20.0)
                {
                    y[i] = -1;
                }
                else
                {
                    if (x[i] > 20)
                    {
                        y[i] = 1;
                    }
                    else
                    {
                        y[i] = (float)Math.Tanh(x[i]);
                    }
                }
            }
            return y;
        }

        public List<float> SoftMax(List<float> entrada)
        {
            float suma = 0;
            foreach (float n in entrada)
            {
                suma += (float)Math.Exp(n);
            }
            List<float> prob = new List<float>();
            foreach (float n2 in entrada)
            {
                prob.Add((float)Math.Exp(n2) / suma);
            }
            return prob;
        }
    }
}
