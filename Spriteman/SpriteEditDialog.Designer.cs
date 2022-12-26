namespace Spriteman
{
	public partial class SpriteEditDialog : global::System.Windows.Forms.Form
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
            this.components = new System.ComponentModel.Container();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.originBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.boundsBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.coordsBox = new System.Windows.Forms.TextBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.framesBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.speedBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.flipXBox = new System.Windows.Forms.CheckBox();
            this.flipYBox = new System.Windows.Forms.CheckBox();
            this.previewBox = new System.Windows.Forms.PictureBox();
            this.extrasMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showGuidesItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showShadowItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frameTimer = new System.Windows.Forms.Timer(this.components);
            this.animateButton = new System.Windows.Forms.Button();
            this.modeBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.stepButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).BeginInit();
            this.extrasMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(256, 286);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(55, 23);
            this.okButton.TabIndex = 9;
            this.okButton.Text = "Save";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(317, 286);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(55, 23);
            this.cancelButton.TabIndex = 10;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 258);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Origin:";
            // 
            // originBox
            // 
            this.originBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.originBox.Location = new System.Drawing.Point(73, 255);
            this.originBox.Name = "originBox";
            this.originBox.Size = new System.Drawing.Size(100, 20);
            this.originBox.TabIndex = 4;
            this.originBox.TextChanged += new System.EventHandler(this.tbBounds_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 232);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Bounds:";
            // 
            // boundsBox
            // 
            this.boundsBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.boundsBox.Location = new System.Drawing.Point(73, 229);
            this.boundsBox.Name = "boundsBox";
            this.boundsBox.Size = new System.Drawing.Size(100, 20);
            this.boundsBox.TabIndex = 3;
            this.boundsBox.TextChanged += new System.EventHandler(this.tbBounds_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Coords:";
            // 
            // coordsBox
            // 
            this.coordsBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.coordsBox.Location = new System.Drawing.Point(73, 203);
            this.coordsBox.Name = "coordsBox";
            this.coordsBox.Size = new System.Drawing.Size(100, 20);
            this.coordsBox.TabIndex = 2;
            this.coordsBox.TextChanged += new System.EventHandler(this.tbBounds_TextChanged);
            // 
            // nameBox
            // 
            this.nameBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nameBox.Location = new System.Drawing.Point(73, 177);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(100, 20);
            this.nameBox.TabIndex = 1;
            this.nameBox.TextChanged += new System.EventHandler(this.nameBox_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // framesBox
            // 
            this.framesBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.framesBox.Location = new System.Drawing.Point(256, 177);
            this.framesBox.Name = "framesBox";
            this.framesBox.Size = new System.Drawing.Size(100, 20);
            this.framesBox.TabIndex = 5;
            this.framesBox.TextChanged += new System.EventHandler(this.tbFrames_TextChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(206, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Frames:";
            // 
            // speedBox
            // 
            this.speedBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.speedBox.Location = new System.Drawing.Point(256, 203);
            this.speedBox.Name = "speedBox";
            this.speedBox.Size = new System.Drawing.Size(100, 20);
            this.speedBox.TabIndex = 6;
            this.speedBox.TextChanged += new System.EventHandler(this.tbSpeed_TextChanged);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(209, 206);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Speed:";
            // 
            // flipXBox
            // 
            this.flipXBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.flipXBox.AutoSize = true;
            this.flipXBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.flipXBox.Location = new System.Drawing.Point(215, 257);
            this.flipXBox.Name = "flipXBox";
            this.flipXBox.Size = new System.Drawing.Size(55, 17);
            this.flipXBox.TabIndex = 7;
            this.flipXBox.Text = "Flip X:";
            this.flipXBox.UseVisualStyleBackColor = true;
            this.flipXBox.CheckedChanged += new System.EventHandler(this.flipXBox_CheckedChanged);
            // 
            // flipYBox
            // 
            this.flipYBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.flipYBox.AutoSize = true;
            this.flipYBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.flipYBox.Location = new System.Drawing.Point(301, 257);
            this.flipYBox.Name = "flipYBox";
            this.flipYBox.Size = new System.Drawing.Size(55, 17);
            this.flipYBox.TabIndex = 8;
            this.flipYBox.Text = "Flip Y:";
            this.flipYBox.UseVisualStyleBackColor = true;
            this.flipYBox.CheckedChanged += new System.EventHandler(this.flipYBox_CheckedChanged);
            // 
            // previewBox
            // 
            this.previewBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.previewBox.BackColor = System.Drawing.Color.White;
            this.previewBox.BackgroundImage = global::Spriteman.Properties.Resources.check;
            this.previewBox.ContextMenuStrip = this.extrasMenu;
            this.previewBox.Location = new System.Drawing.Point(0, 0);
            this.previewBox.Name = "previewBox";
            this.previewBox.Size = new System.Drawing.Size(384, 171);
            this.previewBox.TabIndex = 0;
            this.previewBox.TabStop = false;
            this.previewBox.Paint += new System.Windows.Forms.PaintEventHandler(this.previewBox_Paint);
            // 
            // extrasMenu
            // 
            this.extrasMenu.AllowDrop = true;
            this.extrasMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showGuidesItem,
            this.showShadowItem});
            this.extrasMenu.Name = "extrasMenu";
            this.extrasMenu.Size = new System.Drawing.Size(149, 48);
            // 
            // showGuidesItem
            // 
            this.showGuidesItem.Name = "showGuidesItem";
            this.showGuidesItem.Size = new System.Drawing.Size(148, 22);
            this.showGuidesItem.Text = "Show Guides";
            this.showGuidesItem.Click += new System.EventHandler(this.showGuidesItem_Click);
            // 
            // showShadowItem
            // 
            this.showShadowItem.Name = "showShadowItem";
            this.showShadowItem.Size = new System.Drawing.Size(148, 22);
            this.showShadowItem.Text = "Show Shadow";
            this.showShadowItem.Click += new System.EventHandler(this.showShadowItem_Click);
            // 
            // frameTimer
            // 
            this.frameTimer.Tick += new System.EventHandler(this.frameTimer_Tick);
            // 
            // animateButton
            // 
            this.animateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.animateButton.Location = new System.Drawing.Point(12, 286);
            this.animateButton.Name = "animateButton";
            this.animateButton.Size = new System.Drawing.Size(55, 23);
            this.animateButton.TabIndex = 14;
            this.animateButton.Text = "Animate";
            this.animateButton.UseVisualStyleBackColor = true;
            this.animateButton.Click += new System.EventHandler(this.animateButton_Click);
            // 
            // modeBox
            // 
            this.modeBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.modeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modeBox.FormattingEnabled = true;
            this.modeBox.Items.AddRange(new object[] {
            "Continuous",
            "1-2-1-3"});
            this.modeBox.Location = new System.Drawing.Point(256, 229);
            this.modeBox.Name = "modeBox";
            this.modeBox.Size = new System.Drawing.Size(100, 21);
            this.modeBox.TabIndex = 15;
            this.modeBox.SelectedIndexChanged += new System.EventHandler(this.modeBox_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(213, 233);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Mode:";
            // 
            // stepButton
            // 
            this.stepButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.stepButton.Location = new System.Drawing.Point(73, 286);
            this.stepButton.Name = "stepButton";
            this.stepButton.Size = new System.Drawing.Size(40, 23);
            this.stepButton.TabIndex = 17;
            this.stepButton.Text = "Step";
            this.stepButton.UseVisualStyleBackColor = true;
            this.stepButton.Click += new System.EventHandler(this.stepButton_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(119, 286);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "Show Guide";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SpriteEditDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 312);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.stepButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.modeBox);
            this.Controls.Add(this.animateButton);
            this.Controls.Add(this.flipYBox);
            this.Controls.Add(this.flipXBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.speedBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.framesBox);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.previewBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.originBox);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.coordsBox);
            this.Controls.Add(this.boundsBox);
            this.Controls.Add(this.label2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 480);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "SpriteEditDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Sprite";
            this.Load += new System.EventHandler(this.SpriteEditDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).EndInit();
            this.extrasMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private global::System.ComponentModel.IContainer components;
		private global::System.Windows.Forms.PictureBox previewBox;
		private global::System.Windows.Forms.TextBox nameBox;
		private global::System.Windows.Forms.Label label1;
		private global::System.Windows.Forms.Button okButton;
		private global::System.Windows.Forms.Button cancelButton;
		private global::System.Windows.Forms.Label label4;
		private global::System.Windows.Forms.TextBox originBox;
		private global::System.Windows.Forms.Label label3;
		private global::System.Windows.Forms.TextBox boundsBox;
		private global::System.Windows.Forms.Label label2;
		private global::System.Windows.Forms.TextBox coordsBox;
		private global::System.Windows.Forms.TextBox framesBox;
		private global::System.Windows.Forms.Label label5;
		private global::System.Windows.Forms.TextBox speedBox;
		private global::System.Windows.Forms.Label label6;
		private global::System.Windows.Forms.CheckBox flipXBox;
		private global::System.Windows.Forms.CheckBox flipYBox;
		private global::System.Windows.Forms.Timer frameTimer;
		private global::System.Windows.Forms.Button animateButton;
		private global::System.Windows.Forms.ComboBox modeBox;
		private global::System.Windows.Forms.Label label7;
		private global::System.Windows.Forms.Button stepButton;
		private global::System.Windows.Forms.ContextMenuStrip extrasMenu;
		private global::System.Windows.Forms.ToolStripMenuItem showGuidesItem;
		private global::System.Windows.Forms.ToolStripMenuItem showShadowItem;
        private System.Windows.Forms.Button button1;
    }
}
