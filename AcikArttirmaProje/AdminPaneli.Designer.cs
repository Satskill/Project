
namespace AcikArttirmaProje
{
    partial class AdminPaneli
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnesylr = new System.Windows.Forms.Button();
            this.btnkslr = new System.Windows.Forms.Button();
            this.btnSatistakiler = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(36)))), ((int)(((byte)(81)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(12, 218);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(860, 320);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // btnesylr
            // 
            this.btnesylr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(36)))), ((int)(((byte)(81)))));
            this.btnesylr.FlatAppearance.BorderSize = 0;
            this.btnesylr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnesylr.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnesylr.ForeColor = System.Drawing.Color.White;
            this.btnesylr.Image = global::AcikArttirmaProje.Properties.Resources.icons8_product_64px;
            this.btnesylr.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnesylr.Location = new System.Drawing.Point(382, 43);
            this.btnesylr.Name = "btnesylr";
            this.btnesylr.Size = new System.Drawing.Size(150, 100);
            this.btnesylr.TabIndex = 2;
            this.btnesylr.Text = "EŞYALAR";
            this.btnesylr.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnesylr.UseVisualStyleBackColor = false;
            this.btnesylr.Click += new System.EventHandler(this.btnesylr_Click);
            this.btnesylr.MouseLeave += new System.EventHandler(this.btnesylr_MouseLeave);
            this.btnesylr.MouseHover += new System.EventHandler(this.btnesylr_MouseHover);
            // 
            // btnkslr
            // 
            this.btnkslr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(36)))), ((int)(((byte)(81)))));
            this.btnkslr.FlatAppearance.BorderSize = 0;
            this.btnkslr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnkslr.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnkslr.ForeColor = System.Drawing.Color.White;
            this.btnkslr.Image = global::AcikArttirmaProje.Properties.Resources.icons8_user_64px_1;
            this.btnkslr.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnkslr.Location = new System.Drawing.Point(167, 43);
            this.btnkslr.Name = "btnkslr";
            this.btnkslr.Size = new System.Drawing.Size(150, 100);
            this.btnkslr.TabIndex = 3;
            this.btnkslr.Text = "KİŞİLER";
            this.btnkslr.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnkslr.UseVisualStyleBackColor = false;
            this.btnkslr.Click += new System.EventHandler(this.btnkslr_Click);
            this.btnkslr.MouseLeave += new System.EventHandler(this.btnkslr_MouseLeave);
            this.btnkslr.MouseHover += new System.EventHandler(this.btnkslr_MouseHover);
            // 
            // btnSatistakiler
            // 
            this.btnSatistakiler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(36)))), ((int)(((byte)(81)))));
            this.btnSatistakiler.FlatAppearance.BorderSize = 0;
            this.btnSatistakiler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSatistakiler.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSatistakiler.ForeColor = System.Drawing.Color.White;
            this.btnSatistakiler.Image = global::AcikArttirmaProje.Properties.Resources.icons8_product_64px;
            this.btnSatistakiler.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSatistakiler.Location = new System.Drawing.Point(580, 43);
            this.btnSatistakiler.Name = "btnSatistakiler";
            this.btnSatistakiler.Size = new System.Drawing.Size(150, 100);
            this.btnSatistakiler.TabIndex = 2;
            this.btnSatistakiler.Text = "SATIŞTAKİ EŞYALAR";
            this.btnSatistakiler.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSatistakiler.UseVisualStyleBackColor = false;
            this.btnSatistakiler.Click += new System.EventHandler(this.btnSatistakiler_Click);
            this.btnSatistakiler.MouseLeave += new System.EventHandler(this.btnSatistakiler_MouseLeave);
            this.btnSatistakiler.MouseHover += new System.EventHandler(this.btnSatistakiler_MouseHover);
            // 
            // AdminPaneli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 550);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnSatistakiler);
            this.Controls.Add(this.btnesylr);
            this.Controls.Add(this.btnkslr);
            this.Name = "AdminPaneli";
            this.Text = "AdminPaneli";
            this.Load += new System.EventHandler(this.AdminPaneli_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnesylr;
        private System.Windows.Forms.Button btnkslr;
        private System.Windows.Forms.Button btnSatistakiler;
    }
}