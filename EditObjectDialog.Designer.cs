namespace SpecEd
{
    partial class EditObjectDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditObjectDialog));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.udWidth = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.udHeight = new System.Windows.Forms.NumericUpDown();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnGrid = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnModeDraw = new System.Windows.Forms.ToolStripButton();
            this.btnModeCell = new System.Windows.Forms.ToolStripButton();
            this.btnModeShape = new System.Windows.Forms.ToolStripButton();
            this.gbBlockType = new System.Windows.Forms.GroupBox();
            this.rbGoodie = new System.Windows.Forms.RadioButton();
            this.rbSwitch = new System.Windows.Forms.RadioButton();
            this.rbInfo = new System.Windows.Forms.RadioButton();
            this.rbCollectable = new System.Windows.Forms.RadioButton();
            this.rbDeadly = new System.Windows.Forms.RadioButton();
            this.rbWall = new System.Windows.Forms.RadioButton();
            this.rbPlatform = new System.Windows.Forms.RadioButton();
            this.rbEmpty = new System.Windows.Forms.RadioButton();
            this.gbSwitchType = new System.Windows.Forms.GroupBox();
            this.stPressure = new System.Windows.Forms.RadioButton();
            this.stSingle = new System.Windows.Forms.RadioButton();
            this.stToggle = new System.Windows.Forms.RadioButton();
            this.objectControl = new SpecEd.ObjectControl();
            this.paletteControl = new SpecEd.PaletteControl();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.udWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udHeight)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.gbBlockType.SuspendLayout();
            this.gbSwitchType.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(615, 33);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(38, 13);
            label1.TabIndex = 4;
            label1.Text = "Width:";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(743, 577);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnConfirm.Location = new System.Drawing.Point(619, 577);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(108, 23);
            this.btnConfirm.TabIndex = 3;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            // 
            // udWidth
            // 
            this.udWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.udWidth.Location = new System.Drawing.Point(662, 31);
            this.udWidth.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.udWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udWidth.Name = "udWidth";
            this.udWidth.Size = new System.Drawing.Size(59, 20);
            this.udWidth.TabIndex = 5;
            this.udWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udWidth.ValueChanged += new System.EventHandler(this.udWidth_ValueChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(727, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Height:";
            // 
            // udHeight
            // 
            this.udHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.udHeight.Location = new System.Drawing.Point(774, 31);
            this.udHeight.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.udHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udHeight.Name = "udHeight";
            this.udHeight.Size = new System.Drawing.Size(59, 20);
            this.udHeight.TabIndex = 7;
            this.udHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udHeight.ValueChanged += new System.EventHandler(this.udHeight_ValueChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGrid,
            this.toolStripSeparator1,
            this.btnModeDraw,
            this.btnModeCell,
            this.btnModeShape});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(865, 25);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnGrid
            // 
            this.btnGrid.CheckOnClick = true;
            this.btnGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnGrid.Image = ((System.Drawing.Image)(resources.GetObject("btnGrid.Image")));
            this.btnGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGrid.Name = "btnGrid";
            this.btnGrid.Size = new System.Drawing.Size(23, 22);
            this.btnGrid.Text = "toolStripButton1";
            this.btnGrid.Click += new System.EventHandler(this.btnGrid_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnModeDraw
            // 
            this.btnModeDraw.CheckOnClick = true;
            this.btnModeDraw.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnModeDraw.Image = ((System.Drawing.Image)(resources.GetObject("btnModeDraw.Image")));
            this.btnModeDraw.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnModeDraw.Name = "btnModeDraw";
            this.btnModeDraw.Size = new System.Drawing.Size(23, 22);
            this.btnModeDraw.Text = "toolStripButton1";
            this.btnModeDraw.Click += new System.EventHandler(this.btnModeDraw_Click);
            // 
            // btnModeCell
            // 
            this.btnModeCell.CheckOnClick = true;
            this.btnModeCell.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnModeCell.Image = ((System.Drawing.Image)(resources.GetObject("btnModeCell.Image")));
            this.btnModeCell.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnModeCell.Name = "btnModeCell";
            this.btnModeCell.Size = new System.Drawing.Size(23, 22);
            this.btnModeCell.Text = "toolStripButton2";
            this.btnModeCell.Click += new System.EventHandler(this.btnModeCell_Click);
            // 
            // btnModeShape
            // 
            this.btnModeShape.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnModeShape.Image = ((System.Drawing.Image)(resources.GetObject("btnModeShape.Image")));
            this.btnModeShape.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnModeShape.Name = "btnModeShape";
            this.btnModeShape.Size = new System.Drawing.Size(23, 22);
            this.btnModeShape.Text = "toolStripButton1";
            // 
            // gbBlockType
            // 
            this.gbBlockType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbBlockType.Controls.Add(this.rbGoodie);
            this.gbBlockType.Controls.Add(this.rbSwitch);
            this.gbBlockType.Controls.Add(this.rbInfo);
            this.gbBlockType.Controls.Add(this.rbCollectable);
            this.gbBlockType.Controls.Add(this.rbDeadly);
            this.gbBlockType.Controls.Add(this.rbWall);
            this.gbBlockType.Controls.Add(this.rbPlatform);
            this.gbBlockType.Controls.Add(this.rbEmpty);
            this.gbBlockType.Location = new System.Drawing.Point(618, 73);
            this.gbBlockType.Name = "gbBlockType";
            this.gbBlockType.Size = new System.Drawing.Size(103, 211);
            this.gbBlockType.TabIndex = 10;
            this.gbBlockType.TabStop = false;
            this.gbBlockType.Text = "Block type";
            // 
            // rbGoodie
            // 
            this.rbGoodie.AutoSize = true;
            this.rbGoodie.Location = new System.Drawing.Point(8, 184);
            this.rbGoodie.Name = "rbGoodie";
            this.rbGoodie.Size = new System.Drawing.Size(59, 17);
            this.rbGoodie.TabIndex = 7;
            this.rbGoodie.TabStop = true;
            this.rbGoodie.Tag = SpecEd.BlockType.Goodie;
            this.rbGoodie.Text = "Goodie";
            this.rbGoodie.UseVisualStyleBackColor = true;
            this.rbGoodie.CheckedChanged += new System.EventHandler(this.rbBlockType_CheckedChanged);
            // 
            // rbSwitch
            // 
            this.rbSwitch.AutoSize = true;
            this.rbSwitch.Location = new System.Drawing.Point(7, 161);
            this.rbSwitch.Name = "rbSwitch";
            this.rbSwitch.Size = new System.Drawing.Size(57, 17);
            this.rbSwitch.TabIndex = 6;
            this.rbSwitch.TabStop = true;
            this.rbSwitch.Tag = SpecEd.BlockType.Switch;
            this.rbSwitch.Text = "Switch";
            this.rbSwitch.UseVisualStyleBackColor = true;
            this.rbSwitch.CheckedChanged += new System.EventHandler(this.rbBlockType_CheckedChanged);
            // 
            // rbInfo
            // 
            this.rbInfo.AutoSize = true;
            this.rbInfo.Location = new System.Drawing.Point(7, 138);
            this.rbInfo.Name = "rbInfo";
            this.rbInfo.Size = new System.Drawing.Size(43, 17);
            this.rbInfo.TabIndex = 5;
            this.rbInfo.TabStop = true;
            this.rbInfo.Tag = SpecEd.BlockType.Info;
            this.rbInfo.Text = "Info";
            this.rbInfo.UseVisualStyleBackColor = true;
            this.rbInfo.CheckedChanged += new System.EventHandler(this.rbBlockType_CheckedChanged);
            // 
            // rbCollectable
            // 
            this.rbCollectable.AutoSize = true;
            this.rbCollectable.Location = new System.Drawing.Point(7, 115);
            this.rbCollectable.Name = "rbCollectable";
            this.rbCollectable.Size = new System.Drawing.Size(77, 17);
            this.rbCollectable.TabIndex = 4;
            this.rbCollectable.TabStop = true;
            this.rbCollectable.Tag = SpecEd.BlockType.Collectable;
            this.rbCollectable.Text = "Collectable";
            this.rbCollectable.UseVisualStyleBackColor = true;
            this.rbCollectable.CheckedChanged += new System.EventHandler(this.rbBlockType_CheckedChanged);
            // 
            // rbDeadly
            // 
            this.rbDeadly.AutoSize = true;
            this.rbDeadly.Location = new System.Drawing.Point(7, 92);
            this.rbDeadly.Name = "rbDeadly";
            this.rbDeadly.Size = new System.Drawing.Size(58, 17);
            this.rbDeadly.TabIndex = 3;
            this.rbDeadly.TabStop = true;
            this.rbDeadly.Tag = SpecEd.BlockType.Deadly;
            this.rbDeadly.Text = "Deadly";
            this.rbDeadly.UseVisualStyleBackColor = true;
            this.rbDeadly.CheckedChanged += new System.EventHandler(this.rbBlockType_CheckedChanged);
            // 
            // rbWall
            // 
            this.rbWall.AutoSize = true;
            this.rbWall.Location = new System.Drawing.Point(7, 68);
            this.rbWall.Name = "rbWall";
            this.rbWall.Size = new System.Drawing.Size(46, 17);
            this.rbWall.TabIndex = 2;
            this.rbWall.TabStop = true;
            this.rbWall.Tag = SpecEd.BlockType.Wall;
            this.rbWall.Text = "Wall";
            this.rbWall.UseVisualStyleBackColor = true;
            this.rbWall.CheckedChanged += new System.EventHandler(this.rbBlockType_CheckedChanged);
            // 
            // rbPlatform
            // 
            this.rbPlatform.AutoSize = true;
            this.rbPlatform.Location = new System.Drawing.Point(7, 44);
            this.rbPlatform.Name = "rbPlatform";
            this.rbPlatform.Size = new System.Drawing.Size(63, 17);
            this.rbPlatform.TabIndex = 1;
            this.rbPlatform.TabStop = true;
            this.rbPlatform.Tag = SpecEd.BlockType.Platform;
            this.rbPlatform.Text = "Platform";
            this.rbPlatform.UseVisualStyleBackColor = true;
            this.rbPlatform.CheckedChanged += new System.EventHandler(this.rbBlockType_CheckedChanged);
            // 
            // rbEmpty
            // 
            this.rbEmpty.AutoSize = true;
            this.rbEmpty.Location = new System.Drawing.Point(7, 20);
            this.rbEmpty.Name = "rbEmpty";
            this.rbEmpty.Size = new System.Drawing.Size(54, 17);
            this.rbEmpty.TabIndex = 0;
            this.rbEmpty.TabStop = true;
            this.rbEmpty.Tag = SpecEd.BlockType.Empty;
            this.rbEmpty.Text = "Empty";
            this.rbEmpty.UseVisualStyleBackColor = true;
            this.rbEmpty.CheckedChanged += new System.EventHandler(this.rbBlockType_CheckedChanged);
            // 
            // gbSwitchType
            // 
            this.gbSwitchType.Controls.Add(this.stPressure);
            this.gbSwitchType.Controls.Add(this.stSingle);
            this.gbSwitchType.Controls.Add(this.stToggle);
            this.gbSwitchType.Location = new System.Drawing.Point(730, 73);
            this.gbSwitchType.Name = "gbSwitchType";
            this.gbSwitchType.Size = new System.Drawing.Size(123, 96);
            this.gbSwitchType.TabIndex = 11;
            this.gbSwitchType.TabStop = false;
            this.gbSwitchType.Text = "Switch type";
            // 
            // stPressure
            // 
            this.stPressure.AutoSize = true;
            this.stPressure.Location = new System.Drawing.Point(7, 68);
            this.stPressure.Name = "stPressure";
            this.stPressure.Size = new System.Drawing.Size(93, 17);
            this.stPressure.TabIndex = 2;
            this.stPressure.TabStop = true;
            this.stPressure.Tag = SpecEd.SwitchType.Pressure;
            this.stPressure.Text = "Pressure Plate";
            this.stPressure.UseVisualStyleBackColor = true;
            this.stPressure.CheckedChanged += new System.EventHandler(this.rbSwitchType_CheckedChanged);
            // 
            // stSingle
            // 
            this.stSingle.AutoSize = true;
            this.stSingle.Location = new System.Drawing.Point(7, 44);
            this.stSingle.Name = "stSingle";
            this.stSingle.Size = new System.Drawing.Size(76, 17);
            this.stSingle.TabIndex = 1;
            this.stSingle.TabStop = true;
            this.stSingle.Tag = SpecEd.SwitchType.Single;
            this.stSingle.Text = "Single Use";
            this.stSingle.UseVisualStyleBackColor = true;
            this.stSingle.CheckedChanged += new System.EventHandler(this.rbSwitchType_CheckedChanged);
            // 
            // stToggle
            // 
            this.stToggle.AutoSize = true;
            this.stToggle.Location = new System.Drawing.Point(7, 20);
            this.stToggle.Name = "stToggle";
            this.stToggle.Size = new System.Drawing.Size(58, 17);
            this.stToggle.TabIndex = 0;
            this.stToggle.TabStop = true;
            this.stToggle.Tag = SpecEd.SwitchType.Toggle;
            this.stToggle.Text = "Toggle";
            this.stToggle.UseVisualStyleBackColor = true;
            this.stToggle.CheckedChanged += new System.EventHandler(this.rbSwitchType_CheckedChanged);
            // 
            // objectControl
            // 
            this.objectControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.objectControl.Location = new System.Drawing.Point(0, 28);
            this.objectControl.Mode = SpecEd.ObjectControl.ModeType.Pixel;
            this.objectControl.Name = "objectControl";
            this.objectControl.ShowGrid = true;
            this.objectControl.Size = new System.Drawing.Size(594, 572);
            this.objectControl.TabIndex = 8;
            this.objectControl.Tile = null;
            this.objectControl.ViewScale = 40;
            // 
            // paletteControl
            // 
            this.paletteControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.paletteControl.Attribute = null;
            this.paletteControl.Location = new System.Drawing.Point(766, 188);
            this.paletteControl.Name = "paletteControl";
            this.paletteControl.Size = new System.Drawing.Size(64, 256);
            this.paletteControl.TabIndex = 1;
            // 
            // EditObjectDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 606);
            this.ControlBox = false;
            this.Controls.Add(this.gbSwitchType);
            this.Controls.Add(this.gbBlockType);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.objectControl);
            this.Controls.Add(this.udHeight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.udWidth);
            this.Controls.Add(label1);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.paletteControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "EditObjectDialog";
            this.Text = "Object Editor";
            ((System.ComponentModel.ISupportInitialize)(this.udWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udHeight)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.gbBlockType.ResumeLayout(false);
            this.gbBlockType.PerformLayout();
            this.gbSwitchType.ResumeLayout(false);
            this.gbSwitchType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private PaletteControl paletteControl;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.NumericUpDown udWidth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown udHeight;
        private ObjectControl objectControl;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnGrid;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnModeDraw;
        private System.Windows.Forms.ToolStripButton btnModeCell;
        private System.Windows.Forms.RadioButton rbDeadly;
        private System.Windows.Forms.RadioButton rbWall;
        private System.Windows.Forms.RadioButton rbPlatform;
        private System.Windows.Forms.RadioButton rbEmpty;
        private System.Windows.Forms.GroupBox gbBlockType;
        private System.Windows.Forms.RadioButton rbCollectable;
        private System.Windows.Forms.ToolStripButton btnModeShape;
        private System.Windows.Forms.RadioButton rbInfo;
        private System.Windows.Forms.GroupBox gbSwitchType;
        private System.Windows.Forms.RadioButton stPressure;
        private System.Windows.Forms.RadioButton stSingle;
        private System.Windows.Forms.RadioButton stToggle;
        private System.Windows.Forms.RadioButton rbSwitch;
        private System.Windows.Forms.RadioButton rbGoodie;
    }
}