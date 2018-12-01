namespace backend
{
    partial class BackendForm
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
            this.idListBox = new System.Windows.Forms.ListBox();
            this.dateTimeBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.updateOrdersBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // idListBox
            // 
            this.idListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idListBox.FormattingEnabled = true;
            this.idListBox.ItemHeight = 29;
            this.idListBox.Location = new System.Drawing.Point(30, 105);
            this.idListBox.Name = "idListBox";
            this.idListBox.Size = new System.Drawing.Size(187, 236);
            this.idListBox.TabIndex = 9;
            // 
            // dateTimeBox
            // 
            this.dateTimeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeBox.FormattingEnabled = true;
            this.dateTimeBox.ItemHeight = 29;
            this.dateTimeBox.Location = new System.Drawing.Point(239, 105);
            this.dateTimeBox.Name = "dateTimeBox";
            this.dateTimeBox.Size = new System.Drawing.Size(467, 236);
            this.dateTimeBox.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(239, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(467, 52);
            this.label1.TabIndex = 11;
            this.label1.Text = "product name - time ordered";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // updateOrdersBtn
            // 
            this.updateOrdersBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateOrdersBtn.Location = new System.Drawing.Point(212, 370);
            this.updateOrdersBtn.Name = "updateOrdersBtn";
            this.updateOrdersBtn.Size = new System.Drawing.Size(327, 52);
            this.updateOrdersBtn.TabIndex = 12;
            this.updateOrdersBtn.Text = "update orders";
            this.updateOrdersBtn.UseVisualStyleBackColor = true;
            this.updateOrdersBtn.Click += new System.EventHandler(this.updateOrdersBtn_Click);
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 52);
            this.label2.TabIndex = 11;
            this.label2.Text = "id product";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BackendForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 437);
            this.Controls.Add(this.updateOrdersBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimeBox);
            this.Controls.Add(this.idListBox);
            this.Name = "BackendForm";
            this.Text = "Shipping";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox idListBox;
        private System.Windows.Forms.ListBox dateTimeBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button updateOrdersBtn;
        private System.Windows.Forms.Label label2;
    }
}

