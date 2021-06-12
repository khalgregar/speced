namespace SpecEd
{
    partial class ExportForm
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
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            this.btnExport = new System.Windows.Forms.Button();
            this.tbFolder = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnTemplate = new System.Windows.Forms.Button();
            this.tbTemplate = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(12, 18);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(26, 13);
            label2.TabIndex = 4;
            label2.Text = "File:";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(200, 89);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(112, 25);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Export\r\n";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // tbFolder
            // 
            this.tbFolder.Location = new System.Drawing.Point(93, 15);
            this.tbFolder.Name = "tbFolder";
            this.tbFolder.Size = new System.Drawing.Size(329, 20);
            this.tbFolder.TabIndex = 3;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(428, 14);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(73, 21);
            this.btnBrowse.TabIndex = 5;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnTemplate
            // 
            this.btnTemplate.Location = new System.Drawing.Point(428, 40);
            this.btnTemplate.Name = "btnTemplate";
            this.btnTemplate.Size = new System.Drawing.Size(73, 21);
            this.btnTemplate.TabIndex = 10;
            this.btnTemplate.Text = "Browse...";
            this.btnTemplate.UseVisualStyleBackColor = true;
            this.btnTemplate.Click += new System.EventHandler(this.btnTemplate_Click);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 44);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(51, 13);
            label1.TabIndex = 9;
            label1.Text = "Template";
            // 
            // tbTemplate
            // 
            this.tbTemplate.Location = new System.Drawing.Point(93, 41);
            this.tbTemplate.Name = "tbTemplate";
            this.tbTemplate.Size = new System.Drawing.Size(329, 20);
            this.tbTemplate.TabIndex = 8;
            // 
            // ExportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 123);
            this.Controls.Add(this.btnTemplate);
            this.Controls.Add(label1);
            this.Controls.Add(this.tbTemplate);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(label2);
            this.Controls.Add(this.tbFolder);
            this.Controls.Add(this.btnExport);
            this.Name = "ExportForm";
            this.Text = "ExportForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TextBox tbFolder;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnTemplate;
        private System.Windows.Forms.TextBox tbTemplate;
    }
}