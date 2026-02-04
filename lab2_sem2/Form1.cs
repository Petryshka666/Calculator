using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace lab2_sem2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
       
        double memory_result = 0;

        //стеки для чисел и операций
        private List<double> numbers = new List<double>();
        private List<string> operations = new List<string>();

        private void button_C_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";//удаление только последней записи
        }
        private void button_CE_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            numbers.Clear();
            operations.Clear();
           
        }
        private void button_Pointer_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text;
            if (s.Length > 1)
            {
                s = s.Remove(s.Length - 1);//удалить последний символ строки
                textBox1.Text = s;
            }
            else
            {
                textBox1.Text = "0";//чтоб строку пустой не оставить
            }
        }
      
        private void button_1_Click(object sender, EventArgs e)//+
        {
            if (textBox1.Text == "0") { textBox1.Text = ""; }//чтобы не ввелось 01 а только 1 если только вводить начинаю
            textBox1.Text += "1";
        }
        private void button_2_Click(object sender, EventArgs e)
        {
     
            if (textBox1.Text == "0") { textBox1.Text = ""; }
            textBox1.Text += "2";
        }
        private void button_3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0") { textBox1.Text = ""; }
            textBox1.Text += "3";
        }
        private void button_4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0") { textBox1.Text = ""; }
            textBox1.Text += "4";
        }
        private void button_5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0") { textBox1.Text = ""; }
            textBox1.Text += "5";
        }
        private void button_6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0") { textBox1.Text = ""; }
            textBox1.Text += "6";
        }
        private void button_7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0") { textBox1.Text = ""; }
            textBox1.Text += "7";
        }
        private void button_8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0") { textBox1.Text = ""; }
            textBox1.Text += "8";
        }
        private void button_9_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0") { textBox1.Text = ""; }
            textBox1.Text += "9";
        }
        private void button_0_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0") { textBox1.Text = ""; }
            textBox1.Text += "0";
        }
        private void button_zap_Click(object sender, EventArgs e)//,
        {
            string s = textBox1.Text;
            bool f = false;
            for (int i = 0; i < s.Length; i++)//ищу "," чтоб не дублировать ее
            {
                if (s[i] == ',')
                {
                    f = true;
                }
            }
            if (!f) textBox1.Text += ",";
        }
      
        private void button_sqrt_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out double param))//то что в данный момент есть на экране
            {
                if (param >= 0)
                {
                    param = Math.Sqrt(param);
                    textBox1.Text = Convert.ToString(param);

                }
                else
                {
                    MessageBox.Show("Неверный ввод. Попытка вычисления квадратного корня из отрицательного числа.");
                    textBox1.Text = "0";
                }
            }
            else
            {
                MessageBox.Show("Некорректное значение.");
                textBox1.Text = "0";
            }
        }
        private void button_1x_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out double param))
            {
                if (param == 0)
                {
                    MessageBox.Show("Попытка деления на 0. Операция не может быть выполнена.");

                    textBox1.Text = "0";

                }
                else
                {
                    param = 1 / param;
                    textBox1.Text = Convert.ToString(param);
                }

               
            }
            else
            {
                MessageBox.Show("Некорректное значение");
                textBox1.Text = "0";
            }
        }

        private void button_PM_Click(object sender, EventArgs e)//+-
        {
            if (double.TryParse(textBox1.Text, out double param))
            {
                if (param != 0)
                {
                    param = -param;
                    textBox1.Text = Convert.ToString(param);
                }

            }
            else
            {
                MessageBox.Show("Некорректное значение");
                textBox1.Text = "0";
            }

        }
       
            //метод для определения приоритета операции(чем выше тем больше приоритет)
            private int GetPrioritet(string op)
            {
                if (op == "+" || op == "-") return 1;
                if (op == "*" || op == "/" || op == "%") return 2;
                if (op == "^" || op == "k") return 3;
                return 0;
            }

            //метод для выполнения одной операции
            private double PerformOperation(double a, double b, string op)
            {
                switch (op)
                {
                    case "+": return a + b;
                    case "-": return a - b;
                    case "*": return a * b;
                    case "/":
                        if (b != 0) return a / b;
                        else { MessageBox.Show("Деление на ноль!"); return 0; }
                    case "^": return Math.Pow(a, b);
                    case "k":
                        if (b > 0)//степень корня только положительное число
                        {
                            if (b % 2 == 0 && a < 0)
                            {
                                MessageBox.Show("Невозможно вычислить четный корень из отрицательного числа.");
                                return 0;
                            }
                            else
                            {
                                double res = Math.Pow(Math.Abs(a), 1.0 / b);
                                if (a < 0) { return -res; }
                                else return res; 
                           
                            }
                        }
                        else
                        {
                            MessageBox.Show("Степень корня должна быть положительным числом.");
                            return 0;
                        }
                    case "%":
                        if (b != 0) return a % b;
                        else { MessageBox.Show("Деление на ноль!"); return 0; }
                    default: return 0;
                }
            }

            //метод для обработки операций с учетом приоритета
            private void ProcessOperation(string newOp = null)
            {
                while (operations.Count > 0 && (newOp == null || GetPrioritet(operations[operations.Count - 1]) >= GetPrioritet(newOp)))
                {
                    double b = numbers[numbers.Count - 1]; numbers.RemoveAt(numbers.Count - 1);
                    double a = numbers[numbers.Count - 1]; numbers.RemoveAt(numbers.Count - 1);
                    string op = operations[operations.Count - 1]; operations.RemoveAt(operations.Count - 1);

                    double result = PerformOperation(a, b, op);
                    numbers.Add(result);//и добавляю в конец списка их результат
                }

                //когда стек не пустой и приоритет последней операции меньше новой, новая добавляется в стек просто и ждет следующий аргумент чтоб произвести с ним операцию(2+2*2)
                //когда стек не пустой и приоритет последней операции больше или равен новой сначала оперируются , а потом в стек добавляется новая(2*2+2)
                if (newOp != null)//новая операция добавляется в конец списка
                {
                    operations.Add(newOp);
                }
            }

            private void ApplyOperation(string op)//подготовка к выполнению бинарной операции, запоминание первого числа(2+2 жму * и запомнится вторая 2 только и * будет добавлена в стек и будет ждать следующий аргумент)
            {
                if (double.TryParse(textBox1.Text, out double param))
                {
                    numbers.Add(param);//добавила в стек чисел
                    ProcessOperation(op);
                    textBox1.Text = "0";
                }
                else
                {
                    MessageBox.Show("Некорректный ввод!");
                }
            }

            private void button_Equal_Click(object sender, EventArgs e)
            {
                if (double.TryParse(textBox1.Text, out double current))
                {
                    numbers.Add(current);//добавляю в стек последнее число которое я ввела до нажатия равно
                    ProcessOperation(); //выполняю все оставшиеся операции поскольку это = и нам нужен результат теперь
                    
                if (numbers.Count > 0)//если после всего в стеке остался результат
                    {
                        textBox1.Text = Convert.ToString(numbers[0]);
                        numbers.Clear();
                        operations.Clear();
                    }
                    else
                    {
                        textBox1.Text = "0";
                    }
                }
                else
                {
                    MessageBox.Show("Некорректный ввод! Введите число для завершения операции.");
                    textBox1.Text = "";
                }
            }    

        private void button_Plus_Click(object sender, EventArgs e)
        {
           
            ApplyOperation("+");
        }
        private void button_Munis_Click(object sender, EventArgs e)
        {
           
            ApplyOperation("-");

        }
        private void button_umn_Click(object sender, EventArgs e)
        {
           
            ApplyOperation("*");
        }
        private void button_slash_Click(object sender, EventArgs e)
        {
            ApplyOperation("/");
        }
        private void button_x2_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out double param))//то что в данный момент есть на экране
            {
                param = Math.Pow(param, 2);
                textBox1.Text = Convert.ToString(param);


            }
            else
            {
                MessageBox.Show("Некорректное значение");
                textBox1.Text = "0";
            }
        }

        private void button_x3_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out double param))//то что в данный момент есть на экране
            {
                param = Math.Pow(param, 3);
                textBox1.Text = Convert.ToString(param);

            }
            else
            {
                MessageBox.Show("Некорректное значение");
                textBox1.Text = "0";
            }
        }

        private void button_xy_Click(object sender, EventArgs e)
        {
            ApplyOperation("^");
        }

        private void button_persent_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out double param))//то что в данный момент есть на экране
            {
               
                    double res = param / 100;
                    textBox1.Text = Convert.ToString(res);
              
            }
            else
            {
                MessageBox.Show("Некорректное значение");
                textBox1.Text = "0";
            }
        }

        private void button_Exp_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "∞")
            {
                MessageBox.Show("Некорректный аргумент.");
                textBox1.Text = "0";
                return;
            }
            if (double.TryParse(textBox1.Text, out double param))//то что в данный момент есть на экране
            {
                double zn = Math.Exp(param);
                textBox1.Text = Convert.ToString(zn);

            }
            else
            {
                MessageBox.Show("Некорректное значение");
                textBox1.Text = "0";
            }

        }
        private void button_ln_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "∞")
            {
                MessageBox.Show("Некорректный аргумент.");
                textBox1.Text = "0";
                return;
            }
            if (double.TryParse(textBox1.Text, out double param))//то что в данный момент есть на экране
            {

                if (param > 0)//аргумент логарифма только положительное число
                {
                    double zn = Math.Log(param);
                    textBox1.Text = Convert.ToString(zn);

                }
                else
                {
                    MessageBox.Show($"Натуральный логарифм {param} не определен ");
                    textBox1.Text = "0";
                }

            }
            else
            {
                MessageBox.Show("Некорректное значение");
                textBox1.Text = "0";
            }

        }

        private void button_log_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "∞")
            {
                MessageBox.Show("Некорректный аргумент.");
                textBox1.Text = "0";
                return;
            }
            if (double.TryParse(textBox1.Text, out double param))//то что в данный момент есть на экране
            {
                if (param > 0)
                {

                    double zn = Math.Log10(param);
                    textBox1.Text = Convert.ToString(zn);

                }
                else
                {
                    MessageBox.Show($"Десятичный логарифм {param} не определен ");
                    textBox1.Text = "0";
                }


            }
            else
            {
                MessageBox.Show("Некорректное значение");
                textBox1.Text = "0";
            }

        }

        double Factorial(double n)
        {
            if (n == 1 || n == 0) return 1;


            return n * Factorial(n - 1);
        }

        private void button_fact_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out double param))//то что в данный момент есть на экране
            {
                if (param >= 0)
                {

                    double zn = Factorial(param);
                    textBox1.Text = Convert.ToString(zn);


                }
                else
                {
                    MessageBox.Show("Невозможно вычислить факториал отрицательного числа");
                    textBox1.Text = "0";
                }

            }
            else
            {
                MessageBox.Show("Некорректное значение");
                textBox1.Text = "0";
            }

        }

        private void button_10x_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out double param))//то что в данный момент есть на экране
            {

                double zn = Math.Pow(10, param);
                textBox1.Text = Convert.ToString(zn);


            }
            else
            {
                MessageBox.Show("Некорректное значение");
                textBox1.Text = "0";
            }
        }

        private void button_sin_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out double param))//то что в данный момент есть на экране
            {

                double zn = Math.Sin(param);
                textBox1.Text = Convert.ToString(zn);


            }
            else
            {
                MessageBox.Show("Некорректное значение");
                textBox1.Text = "0";
            }
        }

        private void button_cos_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out double param))//то что в данный момент есть на экране
            {

                double zn = Math.Cos(param);
                textBox1.Text = Convert.ToString(zn);


            }
            else
            {
                MessageBox.Show("Некорректное значение");
                textBox1.Text = "0";
            }

        }

        private void button_tan_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out double param))//то что в данный момент есть на экране
            {

                double zn = Math.Tan(param);
                textBox1.Text = Convert.ToString(zn);


            }
            else
            {
                MessageBox.Show("Некорректное значение");
                textBox1.Text = "0";
            }

        }

        private void button_3Cor_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out double param))//то что в данный момент есть на экране
            {

                double zn = Math.Pow(param, 1.0 / 3.0);
                textBox1.Text = Convert.ToString(zn);


            }
            else
            {
                MessageBox.Show("Некорректное значение");
                textBox1.Text = "0";
            }

        }


        private void button_yCor_Click(object sender, EventArgs e)
        {
            ApplyOperation("k");

        }
        private void button_Mod_Click(object sender, EventArgs e)
        {
            ApplyOperation("%");
        }
        private void button_Author_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Автор приложения: Petryshka666");
        }

        private void button_MS_Click(object sender, EventArgs e)//добавить в память то что в текстовом поле
        {
            if (double.TryParse(textBox1.Text, out double param))
            {

                button_Memory.Enabled = true;
                memory_result = param;
                button_MC.Enabled = true;
                button_MR.Enabled = true;
                button_M_munis.Enabled = true;
                button_M_plus.Enabled = true;
            }
            else
            {
                textBox1.Text = "0";
                MessageBox.Show("Некорректное значение!");
            }

        }
        private void button_MR_Click(object sender, EventArgs e)//вставить значение из памяти как аргумент операции
        {
            textBox1.Text = Convert.ToString(memory_result);
        }
        private void button_M_plus_Click(object sender, EventArgs e)//добавить к значению в памяти значение из текстового поля
        {
            if (double.TryParse(textBox1.Text, out double param))
            {
                memory_result += param;
            }
            else
            {
                textBox1.Text = "0";
                MessageBox.Show("Некорректное значение!");
            }
        }

        private void button_M_munis_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out double param))
            {
                memory_result -= param;
            }
            else
            {
                textBox1.Text = "0";
                MessageBox.Show("Некорректное значение!");
            }
        }

        private void button_MC_Click(object sender, EventArgs e)//очистить память
        {
            memory_result = 0;

            button_MC.Enabled = false;
            button_MR.Enabled = false;
            button_M_munis.Enabled = false;
            button_M_plus.Enabled = false;
            button_Memory.Enabled = false;

        }
        private void button_Memory_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Память: {memory_result}");
        }

    }

}
