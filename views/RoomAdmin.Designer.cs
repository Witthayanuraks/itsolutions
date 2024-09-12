namespace tugas_it_sofware.views
{
    partial class RoomAdmin
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
            this.BoxNumber = new System.Windows.Forms.TextBox();
            this.BoxFloor = new System.Windows.Forms.TextBox();
            this.BoxDescription = new System.Windows.Forms.RichTextBox();
            this.BoxType = new System.Windows.Forms.ComboBox();
            this.DataRoom = new System.Windows.Forms.DataGridView();
            this.BtnInsert = new System.Windows.Forms.Button();
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnCencel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataRoom)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Room Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Room Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 91);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Room Floor";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 123);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Description";
            // 
            // BoxNumber
            // 
            this.BoxNumber.Location = new System.Drawing.Point(176, 25);
            this.BoxNumber.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BoxNumber.Name = "BoxNumber";
            this.BoxNumber.Size = new System.Drawing.Size(284, 20);
            this.BoxNumber.TabIndex = 4;
            // 
            // BoxFloor
            // 
            this.BoxFloor.Location = new System.Drawing.Point(176, 87);
            this.BoxFloor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BoxFloor.Name = "BoxFloor";
            this.BoxFloor.Size = new System.Drawing.Size(284, 20);
            this.BoxFloor.TabIndex = 5;
            // 
            // BoxDescription
            // 
            this.BoxDescription.Location = new System.Drawing.Point(176, 122);
            this.BoxDescription.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BoxDescription.Name = "BoxDescription";
            this.BoxDescription.Size = new System.Drawing.Size(284, 71);
            this.BoxDescription.TabIndex = 7;
            this.BoxDescription.Text = "";
            // 
            // BoxType
            // 
            this.BoxType.FormattingEnabled = true;
            this.BoxType.Location = new System.Drawing.Point(176, 53);
            this.BoxType.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BoxType.Name = "BoxType";
            this.BoxType.Size = new System.Drawing.Size(284, 21);
            this.BoxType.TabIndex = 8;
            // 
            // DataRoom
            // 
            this.DataRoom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataRoom.Location = new System.Drawing.Point(8, 238);
            this.DataRoom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DataRoom.Name = "DataRoom";
            this.DataRoom.RowHeadersWidth = 62;
            this.DataRoom.RowTemplate.Height = 28;
            this.DataRoom.Size = new System.Drawing.Size(516, 162);
            this.DataRoom.TabIndex = 9;
            this.DataRoom.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataRoom_CellContentClick);
            // 
            // BtnInsert
            // 
            this.BtnInsert.Location = new System.Drawing.Point(9, 429);
            this.BtnInsert.Name = "BtnInsert";
            this.BtnInsert.Size = new System.Drawing.Size(75, 23);
            this.BtnInsert.TabIndex = 10;
            this.BtnInsert.Text = "Insert";
            this.BtnInsert.UseVisualStyleBackColor = true;
            this.BtnInsert.Click += new System.EventHandler(this.BtnInsert_Click);
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.Location = new System.Drawing.Point(105, 429);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(75, 23);
            this.BtnUpdate.TabIndex = 11;
            this.BtnUpdate.Text = "Update";
            this.BtnUpdate.UseVisualStyleBackColor = true;
            this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.Location = new System.Drawing.Point(207, 429);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(75, 23);
            this.BtnDelete.TabIndex = 12;
            this.BtnDelete.Text = "Delete";
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(349, 429);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 13;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Visible = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnCencel
            // 
            this.BtnCencel.Location = new System.Drawing.Point(449, 429);
            this.BtnCencel.Name = "BtnCencel";
            this.BtnCencel.Size = new System.Drawing.Size(75, 23);
            this.BtnCencel.TabIndex = 14;
            this.BtnCencel.Text = "Cencel";
            this.BtnCencel.UseVisualStyleBackColor = true;
            this.BtnCencel.Visible = false;
            this.BtnCencel.Click += new System.EventHandler(this.BtnCencel_Click);
            // 
            // RoomAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 456);
            this.Controls.Add(this.BtnCencel);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.BtnUpdate);
            this.Controls.Add(this.BtnInsert);
            this.Controls.Add(this.DataRoom);
            this.Controls.Add(this.BoxType);
            this.Controls.Add(this.BoxDescription);
            this.Controls.Add(this.BoxFloor);
            this.Controls.Add(this.BoxNumber);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "RoomAdmin";
            this.Text = "RoomAdmin";
            ((System.ComponentModel.ISupportInitialize)(this.DataRoom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox BoxNumber;
        private System.Windows.Forms.TextBox BoxFloor;
        private System.Windows.Forms.RichTextBox BoxDescription;
        private System.Windows.Forms.ComboBox BoxType;
        private System.Windows.Forms.DataGridView DataRoom;
        private System.Windows.Forms.Button BtnInsert;
        private System.Windows.Forms.Button BtnUpdate;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnCencel;
    }
}