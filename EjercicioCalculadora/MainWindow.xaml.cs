using System.Windows;
using System.Windows.Controls;

namespace EjercicioCalculadora
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string ERROR_MESSAGE = "Error";
        const string DIVIDE_BY_ZERO_MESSAGE = "No se puede dividir entre cero";
        const string ANY_OPERATION_MESSAGE = "Ninguna operación seleccionada";
        const string DEFAULT_NUMBER = "0";

        public enum OperationType { None, Addition, Substraction, Multiplication, Division};
        OperationType operation = OperationType.None;

        public MainWindow()
        {
            InitializeComponent();
            ResetTextBoxes();
        }

        private void ResetTextBoxes()
        {
            operando1TextBox.Text = DEFAULT_NUMBER;
            operando2TextBox.Text = DEFAULT_NUMBER;
        }

        private void SumaRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            operation = OperationType.Addition;
            Calculus();
        }

        private void OperandoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Calculus();
        }

        private bool CheckNumeric(out double num1, out double num2)
        {
            num1 = 0;
            num2 = 0;
            return double.TryParse(operando1TextBox.Text, out num1) && double.TryParse(operando2TextBox.Text, out num2);
        }

        private void Calculus()
        {
            if (operando1TextBox.Text != string.Empty && operando2TextBox.Text != string.Empty)
            {

                if (CheckNumeric(out double num1, out double num2))
                {
                    switch (operation)
                    {
                        case OperationType.None:
                            resultadoTextBox.Text = ANY_OPERATION_MESSAGE;
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
                                resultadoTextBox.Text = (num1 / num2).ToString();
                            else
                                resultadoTextBox.Text = DIVIDE_BY_ZERO_MESSAGE;
                            break;
                    }
                }
                else
                    resultadoTextBox.Text = ERROR_MESSAGE;
            }
            else
            {
                if(operation == OperationType.None)
                    resultadoTextBox.Text = ANY_OPERATION_MESSAGE;
                else
                    resultadoTextBox.Text = string.Empty;
            }
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

        private void LimpiarButton_Click(object sender, RoutedEventArgs e)
        {
            ResetTextBoxes();
        }

        private void Operando1TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (operando1TextBox.Text == DEFAULT_NUMBER)
                operando1TextBox.Text = string.Empty;
        }

        private void Operando2TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (operando2TextBox.Text == DEFAULT_NUMBER)
                operando2TextBox.Text = string.Empty;
        }

        private void Operando2TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if(operando2TextBox.Text == string.Empty)
                operando2TextBox.Text = DEFAULT_NUMBER;
        }

        private void Operando1TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (operando1TextBox.Text == string.Empty)
                operando1TextBox.Text = DEFAULT_NUMBER;
        }

        private void OperandoTextBox_LostFocus(object sender, RoutedEventArgs e)
        {

        }
    }
}
