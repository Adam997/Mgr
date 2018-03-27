namespace Finger_Tapping_Test
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
            this.components = new System.ComponentModel.Container();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnTime = new System.Windows.Forms.Button();
            this.lbTime = new System.Windows.Forms.Label();
            this.lbDescription = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(128, 55);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(120, 32);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnTime
            // 
            this.btnTime.Location = new System.Drawing.Point(128, 120);
            this.btnTime.Name = "btnTime";
            this.btnTime.Size = new System.Drawing.Size(120, 33);
            this.btnTime.TabIndex = 1;
            this.btnTime.Text = "Oblicz czas badania";
            this.btnTime.UseVisualStyleBackColor = true;
            this.btnTime.Click += new System.EventHandler(this.btnTime_Click);
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Location = new System.Drawing.Point(134, 200);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(35, 13);
            this.lbTime.TabIndex = 2;
            this.lbTime.Text = "label1";
            // 
            // lbDescription
            // 
            this.lbDescription.AutoSize = true;
            this.lbDescription.Location = new System.Drawing.Point(134, 233);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(35, 13);
            this.lbDescription.TabIndex = 3;
            this.lbDescription.Text = "label2";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 331);
            this.Controls.Add(this.lbDescription);
            this.Controls.Add(this.lbTime);
            this.Controls.Add(this.btnTime);
            this.Controls.Add(this.btnStart);
            this.Name = "Form2";
            this.Text = "Finger Tapping Test";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnTime;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.Label lbDescription;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Timer timer1;
    }
}