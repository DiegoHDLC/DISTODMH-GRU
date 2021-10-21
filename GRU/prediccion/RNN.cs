using GRU.prediccion;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GRU.prediccion{

    private double[] vector_entrada; //necesario?
    private double[] vector_salida;
    private RN perceptron;

    public RNN (){
        //aqui se inicializa lo custion
        perceptron = new RN();
        perceptron.inicializarRed();
        //inicializar RNN
    }

    public float[] predecir(float[] vector){
        
    }


}