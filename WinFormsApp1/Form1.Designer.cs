namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            Exit = new Button();
            button4 = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            button6 = new Button();
            button7 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(260, 114);
            button1.Name = "button1";
            button1.Size = new Size(242, 29);
            button1.TabIndex = 0;
            button1.Text = "\"Поиск сокровищ\"";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(260, 169);
            button2.Name = "button2";
            button2.Size = new Size(242, 29);
            button2.TabIndex = 1;
            button2.Text = "\"Виселица\"";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(260, 228);
            button3.Name = "button3";
            button3.Size = new Size(242, 29);
            button3.TabIndex = 2;
            button3.Text = "Настроить число сетов";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Exit
            // 
            Exit.Location = new Point(260, 283);
            Exit.Name = "Exit";
            Exit.Size = new Size(242, 29);
            Exit.TabIndex = 3;
            Exit.Text = "Выход";
            Exit.UseVisualStyleBackColor = true;
            Exit.Click += button4_Click;
            // 
            // button4
            // 
            button4.Location = new Point(49, 364);
            button4.Name = "button4";
            button4.Size = new Size(144, 29);
            button4.TabIndex = 4;
            button4.Text = "Отобразить поля";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click_1;
            // 
            // button6
            // 
            button6.Location = new Point(49, 318);
            button6.Name = "button6";
            button6.Size = new Size(144, 29);
            button6.TabIndex = 6;
            button6.Text = "Создать базу";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(49, 409);
            button7.Name = "button7";
            button7.Size = new Size(144, 29);
            button7.TabIndex = 9;
            button7.Text = "Удалить базу";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button4);
            Controls.Add(Exit);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button Exit;
        private Button button4;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button button6;
        private Button button7;
    }
}
