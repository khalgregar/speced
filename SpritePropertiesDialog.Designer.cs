namespace SpecEd
{
    partial class SpritePropertiesDialog
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
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label8;
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.udStartX = new System.Windows.Forms.NumericUpDown();
            this.udStartY = new System.Windows.Forms.NumericUpDown();
            this.udMinimum = new System.Windows.Forms.NumericUpDown();
            this.udMaximum = new System.Windows.Forms.NumericUpDown();
            this.udSpeed = new System.Windows.Forms.NumericUpDown();
            this.udColour = new System.Windows.Forms.NumericUpDown();
            this.tbEvaluator = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.udFrameSpeed = new System.Windows.Forms.NumericUpDown();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.udStartX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udStartY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udMinimum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udMaximum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFrameSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(57, 12);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(42, 13);
            label1.TabIndex = 0;
            label1.Text = "Start X:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(57, 38);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(42, 13);
            label2.TabIndex = 2;
            label2.Text = "Start Y:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(45, 90);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(54, 13);
            label4.TabIndex = 8;
            label4.Text = "Maximum:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(48, 64);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(51, 13);
            label5.TabIndex = 6;
            label5.Text = "Minimum:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(57, 118);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(41, 13);
            label3.TabIndex = 17;
            label3.Text = "Speed:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(57, 182);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(40, 13);
            label6.TabIndex = 19;
            label6.Text = "Colour:";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(83, 252);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(188, 252);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // udStartX
            // 
            this.udStartX.Location = new System.Drawing.Point(105, 10);
            this.udStartX.Name = "udStartX";
            this.udStartX.Size = new System.Drawing.Size(53, 20);
            this.udStartX.TabIndex = 12;
            // 
            // udStartY
            // 
            this.udStartY.Location = new System.Drawing.Point(105, 36);
            this.udStartY.Name = "udStartY";
            this.udStartY.Size = new System.Drawing.Size(53, 20);
            this.udStartY.TabIndex = 13;
            // 
            // udMinimum
            // 
            this.udMinimum.Location = new System.Drawing.Point(105, 62);
            this.udMinimum.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.udMinimum.Name = "udMinimum";
            this.udMinimum.Size = new System.Drawing.Size(53, 20);
            this.udMinimum.TabIndex = 14;
            // 
            // udMaximum
            // 
            this.udMaximum.Location = new System.Drawing.Point(105, 90);
            this.udMaximum.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.udMaximum.Name = "udMaximum";
            this.udMaximum.Size = new System.Drawing.Size(53, 20);
            this.udMaximum.TabIndex = 15;
            this.udMaximum.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // udSpeed
            // 
            this.udSpeed.Location = new System.Drawing.Point(105, 116);
            this.udSpeed.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.udSpeed.Name = "udSpeed";
            this.udSpeed.Size = new System.Drawing.Size(53, 20);
            this.udSpeed.TabIndex = 16;
            this.udSpeed.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // udColour
            // 
            this.udColour.Location = new System.Drawing.Point(105, 180);
            this.udColour.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.udColour.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udColour.Name = "udColour";
            this.udColour.Size = new System.Drawing.Size(53, 20);
            this.udColour.TabIndex = 18;
            this.udColour.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // tbEvaluator
            // 
            this.tbEvaluator.Location = new System.Drawing.Point(105, 207);
            this.tbEvaluator.Name = "tbEvaluator";
            this.tbEvaluator.Size = new System.Drawing.Size(243, 20);
            this.tbEvaluator.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(42, 210);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Evaluator:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(24, 148);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(73, 13);
            label8.TabIndex = 23;
            label8.Text = "Frame Speed:";
            // 
            // udFrameSpeed
            // 
            this.udFrameSpeed.Location = new System.Drawing.Point(106, 146);
            this.udFrameSpeed.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.udFrameSpeed.Name = "udFrameSpeed";
            this.udFrameSpeed.Size = new System.Drawing.Size(53, 20);
            this.udFrameSpeed.TabIndex = 22;
            this.udFrameSpeed.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // SpritePropertiesDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(356, 279);
            this.ControlBox = false;
            this.Controls.Add(label8);
            this.Controls.Add(this.udFrameSpeed);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbEvaluator);
            this.Controls.Add(label6);
            this.Controls.Add(this.udColour);
            this.Controls.Add(label3);
            this.Controls.Add(this.udSpeed);
            this.Controls.Add(this.udMaximum);
            this.Controls.Add(this.udMinimum);
            this.Controls.Add(this.udStartY);
            this.Controls.Add(this.udStartX);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(label4);
            this.Controls.Add(label5);
            this.Controls.Add(label2);
            this.Controls.Add(label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SpritePropertiesDialog";
            this.Text = "Sprite Properties";
            ((System.ComponentModel.ISupportInitialize)(this.udStartX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udStartY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udMinimum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udMaximum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFrameSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown udStartX;
        private System.Windows.Forms.NumericUpDown udStartY;
        private System.Windows.Forms.NumericUpDown udMinimum;
        private System.Windows.Forms.NumericUpDown udMaximum;
        private System.Windows.Forms.NumericUpDown udSpeed;
        private System.Windows.Forms.NumericUpDown udColour;
        private System.Windows.Forms.TextBox tbEvaluator;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown udFrameSpeed;
    }
}