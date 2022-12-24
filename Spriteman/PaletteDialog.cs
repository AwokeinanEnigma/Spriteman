using Spriteman.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Spriteman
{
    public partial class PaletteDialog : Form
    {
        public List<List<Color>> Palettes => this.palettes;
        public List<Tuple<int, int>> PaletteRemap => this.remap;
        public int ActivePalette => this.activePalette;
        public PaletteDialog(List<List<Color>> palettes, int activePalette)
        {
            this.InitializeComponent();
            this.palettes = palettes;
            this.activePalette = activePalette;
            this.remap = new List<Tuple<int, int>>();
        }
        private void PaletteDialog_Load(object sender, EventArgs e)
        {
            // the active palette isn't reset when you load a new .dat file


            if (this.palettes != null && this.palettes.Count > 0)
            {
                this.PopulatePanel(this.palettes[0], true);
                this.paletteBox.Maximum = this.palettes.Count - 1;
                this.paletteBox.Value = Math.Min(this.paletteBox.Maximum, this.activePalette);
                this.toolTip.SetToolTip(this.paletteLabel, string.Format("{0} colors", this.palettes[0].Count));
            }
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.OK;
            base.Close();
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            base.Close();
        }
        private PictureBox NewColorBox(Color c, int i, bool enable)
        {
            PictureBox pb = new PictureBox
            {
                Size = new Size(24, 24),
                BorderStyle = BorderStyle.None,
                BackColor = c,
                BackgroundImage = Resources.check24,
                Tag = i
            };
            pb.Paint += delegate (object sender, PaintEventArgs e)
            {
                e.Graphics.FillRectangle(new SolidBrush(pb.BackColor), new Rectangle(new Point(0, 0), pb.Size));
                e.Graphics.DrawRectangle(Pens.Black, 0, 0, pb.Size.Width - 1, pb.Size.Height - 1);
            };
            if (enable)
            {
                pb.MouseUp += this.paletteColor_Click;
            }
            this.toolTip.SetToolTip(pb, string.Format("R:{0} G:{1} B:{2} A:{3}\nDouble-click to edit color.", new object[]
            {
                c.R,
                c.G,
                c.B,
                c.A
            }));
            return pb;
        }
        private void PopulatePanel(List<Color> palette, bool enable)
        {
            this.colorPanel.Controls.Clear();
            for (int i = 0; i < palette.Count; i++)
            {
                Color c = palette[i];
                PictureBox value = this.NewColorBox(c, i, enable);
                this.colorPanel.Controls.Add(value);
            }
            this.addColorButton = new Button
            {
                Size = new Size(24, 24),
                Text = "+"
            };
            this.addColorButton.Click += this.addColorButton_Click;
            this.colorPanel.Controls.Add(this.addColorButton);
            this.toolTip.SetToolTip(this.addColorButton, "Add a new color to the palette.\nUseful when palette shifting is necessary.\nPress Ctrl+R to add the reverse of the current palette.");
        }
        private void addColorButton_Click(object sender, EventArgs e)
        {
            ColorEditDialog colorEditDialog = new ColorEditDialog(Color.White);
            int num = (int)colorEditDialog.ShowDialog(this);
            int index = (int)this.paletteBox.Value;
            int count = this.palettes[index].Count;
            if (num == 1)
            {
                PictureBox value = this.NewColorBox(colorEditDialog.Color, count, true);
                this.colorPanel.Controls.Remove(this.addColorButton);
                this.colorPanel.Controls.Add(value);
                this.colorPanel.Controls.Add(this.addColorButton);
                this.palettes[index].Add(colorEditDialog.Color);
            }
        }
        private void newButton_Click(object sender, EventArgs e)
        {
            if (this.palettes != null && this.palettes.Count > 0)
            {
                List<Color> item = new List<Color>(this.palettes[0]);
                this.palettes.Add(item);
                NumericUpDown numericUpDown = this.paletteBox;
                decimal maximum = ++numericUpDown.Maximum;
                numericUpDown.Maximum = maximum;
                numericUpDown.Maximum = maximum;
                this.paletteBox.Value = this.paletteBox.Maximum;
            }
        }
        private void paletteBox_ValueChanged(object sender, EventArgs e)
        {
            int index = (int)this.paletteBox.Value;
            this.activePalette = index;
            this.PopulatePanel(this.palettes[index], true);
        }
        private void paletteColor_Click(object sender, MouseEventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            int index = (int)this.paletteBox.Value;
            int index2 = (int)pictureBox.Tag;
            Color backColor = pictureBox.BackColor;
            if (e.Button == MouseButtons.Left)
            {
                if (this.selectedPb != null)
                {
                    this.selectedPb.BorderStyle = BorderStyle.FixedSingle;
                    if (sender.Equals(this.selectedPb))
                    {
                        ColorEditDialog colorEditDialog = new ColorEditDialog(backColor);
                        if (colorEditDialog.ShowDialog(this) == DialogResult.OK)
                        {
                            Color color = colorEditDialog.Color;
                            pictureBox.BackColor = color;
                            this.palettes[index][index2] = color;
                        }
                    }
                }
                this.selectedPb = (PictureBox)sender;
                this.selectedPb.BorderStyle = BorderStyle.Fixed3D;
                return;
            }
            if (e.Button == MouseButtons.Right)
            {
                this.subSelectedPb = (PictureBox)sender;
                bool enabled = this.selectedPb != null && this.selectedPb != sender;
                this.colorMenu.Items[0].Enabled = enabled;
                this.colorMenu.Items[1].Enabled = enabled;
                Point location = ((PictureBox)sender).Location;
                location.Offset(0, 24);
                this.colorMenu.Show(this.colorPanel, location);
            }
        }
        private void removeButton_Click(object sender, EventArgs e)
        {
            int num = (int)this.paletteBox.Value;
            if (num > 0)
            {
                this.palettes.RemoveAt(num);
                NumericUpDown numericUpDown = this.paletteBox;
                decimal num2 = --numericUpDown.Value;
                numericUpDown.Value = num2;
                numericUpDown.Value = num2;
                NumericUpDown numericUpDown2 = this.paletteBox;
                num2 = --numericUpDown2.Maximum;
                numericUpDown2.Maximum = num2;
                numericUpDown2.Maximum = num2;
            }
        }
        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = (int)this.paletteBox.Value;
            int index2 = (int)this.subSelectedPb.Tag;
            this.palettes[index].RemoveAt(index2);
            this.colorPanel.Controls.Remove(this.subSelectedPb);
            for (int i = 0; i < this.colorPanel.Controls.Count; i++)
            {
                if (this.colorPanel.Controls[i] is PictureBox)
                {
                    this.colorPanel.Controls[i].Tag = i;
                }
            }
            this.subSelectedPb = null;
        }
        private void swapColorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = (int)this.paletteBox.Value;
            int index2 = (int)this.selectedPb.Tag;
            int index3 = (int)this.subSelectedPb.Tag;
            Color color = this.subSelectedPb.BackColor;
            this.subSelectedPb.BackColor = this.selectedPb.BackColor;
            this.selectedPb.BackColor = color;
            color = this.palettes[index][index2];
            this.palettes[index][index2] = this.palettes[index][index3];
            this.palettes[index][index3] = color;
        }
        private void moveColorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.swapColorsToolStripMenuItem_Click(sender, e);
            int num = (int)this.paletteBox.Value;
            this.remap.Add(new Tuple<int, int>((int)this.selectedPb.Tag, (int)this.subSelectedPb.Tag));
        }
        private void PaletteDialog_KeyDown(object sender, KeyEventArgs e)
        {
            int index = (int)this.paletteBox.Value;
            if (e.Control && e.KeyCode == Keys.R)
            {
                Color[] array = this.palettes[index].ToArray();
                Array.Reverse(array);
                this.colorPanel.Controls.Remove(this.addColorButton);
                for (int i = 0; i < array.Length; i++)
                {
                    PictureBox value = this.NewColorBox(array[i], array.Length + i, true);
                    this.colorPanel.Controls.Add(value);
                    this.palettes[index].Add(array[i]);
                }
                this.colorPanel.Controls.Add(this.addColorButton);
            }
        }
        private readonly List<List<Color>> palettes;
        private readonly List<Tuple<int, int>> remap;
        private int activePalette;
        private Button addColorButton;
        private PictureBox selectedPb;
        private PictureBox subSelectedPb;
    }
}
