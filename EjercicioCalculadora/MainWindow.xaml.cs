using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EjercicioCalculadora
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public enum OperationType { None, Addition, Substraction, Multiplication, Division};
        OperationType operation = OperationType.None;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SumaRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            operation = OperationType.Addition;
        }

        private void Operando1TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Calculus();
        }

        private void Operando2TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Calculus();
        }

        private void Calculus()
        {
            if (operando1TextBox.Text != "" && operando2TextBox.Text != "")
            {
                switch (operation)
                {
                    case OperationType.None:
                        resultadoTextBox.Text = "Error";
                        break;
                    case OperationType.Addition:
                        resultadoTextBox.Text = 
                        break;
                    case OperationType.Substraction:
                        break;
                    case OperationType.Multiplication:
                        break;
                    case OperationType.Division:
                        break;
                }
            }
        }
    }
}
