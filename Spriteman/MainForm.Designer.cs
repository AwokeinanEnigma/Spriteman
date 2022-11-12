using Spriteman.Properties;

namespace Spriteman
{
	public partial class MainForm : global::System.Windows.Forms.Form
	{
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}
		private void InitializeComponent()
		{
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.openButton = new System.Windows.Forms.ToolStripButton();
            this.saveButton = new System.Windows.Forms.ToolStripButton();
            this.saveAsButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.importButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.addSpriteButton = new System.Windows.Forms.ToolStripButton();
            this.removeSpriteButton = new System.Windows.Forms.ToolStripButton();
            this.duplicateSpriteButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.paletteButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.previewPanel = new System.Windows.Forms.Panel();
            this.sheetBox = new System.Windows.Forms.PictureBox();
            this.spriteList = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCoords = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBounds = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOrigin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFrames = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSpeed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFlipX = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFlipY = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.openImageDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveImageDialog = new System.Windows.Forms.SaveFileDialog();
            this.importImageDialog = new System.Windows.Forms.OpenFileDialog();
            this.openFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.previewPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sheetBox)).BeginInit();
            this.SuspendLayout();
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openButton,
            this.saveButton,
            this.saveAsButton,
            this.toolStripSeparator1,
            this.importButton,
            this.toolStripSeparator3,
            this.addSpriteButton,
            this.removeSpriteButton,
            this.duplicateSpriteButton,
            this.toolStripSeparator2,
            this.paletteButton,
            this.toolStripButton1,
            this.toolStripButton4,
            this.toolStripButton2});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(784, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            this.openButton.Image = global::Spriteman.Properties.Resources.openButton;
            this.openButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(56, 22);
            this.openButton.Text = "Open";
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            this.saveButton.Enabled = false;
            this.saveButton.Image = global::Spriteman.Properties.Resources.saveButton;
            this.saveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(51, 22);
            this.saveButton.Text = "Save";
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            this.saveAsButton.Enabled = false;
            this.saveAsButton.Image = global::Spriteman.Properties.Resources.saveAsButton;
            this.saveAsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveAsButton.Name = "saveAsButton";
            this.saveAsButton.Size = new System.Drawing.Size(67, 22);
            this.saveAsButton.Text = "Save As";
            this.saveAsButton.Click += new System.EventHandler(this.saveAsButton_Click);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            this.importButton.Enabled = false;
            this.importButton.Image = global::Spriteman.Properties.Resources.importButton;
            this.importButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(104, 22);
            this.importButton.Text = "Change Image";
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            this.addSpriteButton.Enabled = false;
            this.addSpriteButton.Image = global::Spriteman.Properties.Resources.addSpriteButton;
            this.addSpriteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addSpriteButton.Name = "addSpriteButton";
            this.addSpriteButton.Size = new System.Drawing.Size(82, 22);
            this.addSpriteButton.Text = "Add Sprite";
            this.addSpriteButton.Click += new System.EventHandler(this.addSpriteButton_Click);
            this.removeSpriteButton.Enabled = false;
            this.removeSpriteButton.Image = global::Spriteman.Properties.Resources.removeSpriteButton;
            this.removeSpriteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removeSpriteButton.Name = "removeSpriteButton";
            this.removeSpriteButton.Size = new System.Drawing.Size(103, 22);
            this.removeSpriteButton.Text = "Remove Sprite";
            this.removeSpriteButton.Click += new System.EventHandler(this.removeSpriteButton_Click);
            this.duplicateSpriteButton.Enabled = false;
            this.duplicateSpriteButton.Image = global::Spriteman.Properties.Resources.duplicateSpriteButton;
            this.duplicateSpriteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.duplicateSpriteButton.Name = "duplicateSpriteButton";
            this.duplicateSpriteButton.Size = new System.Drawing.Size(110, 22);
            this.duplicateSpriteButton.Text = "Duplicate Sprite";
            this.duplicateSpriteButton.Click += new System.EventHandler(this.duplicateSpriteButton_Click);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            this.paletteButton.Enabled = false;
            this.paletteButton.Image = global::Spriteman.Properties.Resources.paletteButton;
            this.paletteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.paletteButton.Name = "paletteButton";
            this.paletteButton.Size = new System.Drawing.Size(68, 22);
            this.paletteButton.Text = "Palettes";
            this.paletteButton.Click += new System.EventHandler(this.paletteButton_Click);
            this.toolStripButton1.Image = global::Spriteman.Properties.Resources.openButton;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(80, 22);
            this.toolStripButton1.Text = "Extract All";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            this.toolStripButton4.Enabled = false;
            this.toolStripButton4.Image = global::Spriteman.Properties.Resources.duplicateSpriteButton;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(92, 20);
            this.toolStripButton4.Text = "Save as PNG";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            this.toolStripButton2.Image = global::Spriteman.Properties.Resources.duplicateSpriteButton;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(100, 20);
            this.toolStripButton2.Text = "Extract EN_US";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 25);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitContainer.Panel1.Controls.Add(this.previewPanel);
            this.splitContainer.Panel1MinSize = 240;
            this.splitContainer.Panel2.Controls.Add(this.spriteList);
            this.splitContainer.Panel2MinSize = 120;
            this.splitContainer.Size = new System.Drawing.Size(784, 536);
            this.splitContainer.SplitterDistance = 261;
            this.splitContainer.TabIndex = 2;
            this.splitContainer.TabStop = false;
            this.previewPanel.AutoScroll = true;
            this.previewPanel.Controls.Add(this.sheetBox);
            this.previewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewPanel.Location = new System.Drawing.Point(0, 0);
            this.previewPanel.Name = "previewPanel";
            this.previewPanel.Size = new System.Drawing.Size(784, 261);
            this.previewPanel.TabIndex = 1;
            this.sheetBox.BackColor = System.Drawing.Color.Transparent;
            this.sheetBox.BackgroundImage = global::Spriteman.Properties.Resources.check;
            this.sheetBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sheetBox.Location = new System.Drawing.Point(0, 0);
            this.sheetBox.Name = "sheetBox";
            this.sheetBox.Size = new System.Drawing.Size(784, 261);
            this.sheetBox.TabIndex = 0;
            this.sheetBox.TabStop = false;
            this.sheetBox.Paint += new System.Windows.Forms.PaintEventHandler(this.sheetBox_Paint);
            this.spriteList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colCoords,
            this.colBounds,
            this.colOrigin,
            this.colFrames,
            this.colSpeed,
            this.colFlipX,
            this.colFlipY,
            this.colMode});
            this.spriteList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spriteList.FullRowSelect = true;
            this.spriteList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.spriteList.HideSelection = false;
            this.spriteList.Location = new System.Drawing.Point(0, 0);
            this.spriteList.MultiSelect = false;
            this.spriteList.Name = "spriteList";
            this.spriteList.Size = new System.Drawing.Size(784, 271);
            this.spriteList.TabIndex = 1;
            this.spriteList.TabStop = false;
            this.spriteList.UseCompatibleStateImageBehavior = false;
            this.spriteList.View = System.Windows.Forms.View.Details;
            this.spriteList.SelectedIndexChanged += new System.EventHandler(this.spriteList_SelectedIndexChanged);
            this.spriteList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.spriteList_KeyDown);
            this.spriteList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.spriteList_MouseDoubleClick);
            this.colName.Text = "Sprite";
            this.colName.Width = 120;
            this.colCoords.Text = "Coords";
            this.colCoords.Width = 80;
            this.colBounds.Text = "Bounds";
            this.colBounds.Width = 80;
            this.colOrigin.Text = "Origin";
            this.colOrigin.Width = 80;
            this.colFrames.Text = "Frames";
            this.colSpeed.Text = "Speed";
            this.colFlipX.Text = "Flip X";
            this.colFlipX.Width = 40;
            this.colFlipY.Text = "Flip Y";
            this.colFlipY.Width = 40;
            this.colMode.Text = "Mode";
            this.colMode.Width = 40;
            this.openImageDialog.Filter = "All supported files|*.dat;*.bmp;*.png|Sprite files|*.dat|Image files|*.bmp;*.png|" +
    "All files|*.*";
            this.openImageDialog.Title = "Open Image";
            this.saveImageDialog.Filter = "Violet Sprite|*.dat";
            this.saveImageDialog.Title = "Save Image";
            this.importImageDialog.Filter = "Image files|*.bmp;*.png";
            this.importImageDialog.Title = "Import Image";
            this.openFolderDialog.Description = "Open Folder";
            this.saveFileDialog1.Filter = "PNG File|*.png";
            this.saveFileDialog1.Title = "Save Image";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.toolStrip);
            this.DoubleBuffered = true;
            this.Icon = global::Spriteman.Properties.Resources._this;
            this.MinimumSize = new System.Drawing.Size(600, 480);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Spriteman";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.previewPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sheetBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private global::System.ComponentModel.IContainer components;
		private global::System.Windows.Forms.ToolStrip toolStrip;
		private global::System.Windows.Forms.SplitContainer splitContainer;
		private global::System.Windows.Forms.PictureBox sheetBox;
		private global::System.Windows.Forms.ListView spriteList;
		private global::System.Windows.Forms.ColumnHeader colName;
		private global::System.Windows.Forms.ColumnHeader colCoords;
		private global::System.Windows.Forms.ColumnHeader colBounds;
		private global::System.Windows.Forms.ColumnHeader colOrigin;
		private global::System.Windows.Forms.ColumnHeader colFrames;
		private global::System.Windows.Forms.ColumnHeader colSpeed;
		private global::System.Windows.Forms.ColumnHeader colFlipX;
		private global::System.Windows.Forms.ToolStripButton openButton;
		private global::System.Windows.Forms.ToolStripButton saveButton;
		private global::System.Windows.Forms.ToolStripButton saveAsButton;
		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private global::System.Windows.Forms.ToolStripButton addSpriteButton;
		private global::System.Windows.Forms.ToolStripButton removeSpriteButton;
		private global::System.Windows.Forms.OpenFileDialog openImageDialog;
		private global::System.Windows.Forms.SaveFileDialog saveImageDialog;
		private global::System.Windows.Forms.ColumnHeader colFlipY;
		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private global::System.Windows.Forms.ToolStripButton paletteButton;
		private global::System.Windows.Forms.ToolStripButton importButton;
		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private global::System.Windows.Forms.OpenFileDialog importImageDialog;
		private global::System.Windows.Forms.ColumnHeader colMode;
		private global::System.Windows.Forms.Panel previewPanel;
		private global::System.Windows.Forms.ToolStripButton duplicateSpriteButton;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.FolderBrowserDialog openFolderDialog;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}
