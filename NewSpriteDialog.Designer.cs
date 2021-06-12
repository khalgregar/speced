namespace SpecEd
{
    partial class NewSpriteDialog
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            this.udTileWidth = new System.Windows.Forms.NumericUpDown();
            this.udTileHeight = new System.Windows.Forms.NumericUpDown();
            this.udNumFrames = new System.Windows.Forms.NumericUpDown();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbMovement = new System.Windows.Forms.ComboBox();
            this.cbSpriteType = new System.Windows.Forms.ComboBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.udTileWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udTileHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udNumFrames)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(15, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(58, 13);
            label1.TabIndex = 0;
            label1.Text = "Tile Width:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(17, 35);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(61, 13);
            label2.TabIndex = 2;
            label2.Text = "Tile Height:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(15, 61);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(69, 13);
            label3.TabIndex = 4;
            label3.Text = "Num Frames:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(17, 89);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(60, 13);
            label4.TabIndex = 9;
            label4.Text = "Movement:";
            // 
            // udTileWidth
            // 
            this.udTileWidth.Location = new System.Drawing.Point(93, 7);
            this.udTileWidth.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.udTileWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udTileWidth.Name = "udTileWidth";
            this.udTileWidth.Size = new System.Drawing.Size(72, 20);
            this.udTileWidth.TabIndex = 1;
            this.udTileWidth.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // udTileHeight
            // 
            this.udTileHeight.Location = new System.Drawing.Point(93, 33);
            this.udTileHeight.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.udTileHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udTileHeight.Name = "udTileHeight";
            this.udTileHeight.Size = new System.Drawing.Size(72, 20);
            this.udTileHeight.TabIndex = 3;
            this.udTileHeight.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // udNumFrames
            // 
            this.udNumFrames.Location = new System.Drawing.Point(93, 59);
            this.udNumFrames.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udNumFrames.Name = "udNumFrames";
            this.udNumFrames.Size = new System.Drawing.Size(72, 20);
            this.udNumFrames.TabIndex = 5;
            this.udNumFrames.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(34, 174);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(74, 27);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(118, 174);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(74, 27);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // cbMovement
            // 
            this.cbMovement.FormattingEnabled = true;
            this.cbMovement.Items.AddRange(new object[] {
            "Horizontal",
            "Vertical",
            "Custom",
            "Static"});
            this.cbMovement.Location = new System.Drawing.Point(93, 86);
            this.cbMovement.Name = "cbMovement";
            this.cbMovement.Size = new System.Drawing.Size(121, 21);
            this.cbMovement.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(17, 116);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(34, 13);
            label5.TabIndex = 11;
            label5.Text = "Type:";
            // 
            // cbSpriteType
            // 
            this.cbSpriteType.FormattingEnabled = true;
            this.cbSpriteType.Items.AddRange(new object[] {
            "Deadly",
            "Elevator"});
            this.cbSpriteType.Location = new System.Drawing.Point(93, 113);
            this.cbSpriteType.Name = "cbSpriteType";
            this.cbSpriteType.Size = new System.Drawing.Size(121, 21);
            this.cbSpriteType.TabIndex = 10;
            // 
            // NewSpriteDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 213);
            this.ControlBox = false;
            this.Controls.Add(label5);
            this.Controls.Add(this.cbSpriteType);
            this.Controls.Add(label4);
            this.Controls.Add(this.cbMovement);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.udNumFrames);
            this.Controls.Add(label3);
            this.Controls.Add(this.udTileHeight);
            this.Controls.Add(label2);
            this.Controls.Add(this.udTileWidth);
            this.Controls.Add(label1);
            this.Name = "NewSpriteDialog";
            this.Text = "New Sprite";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.udTileWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udTileHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udNumFrames)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown udTileWidth;
        private System.Windows.Forms.NumericUpDown udTileHeight;
        private System.Windows.Forms.NumericUpDown udNumFrames;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cbMovement;
        private System.Windows.Forms.ComboBox cbSpriteType;
    }
}