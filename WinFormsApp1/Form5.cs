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
    public partial class Form5 : Form
    {
        private dynamic form;
        private dynamic sv;
        private int id;
        public Form5()
        {
            InitializeComponent();
            form = new Form1();
            sv = new StringValid();
            dataGridView1.AutoGenerateColumns = true;



        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var dataTable = await form.ShowBd();


            dataGridView1.DataSource = dataTable;
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox4.Text))
            {

                if (sv.IsDigit(textBox4.Text))
                {
                    int id = Convert.ToInt32(textBox4.Text.Trim());
                    form.DeleteBd(id);
                    var dataTable = await form.ShowBd();
                    dataGridView1.DataSource = dataTable;

                }
                else
                {
                    MessageBox.Show("Введите корректный параметр id в формате цифр 0 до 9");
                }
            }
            else
            {
                MessageBox.Show("Строка не должна быть пустой.");
            }
        }

        private async void button4_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Строка не должна быть пустой.");
            }
            else if (!sv.IsDigit(textBox1.Text))
            {
                MessageBox.Show("Введите корректный параметр id в формате цифр 0 до 9");
            }
            else
            { 
                bool IdExists = await form.IdCheck(Convert.ToInt32(textBox1.Text.Trim()));

                if (!IdExists)
                {
                    MessageBox.Show("Ошибка. Не существует строки с id = " + textBox1.Text);
                }
                else
                {
                    DataTable data = await form.ShowColumn(Convert.ToInt32(textBox1.Text));

                    int id = Convert.ToInt32(textBox1.Text);
               
                    Form6 form6 = new Form6(data,id);
                    form6.ShowDialog();
                }
            }
            
        }
    }
}
