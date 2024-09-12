namespace tugas_it_sofware.views
{
    partial class ItemsAdmin
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
            this.BoxName = new System.Windows.Forms.TextBox();
            this.BoxPrice = new System.Windows.Forms.TextBox();
            this.BoxCompensation = new System.Windows.Forms.TextBox();
            this.DataItems = new System.Windows.Forms.DataGridView();
            this.Insert = new System.Windows.Forms.Button();
            this.Update = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.Cencel = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataItems)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Request Price";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Compensation Free";
            // 
            // BoxName
            // 
            this.BoxName.Location = new System.Drawing.Point(260, 29);
            this.BoxName.Name = "BoxName";
            this.BoxName.Size = new System.Drawing.Size(526, 26);
            this.BoxName.TabIndex = 3;
            // 
            // BoxPrice
            // 
            this.BoxPrice.Location = new System.Drawing.Point(260, 74);
            this.BoxPrice.Name = "BoxPrice";
            this.BoxPrice.Size = new System.Drawing.Size(526, 26);
            this.BoxPrice.TabIndex = 4;
            // 
            // BoxCompensation
            // 
            this.BoxCompensation.Location = new System.Drawing.Point(260, 114);
            this.BoxCompensation.Name = "BoxCompensation";
            this.BoxCompensation.Size = new System.Drawing.Size(526, 26);
            this.BoxCompensation.TabIndex = 5;
            // 
            // DataItems
            // 
            this.DataItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataItems.Location = new System.Drawing.Point(12, 220);
            this.DataItems.Name = "DataItems";
            this.DataItems.RowHeadersWidth = 62;
            this.DataItems.RowTemplate.Height = 28;
            this.DataItems.Size = new System.Drawing.Size(774, 300);
            this.DataItems.TabIndex = 6;
            this.DataItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataItems_CellContentClick);
            // 
            // Insert
            // 
            this.Insert.Location = new System.Drawing.Point(12, 547);
            this.Insert.Name = "Insert";
            this.Insert.Size = new System.Drawing.Size(145, 35);
            this.Insert.TabIndex = 7;
            this.Insert.Text = "Insert";
            this.Insert.UseVisualStyleBackColor = true;
            this.Insert.Click += new System.EventHandler(this.Insert_Click);
            // 
            // Update
            // 
            this.Update.Location = new System.Drawing.Point(163, 547);
            this.Update.Name = "Update";
            this.Update.Size = new System.Drawing.Size(145, 35);
            this.Update.TabIndex = 8;
            this.Update.Text = "Update";
            this.Update.UseVisualStyleBackColor = true;
            this.Update.Click += new System.EventHandler(this.Update_Click);
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(314, 547);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(145, 35);
            this.Delete.TabIndex = 9;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Cencel
            // 
            this.Cencel.Location = new System.Drawing.Point(641, 547);
            this.Cencel.Name = "Cencel";
            this.Cencel.Size = new System.Drawing.Size(145, 35);
            this.Cencel.TabIndex = 10;
            this.Cencel.Text = "Cencel";
            this.Cencel.UseVisualStyleBackColor = true;
            this.Cencel.Visible = false;
            this.Cencel.Click += new System.EventHandler(this.Cencel_Click);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(484, 547);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(145, 35);
            this.Save.TabIndex = 11;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Visible = false;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // ItemsAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 594);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Cencel);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Update);
            this.Controls.Add(this.Insert);
            this.Controls.Add(this.DataItems);
            this.Controls.Add(this.BoxCompensation);
            this.Controls.Add(this.BoxPrice);
            this.Controls.Add(this.BoxName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ItemsAdmin";
            this.Text = "ItemsAdmin";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ItemsAdmin_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.DataItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox BoxName;
        private System.Windows.Forms.TextBox BoxPrice;
        private System.Windows.Forms.TextBox BoxCompensation;
        private System.Windows.Forms.DataGridView DataItems;
        private System.Windows.Forms.Button Insert;
        private System.Windows.Forms.Button Update;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button Cencel;
        private System.Windows.Forms.Button Save;
    }
}