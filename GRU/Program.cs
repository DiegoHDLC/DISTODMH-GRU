using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRU
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Control control = new Control();
            Random random = new Random();
            /////////UPDATE GATE
            float[] h = control.generarVector(random, "inicial");
            float[] x = control.generarVector(random, "noInicial");
            float[] biasZ = control.generarVector(random, "bias");
            float[,] Wz = control.generarPeso(random);
            float[,] Uz = control.generarPeso(random);
            float[] Zt = control.updateGate(h, Wz, Uz, x, biasZ);
            //control.imprimirVector(Zt);
            ////////RESET GATE
            float[] biasR = control.generarVector(random, "bias");
            float[,] Wr = control.generarPeso(random);
            float[,] Ur = control.generarPeso(random);
            float[] Rt = control.updateGate(h, Wr, Ur, x, biasR); //Se utiliza el mismo método anterior, pero con diferentes parámetros
            ////////Memoria Intermedia
            float[] biasH = control.generarVector(random, "bias");
            float[,] Wh = control.generarPeso(random);
            float[,] Uh = control.generarPeso(random);
            float[] hTilde = control.memoriaIntermedia(Wh, Uh, x, h, Rt, biasH);
            ///////Memoria Final
            float[] hFinal = control.memoriaFinal(Zt, h, hTilde);
            control.imprimirVector(hFinal);
            Console.ReadLine();
        }

    }
}
