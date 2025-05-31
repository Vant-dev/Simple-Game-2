using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        private dynamic game;
        public Form2()
        {
            InitializeComponent();
            game = new Treasure(0,0,0,0,0,0,0,0,0,0);
        }

        public Form2(Form1 form1)
        {
            InitializeComponent();


        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (game.SetsSetter(textBox1.Text) == 0)
            {
                MessageBox.Show("Ошибка. Введите число сетов в формате: целое число от 1 до 999");
                textBox1.Clear();
            }
            else
            {
                MessageBox.Show("Данные корректные");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(game.GetSets());
        }
    }
}
