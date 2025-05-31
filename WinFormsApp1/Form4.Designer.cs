namespace WinFormsApp1
{
    partial class Form4
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            comboBox1 = new ComboBox();
            label1 = new Label();
            comboBox2 = new ComboBox();
            label2 = new Label();
            button1 = new Button();
            button2 = new Button();
            button4 = new Button();
            button3 = new Button();
            textBox1 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            button5 = new Button();
            label5 = new Label();
            button6 = new Button();
            label8 = new Label();
            textBox4 = new TextBox();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(23, 21);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(180, 24);
            label1.Name = "label1";
            label1.Size = new Size(192, 20);
            label1.TabIndex = 1;
            label1.Text = "Выберите категорию слов";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(23, 117);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(151, 28);
            comboBox2.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(180, 120);
            label2.Name = "label2";
            label2.Size = new Size(176, 20);
            label2.TabIndex = 3;
            label2.Text = "Выберите длинну слова";
            // 
            // button1
            // 
            button1.Location = new Point(36, 55);
            button1.Name = "button1";
            button1.Size = new Size(125, 29);
            button1.TabIndex = 4;
            button1.Text = "Установить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(36, 161);
            button2.Name = "button2";
            button2.Size = new Size(125, 29);
            button2.TabIndex = 5;
            button2.Text = "Установить";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button4
            // 
            button4.Location = new Point(36, 293);
            button4.Name = "button4";
            button4.Size = new Size(125, 29);
            button4.TabIndex = 17;
            button4.Text = "Выход";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Location = new Point(36, 240);
            button3.Name = "button3";
            button3.Size = new Size(125, 29);
            button3.TabIndex = 16;
            button3.Text = "Начать игру";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(214, 339);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 19;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(355, 342);
            label3.Name = "label3";
            label3.Size = new Size(107, 20);
            label3.TabIndex = 20;
            label3.Text = "Введите букву";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label4.Location = new Point(213, 228);
            label4.Name = "label4";
            label4.Size = new Size(143, 81);
            label4.TabIndex = 21;
            label4.Text = "****";
            // 
            // button5
            // 
            button5.Location = new Point(214, 393);
            button5.Name = "button5";
            button5.Size = new Size(125, 29);
            button5.TabIndex = 22;
            button5.Text = "Проверить";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(29, 402);
            label5.Name = "label5";
            label5.Size = new Size(145, 20);
            label5.TabIndex = 23;
            label5.Text = "Жизней осталось: 3";
            // 
            // button6
            // 
            button6.Location = new Point(593, 67);
            button6.Name = "button6";
            button6.Size = new Size(125, 29);
            button6.TabIndex = 28;
            button6.Text = "Установить";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(458, 24);
            label8.Name = "label8";
            label8.Size = new Size(129, 20);
            label8.TabIndex = 27;
            label8.Text = "Введите ваш ник:";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(593, 21);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(125, 27);
            textBox4.TabIndex = 26;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button6);
            Controls.Add(label8);
            Controls.Add(textBox4);
            Controls.Add(label5);
            Controls.Add(button5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(comboBox2);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Name = "Form4";
            Text = "Form4";
            Load += Form4_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private Label label1;
        private ComboBox comboBox2;
        private Label label2;
        private Button button1;
        private Button button2;
        private Button button4;
        private Button button3;
        private TextBox textBox1;
        private Label label3;
        private Label label4;
        private Button button5;
        private Label label5;
        private Button button6;
        private Label label8;
        private TextBox textBox4;
    }
}