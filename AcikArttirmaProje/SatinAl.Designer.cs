
namespace AcikArttirmaProje
{
    partial class SatinAl
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblad = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbldgr = new System.Windows.Forms.Label();
            this.btndgr = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.nudesydgr = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudesydgr)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Eşya Adı";
            // 
            // lblad
            // 
            this.lblad.AutoSize = true;
            this.lblad.Location = new System.Drawing.Point(119, 29);
            this.lblad.Name = "lblad";
            this.lblad.Size = new System.Drawing.Size(35, 13);
            this.lblad.TabIndex = 0;
            this.lblad.Text = "label1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Eşya Değeri";
            // 
            // lbldgr
            // 
            this.lbldgr.AutoSize = true;
            this.lbldgr.Location = new System.Drawing.Point(194, 168);
            this.lbldgr.Name = "lbldgr";
            this.lbldgr.Size = new System.Drawing.Size(35, 13);
            this.lbldgr.TabIndex = 0;
            this.lbldgr.Text = "label1";
            // 
            // btndgr
            // 
            this.btndgr.Location = new System.Drawing.Point(47, 107);
            this.btndgr.Name = "btndgr";
            this.btndgr.Size = new System.Drawing.Size(170, 31);
            this.btndgr.TabIndex = 1;
            this.btndgr.Text = "DEĞER VER";
            this.btndgr.UseVisualStyleBackColor = true;
            this.btndgr.Click += new System.EventHandler(this.btndgr_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // nudesydgr
            // 
            this.nudesydgr.Location = new System.Drawing.Point(109, 50);
            this.nudesydgr.Name = "nudesydgr";
            this.nudesydgr.Size = new System.Drawing.Size(120, 20);
            this.nudesydgr.TabIndex = 2;
            // 
            // SatinAl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 179);
            this.Controls.Add(this.nudesydgr);
            this.Controls.Add(this.btndgr);
            this.Controls.Add(this.lbldgr);
            this.Controls.Add(this.lblad);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "SatinAl";
            this.Text = "SatinAl";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SatinAl_FormClosed);
            this.Load += new System.EventHandler(this.SatinAl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudesydgr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbldgr;
        private System.Windows.Forms.Button btndgr;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NumericUpDown nudesydgr;
    }
}