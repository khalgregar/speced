namespace SpecEd
{
    partial class TileInstancePropertiesDialog
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
            this.udX = new System.Windows.Forms.NumericUpDown();
            this.udY = new System.Windows.Forms.NumericUpDown();
            this.udRX = new System.Windows.Forms.NumericUpDown();
            this.udRY = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.udX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udRX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udRY)).BeginInit();
            this.SuspendLayout();
            // 
            // udX
            // 
            this.udX.Location = new System.Drawing.Point(67, 11);
            this.udX.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.udX.Name = "udX";
            this.udX.Size = new System.Drawing.Size(51, 20);
            this.udX.TabIndex = 0;
            // 
            // udY
            // 
            this.udY.Location = new System.Drawing.Point(67, 37);
            this.udY.Maximum = new decimal(new int[] {
            19,
            0,
            0,
            0});
            this.udY.Name = "udY";
            this.udY.Size = new System.Drawing.Size(51, 20);
            this.udY.TabIndex = 1;
            // 
            // udRX
            // 
            this.udRX.Location = new System.Drawing.Point(67, 74);
            this.udRX.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.udRX.Name = "udRX";
            this.udRX.Size = new System.Drawing.Size(51, 20);
            this.udRX.TabIndex = 2;
            // 
            // udRY
            // 
            this.udRY.Location = new System.Drawing.Point(67, 100);
            this.udRY.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.udRY.Name = "udRY";
            this.udRY.Size = new System.Drawing.Size(51, 20);
            this.udRY.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Cell X:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Cell Y:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Repeat X:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Repeat Y:";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(44, 194);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(129, 194);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(67, 140);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(182, 20);
            this.tbName.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Name:";
            // 
            // TileInstancePropertiesDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(258, 225);
            this.ControlBox = false;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.udRY);
            this.Controls.Add(this.udRX);
            this.Controls.Add(this.udY);
            this.Controls.Add(this.udX);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "TileInstancePropertiesDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tile Properties";
            ((System.ComponentModel.ISupportInitialize)(this.udX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udRX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udRY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown udX;
        private System.Windows.Forms.NumericUpDown udY;
        private System.Windows.Forms.NumericUpDown udRX;
        private System.Windows.Forms.NumericUpDown udRY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label5;
    }
}