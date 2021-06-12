namespace SpecEd
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabRooms = new System.Windows.Forms.TabPage();
            this.roomsContainer = new System.Windows.Forms.SplitContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnPanRooms = new System.Windows.Forms.ToolStripButton();
            this.btnRoomDraw = new System.Windows.Forms.ToolStripButton();
            this.btnModeSprites = new System.Windows.Forms.ToolStripButton();
            this.btnRoomSelect = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.menuItem_RoomScale1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_RoomScale2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_RoomScale3 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_RoomScale4 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_RoomScale5 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRoomGrid = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRoomCreate = new System.Windows.Forms.ToolStripButton();
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            this.roomControl = new SpecEd.RoomControl();
            this.tabControlTools = new System.Windows.Forms.TabControl();
            this.tabTiles = new System.Windows.Forms.TabPage();
            this.objectPalette = new SpecEd.ObjectPalette();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnNewObject = new System.Windows.Forms.ToolStripButton();
            this.btnEditObject = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tabSprites = new System.Windows.Forms.TabPage();
            this.spritePalette = new SpecEd.SpritePalette();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.btnNewSprite = new System.Windows.Forms.ToolStripButton();
            this.btnEditSprite = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteSprite = new System.Windows.Forms.ToolStripButton();
            this.btnSetAsPlayer = new System.Windows.Forms.ToolStripButton();
            this.tabRoomDetails = new System.Windows.Forms.TabPage();
            this.tbRoomHash = new System.Windows.Forms.TextBox();
            this.tbRoomY = new System.Windows.Forms.TextBox();
            this.tbRoomX = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbRoomInfoID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSetTitle = new System.Windows.Forms.Button();
            this.tbRoomTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabStatics = new System.Windows.Forms.TabPage();
            this.btnDeleteStatic = new System.Windows.Forms.Button();
            this.btnRenameStatic = new System.Windows.Forms.Button();
            this.btnEditStatic = new System.Windows.Forms.Button();
            this.btnNewStatic = new System.Windows.Forms.Button();
            this.lbStatics = new System.Windows.Forms.ListBox();
            this.tabAudio = new System.Windows.Forms.TabPage();
            this.btnAudioDelete = new System.Windows.Forms.Button();
            this.btnAudioImport = new System.Windows.Forms.Button();
            this.lbAudio = new System.Windows.Forms.ListBox();
            this.tabStrings = new System.Windows.Forms.TabPage();
            this.btnAddRow = new System.Windows.Forms.Button();
            this.stringTableView = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tabRooms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roomsContainer)).BeginInit();
            this.roomsContainer.Panel1.SuspendLayout();
            this.roomsContainer.Panel2.SuspendLayout();
            this.roomsContainer.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabControlTools.SuspendLayout();
            this.tabTiles.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.tabSprites.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.tabRoomDetails.SuspendLayout();
            this.tabStatics.SuspendLayout();
            this.tabAudio.SuspendLayout();
            this.tabStrings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stringTableView)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabRooms
            // 
            this.tabRooms.Controls.Add(this.roomsContainer);
            this.tabRooms.Location = new System.Drawing.Point(4, 22);
            this.tabRooms.Name = "tabRooms";
            this.tabRooms.Padding = new System.Windows.Forms.Padding(3);
            this.tabRooms.Size = new System.Drawing.Size(1559, 686);
            this.tabRooms.TabIndex = 1;
            this.tabRooms.Text = "Rooms";
            this.tabRooms.UseVisualStyleBackColor = true;
            // 
            // roomsContainer
            // 
            this.roomsContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.roomsContainer.Location = new System.Drawing.Point(3, 3);
            this.roomsContainer.Name = "roomsContainer";
            // 
            // roomsContainer.Panel1
            // 
            this.roomsContainer.Panel1.Controls.Add(this.toolStrip1);
            this.roomsContainer.Panel1.Controls.Add(this.roomControl);
            // 
            // roomsContainer.Panel2
            // 
            this.roomsContainer.Panel2.Controls.Add(this.tabControlTools);
            this.roomsContainer.Size = new System.Drawing.Size(1553, 680);
            this.roomsContainer.SplitterDistance = 1073;
            this.roomsContainer.TabIndex = 2;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPanRooms,
            this.btnRoomDraw,
            this.btnModeSprites,
            this.btnRoomSelect,
            this.toolStripSeparator1,
            this.toolStripDropDownButton1,
            this.btnRoomGrid,
            this.toolStripSeparator2,
            this.btnRoomCreate,
            this.btnExport});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1073, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnPanRooms
            // 
            this.btnPanRooms.CheckOnClick = true;
            this.btnPanRooms.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnPanRooms.Image = ((System.Drawing.Image)(resources.GetObject("btnPanRooms.Image")));
            this.btnPanRooms.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPanRooms.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPanRooms.Name = "btnPanRooms";
            this.btnPanRooms.Size = new System.Drawing.Size(31, 22);
            this.btnPanRooms.Text = "Pan";
            this.btnPanRooms.Click += new System.EventHandler(this.btnPanRooms_Click);
            // 
            // btnRoomDraw
            // 
            this.btnRoomDraw.CheckOnClick = true;
            this.btnRoomDraw.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnRoomDraw.Image = ((System.Drawing.Image)(resources.GetObject("btnRoomDraw.Image")));
            this.btnRoomDraw.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnRoomDraw.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRoomDraw.Name = "btnRoomDraw";
            this.btnRoomDraw.Size = new System.Drawing.Size(35, 22);
            this.btnRoomDraw.Text = "Tiles";
            this.btnRoomDraw.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // btnModeSprites
            // 
            this.btnModeSprites.CheckOnClick = true;
            this.btnModeSprites.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnModeSprites.Image = ((System.Drawing.Image)(resources.GetObject("btnModeSprites.Image")));
            this.btnModeSprites.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnModeSprites.Name = "btnModeSprites";
            this.btnModeSprites.Size = new System.Drawing.Size(46, 22);
            this.btnModeSprites.Text = "Sprites";
            this.btnModeSprites.ToolTipText = "Sprites";
            this.btnModeSprites.Click += new System.EventHandler(this.btnModeSprites_Click);
            // 
            // btnRoomSelect
            // 
            this.btnRoomSelect.CheckOnClick = true;
            this.btnRoomSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnRoomSelect.Image = ((System.Drawing.Image)(resources.GetObject("btnRoomSelect.Image")));
            this.btnRoomSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRoomSelect.Name = "btnRoomSelect";
            this.btnRoomSelect.Size = new System.Drawing.Size(48, 22);
            this.btnRoomSelect.Text = "Rooms";
            this.btnRoomSelect.Click += new System.EventHandler(this.btnRoomSelect_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_RoomScale1,
            this.menuItem_RoomScale2,
            this.menuItem_RoomScale3,
            this.menuItem_RoomScale4,
            this.menuItem_RoomScale5});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(47, 22);
            this.toolStripDropDownButton1.Text = "Scale";
            // 
            // menuItem_RoomScale1
            // 
            this.menuItem_RoomScale1.Name = "menuItem_RoomScale1";
            this.menuItem_RoomScale1.Size = new System.Drawing.Size(85, 22);
            this.menuItem_RoomScale1.Text = "1x";
            this.menuItem_RoomScale1.Click += new System.EventHandler(this.menuItem_RoomScale1_Click);
            // 
            // menuItem_RoomScale2
            // 
            this.menuItem_RoomScale2.Name = "menuItem_RoomScale2";
            this.menuItem_RoomScale2.Size = new System.Drawing.Size(85, 22);
            this.menuItem_RoomScale2.Text = "2x";
            this.menuItem_RoomScale2.Click += new System.EventHandler(this.menuItem_RoomScale2_Click);
            // 
            // menuItem_RoomScale3
            // 
            this.menuItem_RoomScale3.Name = "menuItem_RoomScale3";
            this.menuItem_RoomScale3.Size = new System.Drawing.Size(85, 22);
            this.menuItem_RoomScale3.Text = "3x";
            this.menuItem_RoomScale3.Click += new System.EventHandler(this.menuItem_RoomScale3_Click);
            // 
            // menuItem_RoomScale4
            // 
            this.menuItem_RoomScale4.Name = "menuItem_RoomScale4";
            this.menuItem_RoomScale4.Size = new System.Drawing.Size(85, 22);
            this.menuItem_RoomScale4.Text = "4x";
            this.menuItem_RoomScale4.Click += new System.EventHandler(this.menuItem_RoomScale4_Click);
            // 
            // menuItem_RoomScale5
            // 
            this.menuItem_RoomScale5.Name = "menuItem_RoomScale5";
            this.menuItem_RoomScale5.Size = new System.Drawing.Size(85, 22);
            this.menuItem_RoomScale5.Tag = "";
            this.menuItem_RoomScale5.Text = "5x";
            this.menuItem_RoomScale5.Click += new System.EventHandler(this.menuItem_RoomScale5_Click);
            // 
            // btnRoomGrid
            // 
            this.btnRoomGrid.Checked = true;
            this.btnRoomGrid.CheckOnClick = true;
            this.btnRoomGrid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnRoomGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRoomGrid.Image = ((System.Drawing.Image)(resources.GetObject("btnRoomGrid.Image")));
            this.btnRoomGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRoomGrid.Name = "btnRoomGrid";
            this.btnRoomGrid.Size = new System.Drawing.Size(23, 22);
            this.btnRoomGrid.Text = "toolStripButton1";
            this.btnRoomGrid.Click += new System.EventHandler(this.btnRoomGrid_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnRoomCreate
            // 
            this.btnRoomCreate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnRoomCreate.Image = ((System.Drawing.Image)(resources.GetObject("btnRoomCreate.Image")));
            this.btnRoomCreate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRoomCreate.Name = "btnRoomCreate";
            this.btnRoomCreate.Size = new System.Drawing.Size(80, 22);
            this.btnRoomCreate.Text = "Create Room";
            this.btnRoomCreate.Click += new System.EventHandler(this.btnRoomCreate_Click);
            // 
            // btnExport
            // 
            this.btnExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(44, 22);
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // roomControl
            // 
            this.roomControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.roomControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.roomControl.CellBrush = 0;
            this.roomControl.CellBrushAlternate = 0;
            this.roomControl.ControlMode = SpecEd.RoomControl.ControlModeType.Pan;
            this.roomControl.GameData = null;
            this.roomControl.Location = new System.Drawing.Point(0, 31);
            this.roomControl.Margin = new System.Windows.Forms.Padding(0);
            this.roomControl.Name = "roomControl";
            this.roomControl.ShowGrid = true;
            this.roomControl.Size = new System.Drawing.Size(1073, 649);
            this.roomControl.SpriteBrush = -1;
            this.roomControl.TabIndex = 0;
            this.roomControl.TileBrush = -1;
            this.roomControl.ViewScale = 2;
            // 
            // tabControlTools
            // 
            this.tabControlTools.Controls.Add(this.tabTiles);
            this.tabControlTools.Controls.Add(this.tabSprites);
            this.tabControlTools.Controls.Add(this.tabRoomDetails);
            this.tabControlTools.Controls.Add(this.tabStatics);
            this.tabControlTools.Controls.Add(this.tabAudio);
            this.tabControlTools.Controls.Add(this.tabStrings);
            this.tabControlTools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlTools.Location = new System.Drawing.Point(0, 0);
            this.tabControlTools.Name = "tabControlTools";
            this.tabControlTools.SelectedIndex = 0;
            this.tabControlTools.Size = new System.Drawing.Size(476, 680);
            this.tabControlTools.TabIndex = 0;
            // 
            // tabTiles
            // 
            this.tabTiles.Controls.Add(this.objectPalette);
            this.tabTiles.Controls.Add(this.toolStrip2);
            this.tabTiles.Location = new System.Drawing.Point(4, 22);
            this.tabTiles.Name = "tabTiles";
            this.tabTiles.Padding = new System.Windows.Forms.Padding(3);
            this.tabTiles.Size = new System.Drawing.Size(468, 654);
            this.tabTiles.TabIndex = 0;
            this.tabTiles.Text = "Tiles";
            this.tabTiles.UseVisualStyleBackColor = true;
            // 
            // objectPalette
            // 
            this.objectPalette.ColumnWidth = 120;
            this.objectPalette.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectPalette.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.objectPalette.FormattingEnabled = true;
            this.objectPalette.GameData = null;
            this.objectPalette.ItemHeight = 120;
            this.objectPalette.Location = new System.Drawing.Point(3, 28);
            this.objectPalette.MultiColumn = true;
            this.objectPalette.Name = "objectPalette";
            this.objectPalette.Size = new System.Drawing.Size(462, 623);
            this.objectPalette.TabIndex = 3;
            this.objectPalette.SelectedIndexChanged += new System.EventHandler(this.objectPalette_SelectedIndexChanged);
            // 
            // toolStrip2
            // 
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNewObject,
            this.btnEditObject,
            this.toolStripButton1});
            this.toolStrip2.Location = new System.Drawing.Point(3, 3);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(462, 25);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnNewObject
            // 
            this.btnNewObject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnNewObject.Image = ((System.Drawing.Image)(resources.GetObject("btnNewObject.Image")));
            this.btnNewObject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNewObject.Name = "btnNewObject";
            this.btnNewObject.Size = new System.Drawing.Size(35, 22);
            this.btnNewObject.Text = "New";
            this.btnNewObject.Click += new System.EventHandler(this.btnNewObject_Click);
            // 
            // btnEditObject
            // 
            this.btnEditObject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnEditObject.Image = ((System.Drawing.Image)(resources.GetObject("btnEditObject.Image")));
            this.btnEditObject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditObject.Name = "btnEditObject";
            this.btnEditObject.Size = new System.Drawing.Size(31, 22);
            this.btnEditObject.Text = "Edit";
            this.btnEditObject.Click += new System.EventHandler(this.btnEditObject_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(44, 22);
            this.toolStripButton1.Text = "Delete";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click_1);
            // 
            // tabSprites
            // 
            this.tabSprites.Controls.Add(this.spritePalette);
            this.tabSprites.Controls.Add(this.toolStrip3);
            this.tabSprites.Location = new System.Drawing.Point(4, 22);
            this.tabSprites.Name = "tabSprites";
            this.tabSprites.Padding = new System.Windows.Forms.Padding(3);
            this.tabSprites.Size = new System.Drawing.Size(468, 654);
            this.tabSprites.TabIndex = 1;
            this.tabSprites.Text = "Sprites";
            this.tabSprites.UseVisualStyleBackColor = true;
            // 
            // spritePalette
            // 
            this.spritePalette.BackColor = System.Drawing.Color.DarkSlateGray;
            this.spritePalette.ColumnWidth = 120;
            this.spritePalette.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spritePalette.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.spritePalette.FormattingEnabled = true;
            this.spritePalette.GameData = null;
            this.spritePalette.ItemHeight = 120;
            this.spritePalette.Location = new System.Drawing.Point(3, 28);
            this.spritePalette.MultiColumn = true;
            this.spritePalette.Name = "spritePalette";
            this.spritePalette.Size = new System.Drawing.Size(462, 623);
            this.spritePalette.TabIndex = 1;
            this.spritePalette.SelectedIndexChanged += new System.EventHandler(this.spritePalette_SelectedIndexChanged);
            // 
            // toolStrip3
            // 
            this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNewSprite,
            this.btnEditSprite,
            this.btnDeleteSprite,
            this.btnSetAsPlayer});
            this.toolStrip3.Location = new System.Drawing.Point(3, 3);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip3.Size = new System.Drawing.Size(462, 25);
            this.toolStrip3.TabIndex = 0;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // btnNewSprite
            // 
            this.btnNewSprite.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnNewSprite.Image = ((System.Drawing.Image)(resources.GetObject("btnNewSprite.Image")));
            this.btnNewSprite.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNewSprite.Name = "btnNewSprite";
            this.btnNewSprite.Size = new System.Drawing.Size(35, 22);
            this.btnNewSprite.Text = "New";
            this.btnNewSprite.Click += new System.EventHandler(this.btnNewSprite_Click);
            // 
            // btnEditSprite
            // 
            this.btnEditSprite.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnEditSprite.Image = ((System.Drawing.Image)(resources.GetObject("btnEditSprite.Image")));
            this.btnEditSprite.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditSprite.Name = "btnEditSprite";
            this.btnEditSprite.Size = new System.Drawing.Size(31, 22);
            this.btnEditSprite.Text = "Edit";
            this.btnEditSprite.Click += new System.EventHandler(this.btnEditSprite_Click);
            // 
            // btnDeleteSprite
            // 
            this.btnDeleteSprite.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnDeleteSprite.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteSprite.Image")));
            this.btnDeleteSprite.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteSprite.Name = "btnDeleteSprite";
            this.btnDeleteSprite.Size = new System.Drawing.Size(44, 22);
            this.btnDeleteSprite.Text = "Delete";
            this.btnDeleteSprite.Click += new System.EventHandler(this.btnDeleteSprite_Click);
            // 
            // btnSetAsPlayer
            // 
            this.btnSetAsPlayer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSetAsPlayer.Image = ((System.Drawing.Image)(resources.GetObject("btnSetAsPlayer.Image")));
            this.btnSetAsPlayer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSetAsPlayer.Name = "btnSetAsPlayer";
            this.btnSetAsPlayer.Size = new System.Drawing.Size(76, 22);
            this.btnSetAsPlayer.Text = "Set as Player";
            this.btnSetAsPlayer.Click += new System.EventHandler(this.btnSetAsPlayer_Click);
            // 
            // tabRoomDetails
            // 
            this.tabRoomDetails.Controls.Add(this.tbRoomHash);
            this.tabRoomDetails.Controls.Add(this.tbRoomY);
            this.tabRoomDetails.Controls.Add(this.tbRoomX);
            this.tabRoomDetails.Controls.Add(this.label5);
            this.tabRoomDetails.Controls.Add(this.label4);
            this.tabRoomDetails.Controls.Add(this.label3);
            this.tabRoomDetails.Controls.Add(this.tbRoomInfoID);
            this.tabRoomDetails.Controls.Add(this.label2);
            this.tabRoomDetails.Controls.Add(this.btnSetTitle);
            this.tabRoomDetails.Controls.Add(this.tbRoomTitle);
            this.tabRoomDetails.Controls.Add(this.label1);
            this.tabRoomDetails.Location = new System.Drawing.Point(4, 22);
            this.tabRoomDetails.Name = "tabRoomDetails";
            this.tabRoomDetails.Size = new System.Drawing.Size(468, 654);
            this.tabRoomDetails.TabIndex = 2;
            this.tabRoomDetails.Text = "Room Details";
            this.tabRoomDetails.UseVisualStyleBackColor = true;
            // 
            // tbRoomHash
            // 
            this.tbRoomHash.Location = new System.Drawing.Point(268, 28);
            this.tbRoomHash.Name = "tbRoomHash";
            this.tbRoomHash.ReadOnly = true;
            this.tbRoomHash.Size = new System.Drawing.Size(54, 20);
            this.tbRoomHash.TabIndex = 10;
            // 
            // tbRoomY
            // 
            this.tbRoomY.Location = new System.Drawing.Point(150, 28);
            this.tbRoomY.Name = "tbRoomY";
            this.tbRoomY.ReadOnly = true;
            this.tbRoomY.Size = new System.Drawing.Size(54, 20);
            this.tbRoomY.TabIndex = 9;
            // 
            // tbRoomX
            // 
            this.tbRoomX.Location = new System.Drawing.Point(53, 28);
            this.tbRoomX.Name = "tbRoomX";
            this.tbRoomX.ReadOnly = true;
            this.tbRoomX.Size = new System.Drawing.Size(54, 20);
            this.tbRoomX.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(227, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Hash:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(127, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Y:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "X:";
            // 
            // tbRoomInfoID
            // 
            this.tbRoomInfoID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRoomInfoID.Location = new System.Drawing.Point(59, 130);
            this.tbRoomInfoID.Name = "tbRoomInfoID";
            this.tbRoomInfoID.Size = new System.Drawing.Size(393, 20);
            this.tbRoomInfoID.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "InfoID:";
            // 
            // btnSetTitle
            // 
            this.btnSetTitle.Location = new System.Drawing.Point(204, 177);
            this.btnSetTitle.Name = "btnSetTitle";
            this.btnSetTitle.Size = new System.Drawing.Size(75, 23);
            this.btnSetTitle.TabIndex = 2;
            this.btnSetTitle.Text = "Apply";
            this.btnSetTitle.UseVisualStyleBackColor = true;
            this.btnSetTitle.Click += new System.EventHandler(this.btnSetTitle_Click);
            // 
            // tbRoomTitle
            // 
            this.tbRoomTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRoomTitle.Location = new System.Drawing.Point(59, 89);
            this.tbRoomTitle.Name = "tbRoomTitle";
            this.tbRoomTitle.Size = new System.Drawing.Size(393, 20);
            this.tbRoomTitle.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Title";
            // 
            // tabStatics
            // 
            this.tabStatics.Controls.Add(this.btnDeleteStatic);
            this.tabStatics.Controls.Add(this.btnRenameStatic);
            this.tabStatics.Controls.Add(this.btnEditStatic);
            this.tabStatics.Controls.Add(this.btnNewStatic);
            this.tabStatics.Controls.Add(this.lbStatics);
            this.tabStatics.Location = new System.Drawing.Point(4, 22);
            this.tabStatics.Name = "tabStatics";
            this.tabStatics.Size = new System.Drawing.Size(468, 654);
            this.tabStatics.TabIndex = 3;
            this.tabStatics.Text = "Statics";
            this.tabStatics.UseVisualStyleBackColor = true;
            // 
            // btnDeleteStatic
            // 
            this.btnDeleteStatic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteStatic.Location = new System.Drawing.Point(316, 620);
            this.btnDeleteStatic.Name = "btnDeleteStatic";
            this.btnDeleteStatic.Size = new System.Drawing.Size(94, 31);
            this.btnDeleteStatic.TabIndex = 5;
            this.btnDeleteStatic.Text = "Delete";
            this.btnDeleteStatic.UseVisualStyleBackColor = true;
            this.btnDeleteStatic.Click += new System.EventHandler(this.btnDeleteStatic_Click);
            // 
            // btnRenameStatic
            // 
            this.btnRenameStatic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRenameStatic.Location = new System.Drawing.Point(216, 620);
            this.btnRenameStatic.Name = "btnRenameStatic";
            this.btnRenameStatic.Size = new System.Drawing.Size(94, 31);
            this.btnRenameStatic.TabIndex = 4;
            this.btnRenameStatic.Text = "Rename";
            this.btnRenameStatic.UseVisualStyleBackColor = true;
            this.btnRenameStatic.Click += new System.EventHandler(this.btnRenameStatic_Click);
            // 
            // btnEditStatic
            // 
            this.btnEditStatic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditStatic.Location = new System.Drawing.Point(116, 620);
            this.btnEditStatic.Name = "btnEditStatic";
            this.btnEditStatic.Size = new System.Drawing.Size(94, 31);
            this.btnEditStatic.TabIndex = 3;
            this.btnEditStatic.Text = "Edit";
            this.btnEditStatic.UseVisualStyleBackColor = true;
            this.btnEditStatic.Click += new System.EventHandler(this.btnEditStatic_Click);
            // 
            // btnNewStatic
            // 
            this.btnNewStatic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewStatic.Location = new System.Drawing.Point(16, 620);
            this.btnNewStatic.Name = "btnNewStatic";
            this.btnNewStatic.Size = new System.Drawing.Size(94, 31);
            this.btnNewStatic.TabIndex = 2;
            this.btnNewStatic.Text = "New";
            this.btnNewStatic.UseVisualStyleBackColor = true;
            this.btnNewStatic.Click += new System.EventHandler(this.btnNewStatic_Click);
            // 
            // lbStatics
            // 
            this.lbStatics.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbStatics.FormattingEnabled = true;
            this.lbStatics.Location = new System.Drawing.Point(16, 25);
            this.lbStatics.Name = "lbStatics";
            this.lbStatics.Size = new System.Drawing.Size(439, 589);
            this.lbStatics.TabIndex = 1;
            // 
            // tabAudio
            // 
            this.tabAudio.Controls.Add(this.btnAudioDelete);
            this.tabAudio.Controls.Add(this.btnAudioImport);
            this.tabAudio.Controls.Add(this.lbAudio);
            this.tabAudio.Location = new System.Drawing.Point(4, 22);
            this.tabAudio.Name = "tabAudio";
            this.tabAudio.Size = new System.Drawing.Size(468, 654);
            this.tabAudio.TabIndex = 4;
            this.tabAudio.Text = "Audio";
            this.tabAudio.UseVisualStyleBackColor = true;
            // 
            // btnAudioDelete
            // 
            this.btnAudioDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAudioDelete.Location = new System.Drawing.Point(376, 622);
            this.btnAudioDelete.Name = "btnAudioDelete";
            this.btnAudioDelete.Size = new System.Drawing.Size(75, 23);
            this.btnAudioDelete.TabIndex = 2;
            this.btnAudioDelete.Text = "Delete";
            this.btnAudioDelete.UseVisualStyleBackColor = true;
            this.btnAudioDelete.Click += new System.EventHandler(this.btnAudioDelete_Click);
            // 
            // btnAudioImport
            // 
            this.btnAudioImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAudioImport.Location = new System.Drawing.Point(19, 622);
            this.btnAudioImport.Name = "btnAudioImport";
            this.btnAudioImport.Size = new System.Drawing.Size(75, 23);
            this.btnAudioImport.TabIndex = 1;
            this.btnAudioImport.Text = "Import...";
            this.btnAudioImport.UseVisualStyleBackColor = true;
            this.btnAudioImport.Click += new System.EventHandler(this.btnAudioImport_Click);
            // 
            // lbAudio
            // 
            this.lbAudio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbAudio.FormattingEnabled = true;
            this.lbAudio.Location = new System.Drawing.Point(15, 9);
            this.lbAudio.Name = "lbAudio";
            this.lbAudio.Size = new System.Drawing.Size(436, 602);
            this.lbAudio.TabIndex = 0;
            // 
            // tabStrings
            // 
            this.tabStrings.Controls.Add(this.btnAddRow);
            this.tabStrings.Controls.Add(this.stringTableView);
            this.tabStrings.Location = new System.Drawing.Point(4, 22);
            this.tabStrings.Name = "tabStrings";
            this.tabStrings.Padding = new System.Windows.Forms.Padding(3);
            this.tabStrings.Size = new System.Drawing.Size(468, 654);
            this.tabStrings.TabIndex = 5;
            this.tabStrings.Text = "Strings";
            this.tabStrings.UseVisualStyleBackColor = true;
            // 
            // btnAddRow
            // 
            this.btnAddRow.Location = new System.Drawing.Point(345, 624);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(117, 23);
            this.btnAddRow.TabIndex = 5;
            this.btnAddRow.Text = "Add String";
            this.btnAddRow.UseVisualStyleBackColor = true;
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // stringTableView
            // 
            this.stringTableView.AllowUserToResizeRows = false;
            this.stringTableView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stringTableView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.stringTableView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stringTableView.Location = new System.Drawing.Point(0, 0);
            this.stringTableView.Name = "stringTableView";
            this.stringTableView.Size = new System.Drawing.Size(491, 618);
            this.stringTableView.TabIndex = 4;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabRooms);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1567, 712);
            this.tabControl1.TabIndex = 1;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.toolStripMenuItem1,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exportToolStripMenuItem,
            this.toolStripMenuItem3,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.closeToolStripMenuItem.Text = "Close";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(113, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(113, 6);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.exportToolStripMenuItem.Text = "Export...";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(113, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1567, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1567, 736);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "SpecED";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.tabRooms.ResumeLayout(false);
            this.roomsContainer.Panel1.ResumeLayout(false);
            this.roomsContainer.Panel1.PerformLayout();
            this.roomsContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.roomsContainer)).EndInit();
            this.roomsContainer.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControlTools.ResumeLayout(false);
            this.tabTiles.ResumeLayout(false);
            this.tabTiles.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.tabSprites.ResumeLayout(false);
            this.tabSprites.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.tabRoomDetails.ResumeLayout(false);
            this.tabRoomDetails.PerformLayout();
            this.tabStatics.ResumeLayout(false);
            this.tabAudio.ResumeLayout(false);
            this.tabStrings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stringTableView)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabPage tabRooms;
        private RoomControl roomControl;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.SplitContainer roomsContainer;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnPanRooms;
        private System.Windows.Forms.ToolStripButton btnRoomDraw;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem menuItem_RoomScale1;
        private System.Windows.Forms.ToolStripMenuItem menuItem_RoomScale2;
        private System.Windows.Forms.ToolStripMenuItem menuItem_RoomScale3;
        private System.Windows.Forms.ToolStripMenuItem menuItem_RoomScale4;
        private System.Windows.Forms.ToolStripMenuItem menuItem_RoomScale5;
        private System.Windows.Forms.ToolStripButton btnNewObject;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private ObjectPalette objectPalette;
        private System.Windows.Forms.ToolStripButton btnRoomGrid;
        private System.Windows.Forms.ToolStripButton btnEditObject;
        private System.Windows.Forms.ToolStripButton btnRoomSelect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnRoomCreate;
        private System.Windows.Forms.TabControl tabControlTools;
        private System.Windows.Forms.TabPage tabTiles;
        private System.Windows.Forms.TabPage tabSprites;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton btnNewSprite;
        private System.Windows.Forms.ToolStripButton btnEditSprite;
        private SpritePalette spritePalette;
        private System.Windows.Forms.ToolStripButton btnSetAsPlayer;
        private System.Windows.Forms.ToolStripButton btnModeSprites;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton btnDeleteSprite;
        private System.Windows.Forms.TabPage tabRoomDetails;
        private System.Windows.Forms.TextBox tbRoomTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSetTitle;
        private System.Windows.Forms.TabPage tabStatics;
        private System.Windows.Forms.Button btnNewStatic;
        private System.Windows.Forms.ListBox lbStatics;
        private System.Windows.Forms.Button btnDeleteStatic;
        private System.Windows.Forms.Button btnRenameStatic;
        private System.Windows.Forms.Button btnEditStatic;
        private System.Windows.Forms.ToolStripButton btnExport;
        private System.Windows.Forms.TabPage tabAudio;
        private System.Windows.Forms.Button btnAudioDelete;
        private System.Windows.Forms.Button btnAudioImport;
        private System.Windows.Forms.ListBox lbAudio;
        private System.Windows.Forms.DataGridView stringTableView;
        private System.Windows.Forms.TabPage tabStrings;
        private System.Windows.Forms.Button btnAddRow;
        private System.Windows.Forms.TextBox tbRoomInfoID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbRoomHash;
        private System.Windows.Forms.TextBox tbRoomY;
        private System.Windows.Forms.TextBox tbRoomX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}

