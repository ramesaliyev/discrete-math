namespace HW_04_Project_Graph_Coloring_GUI
{
    partial class MainForm
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
            this.canvas = new System.Windows.Forms.Panel();
            this.textBoxDataPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonReloadAndCalculate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxIndexFile = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.canvas.Location = new System.Drawing.Point(0, 0);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(560, 560);
            this.canvas.TabIndex = 0;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
            // 
            // textBoxDataPath
            // 
            this.textBoxDataPath.Location = new System.Drawing.Point(566, 25);
            this.textBoxDataPath.Name = "textBoxDataPath";
            this.textBoxDataPath.Size = new System.Drawing.Size(313, 20);
            this.textBoxDataPath.TabIndex = 1;
            this.textBoxDataPath.Text = "C:\\Personal\\DiscreteProjectData\\Set1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(563, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Path of Data Files";
            // 
            // buttonReloadAndCalculate
            // 
            this.buttonReloadAndCalculate.Location = new System.Drawing.Point(566, 57);
            this.buttonReloadAndCalculate.Margin = new System.Windows.Forms.Padding(0);
            this.buttonReloadAndCalculate.Name = "buttonReloadAndCalculate";
            this.buttonReloadAndCalculate.Size = new System.Drawing.Size(430, 36);
            this.buttonReloadAndCalculate.TabIndex = 3;
            this.buttonReloadAndCalculate.Text = "Load Data and Calculate";
            this.buttonReloadAndCalculate.UseVisualStyleBackColor = true;
            this.buttonReloadAndCalculate.Click += new System.EventHandler(this.buttonReloadAndCalculate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(882, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Lecture Index File";
            // 
            // textBoxIndexFile
            // 
            this.textBoxIndexFile.Location = new System.Drawing.Point(885, 25);
            this.textBoxIndexFile.Name = "textBoxIndexFile";
            this.textBoxIndexFile.Size = new System.Drawing.Size(111, 20);
            this.textBoxIndexFile.TabIndex = 4;
            this.textBoxIndexFile.Text = "Dersler";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1008, 561);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxIndexFile);
            this.Controls.Add(this.buttonReloadAndCalculate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxDataPath);
            this.Controls.Add(this.canvas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Least Exam Sessions Calculator, YTU, 18011708";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel canvas;
        private System.Windows.Forms.TextBox textBoxDataPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonReloadAndCalculate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxIndexFile;
    }
}

