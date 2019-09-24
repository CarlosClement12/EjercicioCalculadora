using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        const string ERROR_MESSAGE = "Error";
        public enum OperationType { None, Addition, Substraction, Multiplication, Division};
        OperationType operation = OperationType.None;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SumaRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            operation = OperationType.Addition;
            Calculus();
        }

        private void Operando1TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // LIMIT TO NUMERIC ON EACH CHANGE
            
            Calculus();
        }

        private void Operando2TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Calculus();
        }

        private bool CheckNumeric()
        {
            return double.TryParse(operando1TextBox.Text, out double aux1) && double.TryParse(operando2TextBox.Text, out double aux2);
        }

        private void Calculus()
        {
            if (operando1TextBox.Text != "" && operando2TextBox.Text != "" && CheckNumeric()) 
            {

                    double num1 = double.Parse(operando1TextBox.Text);
                    double num2 = double.Parse(operando2TextBox.Text);

                switch (operation)
                {
                    case OperationType.None:
                        resultadoTextBox.Text = ERROR_MESSAGE;
                        break;
                    case OperationType.Addition:
                        resultadoTextBox.Text = (num1 + num2).ToString();
                        break;
                    case OperationType.Substraction:
                        resultadoTextBox.Text = (num1 - num2).ToString();
                        break;
                    case OperationType.Multiplication:
                        resultadoTextBox.Text = (num1 * num2).ToString();
                        break;
                    case OperationType.Division:
                        if (num2 != 0)
                            resultadoTextBox.Text = (num1 - num2).ToString();
                        else
                            resultadoTextBox.Text = ERROR_MESSAGE;
                        break;
                }
            }
            else
                resultadoTextBox.Text = ERROR_MESSAGE;
        }

        private void RestaRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            operation = OperationType.Substraction;
            Calculus();
        }

        private void MultiplicacionRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            operation = OperationType.Multiplication;
            Calculus();
        }

        private void DivisionRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            operation = OperationType.Division;
            Calculus();
        }
    }
}
