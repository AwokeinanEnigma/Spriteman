using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Spriteman
{
    public partial class ColorEditDialog : Form
    {
        public Color Color => this.newColor;
        public ColorEditDialog(Color color)
        {
            this.InitializeComponent();
            this.origColor = color;
            this.newColor = color;
            this.alphaBox.Value = color.A;
            this.redBox.Value = color.R;
            this.greenBox.Value = color.G;
            this.blueBox.Value = color.B;
            this.UpdateColor();
        }
        private void alphaBar_Scroll(object sender, EventArgs e)
        {
            this.alphaBox.Value = this.alphaBar.Value;
            this.UpdateColor();
        }
        private void alphaBox_ValueChanged(object sender, EventArgs e)
        {
            this.alphaBar.Value = (int)this.alphaBox.Value;
            this.UpdateColor();
        }
        private void redBar_Scroll(object sender, EventArgs e)
        {
            this.redBox.Value = this.redBar.Value;
            this.UpdateColor();
        }
        private void redBox_ValueChanged(object sender, EventArgs e)
        {
            this.redBar.Value = (int)this.redBox.Value;
            this.UpdateColor();
        }
        private void greenBar_Scroll(object sender, EventArgs e)
        {
            this.greenBox.Value = this.greenBar.Value;
            this.UpdateColor();
        }
        private void greenBox_ValueChanged(object sender, EventArgs e)
        {
            this.greenBar.Value = (int)this.greenBox.Value;
            this.UpdateColor();
        }
        private void blueBar_Scroll(object sender, EventArgs e)
        {
            this.blueBox.Value = this.blueBar.Value;
            this.UpdateColor();
        }
        private void blueBox_ValueChanged(object sender, EventArgs e)
        {
            this.blueBar.Value = (int)this.blueBox.Value;
            this.UpdateColor();
        }
        private void UpdateColor()
        {
            this.newColor = Color.FromArgb(this.alphaBar.Value, this.redBar.Value, this.greenBar.Value, this.blueBar.Value);
            this.newPreviewBox.Refresh();
            this.hexBox.TextChanged -= this.hexBox_TextChanged;
            this.hexBox.Text = string.Format("{0:x2}{1:x2}{2:x2}", this.newColor.R, this.newColor.G, this.newColor.B);
            this.hexBox.TextChanged += this.hexBox_TextChanged;
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
        private void origPreviewBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(this.origColor), new Rectangle(default(Point), this.origPreviewBox.Size));
        }
        private void newPreviewBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(this.newColor), new Rectangle(default(Point), this.origPreviewBox.Size));
        }
        private void hexBox_TextChanged(object sender, EventArgs e)
        {
            string text = this.hexBox.Text;
            if (text.Length < 6)
            {
                return;
            }
            string[] array = new string[]
            {
                text.Substring(0, 2),
                text.Substring(2, 2),
                text.Substring(4, 2)
            };
            bool flag = int.TryParse(array[0], NumberStyles.HexNumber, CultureInfo.CurrentCulture, out int num);
            bool flag2 = int.TryParse(array[1], NumberStyles.HexNumber, CultureInfo.CurrentCulture, out int num2);
            bool flag3 = int.TryParse(array[2], NumberStyles.HexNumber, CultureInfo.CurrentCulture, out int num3);
            if (flag && flag2 && flag3)
            {
                this.newColor = Color.FromArgb(this.alphaBar.Value, num, num2, num3);
                this.redBox.Value = num;
                this.greenBox.Value = num2;
                this.blueBox.Value = num3;
                this.newPreviewBox.Refresh();
            }
        }
        private readonly Color origColor;
        private Color newColor;
    }
}
