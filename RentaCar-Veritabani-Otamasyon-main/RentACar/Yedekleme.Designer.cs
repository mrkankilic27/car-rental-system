﻿namespace RentACar
{
    partial class Yedekleme
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_sunucu_adi = new System.Windows.Forms.TextBox();
            this.txt_veritabani_adi = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sunucu Adı";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Veritabanı Adı";
            // 
            // txt_sunucu_adi
            // 
            this.txt_sunucu_adi.Location = new System.Drawing.Point(165, 40);
            this.txt_sunucu_adi.Name = "txt_sunucu_adi";
            this.txt_sunucu_adi.Size = new System.Drawing.Size(209, 20);
            this.txt_sunucu_adi.TabIndex = 2;
            this.txt_sunucu_adi.Text = "DESKTOP-105P9VT\\\\MSSQLSERVER0";
            // 
            // txt_veritabani_adi
            // 
            this.txt_veritabani_adi.Location = new System.Drawing.Point(165, 107);
            this.txt_veritabani_adi.Name = "txt_veritabani_adi";
            this.txt_veritabani_adi.Size = new System.Drawing.Size(100, 20);
            this.txt_veritabani_adi.TabIndex = 3;
            this.txt_veritabani_adi.Text = "arackiralama";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(165, 157);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Yedekle";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Yedekleme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_veritabani_adi);
            this.Controls.Add(this.txt_sunucu_adi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Yedekleme";
            this.Text = "Yedekleme";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_sunucu_adi;
        private System.Windows.Forms.TextBox txt_veritabani_adi;
        private System.Windows.Forms.Button button1;
    }
}