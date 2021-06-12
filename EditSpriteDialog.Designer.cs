namespace SpecEd
{
    partial class EditSpriteDialog
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
            this.lblFrame = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.spriteControl = new SpecEd.SpriteControl();
            this.cbGenerateReverse = new System.Windows.Forms.CheckBox();
            this.cbShowMask = new System.Windows.Forms.CheckBox();
            this.btnAddMask = new System.Windows.Forms.Button();
            this.btnShiftD = new System.Windows.Forms.Button();
            this.btnShiftU = new System.Windows.Forms.Button();
            this.btnShiftR = new System.Windows.Forms.Button();
            this.btnShiftL = new System.Windows.Forms.Button();
            this.btnIncFrame = new System.Windows.Forms.Button();
            this.btnDecFrame = new System.Windows.Forms.Button();
            this.btnPasteFrame = new System.Windows.Forms.Button();
            this.btnCopyFrame = new System.Windows.Forms.Button();
            this.cbVertical = new System.Windows.Forms.CheckBox();
            this.cbDeadly = new System.Windows.Forms.CheckBox();
            this.udMoveId = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udMoveId)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFrame
            // 
            this.lblFrame.AutoSize = true;
            this.lblFrame.Location = new System.Drawing.Point(66, 14);
            this.lblFrame.Name = "lblFrame";
            this.lblFrame.Size = new System.Drawing.Size(39, 13);
            this.lblFrame.TabIndex = 2;
            this.lblFrame.Text = "Frame:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.spriteControl);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.udMoveId);
            this.splitContainer1.Panel2.Controls.Add(this.cbDeadly);
            this.splitContainer1.Panel2.Controls.Add(this.cbVertical);
            this.splitContainer1.Panel2.Controls.Add(this.cbGenerateReverse);
            this.splitContainer1.Panel2.Controls.Add(this.cbShowMask);
            this.splitContainer1.Panel2.Controls.Add(this.btnAddMask);
            this.splitContainer1.Panel2.Controls.Add(this.btnShiftD);
            this.splitContainer1.Panel2.Controls.Add(this.btnShiftU);
            this.splitContainer1.Panel2.Controls.Add(this.btnShiftR);
            this.splitContainer1.Panel2.Controls.Add(this.btnShiftL);
            this.splitContainer1.Panel2.Controls.Add(this.btnIncFrame);
            this.splitContainer1.Panel2.Controls.Add(this.btnDecFrame);
            this.splitContainer1.Panel2.Controls.Add(this.btnPasteFrame);
            this.splitContainer1.Panel2.Controls.Add(this.btnCopyFrame);
            this.splitContainer1.Panel2.Controls.Add(this.lblFrame);
            this.splitContainer1.Panel2MinSize = 150;
            this.splitContainer1.Size = new System.Drawing.Size(848, 565);
            this.splitContainer1.SplitterDistance = 661;
            this.splitContainer1.TabIndex = 3;
            // 
            // spriteControl
            // 
            this.spriteControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spriteControl.Frame = 0;
            this.spriteControl.Location = new System.Drawing.Point(0, 0);
            this.spriteControl.Name = "spriteControl";
            this.spriteControl.ShowMask = false;
            this.spriteControl.Size = new System.Drawing.Size(661, 565);
            this.spriteControl.Sprite = null;
            this.spriteControl.TabIndex = 0;
            this.spriteControl.ViewScale = 16;
            // 
            // cbGenerateReverse
            // 
            this.cbGenerateReverse.AutoSize = true;
            this.cbGenerateReverse.Location = new System.Drawing.Point(17, 380);
            this.cbGenerateReverse.Name = "cbGenerateReverse";
            this.cbGenerateReverse.Size = new System.Drawing.Size(132, 17);
            this.cbGenerateReverse.TabIndex = 15;
            this.cbGenerateReverse.Text = "Generate mirror frames";
            this.cbGenerateReverse.UseVisualStyleBackColor = true;
            this.cbGenerateReverse.CheckedChanged += new System.EventHandler(this.cbGenerateReverse_CheckedChanged);
            // 
            // cbShowMask
            // 
            this.cbShowMask.AutoSize = true;
            this.cbShowMask.Location = new System.Drawing.Point(36, 537);
            this.cbShowMask.Name = "cbShowMask";
            this.cbShowMask.Size = new System.Drawing.Size(82, 17);
            this.cbShowMask.TabIndex = 13;
            this.cbShowMask.Text = "Show Mask";
            this.cbShowMask.UseVisualStyleBackColor = true;
            this.cbShowMask.Click += new System.EventHandler(this.cbShowMask_Click);
            // 
            // btnAddMask
            // 
            this.btnAddMask.Location = new System.Drawing.Point(41, 508);
            this.btnAddMask.Name = "btnAddMask";
            this.btnAddMask.Size = new System.Drawing.Size(75, 23);
            this.btnAddMask.TabIndex = 12;
            this.btnAddMask.Text = "Add Mask";
            this.btnAddMask.UseVisualStyleBackColor = true;
            this.btnAddMask.Click += new System.EventHandler(this.btnAddMask_Click);
            // 
            // btnShiftD
            // 
            this.btnShiftD.Location = new System.Drawing.Point(80, 157);
            this.btnShiftD.Name = "btnShiftD";
            this.btnShiftD.Size = new System.Drawing.Size(30, 23);
            this.btnShiftD.TabIndex = 10;
            this.btnShiftD.Text = "D";
            this.btnShiftD.UseVisualStyleBackColor = true;
            this.btnShiftD.Click += new System.EventHandler(this.btnShiftD_Click);
            // 
            // btnShiftU
            // 
            this.btnShiftU.Location = new System.Drawing.Point(80, 99);
            this.btnShiftU.Name = "btnShiftU";
            this.btnShiftU.Size = new System.Drawing.Size(30, 23);
            this.btnShiftU.TabIndex = 9;
            this.btnShiftU.Text = "U";
            this.btnShiftU.UseVisualStyleBackColor = true;
            this.btnShiftU.Click += new System.EventHandler(this.btnShiftU_Click);
            // 
            // btnShiftR
            // 
            this.btnShiftR.Location = new System.Drawing.Point(107, 128);
            this.btnShiftR.Name = "btnShiftR";
            this.btnShiftR.Size = new System.Drawing.Size(30, 23);
            this.btnShiftR.TabIndex = 8;
            this.btnShiftR.Text = "R";
            this.btnShiftR.UseVisualStyleBackColor = true;
            this.btnShiftR.Click += new System.EventHandler(this.btnShiftR_Click);
            // 
            // btnShiftL
            // 
            this.btnShiftL.Location = new System.Drawing.Point(52, 128);
            this.btnShiftL.Name = "btnShiftL";
            this.btnShiftL.Size = new System.Drawing.Size(30, 23);
            this.btnShiftL.TabIndex = 7;
            this.btnShiftL.Text = "L";
            this.btnShiftL.UseVisualStyleBackColor = true;
            this.btnShiftL.Click += new System.EventHandler(this.btnShiftL_Click);
            // 
            // btnIncFrame
            // 
            this.btnIncFrame.Location = new System.Drawing.Point(131, 9);
            this.btnIncFrame.Name = "btnIncFrame";
            this.btnIncFrame.Size = new System.Drawing.Size(30, 23);
            this.btnIncFrame.TabIndex = 6;
            this.btnIncFrame.Text = ">";
            this.btnIncFrame.UseVisualStyleBackColor = true;
            this.btnIncFrame.Click += new System.EventHandler(this.btnIncFrame_Click);
            // 
            // btnDecFrame
            // 
            this.btnDecFrame.Location = new System.Drawing.Point(30, 9);
            this.btnDecFrame.Name = "btnDecFrame";
            this.btnDecFrame.Size = new System.Drawing.Size(30, 23);
            this.btnDecFrame.TabIndex = 5;
            this.btnDecFrame.Text = "<";
            this.btnDecFrame.UseVisualStyleBackColor = true;
            this.btnDecFrame.Click += new System.EventHandler(this.btnDecFrame_Click);
            // 
            // btnPasteFrame
            // 
            this.btnPasteFrame.Location = new System.Drawing.Point(103, 58);
            this.btnPasteFrame.Name = "btnPasteFrame";
            this.btnPasteFrame.Size = new System.Drawing.Size(58, 23);
            this.btnPasteFrame.TabIndex = 4;
            this.btnPasteFrame.Text = "Paste";
            this.btnPasteFrame.UseVisualStyleBackColor = true;
            this.btnPasteFrame.Click += new System.EventHandler(this.btnPasteFrame_Click);
            // 
            // btnCopyFrame
            // 
            this.btnCopyFrame.Location = new System.Drawing.Point(30, 58);
            this.btnCopyFrame.Name = "btnCopyFrame";
            this.btnCopyFrame.Size = new System.Drawing.Size(58, 23);
            this.btnCopyFrame.TabIndex = 3;
            this.btnCopyFrame.Text = "Copy";
            this.btnCopyFrame.UseVisualStyleBackColor = true;
            this.btnCopyFrame.Click += new System.EventHandler(this.btnCopyFrame_Click);
            // 
            // cbVertical
            // 
            this.cbVertical.AutoSize = true;
            this.cbVertical.Location = new System.Drawing.Point(17, 334);
            this.cbVertical.Name = "cbVertical";
            this.cbVertical.Size = new System.Drawing.Size(61, 17);
            this.cbVertical.TabIndex = 16;
            this.cbVertical.Text = "Vertical";
            this.cbVertical.UseVisualStyleBackColor = true;
            this.cbVertical.CheckedChanged += new System.EventHandler(this.cbVertical_CheckedChanged);
            // 
            // cbDeadly
            // 
            this.cbDeadly.AutoSize = true;
            this.cbDeadly.Location = new System.Drawing.Point(17, 357);
            this.cbDeadly.Name = "cbDeadly";
            this.cbDeadly.Size = new System.Drawing.Size(59, 17);
            this.cbDeadly.TabIndex = 17;
            this.cbDeadly.Text = "Deadly";
            this.cbDeadly.UseVisualStyleBackColor = true;
            this.cbDeadly.CheckedChanged += new System.EventHandler(this.cbDeadly_CheckedChanged);
            // 
            // udMoveId
            // 
            this.udMoveId.Location = new System.Drawing.Point(93, 413);
            this.udMoveId.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.udMoveId.Name = "udMoveId";
            this.udMoveId.Size = new System.Drawing.Size(56, 20);
            this.udMoveId.TabIndex = 18;
            this.udMoveId.ValueChanged += new System.EventHandler(this.udMoveId_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 415);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Movement ID:";
            // 
            // EditSpriteDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 565);
            this.Controls.Add(this.splitContainer1);
            this.Name = "EditSpriteDialog";
            this.Text = "Sprite Editor";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.udMoveId)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SpriteControl spriteControl;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnIncFrame;
        private System.Windows.Forms.Button btnDecFrame;
        private System.Windows.Forms.Button btnPasteFrame;
        private System.Windows.Forms.Button btnCopyFrame;
        private System.Windows.Forms.Label lblFrame;
        private System.Windows.Forms.Button btnShiftD;
        private System.Windows.Forms.Button btnShiftU;
        private System.Windows.Forms.Button btnShiftR;
        private System.Windows.Forms.Button btnShiftL;
        private System.Windows.Forms.Button btnAddMask;
        private System.Windows.Forms.CheckBox cbShowMask;
        private System.Windows.Forms.CheckBox cbGenerateReverse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown udMoveId;
        private System.Windows.Forms.CheckBox cbDeadly;
        private System.Windows.Forms.CheckBox cbVertical;
    }
}