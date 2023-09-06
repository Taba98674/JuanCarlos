using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Trabajo_Interfas
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Obtener los valores de los cuadros de texto
            string actividad = ActividadTextBox.Text;
            string valorStr = ValorTextBox.Text;

            // Validar la entrada (puedes agregar más validaciones según sea necesario)
            if (string.IsNullOrEmpty(actividad) || string.IsNullOrEmpty(valorStr))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!double.TryParse(valorStr, out double valor))
            {
                MessageBox.Show("El valor ingresado no es válido.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Crear un objeto de gasto
            Gasto nuevoGasto = new Gasto(actividad, valor);

            // Agregar el nuevo gasto a la lista y actualizar el ListBox
            ListaDeGastos.Add(nuevoGasto);
            ActualizarListBox();

            // Limpiar los cuadros de texto
            ActividadTextBox.Clear();
            ValorTextBox.Clear();
        }

        private void ActualizarListBox()
        {
            ListaDeGastosListBox.Items.Clear();
            foreach (var gasto in ListaDeGastos)
            {
                ListaDeGastosListBox.Items.Add($"{gasto.Actividad}: ${gasto.Valor}");
            }
        }
        private List<Gasto> ListaDeGastos = new List<Gasto>();

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }

    public class Gasto
    {
        public string Actividad { get; set; }
        public double Valor { get; set; }

        public Gasto(string actividad, double valor)
        {
            Actividad = actividad;
            Valor = valor;
        }
    }
}
