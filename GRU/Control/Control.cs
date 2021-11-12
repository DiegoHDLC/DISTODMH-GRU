using GRU.GRU.prediccion;
using System;

namespace GRU
{
    public class Control
    {
        Logica logica = new Logica();
        FuncionesActivacion funcionesActivacion = new FuncionesActivacion();
        
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
            float[] sigmoide = funcionesActivacion.funcionSigmoide(sumaBias);
            return sigmoide;
        }

        internal float productoPuntoVector(float[] vector)
        {
            float pp = logica.productoPuntoVector(vector);
            return pp;
        }

        internal float[,] matrizTraspuesta(float[,] matriz)
        {
            float[,] mt = logica.matrizTraspuesta(matriz);
            return mt;
        }

        internal float[] productoPuntoMatrizVector(float[,] matriz, float[] vector)
        {
            float[] pp = logica.productoPuntoMatrizVector(matriz, vector);
            return pp;
        }

        public float[,] multiplicarVectores (float[] v1, float[] v2)
        {
            float[,] res = logica.multiplicarVectores(v1,v2);
            return res;
        }

        internal float[] resta(float[] zt)
        {
            float[] resta = logica.resta(zt);
            return resta;
        }

        internal float[] sumaVectores(float[] d2, float[] d4)
        {
            float[] suma = logica.sumaVectores(d2,d4);
            return suma;
            
        }

        internal float[] productoHadamard(float v, float[] d3)
        {
            float[] ph = funcionesActivacion.productoHadamard(v, d3);
            return ph;
        }

        internal float[] productoHadamard(float[] h, float[] rt)
        {
            float[] ph = funcionesActivacion.productoHadamard(h, rt);
            return ph;
        }

        internal float[] memoriaIntermedia(float[,] wh, float[,] uh, float[] x, float[] h, float[] rt, float[] biasH)
        {
            float[] Uh = logica.multiplcarMatrizVector(uh, h);
            float[] Wx = logica.multiplcarMatrizVector(wh, x);
            float[] ph = funcionesActivacion.productoHadamard(h,Uh);
            float[] suma = logica.sumaVectores(Wx, ph);
            float[] suma2 = logica.sumaVectores(suma, biasH);
            float[] tanh = funcionesActivacion.tangenteHiperbolica(suma2);
            return tanh;

        }

        internal void imprimirVector(float[] vector)
        {
            logica.imprimirVector(vector);
        }

        internal float[] memoriaFinal(float[] zt, float[] h, float[] hTilde)
        {
            float[] ph1 = funcionesActivacion.productoHadamard(zt, h);
            float[] resta = logica.resta(zt);////resta 1 - zt
            float[] ph2 = funcionesActivacion.productoHadamard(resta,hTilde);
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
