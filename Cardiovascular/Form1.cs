namespace Cardiovascular
{
    public partial class Form1 : Form
    {
        private int conteo =0, ramdon = 0;
        bool reduccion = false;
        Random ramdo = new Random();
        public Form1()
        {
            InitializeComponent();
            //conteo = 0;
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            
            if (conteo == 180){
               Thread.Sleep(100);
                conteo--;
                label1.Text = conteo.ToString();
                ramdon = ramdo.Next(0, 180);
                reduccion = true;

            }else if (reduccion) {
                conteo--;
                label1.Text = conteo.ToString();
                if (conteo == ramdon)
                {
                    timer1.Enabled = false;
                    button1.Enabled = false;
                    if (ramdon == 0)
                    {
                        MessageBox.Show(
                            "Recomendaciones: " +
                            "\nRCP!!!" +
                            "\nUna persona debe hacer: " +
                            "\n1. Una llamada al centro médico." +
                            "\n2. Enviar un mensaje al Doctor." +
                            "\n3. Visitar de inmediato al centro de salud más cercano!!!", 
                            "Emergencia!", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Warning);
                    }
                    else if (ramdon > 0 && ramdon < 70)
                    {
                        MessageBox.Show(
                            "Recomendaciones: " +
                            "\n1. Realizar una llamada de emergencia (más recomendable al 911)." +
                            "\n2. Enviar un mensaje al Doctor." +
                            "\n3. Visitar de inmediato al centro de salud más cercano!!!", 
                            "Advertencia!", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Warning);
                    }
                    else if (ramdon >= 70 && ramdon <= 120)
                    {
                        MessageBox.Show(
                            "Recomendación: " +
                            "\nNecesita realizar ejercicio cardiovascular!!!", 
                            "Advertencia!", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Warning);
                    }
                    else if (ramdon > 120 && ramdon <= 140)
                    {
                        MessageBox.Show(
                            "Recomendación: " +
                            "\nIndicación a visita médica!!!", 
                            "Advertencia!", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Warning);
                        
                    }
                    else if (ramdon > 140 && ramdon <= 180)
                    {
                        MessageBox.Show(
                            "Nivel de gravedad en tendencia peligrosa!!!" +
                            "\nRecomendaciones: " +
                            "\nLa persona debe: " +
                            "\n1. Hacer una llamada al centro médico." +
                            "\n2. Enviar un mensaje al Doctor." +
                            "\n3. Visitar de inmediato al centro de salud más cercano!!!", 
                            "Advertencia!", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Warning);
                        
                    }
                }
            }


            if (!reduccion)
            {
                conteo++;
                label1.Text = conteo.ToString();
                Thread.Sleep(5);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt32(label1.Text) != 0)
            {
               DialogResult opcion = MessageBox.Show("¿Está seguro de que desea reiniciar la prueba?", 
                   "Advertencia!",  
                   MessageBoxButtons.YesNo, 
                   MessageBoxIcon.Warning);

                if (opcion == DialogResult.Yes)
                {
                    label1.Text = "0";
                    conteo = 0;
                    timer1.Enabled = false;
                    reduccion = false;
                    button1.Enabled = true;
                }

            }
        }
    }
}