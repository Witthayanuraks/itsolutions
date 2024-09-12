namespace tugas_it_sofware.views
{
    partial class FoodAndDrinkAdmin
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BoxName = new System.Windows.Forms.TextBox();
            this.BoxPrince = new System.Windows.Forms.TextBox();
            this.BoxType = new System.Windows.Forms.ComboBox();
            this.Browse = new System.Windows.Forms.Button();
            this.Insert = new System.Windows.Forms.Button();
            this.DataFD = new System.Windows.Forms.DataGridView();
            this.Update = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.Cencel = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.BoxPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DataFD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoxPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Price";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Photo";
            // 
            // BoxName
            // 
            this.BoxName.Location = new System.Drawing.Point(179, 29);
            this.BoxName.Name = "BoxName";
            this.BoxName.Size = new System.Drawing.Size(565, 26);
            this.BoxName.TabIndex = 4;
            // 
            // BoxPrince
            // 
            this.BoxPrince.Location = new System.Drawing.Point(179, 114);
            this.BoxPrince.Name = "BoxPrince";
            this.BoxPrince.Size = new System.Drawing.Size(565, 26);
            this.BoxPrince.TabIndex = 5;
            // 
            // BoxType
            // 
            this.BoxType.FormattingEnabled = true;
            this.BoxType.Location = new System.Drawing.Point(179, 76);
            this.BoxType.Name = "BoxType";
            this.BoxType.Size = new System.Drawing.Size(565, 28);
            this.BoxType.TabIndex = 6;
            // 
            // Browse
            // 
            this.Browse.Location = new System.Drawing.Point(54, 204);
            this.Browse.Name = "Browse";
            this.Browse.Size = new System.Drawing.Size(127, 35);
            this.Browse.TabIndex = 8;
            this.Browse.Text = "Browse";
            this.Browse.UseVisualStyleBackColor = true;
            this.Browse.Click += new System.EventHandler(this.Browse_Click);
            // 
            // Insert
            // 
            this.Insert.Location = new System.Drawing.Point(12, 547);
            this.Insert.Name = "Insert";
            this.Insert.Size = new System.Drawing.Size(145, 35);
            this.Insert.TabIndex = 9;
            this.Insert.Text = "Insert";
            this.Insert.UseVisualStyleBackColor = true;
            this.Insert.Click += new System.EventHandler(this.Insert_Click);
            // 
            // DataFD
            // 
            this.DataFD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataFD.Location = new System.Drawing.Point(13, 321);
            this.DataFD.Name = "DataFD";
            this.DataFD.RowHeadersWidth = 62;
            this.DataFD.RowTemplate.Height = 28;
            this.DataFD.Size = new System.Drawing.Size(773, 220);
            this.DataFD.TabIndex = 10;
            this.DataFD.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataFD_CellContentClick);
            // 
            // Update
            // 
            this.Update.Location = new System.Drawing.Point(163, 547);
            this.Update.Name = "Update";
            this.Update.Size = new System.Drawing.Size(145, 35);
            this.Update.TabIndex = 11;
            this.Update.Text = "Update";
            this.Update.UseVisualStyleBackColor = true;
            this.Update.Click += new System.EventHandler(this.Update_Click);
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(314, 547);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(145, 35);
            this.Delete.TabIndex = 12;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Cencel
            // 
            this.Cencel.Location = new System.Drawing.Point(641, 547);
            this.Cencel.Name = "Cencel";
            this.Cencel.Size = new System.Drawing.Size(145, 35);
            this.Cencel.TabIndex = 13;
            this.Cencel.Text = "Cencel";
            this.Cencel.UseVisualStyleBackColor = true;
            this.Cencel.Visible = false;
            this.Cencel.Click += new System.EventHandler(this.Cencel_Click);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(490, 547);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(145, 35);
            this.Save.TabIndex = 14;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Visible = false;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // BoxPicture
            // 
            this.BoxPicture.Location = new System.Drawing.Point(279, 155);
            this.BoxPicture.Name = "BoxPicture";
            this.BoxPicture.Size = new System.Drawing.Size(250, 150);
            this.BoxPicture.TabIndex = 15;
            this.BoxPicture.TabStop = false;
            // 
            // FoodAndDrinkAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 594);
            this.Controls.Add(this.BoxPicture);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Cencel);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Update);
            this.Controls.Add(this.DataFD);
            this.Controls.Add(this.Insert);
            this.Controls.Add(this.Browse);
            this.Controls.Add(this.BoxType);
            this.Controls.Add(this.BoxPrince);
            this.Controls.Add(this.BoxName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FoodAndDrinkAdmin";
            this.Text = "FoodAndDrinkAdmin";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FoodAndDrinkAdmin_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.DataFD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoxPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox BoxName;
        private System.Windows.Forms.TextBox BoxPrince;
        private System.Windows.Forms.ComboBox BoxType;
        private System.Windows.Forms.Button Browse;
        private System.Windows.Forms.Button Insert;
        private System.Windows.Forms.DataGridView DataFD;
        private System.Windows.Forms.Button Update;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button Cencel;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.PictureBox BoxPicture;
    }
}