namespace Finger_Tapping_Test
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
            this.btnDodaj = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lPanel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnDodaj
            // 
            this.btnDodaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDodaj.Location = new System.Drawing.Point(47, 39);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(102, 42);
            this.btnDodaj.TabIndex = 0;
            this.btnDodaj.Text = "Dodaj nowego pacjenta";
            this.btnDodaj.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(244, 39);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 42);
            this.button2.TabIndex = 1;
            this.button2.Text = "Wybierz pacjenta z listy";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // lPanel
            // 
            this.lPanel.AutoSize = true;
            this.lPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lPanel.Location = new System.Drawing.Point(119, 9);
            this.lPanel.Name = "lPanel";
            this.lPanel.Size = new System.Drawing.Size(161, 20);
            this.lPanel.TabIndex = 2;
            this.lPanel.Text = "PANEL PACJENTA";
            this.lPanel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 285);
            this.Controls.Add(this.lPanel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnDodaj);
            this.Name = "Form1";
            this.Text = "Panel pacjenta";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lPanel;
    }
}

