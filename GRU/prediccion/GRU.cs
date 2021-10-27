using GRU.prediccion;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GRU{
    
    public class GRU{
        
        
        private const string rutaPesos = @"../../../zDataSet/datasetEntrenamiento/pesosRed.txt";
        Random random = new Random();
        //Variables a utilizar
        private float [,] Wz;
        private float [,] Uz;
        private float [,] Wr;
        private float [,] Ur;
        private float [,] Wh;
        private float [,] Uh;
        private float[] biasZ;
        private float[] biasR;
        private float[] biasH;
        private float[] h;

        public GRU(Boolean entrenada){
            if(entrenada){
                cargarGRU();
            }else{
                inicializarGRU();
            }
        }

        private void inicializarGRU(){
            Control control = new Control();
            this.h = control.generarVector(random,"inicial");
            this.Uz = control.generarPeso(random);
            this.Wz = control.generarPeso(random);
            this.biasZ = control.generarVector(random, "bias");
            this.Wr = control.generarPeso(random);
            this.Ur = control.generarPeso(random);
            this.biasR = control.generarVector(random, "bias");
            this.Uh = control.generarPeso(random);
            this.Wh = control.generarPeso(random);
            this.biasH = control.generarVector(random, "bias");
        }

        private void cargarGRU(){
            Control control = new Control();
            this.h = control.generarVector(random, "inicial");
        }

        public float [] feedForward(float[] Xt){
            /* float []Zt = control.updateGate(this.h, this.Wz, this.Uz, Xt, this.biasZ);
             float [] Rt;
             float [] Htilde;
             float [] Hfinal;



             return Hfinal;*/
            return null;
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