﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRU
{
    public class Control
    {
        Logica logica = new Logica();
        public float[] generarVector(Random random, string tipo)
        {
            float[] vector = new float[300];
            switch (tipo)
            {
                case "inicial": vector = logica.generarVector(random, "inicial"); break;
                case "noInicial": vector = logica.generarVector(random, "noInicial");break;
                case "bias": vector = logica.generarVector(random, "bias");break;
            }
            
            return vector;
        }

        internal float[] updateGate(float[] h, float[,] w, float[,] u, float[] x, float[] bias)
        {
            float[] Wx = logica.multiplcarMatrizVector(w,x);
            float[] Uh = logica.multiplcarMatrizVector(u,h);
            float[] sumaVectores = logica.sumaVectores(Wx, Uh);
            float[] sumaBias = logica.sumaVectores(sumaVectores, bias);
            //logica.imprimirVector(sumaBias);
            float[] sigmoide = logica.funcionSigmoide(sumaBias);
            return sigmoide;
        }

        internal float[] productoHalamard(float[] h, float[] rt)
        {
            float[] ph = logica.productoHalamard(h, rt);
            return ph;
        }

        internal float[] memoriaIntermedia(float[,] wh, float[,] uh, float[] x, float[] h, float[] rt, float[] biasH)
        {
            float[] Uh = logica.multiplcarMatrizVector(uh, h);
            float[] Wx = logica.multiplcarMatrizVector(wh, x);
            float[] ph = logica.productoHalamard(h,Uh);
            float[] suma = logica.sumaVectores(Wx, ph);
            float[] suma2 = logica.sumaVectores(suma, biasH);
            float[] tanh = logica.tangenteHiperbolica(suma2);
            return tanh;

        }

        internal void imprimirVector(float[] vector)
        {
            logica.imprimirVector(vector);
        }

        internal float[] memoriaFinal(float[] zt, float[] h, float[] hTilde)
        {
            float[] ph1 = logica.productoHalamard(zt, h);
            float[] resta = logica.resta(zt);////resta 1 - zt
            float[] ph2 = logica.productoHalamard(resta,hTilde);
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