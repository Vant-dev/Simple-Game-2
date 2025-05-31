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

    public partial class Form4 : Form
    {
        private dynamic game;
        public Form4()
        {
            InitializeComponent();
            game = new Hangman(4, 3, 0, 0, false, "", "");
            comboBox1.Enabled = false;
            button1.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label5.Text = "Жизней осталось: " + Convert.ToString(game.GetLife());
            comboBox2.Enabled = false;
            button2.Enabled = false;
            textBox1.Enabled = true;
            button5.Enabled = true;

            int len = Convert.ToInt32(comboBox2.Text);

            label4.Text = new string('*', len);

            game.GameStart();

            game.setNick(textBox4.Text);

            game.setUCC(Convert.ToInt32(comboBox2.Text));



        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

            comboBox1.Items.Add("Технологии");
            comboBox1.Items.Add("Биология");
            comboBox1.Items.Add("Готовка");
            comboBox1.SelectedIndex = 0;

            comboBox2.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            textBox1.Enabled = false;
            button5.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Enabled = false;
            button1.Enabled = false;

            comboBox2.Enabled = true;
            button2.Enabled = true;

            int arrLength = game.getLength(comboBox1.Text);

            for (int i = 0; i < arrLength; i++)
            {
                int item = game.setLength(comboBox1.Text, i);

                // Проверяем, не было ли такое значение добавлено ранее
                if (!comboBox2.Items.Contains(item))
                {
                    comboBox2.Items.Add(item);
                }
            }
            comboBox2.SelectedIndex = 0;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox2.Enabled = false;
            button2.Enabled = false;

            button3.Enabled = true;


            game.setWord(Convert.ToInt32(comboBox2.Text));
            game.SetLn(Convert.ToInt32(comboBox2.Text));

            game.setWord(Convert.ToInt32(comboBox2.Text));

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (game.SetCharacter(textBox1.Text))
            {
                var result = game.CheckWord(textBox1.Text);

                if (game.GetLife() < 1 || game.getUCC() < 1)
                {
                    comboBox1.Enabled = true;
                    button1.Enabled = true;
                    textBox1.Enabled = false;
                    button5.Enabled = false;
                    game.GameEnd();
                }
                else if (result.Item1)
                {
                    MessageBox.Show("Вы отгадали букву " + textBox1.Text);
                    char[] chars = label4.Text.ToCharArray();
                    // Убедимся, что индекс находится в правильном диапазоне
                    // Здесь, возможно, нужно получить именно символ из строки, убедитесь, что textBox1 содержит один символ
                    chars[result.Item2] = textBox1.Text[0];
                    label4.Text = new string(chars);


                }
                else
                {
                    MessageBox.Show("Вы ошиблись");
                    label5.Text = "Жизней осталось: " + Convert.ToString(game.GetLife());
                }
            }
            else
            {
                MessageBox.Show("Ошибка. Необходимо ввести 1 русскую букву.");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox4.Text.Length < 1)
            {
                MessageBox.Show("Длинна ника должна быть минимум 1 символ.");
            }
            else
            {
                comboBox1.Enabled = true;
                button1.Enabled = true;
                button6.Enabled = false;
                textBox4.Enabled = false;
            }
        }
    }
}
