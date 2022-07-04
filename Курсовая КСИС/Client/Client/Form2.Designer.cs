namespace Client
{
    partial class Form2
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbN1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbP = new System.Windows.Forms.TextBox();
            this.tbKs = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbFi = new System.Windows.Forms.TextBox();
            this.tbQ = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbKo = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.tbN1);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.tbP);
            this.groupBox3.Controls.Add(this.tbKs);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.tbFi);
            this.groupBox3.Controls.Add(this.tbQ);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.tbKo);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(401, 78);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Генерация ключей";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(109, 52);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(27, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = " φ =";
            // 
            // tbN1
            // 
            this.tbN1.Location = new System.Drawing.Point(151, 22);
            this.tbN1.Name = "tbN1";
            this.tbN1.ReadOnly = true;
            this.tbN1.Size = new System.Drawing.Size(94, 20);
            this.tbN1.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(114, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "n =";
            // 
            // tbP
            // 
            this.tbP.Location = new System.Drawing.Point(40, 22);
            this.tbP.Name = "tbP";
            this.tbP.Size = new System.Drawing.Size(52, 20);
            this.tbP.TabIndex = 0;
            this.tbP.Leave += new System.EventHandler(this.tbP_Leave);
            // 
            // tbKs
            // 
            this.tbKs.Location = new System.Drawing.Point(309, 22);
            this.tbKs.Name = "tbKs";
            this.tbKs.Size = new System.Drawing.Size(81, 20);
            this.tbKs.TabIndex = 6;
            this.tbKs.Leave += new System.EventHandler(this.tbKs_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(267, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Kc =";
            // 
            // tbFi
            // 
            this.tbFi.Location = new System.Drawing.Point(151, 49);
            this.tbFi.Name = "tbFi";
            this.tbFi.ReadOnly = true;
            this.tbFi.Size = new System.Drawing.Size(94, 20);
            this.tbFi.TabIndex = 5;
            // 
            // tbQ
            // 
            this.tbQ.Location = new System.Drawing.Point(40, 49);
            this.tbQ.Name = "tbQ";
            this.tbQ.Size = new System.Drawing.Size(52, 20);
            this.tbQ.TabIndex = 1;
            this.tbQ.Leave += new System.EventHandler(this.tbQ_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(266, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Ko =";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "q =";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "p = ";
            // 
            // tbKo
            // 
            this.tbKo.Location = new System.Drawing.Point(308, 48);
            this.tbKo.Name = "tbKo";
            this.tbKo.ReadOnly = true;
            this.tbKo.Size = new System.Drawing.Size(82, 20);
            this.tbKo.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(163, 96);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "Применить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 124);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Name = "Form2";
            this.Text = "Генерация ключей";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbN1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbP;
        private System.Windows.Forms.TextBox tbKs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbFi;
        private System.Windows.Forms.TextBox tbQ;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbKo;
        private System.Windows.Forms.Button button1;
    }
}