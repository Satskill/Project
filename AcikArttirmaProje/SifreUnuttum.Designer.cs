
namespace AcikArttirmaProje
{
    partial class SifreUnuttum
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
            this.txteml = new System.Windows.Forms.TextBox();
            this.btnynl = new System.Windows.Forms.Button();
            this.txtynsfr = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txteml
            // 
            this.txteml.Location = new System.Drawing.Point(62, 67);
            this.txteml.Name = "txteml";
            this.txteml.Size = new System.Drawing.Size(184, 20);
            this.txteml.TabIndex = 0;
            // 
            // btnynl
            // 
            this.btnynl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(36)))), ((int)(((byte)(81)))));
            this.btnynl.FlatAppearance.BorderSize = 0;
            this.btnynl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnynl.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnynl.ForeColor = System.Drawing.Color.White;
            this.btnynl.Location = new System.Drawing.Point(103, 194);
            this.btnynl.Name = "btnynl";
            this.btnynl.Size = new System.Drawing.Size(97, 33);
            this.btnynl.TabIndex = 1;
            this.btnynl.Text = "YENİLE";
            this.btnynl.UseVisualStyleBackColor = false;
            this.btnynl.Click += new System.EventHandler(this.btnynl_Click);
            // 
            // txtynsfr
            // 
            this.txtynsfr.Location = new System.Drawing.Point(62, 135);
            this.txtynsfr.Name = "txtynsfr";
            this.txtynsfr.Size = new System.Drawing.Size(184, 20);
            this.txtynsfr.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(59, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "E-Mail";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(59, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Yeni Şifre";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = global::AcikArttirmaProje.Properties.Resources.icons8_delete_32px_1;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(157)))), ((int)(((byte)(157)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(288, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(27, 26);
            this.button1.TabIndex = 8;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SifreUnuttum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(150)))));
            this.ClientSize = new System.Drawing.Size(315, 239);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnynl);
            this.Controls.Add(this.txtynsfr);
            this.Controls.Add(this.txteml);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SifreUnuttum";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Şifremi Yenileme";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SifreUnuttum_FormClosed);
            this.Load += new System.EventHandler(this.SifreUnuttum_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txteml;
        private System.Windows.Forms.Button btnynl;
        private System.Windows.Forms.TextBox txtynsfr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}