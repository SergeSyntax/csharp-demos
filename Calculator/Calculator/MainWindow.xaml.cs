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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNumber, result;
        SelectedOperator selectedOperator;

        public MainWindow()
        {
            InitializeComponent();
            buttonAC.Click += ButtonAC_Click;
            buttonNegative.Click += ButtonNegative_Click;
            buttonPrcentage.Click += ButtonPrcentage_Click;
            buttonResult.Click += ButtonResult_Click;
        }

        private void ButtonResult_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out double newNumber))
            {
                switch(selectedOperator)
                {
                    case SelectedOperator.Addition:
                        result = SimpleMath.Addition(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Division:
                        result = SimpleMath.Division(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Multiplication:
                        result = SimpleMath.Multiplication(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Substraction:
                        result = SimpleMath.Substraction(lastNumber, newNumber);
                        break;
                }
                resultLabel.Content = result.ToString();
            }
               
        }

        private void ButtonPrcentage_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out double tempNum))
            {
                tempNum /= 100;
                // if you want to convert the second number to presentage
                if (lastNumber != 0)
                    tempNum *= lastNumber; 
                resultLabel.Content = tempNum.ToString();
            }
        }

        private void ButtonNegative_Click(object sender, RoutedEventArgs e) {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
                resultLabel.Content = (lastNumber * -1).ToString();
        }

        private void ButtonAC_Click(object sender, RoutedEventArgs e) => resultLabel.Content = 0;


        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                resultLabel.Content = "0";

                if (sender == buttonMultiplie) selectedOperator = SelectedOperator.Multiplication;
                if (sender == buttonDivide) selectedOperator = SelectedOperator.Division;
                if (sender == buttonPlus) selectedOperator = SelectedOperator.Addition;
                if (sender == buttonMinus) selectedOperator = SelectedOperator.Substraction;
            }

        }

        private void ButtonNumber_Click(object sender, RoutedEventArgs e)
        {
            string eventValue = (sender as Button).Content.ToString();
            if (int.TryParse(eventValue, out int selectedValue))
            {
                if (resultLabel.Content.ToString() == "0")
                    resultLabel.Content = $"{selectedValue}";
                else
                    resultLabel.Content = $"{resultLabel.Content}{selectedValue}";
            }
        }

        public void pointButton_Click(object sender, RoutedEventArgs e)
        {
            if (resultLabel.Content.ToString().Contains("."))
                return;
            resultLabel.Content = $"{resultLabel.Content}.";
        }
    }

    public enum SelectedOperator
    {
        Addition,
        Substraction,
        Multiplication,
        Division
    }

    public class SimpleMath
    {
        public static double Addition(double num1, double num2) => num1 + num2;
        public static double Substraction(double num1, double num2) => num1 - num2;
        public static double Multiplication(double num1, double num2) => num1 * num2;
        public static double Division(double num1, double num2)
        {
            if(num2 == 0)
            {
                MessageBox.Show("Devision by 0 is not supported.", "Wrong operation", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
            return num1 / num2; 
        }
    }
}

