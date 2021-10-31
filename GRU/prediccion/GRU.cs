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

        //PREGUNTAS
        /*
        - Es necesario que se inicialice cada una de estas?
        - En caso de que si se inicializa en el constru

        - Es necesario tener Control en cada metodo?
        - En caso de que no habria que hacer uno global

        */

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
            //metodo cargar ~ desde control
        }

        public float [] feedForward(float[] Xt){
            float []Zt = control.updateGate(this.h, this.Wz, this.Uz, Xt, this.biasZ);
            float []Rt = control.updateGate(this.h, this.Wr, this.Ur, Xt, this.biasR);
            float [] Htilde = control.memoriaIntermedia(this.Wh, this.Uh, Xt, this.h, Rt, this.biasH);
            float [] Hfinal = control.memoriaFinal(Zt, this.h, Htilde);
            return Hfinal;
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