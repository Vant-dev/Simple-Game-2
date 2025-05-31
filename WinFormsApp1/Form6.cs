using System;
using Npgsql;
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
    public partial class Form6 : Form
    {
        private int id;
        private int difficult;
        private int score;
        private int collectTreasure;

        private dynamic form;
        private dynamic sv;
        public Form6(DataTable dataTable, int id1)
        {
            InitializeComponent();
            textBox4.Text = dataTable.Rows[0][1].ToString();
            textBox1.Text = dataTable.Rows[0][2].ToString();
            textBox2.Text = dataTable.Rows[0][3].ToString();
            textBox3.Text = dataTable.Rows[0][4].ToString();
            textBox5.Text = dataTable.Rows[0][5].ToString();
            textBox6.Text = dataTable.Rows[0][6].ToString();
            id = id1;

            form = new Form1();
            sv = new StringValid();

        }



        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Значения в таблице не должны быть пустыми.");
            }
            else if (!sv.IsDigit(textBox1.Text) || !sv.IsDigit(textBox3.Text) || !sv.IsDigit(textBox5.Text)) 
            {
                MessageBox.Show("Столбцы difficult и score должны быть в числовом формате.");
            }
            else
            {
                score = Convert.ToInt32(textBox3.Text);
                difficult = Convert.ToInt32(textBox1.Text);
                collectTreasure = Convert.ToInt32(textBox5.Text);

                string nick = textBox4.Text;
                string gameType = textBox2.Text;
                string choosedString = textBox6.Text;

                form.UpdateBd(id, nick, difficult, gameType, score,collectTreasure,choosedString);
                this.Close();

            }
        }
    }
}
