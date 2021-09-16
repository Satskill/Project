
namespace AcikArttirmaProje
{
    partial class Adresim
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
            this.btnkyt = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtadrs = new System.Windows.Forms.TextBox();
            this.txtad = new System.Windows.Forms.TextBox();
            this.cmbshr = new System.Windows.Forms.ComboBox();
            this.cmbadrslrm = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnkyt
            // 
            this.btnkyt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnkyt.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnkyt.Image = global::AcikArttirmaProje.Properties.Resources.icons8_location_32px_1;
            this.btnkyt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnkyt.Location = new System.Drawing.Point(87, 478);
            this.btnkyt.Name = "btnkyt";
            this.btnkyt.Size = new System.Drawing.Size(130, 40);
            this.btnkyt.TabIndex = 12;
            this.btnkyt.Text = "KAYDET";
            this.btnkyt.UseVisualStyleBackColor = true;
            this.btnkyt.Click += new System.EventHandler(this.btnkyt_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(61, 332);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Şehir";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(61, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Açık Adres";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(61, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Adres Adı";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(61, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Adreslerim";
            // 
            // txtadrs
            // 
            this.txtadrs.Location = new System.Drawing.Point(54, 233);
            this.txtadrs.Multiline = true;
            this.txtadrs.Name = "txtadrs";
            this.txtadrs.Size = new System.Drawing.Size(181, 69);
            this.txtadrs.TabIndex = 6;
            // 
            // txtad
            // 
            this.txtad.Location = new System.Drawing.Point(54, 163);
            this.txtad.Name = "txtad";
            this.txtad.Size = new System.Drawing.Size(181, 20);
            this.txtad.TabIndex = 7;
            // 
            // cmbshr
            // 
            this.cmbshr.FormattingEnabled = true;
            this.cmbshr.Location = new System.Drawing.Point(54, 348);
            this.cmbshr.Name = "cmbshr";
            this.cmbshr.Size = new System.Drawing.Size(181, 21);
            this.cmbshr.TabIndex = 4;
            // 
            // cmbadrslrm
            // 
            this.cmbadrslrm.FormattingEnabled = true;
            this.cmbadrslrm.Location = new System.Drawing.Point(54, 82);
            this.cmbadrslrm.Name = "cmbadrslrm";
            this.cmbadrslrm.Size = new System.Drawing.Size(181, 21);
            this.cmbadrslrm.TabIndex = 5;
            this.cmbadrslrm.SelectedIndexChanged += new System.EventHandler(this.cmbadrslrm_SelectedIndexChanged);
            // 
            // Adresim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 550);
            this.Controls.Add(this.btnkyt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtadrs);
            this.Controls.Add(this.txtad);
            this.Controls.Add(this.cmbshr);
            this.Controls.Add(this.cmbadrslrm);
            this.Name = "Adresim";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Adresim_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnkyt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtadrs;
        private System.Windows.Forms.TextBox txtad;
        private System.Windows.Forms.ComboBox cmbshr;
        private System.Windows.Forms.ComboBox cmbadrslrm;
    }
}