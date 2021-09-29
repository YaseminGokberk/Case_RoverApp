
namespace RoverApp
{
    partial class Main
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
            this.gBoxPlateau = new System.Windows.Forms.GroupBox();
            this.pnlPlateau = new System.Windows.Forms.Panel();
            this.gBoxCommandLine = new System.Windows.Forms.GroupBox();
            this.txtCommandLine = new System.Windows.Forms.TextBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.gBoxOutput = new System.Windows.Forms.GroupBox();
            this.gBoxPlateau.SuspendLayout();
            this.gBoxCommandLine.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gBoxOutput.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBoxPlateau
            // 
            this.gBoxPlateau.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gBoxPlateau.Controls.Add(this.pnlPlateau);
            this.gBoxPlateau.Location = new System.Drawing.Point(12, 12);
            this.gBoxPlateau.Name = "gBoxPlateau";
            this.gBoxPlateau.Size = new System.Drawing.Size(620, 341);
            this.gBoxPlateau.TabIndex = 0;
            this.gBoxPlateau.TabStop = false;
            this.gBoxPlateau.Text = "Plateau";
            // 
            // pnlPlateau
            // 
            this.pnlPlateau.AutoScroll = true;
            this.pnlPlateau.BackColor = System.Drawing.Color.Silver;
            this.pnlPlateau.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPlateau.Location = new System.Drawing.Point(3, 19);
            this.pnlPlateau.Name = "pnlPlateau";
            this.pnlPlateau.Size = new System.Drawing.Size(614, 319);
            this.pnlPlateau.TabIndex = 0;
            // 
            // gBoxCommandLine
            // 
            this.gBoxCommandLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gBoxCommandLine.Controls.Add(this.txtCommandLine);
            this.gBoxCommandLine.Location = new System.Drawing.Point(12, 359);
            this.gBoxCommandLine.Name = "gBoxCommandLine";
            this.gBoxCommandLine.Size = new System.Drawing.Size(461, 154);
            this.gBoxCommandLine.TabIndex = 1;
            this.gBoxCommandLine.TabStop = false;
            this.gBoxCommandLine.Text = "Command Line";
            // 
            // txtCommandLine
            // 
            this.txtCommandLine.BackColor = System.Drawing.SystemColors.InfoText;
            this.txtCommandLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCommandLine.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCommandLine.ForeColor = System.Drawing.Color.White;
            this.txtCommandLine.Location = new System.Drawing.Point(3, 19);
            this.txtCommandLine.Multiline = true;
            this.txtCommandLine.Name = "txtCommandLine";
            this.txtCommandLine.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCommandLine.Size = new System.Drawing.Size(455, 132);
            this.txtCommandLine.TabIndex = 0;
            this.txtCommandLine.WordWrap = false;
            // 
            // txtOutput
            // 
            this.txtOutput.BackColor = System.Drawing.SystemColors.InfoText;
            this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOutput.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtOutput.ForeColor = System.Drawing.Color.White;
            this.txtOutput.Location = new System.Drawing.Point(3, 19);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutput.Size = new System.Drawing.Size(455, 111);
            this.txtOutput.TabIndex = 1;
            this.txtOutput.WordWrap = false;
            // 
            // btnRun
            // 
            this.btnRun.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRun.Location = new System.Drawing.Point(9, 1);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(114, 48);
            this.btnRun.TabIndex = 1;
            this.btnRun.Text = "RUN";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(9, 83);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(132, 61);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Please enter the commands in the command line and press run.";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(9, 60);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(31, 15);
            this.lblInfo.TabIndex = 3;
            this.lblInfo.Text = "Info:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnRun);
            this.panel1.Controls.Add(this.lblDescription);
            this.panel1.Controls.Add(this.lblInfo);
            this.panel1.Location = new System.Drawing.Point(479, 365);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 284);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 123);
            this.label1.TabIndex = 5;
            this.label1.Text = "The processing results will be displayed in the output section.";
            // 
            // gBoxOutput
            // 
            this.gBoxOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gBoxOutput.Controls.Add(this.txtOutput);
            this.gBoxOutput.Location = new System.Drawing.Point(12, 516);
            this.gBoxOutput.Name = "gBoxOutput";
            this.gBoxOutput.Size = new System.Drawing.Size(461, 133);
            this.gBoxOutput.TabIndex = 4;
            this.gBoxOutput.TabStop = false;
            this.gBoxOutput.Text = "Output";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 653);
            this.Controls.Add(this.gBoxOutput);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gBoxCommandLine);
            this.Controls.Add(this.gBoxPlateau);
            this.MinimumSize = new System.Drawing.Size(660, 692);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rover GUI";
            this.gBoxPlateau.ResumeLayout(false);
            this.gBoxCommandLine.ResumeLayout(false);
            this.gBoxCommandLine.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gBoxOutput.ResumeLayout(false);
            this.gBoxOutput.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gBoxPlateau;
        private System.Windows.Forms.GroupBox gBoxCommandLine;
        private System.Windows.Forms.TextBox txtCommandLine;
        private System.Windows.Forms.Panel pnlPlateau;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gBoxOutput;
        private System.Windows.Forms.Label label1;
    }
}