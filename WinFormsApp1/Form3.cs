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
    public partial class Form3 : Form
    {
        private dynamic game;
        private dynamic form1;
        private Treasure treasure;
        public Form3()
        {
            InitializeComponent();

            form1 = new Form1();
            game = new Treasure(0, 0, 0, 0, 3, 0, 0, 0, 0, 0);

        }

        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            textBox1 = new TextBox();
            label1 = new Label();
            button1 = new Button();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            button2 = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label7 = new Label();
            label8 = new Label();
            button3 = new Button();
            button4 = new Button();
            textBox4 = new TextBox();
            label6 = new Label();
            button5 = new Button();
            button6 = new Button();
            textBox5 = new TextBox();
            ((ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ColumnHeadersHeight = 5;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditOnKeystroke;
            dataGridView1.ImeMode = ImeMode.NoControl;
            dataGridView1.Location = new Point(334, 137);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 10;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(254, 149);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellMouseDown += dataGridView1_CellMouseDown;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(30, 14);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(161, 17);
            label1.Name = "label1";
            label1.Size = new Size(249, 20);
            label1.TabIndex = 2;
            label1.Text = "Установите сложность игры (1-10)";
            // 
            // button1
            // 
            button1.Location = new Point(30, 61);
            button1.Name = "button1";
            button1.Size = new Size(125, 29);
            button1.TabIndex = 3;
            button1.Text = "Установить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(823, 176);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(94, 27);
            textBox2.TabIndex = 4;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(823, 222);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(94, 27);
            textBox3.TabIndex = 5;
            // 
            // button2
            // 
            button2.Location = new Point(823, 271);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 6;
            button2.Text = "Проверить";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(789, 172);
            label2.Name = "label2";
            label2.Size = new Size(28, 28);
            label2.TabIndex = 7;
            label2.Text = "X:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(789, 221);
            label3.Name = "label3";
            label3.Size = new Size(27, 28);
            label3.TabIndex = 8;
            label3.Text = "Y:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(30, 446);
            label4.Name = "label4";
            label4.Size = new Size(146, 20);
            label4.TabIndex = 9;
            label4.Text = "Сокровищь всего: 0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(207, 446);
            label5.Name = "label5";
            label5.Size = new Size(160, 20);
            label5.TabIndex = 10;
            label5.Text = "Сокровищ найдено: 0";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(534, 446);
            label7.Name = "label7";
            label7.Size = new Size(126, 20);
            label7.TabIndex = 12;
            label7.Text = "Бомб найдено: 0";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(693, 446);
            label8.Name = "label8";
            label8.Size = new Size(124, 20);
            label8.TabIndex = 13;
            label8.Text = "Число жизней: 3";
            // 
            // button3
            // 
            button3.Location = new Point(30, 171);
            button3.Name = "button3";
            button3.Size = new Size(125, 29);
            button3.TabIndex = 14;
            button3.Text = "Начать игру";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(30, 224);
            button4.Name = "button4";
            button4.Size = new Size(125, 29);
            button4.TabIndex = 15;
            button4.Text = "Выход";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(723, 6);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(125, 27);
            textBox4.TabIndex = 16;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(588, 9);
            label6.Name = "label6";
            label6.Size = new Size(129, 20);
            label6.TabIndex = 17;
            label6.Text = "Введите ваш ник:";
            // 
            // button5
            // 
            button5.Location = new Point(723, 52);
            button5.Name = "button5";
            button5.Size = new Size(125, 29);
            button5.TabIndex = 18;
            button5.Text = "Установить";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(620, 342);
            button6.Name = "button6";
            button6.Size = new Size(144, 29);
            button6.TabIndex = 20;
            button6.Text = "Выбрать";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(629, 298);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(125, 27);
            textBox5.TabIndex = 19;
            // 
            // Form3
            // 
            ClientSize = new Size(981, 491);
            Controls.Add(button6);
            Controls.Add(textBox5);
            Controls.Add(button5);
            Controls.Add(label6);
            Controls.Add(textBox4);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(dataGridView1);
            Name = "Form3";
            Load += Form3_Load;
            ((ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private TextBox textBox1;
        private Label label1;
        private Button button1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Button button2;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label7;
        private Label label8;
        private Button button3;
        private Button button4;
        private DataGridView dataGridView1;

        private void Form3_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 5;
            dataGridView1.RowCount = 5;
            textBox1.Text = Convert.ToString(game.GetDifficult());

            dataGridView1.RowTemplate.Height = 20; // Устанавливаем высоту строк в 20 пикселей

            // Установка ширины столбцов
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].Width = 50; // Устанавливаем ширину каждого столбца в 50 пикселей
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable; // Отключаем сортировку
            }

            button3.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            button2.Enabled = false;
            textBox1.Enabled = false;
            button1.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (game.SetDifficult(textBox1.Text) == 0)
            {
                MessageBox.Show("Ошмбка. Ввелите корректный уровень сложности в формате: целое число от 1 до 10");
                textBox1.Text = Convert.ToString(game.GetDifficult());
            }
            else
            {
                MessageBox.Show("Данные корректны");
                button3.Enabled = true;
                button1.Enabled = false;
                textBox1.Enabled = false;
            }

        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dataGridView1.ClearSelection();
            }
        }



        private  void button3_Click(object sender, EventArgs e)
        {
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            button2.Enabled = true;

            int height = game.GetHeight();
            int width = game.GetWidth();


            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = game.ShowCell(i, j);
                }
            }


            game.GameStart();
            game.setNick(textBox4.Text);


       

            label4.Text = "Всего сокровищ: " + Convert.ToString(game.GetMaxTreasure());
            label5.Text = "Собрано сокровищ: " + Convert.ToString(game.GetCollectTreasure());
            label7.Text = "Собрано бомб: " + Convert.ToString(game.GetBombCount());
            label8.Text = "Число жизней: " + Convert.ToString(game.GetLife());






        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int height = game.GetHeight();
            int width = game.GetWidth();

            int result = game.PlayTurn(textBox2.Text, textBox3.Text);

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = game.ShowCell(i, j);
                }
            }

            if (result == 0)
            {

                button1.Enabled = true;
                textBox1.Enabled = true;
                game.GameEnd();
            }
            else if (result == 2)
            {
                MessageBox.Show("Ошибка. Введите координаты клетки в корректном формате: целое число от 0 до 4.");
            }
            else if (result == 3)
            {
                MessageBox.Show("Вы уже проверяли эту клетку.");
                textBox2.Clear();
                textBox3.Clear();
            }
            else if (result == 4)
            {
                MessageBox.Show("Вы наткнулись на бомбу");
                game.SetLife();
                game.SetBombs();
                label7.Text = "Собрано бомб: " + Convert.ToString(game.GetBombCount());
                label8.Text = "Число жизней: " + Convert.ToString(game.GetLife());
            }
            else if (result == 5)
            {
                MessageBox.Show("Вы выбрали пустую клетку.");
            }
            else if (result == 6)
            {
                MessageBox.Show("Поздравляем вы нашли сокровище.");
                game.SetTreasure();
                label5.Text = "Собрано сокровищ: " + Convert.ToString(game.GetCollectTreasure());
            }

        }

        private TextBox textBox4;
        private Label label6;
        private Button button5;

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox4.Text.Length < 1)
            {
                MessageBox.Show("Длинна ника должна быть минимум 1 символ.");
            }
            else
            {
                textBox1.Enabled = true;
                button1.Enabled = true;
                textBox4.Enabled = false;
                button5.Enabled = false;
            }
        }

        private Button button6;
        private TextBox textBox5;

        private async void button6_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            int id = Convert.ToInt32(textBox5.Text);
            dt = await form1.ShowRow(id);
            bool ch = Convert.ToBoolean(dt.Rows[0]["Hangman"]);

            if(ch)
            {
                MessageBox.Show("Ошибка. Вы выбрали строку принадлежащую классу Hangman");
            }
            else
            {
                game.setsLife(Convert.ToInt32(dt.Rows[0]["lifecount"]));
                game.setCollectTreasure(Convert.ToInt32(dt.Rows[0]["collecttreasure"]));
            }
          
        }
    }
}
