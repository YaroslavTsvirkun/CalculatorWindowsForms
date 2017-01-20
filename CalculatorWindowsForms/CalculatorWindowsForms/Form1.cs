using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorWindowsForms
{
    /// <summary>
    /// Класс FormCalculator обрабатывает события отрисовки формы калькулятора
    /// </summary>
    public partial class FormCalculator : Form
    {
        /// <summary>
        /// 
        /// </summary>
        Double a, b;
        /// <summary>
        /// 
        /// </summary>
        Int64 count;
        /// <summary>
        /// 
        /// </summary>
        String symbol;
        /// <summary>
        /// 
        /// </summary>
        Boolean sign = true;
        /// <summary>
        /// 
        /// </summary>
        ToolStripLabel dateLabel;
        /// <summary>
        /// 
        /// </summary>
        ToolStripLabel timeLabel;
        /// <summary>
        /// 
        /// </summary>
        ToolStripLabel infoLabel;
        /// <summary>
        /// 
        /// </summary>
        Timer timer;
        /// <summary>
        /// Конструктор FormCalculator инициализирует объекты формы
        /// </summary>
        public FormCalculator()
        {
            // Инициализация формы программы 
            InitializeComponent();
            // Инициализация даты и времени на форме
            Time();
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            tb.Text = tb.Text + 0;
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            tb.Text = tb.Text + ",";
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            tb.Text = tb.Text + 1;
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            tb.Text = tb.Text + 2;
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            tb.Text = tb.Text + 3;
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            tb.Text = tb.Text + 4;
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            tb.Text = tb.Text + 5;
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            tb.Text = tb.Text + 6;
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            tb.Text = tb.Text + 7;
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            tb.Text = tb.Text + 8;
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            tb.Text = tb.Text + 9;
        }

        private void btnPlus_Minus_Click(object sender, EventArgs e)
        {
            if (sign == true)
            {
                tb.Text = "-" + tb.Text;
                sign = false;
            }
            else if (sign == false)
            {
                tb.Text = tb.Text.Replace("-", "");
                sign = true;
            }
        }

        private void Calculate()
        {
            switch (count)
            {
                case 1:
                    b = a + Double.Parse(tb.Text);
                    tb.Text = b.ToString();
                    break;
                case 2:
                    b = a - Double.Parse(tb.Text);
                    tb.Text = b.ToString();
                    break;
                case 3:
                    b = a * Double.Parse(tb.Text);
                    tb.Text = b.ToString();
                    break;
                case 4:
                    b = a / Double.Parse(tb.Text);
                    tb.Text = b.ToString();
                    break;
                case 5:
                    b = a % Double.Parse(tb.Text);
                    tb.Text = b.ToString();
                    break;
                default:
                    break;
            }
        }
        private void Logic_Click(Int64 count, String symbol)
        {
            a = Double.Parse(tb.Text);
            tb.Clear();
            this.count = count;
            lb.Text = a.ToString() + symbol;
            sign = true;
        }
        private void btnPlus_Click(object sender, EventArgs e)
        {
            try
            {
                count = 1;
                symbol = "+";
                Logic_Click(count, symbol);
            }
            catch { }
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            try
            {
                count = 2;
                symbol = "-";
                Logic_Click(count, symbol);
            }
            catch { }
        }

        private void btnMultiplication_Click(object sender, EventArgs e)
        {
            try
            {
                count = 3;
                symbol = "*";
                Logic_Click(count, symbol);
            }
            catch { }
        }

        private void btnDivision_Click(object sender, EventArgs e)
        {
            try
            {
                count = 4;
                symbol = "/";
                Logic_Click(count, symbol);
            }
            catch { }
        }

        private void btnEqually_Click(object sender, EventArgs e)
        {
            Calculate();
            lb.Text = "";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            tb.Text = "";
            lb.Text = "";
        }

        private void tb_TextChanged(object sender, EventArgs e) { }

        private void lb_Click(object sender, EventArgs e) { }

        private void FileToolStripMenuItem_Click(object sender, EventArgs e) { }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            Int64 lenght = tb.Text.Length - 1;
            String text = tb.Text;
            tb.Clear();
            for (Int32 i = 0; i < lenght; i++) tb.Text = tb.Text + text[i];
        }
        
        /// <summary>
        /// Метод Time для расчета текущего времени и даты
        /// </summary>
        private void Time()
        {
            dateLabel = new ToolStripLabel();
            timeLabel = new ToolStripLabel();
            infoLabel = new ToolStripLabel();
            timer = new Timer() { Interval = 1000 };
            infoLabel.Text = "Дата и время:";

            StatusStrip.Items.Add(infoLabel);
            StatusStrip.Items.Add(dateLabel);
            StatusStrip.Items.Add(timeLabel);

            timer.Tick += tsslTime_Click;
            timer.Start();
        }
        /// <summary>
        /// Метод tsslTime_Click для обработки события StatusStrip
        /// </summary>
        /// <param name="sender">Принимает параметр любого типа</param>
        /// <param name="e">Аргумент события</param>
        private void tsslTime_Click(object sender, EventArgs e)
        {
            dateLabel.Text = DateTime.Now.ToLongDateString();
            timeLabel.Text = DateTime.Now.ToLongTimeString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StatusStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e) { }
        /// <summary>
        /// Метод AboutToolStripMenuItem_Click выводит информацию "О программе"
        /// </summary>
        /// <param name="sender">Принимает параметр любого типа</param>
        /// <param name="e">Аргумент события</param>
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа Calculator, представляет собой старый добрый стандартный калькулятор для вычисления простых арифметических выражений.", "About the program");
        }
        /// <summary>
        /// Метод AuthorDeveloperToolStripMenuItem_Click выводит информацию "Автор разработчик"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AuthorDeveloperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Developer: Tsvirkun Yaroslav \nПредложения по улучшению программы: \nyaroslav.tsvirkun.1992@outlook.com", "Author Developer");
        }
    }
}