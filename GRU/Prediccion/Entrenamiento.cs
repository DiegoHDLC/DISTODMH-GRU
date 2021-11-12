using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace GRU.Prediccion
{
    internal class Entrenamiento
    {
        Control control = new Control();
        public void backpropagation(float[] Zt, float[] hAnterior, float[] hGorro, float[,] Uh, float[,] Wh, float[,] Uz, float[,] Wz, float[] rt, float[,] Ur, float[,] Wr, float[] x)
        {
            Random random = new Random();
            //En realidad el d0 viene de la funcion loss parece, pero aca simulo ese vector
            float[] d0 = control.generarVector(random, "noInicial");
            float[] d1 = control.productoHadamard(Zt, d0);
            float[] d2 = control.productoHadamard(hAnterior, d0);
            float[] d3 = control.productoHadamard(hGorro, d0);
            float[] d4 = control.productoHadamard(-1, d3);
            float[] d5 = control.sumaVectores(d2, d4);
            float[] resta = control.resta(Zt);
            float[] d6 = control.productoHadamard(resta, d0);
            float[] resultadoProducto = control.productoHadamard(Zt, resta);
            float[] d7 = control.productoHadamard(d5, resultadoProducto);
            float hGorroCuadrado = control.productoPuntoVector(hGorro);
            float[] d8 = control.productoHadamard(1 - hGorroCuadrado, d6);
            float[,] Uht = control.matrizTraspuesta(Uh);
            float[] d9 = control.productoPuntoMatrizVector(Uht, d8);
            float[,] Wht = control.matrizTraspuesta(Wh);
            float[] d10 = control.productoPuntoMatrizVector(Wht, d8);
            float[,] Uzt = control.matrizTraspuesta(Uz);
            float[] d11 = control.productoPuntoMatrizVector(Uzt, d7);
            float[,] Wzt = control.matrizTraspuesta(Wz);
            float[] d12 = control.productoPuntoMatrizVector(Wzt, d7);
            float[] d14 = control.productoHadamard(d10, rt);
            float[] d15 = control.productoHadamard(d10, hAnterior);
            float[] resta2 = control.resta(rt);
            float[] resultadoProducto2 = control.productoHadamard(rt, resta2);
            float[] d16 = control.productoHadamard(d15, resultadoProducto2);
            float[,] Urt = control.matrizTraspuesta(Ur);
            float[] d13 = control.productoPuntoMatrizVector(Urt, d16);
            float[,] Wrt = control.matrizTraspuesta(Wr);
            float[] d17 = control.productoPuntoMatrizVector(Wrt, d16);

            ////Calculando gradientes
            ///
            float[] s1 = control.sumaVectores(d9, d11);
            float[] dx = control.sumaVectores(s1, d13);
            float[] s2 = control.sumaVectores(d12, d14);
            float[] s3 = control.sumaVectores(s2, d1);
            float[] dHAnterior = control.sumaVectores(s3, d17);
            float[,] dUr = control.multiplicarVectores(x, d16);
            float[,] dUz = control.multiplicarVectores(x, d7);
            float[,] dUh = control.multiplicarVectores(x, d8);
            float[,] dWr = control.multiplicarVectores(hAnterior, d16);
            float[,] dWz = control.multiplicarVectores(hAnterior, d17);
            float[] resultadoProducto3 = control.productoHadamard(hAnterior, rt);
            float[,] dWh = control.multiplicarVectores(resultadoProducto3, d8);
           
                




        }



    }
}
