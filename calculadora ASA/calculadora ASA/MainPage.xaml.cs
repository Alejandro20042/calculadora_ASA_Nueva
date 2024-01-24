using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace calculadora_ASA
{
    public partial class MainPage : ContentPage
    {
        string operador = string.Empty;
        double primerNumero, segundoNumero, resultado;

        public MainPage()
        {
            InitializeComponent();
        }

        //Este metodo es para seleccionar los botones
        void Button_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            resultEntry.Text += button.Text;
        }

        //Metodo para borrar
        void ACButton_Clicked(object sender, EventArgs e)
        {
            resultEntry.Text = string.Empty;
            operador = string.Empty;
            primerNumero = 0;
            segundoNumero = 0;
        }

        void OperadorButton_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            // Verificar si hay un número en el Entry y no sea null
            if (!string.IsNullOrEmpty(resultEntry.Text) && double.TryParse(resultEntry.Text, out primerNumero))
            {
                // Almacenar el operador y limpiar el Entry
                operador = button.Text;
                resultEntry.Text = string.Empty;
            }
        }

        //Metodo para calcular el resultado de la operacion
        void ResultadoButton_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(resultEntry.Text) && double.TryParse(resultEntry.Text, out segundoNumero))
            {
                switch (operador)
                {
                    case "+":
                        resultado = primerNumero + segundoNumero;
                        break;
                    case "-":
                        resultado = primerNumero - segundoNumero;
                        break;
                    case "*":
                        resultado = primerNumero * segundoNumero;
                        break;
                    case "/":
                        if (segundoNumero != 0)
                        {
                            resultado = primerNumero / segundoNumero;
                        }
                        else
                        {
                            resultEntry.Text = "Error";
                            return;
                        }
                        break;
                    default:
                        return;
                }
                resultEntry.Text = resultado.ToString();
                operador = string.Empty;
            }
        }
        void Button_Clicked1(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            // Verificar si el botón es un punto y si ya existe un punto en el resultado
            if (button.Text == "." && resultEntry.Text.Contains("."))
            {
                return; // No agregar otro punto si ya hay uno presente
            }

            resultEntry.Text += button.Text;
        }


    }
}
