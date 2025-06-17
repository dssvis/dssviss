namespace Ekzamen
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
            numericUpDown1 = new NumericUpDown();
            label1 = new Label();
            button1 = new Button();
            label2 = new Label();
            label3 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(147, 52);
            numericUpDown1.Minimum = 2;
            numericUpDown1.Maximum = 10;
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(35, 23);
            numericUpDown1.TabIndex = 0;
            numericUpDown1.Value = new decimal(new int[] { 8, 0, 0, 0 });
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Verdana", 9F);
            label1.Location = new Point(48, 54);
            label1.Name = "label1";
            label1.Size = new Size(93, 14);
            label1.TabIndex = 1;
            label1.Text = "Число дисков";
            // 
            // button1
            // 
            button1.Location = new Point(241, 50);
            button1.Name = "button1";
            button1.Size = new Size(80, 23);
            button1.TabIndex = 2;
            button1.Text = "Сброс";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Verdana", 9F);
            label2.Location = new Point(415, 52);
            label2.Name = "label2";
            label2.Size = new Size(177, 14);
            label2.TabIndex = 3;
            label2.Text = "Число сделанных ходов: 0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Verdana", 9F);
            label3.Location = new Point(717, 52);
            label3.Name = "label3";
            label3.Size = new Size(195, 14);
            label3.TabIndex = 4;
            label3.Text = "Минимальное число ходов: 0";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.ForeColor = Color.Coral;
            panel1.Location = new Point(37, 112);
            panel1.Name = "panel1";
            panel1.Size = new Size(284, 499);
            panel1.TabIndex = 5;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Location = new Point(352, 112);
            panel2.Name = "panel2";
            panel2.Size = new Size(284, 499);
            panel2.TabIndex = 6;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Location = new Point(671, 112);
            panel3.Name = "panel3";
            panel3.Size = new Size(284, 499);
            panel3.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 761);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(numericUpDown1);
            Name = "Form1";
            Text = "Ханойские башни";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown numericUpDown1;
        private Label label1;
        private Button button1;
        private Label label2;
        private Label label3;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
    }
}
