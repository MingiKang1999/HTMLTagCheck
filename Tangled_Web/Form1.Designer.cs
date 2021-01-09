namespace Tangled_Web
{
    partial class fileCheckerForm
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
            this.fileMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.fileLoadMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.fileExitMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.processMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.processCheckMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.fileLabel = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.fileListBox = new System.Windows.Forms.ListBox();
            this.fileMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileMenuStrip
            // 
            this.fileMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.fileMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.processMenu});
            this.fileMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.fileMenuStrip.Name = "fileMenuStrip";
            this.fileMenuStrip.Padding = new System.Windows.Forms.Padding(11, 3, 0, 3);
            this.fileMenuStrip.Size = new System.Drawing.Size(387, 30);
            this.fileMenuStrip.TabIndex = 0;
            this.fileMenuStrip.Text = "menuStrip1";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileLoadMenu,
            this.fileExitMenu});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(46, 24);
            this.fileMenu.Text = "&File";
            // 
            // fileLoadMenu
            // 
            this.fileLoadMenu.Name = "fileLoadMenu";
            this.fileLoadMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.fileLoadMenu.Size = new System.Drawing.Size(210, 26);
            this.fileLoadMenu.Text = "&Load File...";
            this.fileLoadMenu.Click += new System.EventHandler(this.fileLoadMenu_Click);
            // 
            // fileExitMenu
            // 
            this.fileExitMenu.Name = "fileExitMenu";
            this.fileExitMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.fileExitMenu.Size = new System.Drawing.Size(210, 26);
            this.fileExitMenu.Text = "E&xit";
            this.fileExitMenu.Click += new System.EventHandler(this.fileExitMenu_Click);
            // 
            // processMenu
            // 
            this.processMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.processCheckMenu});
            this.processMenu.Name = "processMenu";
            this.processMenu.Size = new System.Drawing.Size(72, 24);
            this.processMenu.Text = "&Process";
            // 
            // processCheckMenu
            // 
            this.processCheckMenu.Enabled = false;
            this.processCheckMenu.Name = "processCheckMenu";
            this.processCheckMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.processCheckMenu.Size = new System.Drawing.Size(215, 26);
            this.processCheckMenu.Text = "&Check Tags";
            this.processCheckMenu.Click += new System.EventHandler(this.processCheckMenu_Click);
            // 
            // fileLabel
            // 
            this.fileLabel.AutoSize = true;
            this.fileLabel.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.fileLabel.Location = new System.Drawing.Point(13, 39);
            this.fileLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fileLabel.Name = "fileLabel";
            this.fileLabel.Size = new System.Drawing.Size(150, 20);
            this.fileLabel.TabIndex = 1;
            this.fileLabel.Text = "No File Loaded";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "HTML files(*.htm; *html)|*.html";
            this.openFileDialog.InitialDirectory = "TestFiles";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // fileListBox
            // 
            this.fileListBox.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileListBox.FormattingEnabled = true;
            this.fileListBox.ItemHeight = 21;
            this.fileListBox.Location = new System.Drawing.Point(17, 94);
            this.fileListBox.Name = "fileListBox";
            this.fileListBox.Size = new System.Drawing.Size(314, 256);
            this.fileListBox.TabIndex = 2;
            // 
            // fileCheckerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 394);
            this.Controls.Add(this.fileListBox);
            this.Controls.Add(this.fileLabel);
            this.Controls.Add(this.fileMenuStrip);
            this.Font = new System.Drawing.Font("Haan Baekje B", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.MainMenuStrip = this.fileMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "fileCheckerForm";
            this.Text = "Harry\'s Simple HTML File Checker";
            this.fileMenuStrip.ResumeLayout(false);
            this.fileMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip fileMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem processMenu;
        private System.Windows.Forms.ToolStripMenuItem fileLoadMenu;
        private System.Windows.Forms.ToolStripMenuItem fileExitMenu;
        private System.Windows.Forms.ToolStripMenuItem processCheckMenu;
        private System.Windows.Forms.Label fileLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ListBox fileListBox;
    }
}

