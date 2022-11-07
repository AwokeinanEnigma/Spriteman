namespace Spriteman
{
	public partial class PaletteDialog : global::System.Windows.Forms.Form
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
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Spriteman.PaletteDialog));
			this.paletteBox = new global::System.Windows.Forms.NumericUpDown();
			this.paletteLabel = new global::System.Windows.Forms.Label();
			this.cancelButton = new global::System.Windows.Forms.Button();
			this.saveButton = new global::System.Windows.Forms.Button();
			this.colorPanel = new global::System.Windows.Forms.FlowLayoutPanel();
			this.newButton = new global::System.Windows.Forms.Button();
			this.toolTip = new global::System.Windows.Forms.ToolTip(this.components);
			this.removeButton = new global::System.Windows.Forms.Button();
			this.colorDialog = new global::System.Windows.Forms.ColorDialog();
			this.colorMenu = new global::System.Windows.Forms.ContextMenuStrip(this.components);
			this.swapColorsToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.moveColorsToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new global::System.Windows.Forms.ToolStripSeparator();
			this.removeToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			((global::System.ComponentModel.ISupportInitialize)this.paletteBox).BeginInit();
			this.colorMenu.SuspendLayout();
			base.SuspendLayout();
			this.paletteBox.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.paletteBox.Location = new global::System.Drawing.Point(61, 229);
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.paletteBox;
			int[] bits = new int[4];
			numericUpDown.Maximum = new decimal(bits);
			this.paletteBox.Name = "paletteBox";
			this.paletteBox.Size = new global::System.Drawing.Size(40, 20);
			this.paletteBox.TabIndex = 0;
			this.paletteBox.ValueChanged += new global::System.EventHandler(this.paletteBox_ValueChanged);
			this.paletteLabel.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.paletteLabel.AutoSize = true;
			this.paletteLabel.Location = new global::System.Drawing.Point(12, 231);
			this.paletteLabel.Name = "paletteLabel";
			this.paletteLabel.Size = new global::System.Drawing.Size(43, 13);
			this.paletteLabel.TabIndex = 1;
			this.paletteLabel.Text = "Palette:";
			this.cancelButton.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.cancelButton.Location = new global::System.Drawing.Point(317, 226);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new global::System.Drawing.Size(55, 23);
			this.cancelButton.TabIndex = 2;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new global::System.EventHandler(this.cancelButton_Click);
			this.saveButton.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.saveButton.Location = new global::System.Drawing.Point(256, 226);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new global::System.Drawing.Size(55, 23);
			this.saveButton.TabIndex = 3;
			this.saveButton.Text = "Save";
			this.saveButton.UseVisualStyleBackColor = true;
			this.saveButton.Click += new global::System.EventHandler(this.saveButton_Click);
			this.colorPanel.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.colorPanel.AutoScroll = true;
			this.colorPanel.BackColor = global::System.Drawing.Color.White;
			this.colorPanel.Location = new global::System.Drawing.Point(12, 12);
			this.colorPanel.Name = "colorPanel";
			this.colorPanel.Size = new global::System.Drawing.Size(360, 208);
			this.colorPanel.TabIndex = 4;
			this.newButton.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.newButton.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("newButton.Image");
			this.newButton.Location = new global::System.Drawing.Point(107, 227);
			this.newButton.Name = "newButton";
			this.newButton.Size = new global::System.Drawing.Size(23, 23);
			this.newButton.TabIndex = 5;
			this.toolTip.SetToolTip(this.newButton, "Add palette");
			this.newButton.UseVisualStyleBackColor = true;
			this.newButton.Click += new global::System.EventHandler(this.newButton_Click);
			this.toolTip.ShowAlways = true;
			this.removeButton.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.removeButton.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("removeButton.Image");
			this.removeButton.Location = new global::System.Drawing.Point(136, 227);
			this.removeButton.Name = "removeButton";
			this.removeButton.Size = new global::System.Drawing.Size(23, 23);
			this.removeButton.TabIndex = 6;
			this.toolTip.SetToolTip(this.removeButton, "Remove palette");
			this.removeButton.UseVisualStyleBackColor = true;
			this.removeButton.Click += new global::System.EventHandler(this.removeButton_Click);
			this.colorDialog.AnyColor = true;
			this.colorDialog.FullOpen = true;
			this.colorDialog.SolidColorOnly = true;
			this.colorMenu.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.swapColorsToolStripMenuItem,
				this.moveColorsToolStripMenuItem,
				this.toolStripSeparator1,
				this.removeToolStripMenuItem
			});
			this.colorMenu.Name = "colorMenu";
			this.colorMenu.Size = new global::System.Drawing.Size(150, 76);
			this.swapColorsToolStripMenuItem.Name = "swapColorsToolStripMenuItem";
			this.swapColorsToolStripMenuItem.Size = new global::System.Drawing.Size(152, 22);
			this.swapColorsToolStripMenuItem.Text = "Swap Colors";
			this.swapColorsToolStripMenuItem.Click += new global::System.EventHandler(this.swapColorsToolStripMenuItem_Click);
			this.moveColorsToolStripMenuItem.Name = "moveColorsToolStripMenuItem";
			this.moveColorsToolStripMenuItem.Size = new global::System.Drawing.Size(152, 22);
			this.moveColorsToolStripMenuItem.Text = "Move Colors";
			this.moveColorsToolStripMenuItem.Click += new global::System.EventHandler(this.moveColorsToolStripMenuItem_Click);
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new global::System.Drawing.Size(149, 6);
			this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
			this.removeToolStripMenuItem.Size = new global::System.Drawing.Size(152, 22);
			this.removeToolStripMenuItem.Text = "Remove Color";
			this.removeToolStripMenuItem.Click += new global::System.EventHandler(this.removeToolStripMenuItem_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(384, 261);
			base.Controls.Add(this.removeButton);
			base.Controls.Add(this.newButton);
			base.Controls.Add(this.colorPanel);
			base.Controls.Add(this.saveButton);
			base.Controls.Add(this.cancelButton);
			base.Controls.Add(this.paletteLabel);
			base.Controls.Add(this.paletteBox);
			base.KeyPreview = true;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			this.MinimumSize = new global::System.Drawing.Size(400, 300);
			base.Name = "PaletteDialog";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Edit Palettes";
			base.Load += new global::System.EventHandler(this.PaletteDialog_Load);
			base.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.PaletteDialog_KeyDown);
			((global::System.ComponentModel.ISupportInitialize)this.paletteBox).EndInit();
			this.colorMenu.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
		private global::System.ComponentModel.IContainer components;
		private global::System.Windows.Forms.NumericUpDown paletteBox;
		private global::System.Windows.Forms.Label paletteLabel;
		private global::System.Windows.Forms.Button cancelButton;
		private global::System.Windows.Forms.Button saveButton;
		private global::System.Windows.Forms.FlowLayoutPanel colorPanel;
		private global::System.Windows.Forms.Button newButton;
		private global::System.Windows.Forms.ToolTip toolTip;
		private global::System.Windows.Forms.ColorDialog colorDialog;
		private global::System.Windows.Forms.Button removeButton;
		private global::System.Windows.Forms.ContextMenuStrip colorMenu;
		private global::System.Windows.Forms.ToolStripMenuItem swapColorsToolStripMenuItem;
		private global::System.Windows.Forms.ToolStripMenuItem moveColorsToolStripMenuItem;
		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private global::System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
	}
}
