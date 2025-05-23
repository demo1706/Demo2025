namespace Demo2025
{
    partial class FormPartner
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            comboBox1 = new ComboBox();
            maskedTextBox1 = new MaskedTextBox();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(103, 186, 128);
            label1.Location = new Point(121, 26);
            label1.Name = "label1";
            label1.Size = new Size(219, 25);
            label1.TabIndex = 0;
            label1.Text = "Добавление партнера";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(51, 66);
            label2.Name = "label2";
            label2.Size = new Size(90, 15);
            label2.TabIndex = 1;
            label2.Text = "Наименование";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(51, 104);
            label3.Name = "label3";
            label3.Size = new Size(28, 15);
            label3.TabIndex = 2;
            label3.Text = "Тип";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(51, 145);
            label4.Name = "label4";
            label4.Size = new Size(51, 15);
            label4.TabIndex = 3;
            label4.Text = "Рейтинг";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(51, 190);
            label5.Name = "label5";
            label5.Size = new Size(40, 15);
            label5.TabIndex = 4;
            label5.Text = "Адрес";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(51, 235);
            label6.Name = "label6";
            label6.Size = new Size(94, 15);
            label6.TabIndex = 5;
            label6.Text = "ФИО директора";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(51, 273);
            label7.Name = "label7";
            label7.Size = new Size(56, 15);
            label7.TabIndex = 6;
            label7.Text = "Телефон";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(51, 318);
            label8.Name = "label8";
            label8.Size = new Size(113, 15);
            label8.TabIndex = 7;
            label8.Text = "Электронная почта";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(172, 66);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(246, 23);
            textBox1.TabIndex = 8;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(172, 142);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(246, 23);
            textBox2.TabIndex = 9;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(172, 190);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(246, 23);
            textBox3.TabIndex = 10;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(172, 232);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(246, 23);
            textBox4.TabIndex = 11;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(172, 318);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(246, 23);
            textBox5.TabIndex = 12;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(172, 104);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(246, 23);
            comboBox1.TabIndex = 13;
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.Location = new Point(172, 273);
            maskedTextBox1.Mask = "+7 000 000 00 00";
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.Size = new Size(246, 23);
            maskedTextBox1.TabIndex = 14;
            // 
            // button1
            // 
            button1.Location = new Point(144, 375);
            button1.Name = "button1";
            button1.Size = new Size(134, 23);
            button1.TabIndex = 15;
            button1.Text = "Добавить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            button1.MouseEnter += button1_MouseEnter;
            button1.MouseLeave += button1_MouseLeave;
            // 
            // button2
            // 
            button2.Location = new Point(4, 2);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 16;
            button2.Text = "Назад";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // FormPartner
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(maskedTextBox1);
            Controls.Add(comboBox1);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormPartner";
            Text = "FormPartner";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private ComboBox comboBox1;
        private MaskedTextBox maskedTextBox1;
        private Button button1;
        private Button button2;
    }
}