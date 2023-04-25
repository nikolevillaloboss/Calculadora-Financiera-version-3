using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora_Financiera
{
    public partial class Form2 : Form
    {
        //Inialización de variables globales
        int cantidadMeses = 0;
        double tasaInteres = 0;
        int opcionPrestamo = 0;
        int opcion_cantidadMeses = 0;
        double monto = 0;

        public Form2()
        {
            InitializeComponent();
        }

        private void button_Atrás_Click(object sender, EventArgs e)
        {
            this.Hide(); //Esconder esta ventana "Datos"
            Form1 Bienvenida = new Form1(); //Se crea una nueva ventana Bienvenida
            Bienvenida.Show(); //Se muestra
        }

        //Botón de SALIR, antes de programar no le cambié el nombre
        private void button1_Click(object sender, EventArgs e)
        {
            //Acá creamos un mensaje flotante para confirmar que queremos salir del app
            if (MessageBox.Show("¿Está seguro que desea salir?", "Salir de la aplicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void comboBox_TipoPréstamo_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            if (comboBox_TipoPréstamo.SelectedIndex != -1)
            {
                int opcionPrestamo = comboBox_TipoPréstamo.SelectedIndex; // Establece la tasa de interés según la opción de préstamo seleccionada
                {
                    switch (opcionPrestamo)
                    {
                        case 0:
                            tasaInteres = 0.15;
                            break;
                        case 1: 
                            tasaInteres = 0.18;
                            break;
                        case 2:
                            tasaInteres = 0.12;
                            break;
                        case 3: 
                            tasaInteres = 0.12;
                            break;
                        case 4: 
                            tasaInteres = 0.18;
                            break;
                        default:
                            tasaInteres = 0.9;
                            break;
                    }
                }
            }
        }

        private void label_MontoT_Click(object sender, EventArgs e)
        {

        }

        private void label_CuotaMensual_Click(object sender, EventArgs e)
        {

        }
        private void textBox_MontoSolicitar_TextChanged(object sender, EventArgs e)
        {
            // Verifica si el monto del préstamo ingresado es válido y lo almacena en la variable
            if (double.TryParse(textBox_MontoSolicitar.Text, NumberStyles.Currency, CultureInfo.InvariantCulture, out monto))
            {
            }
            else
            {
                MessageBox.Show("Ingrese un valor numérico válido para el monto del préstamo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox_PlazoMeses_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica si la cantidad de meses  ingresada es válida y la almacena en la variable
            if (int.TryParse(comboBox_PlazoMeses.SelectedIndex.ToString(), out cantidadMeses))
            {
                // usa el valor recibido en la conversión de String a int

                // Establece la tasa de interés según la opción de préstamo seleccionada
                int opcion_cantidadMeses = comboBox_PlazoMeses.SelectedIndex;
                {
                    switch (opcion_cantidadMeses)
                    {
                        case 0:
                            cantidadMeses = 24;
                            break;
                        case 1:
                            cantidadMeses = 60;
                            break;
                        case 2: 
                            cantidadMeses = 84;
                            break;
                        default: 
                            MessageBox.Show("Opción de plazo de meses no es válida.", "Error");
                            return;
                    }
                }
            }
            else
            {
                // entrada no válida
            }
        }

        // funcion para validar 
        private string ValidarPrestamo()
        {
            string mensaje = "";
           double monto = Double.Parse(textBox_MontoSolicitar.Text);// asignar variable
            if (monto > 1000000 && comboBox_TipoPréstamo.SelectedIndex == 1)
            {
                mensaje += "El tipo de prestamo superado no puede superar el millon de colones, por favor cuelva a intentarlo\n";
            }
            if (monto > 1500000)
            {
                mensaje += "El tipo de prestamo superado no puede superar los 15 millones de colones, por favor cuelva a intentarlo\n";
            }
            if (comboBox_TipoPréstamo.SelectedIndex == 0 && cantidadMeses==84 )
            {
                mensaje += "El tipo de prestamo superado no puede superar los 15 millones de colones, por favor cuelva a intentarlo\n";
            }
                return mensaje;
            
            
        }
        
        private void button_Calcular_Click(object sender, EventArgs e)
        {
            string mensaje  = ValidarPrestamo();
            if (mensaje=="")
            {
                double monto, interesMensual, cuotaMensual, montoTotal;
                monto = Double.Parse(textBox_MontoSolicitar.Text);// asignar variable
                interesMensual = 0;
                interesMensual = monto * tasaInteres / (100 * 12);
                cuotaMensual = (monto + interesMensual) / cantidadMeses; //llamar a la funcion
                montoTotal = cuotaMensual * cantidadMeses;

                label_CuotaMensual.Text = cuotaMensual.ToString();
                label_MontoT.Text = montoTotal.ToString();
            }
            else
            {
                MessageBox.Show(mensaje);
            }
        }
    }
    //interesMensual = monto* tasaInteres / (100 * 12);
    //        cuotaMensual = (monto + interesMensual) / cantidadMeses;
    //        montoTotal = cuotaMensual* cantidadMeses;
    
}
