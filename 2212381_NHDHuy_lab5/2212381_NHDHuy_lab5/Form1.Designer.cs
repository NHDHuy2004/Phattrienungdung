﻿namespace _2212381_NHDHuy_lab5
{
    partial class Form1
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
            this.btnJSON_Click = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnJSON_Click
            // 
            this.btnJSON_Click.Location = new System.Drawing.Point(343, 325);
            this.btnJSON_Click.Name = "btnJSON_Click";
            this.btnJSON_Click.Size = new System.Drawing.Size(75, 23);
            this.btnJSON_Click.TabIndex = 0;
            this.btnJSON_Click.Text = "button1";
            this.btnJSON_Click.UseVisualStyleBackColor = true;
            this.btnJSON_Click.Click += new System.EventHandler(this.btnJSON_Click_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 584);
            this.Controls.Add(this.btnJSON_Click);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnJSON_Click;
    }
}

