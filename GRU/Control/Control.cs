using GRU.GRU.prediccion;
using System;

namespace GRU
{
    public class Control
    {
        Logica logica = new Logica();
        FA fa = new FA();
        
        public float[] generarVector(Random random, string tipo)
        {
            switch (tipo)
            {
                case "inicial": return logica.generarVector(random, "inicial");
                case "noInicial": return logica.generarVector(random, "noInicial");
                case "bias": return logica.generarVector(random, "bias");
            }
            return null;
        }

        internal float[] updateGate(float[] h, float[,] w, float[,] u, float[] x, float[] bias)
        {
            float[] Wx = logica.multiplcarMatrizVector(w,x);
            float[] Uh = logica.multiplcarMatrizVector(u,h);
            float[] sumaVectores = logica.sumaVectores(Wx, Uh);
            float[] sumaBias = logica.sumaVectores(sumaVectores, bias);
            //logica.imprimirVector(sumaBias);
            float[] sigmoide = fa.funcionSigmoide(sumaBias);
            return sigmoide;
        }

        internal float[] productoHalamard(float[] h, float[] rt)
        {
            float[] ph = fa.productoHalamard(h, rt);
            return ph;
        }

        internal float[] memoriaIntermedia(float[,] wh, float[,] uh, float[] x, float[] h, float[] rt, float[] biasH)
        {
            float[] Uh = logica.multiplcarMatrizVector(uh, h);
            float[] Wx = logica.multiplcarMatrizVector(wh, x);
            float[] ph = fa.productoHalamard(h,Uh);
            float[] suma = logica.sumaVectores(Wx, ph);
            float[] suma2 = logica.sumaVectores(suma, biasH);
            float[] tanh = fa.tangenteHiperbolica(suma2);
            return tanh;

        }

        internal void imprimirVector(float[] vector)
        {
            logica.imprimirVector(vector);
        }

        internal float[] memoriaFinal(float[] zt, float[] h, float[] hTilde)
        {
            float[] ph1 = fa.productoHalamard(zt, h);
            float[] resta = logica.resta(zt);////resta 1 - zt
            float[] ph2 = fa.productoHalamard(resta,hTilde);
            float[] suma = logica.sumaVectores(ph1, ph2);
            return suma;

        }

        public float[,] generarPeso(Random random)
        {
            float [,] peso = logica.generarPeso(random);
            return peso;
        }
       
    }
}
