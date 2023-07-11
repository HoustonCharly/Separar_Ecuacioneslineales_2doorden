using System;
using info.lundin.math;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ecuaciones
{
    public partial class Form1 : Form
    {
        string xd, xi;//Variables para cuando introduzca datos
        double xizq, numizq, xder, //Variables para 
        numder, xfin, nfin, salida;//Operaciones en el calculo de X

        private void equipoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Los Increibles.\n" +
                            "");
        }

        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            lB1.Items.Clear();//Limpia por si se evalua de nuevo
            
            Entrada();
            
            numizq = funcion(0, xi);//se hace una evaluacion con x=0 para que solo queden el numero total de x
            numder = funcion(0, xd);//se hace una evaluacion con x=0 para que solo queden el numero total de x
            xizq = funcion(1, xi)-numizq;// se evalua x=1 para operar las x con el valor entero lado izq
            xder = funcion(1, xd)-numder;// se evalua x=1 para operar las x con el valor entero lado der
            //se opera ya con los numeros de los coeficientes de x como de los numeros solos
            xfin = xizq - xder;
            nfin = numder - numizq;

            Salida();
        }
        public void Entrada()
        {
            //Hace lectura de lo que introduce en el tezbos de la der e izq
            xd = tb1.Text;
            xi = tB2.Text;
        }

        public void Salida()
        {
            //imprime lo  que resulta de operar en ambos lados de la ecuacio en una sola variable (salida)
           salida = nfin / xfin;
           lB1.Items.Add("El valor de x =  " + salida);
        }

        public double funcion(double x, string res)
        {
            //Se hace la conversion de lo que entra el tezbos de cadena a double para poder operar 
            //de modo que si existe una x en la ecuacion la sustituye por otra x pero de tipo double
            ExpressionParser paser1 = new ExpressionParser();
            paser1.Values.Add("x", x);
            return (paser1.Parse(res));
        }
    }
}