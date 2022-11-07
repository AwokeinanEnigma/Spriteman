using Spriteman.Properties;
using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Spriteman
{
    public partial class SpriteEditDialog : Form
    {
        public Sprite SpriteResult => this.sprite;
        public SpriteEditDialog(Bitmap sheet, Sprite sprite)
        {
            this.InitializeComponent();
            this.sheet = sheet;
            this.sprite = sprite;
        }
        private void SpriteEditDialog_Load(object sender, EventArgs e)
        {
            this.isSetup = false;
            this.showGuides = false;
            this.showShadow = false;
            this.showGuidesItem.Checked = this.showGuides;
            this.showShadowItem.Checked = this.showShadow;
            this.nameBox.Text = this.sprite.Name;
            this.coordsBox.Text = string.Format("{0},{1}", this.sprite.Coords.X, this.sprite.Coords.Y);
            this.boundsBox.Text = string.Format("{0},{1}", this.sprite.Bounds.Width, this.sprite.Bounds.Height);
            this.originBox.Text = string.Format("{0},{1}", this.sprite.Origin.X, this.sprite.Origin.Y);
            this.framesBox.Text = this.sprite.Frames.ToString();
            this.speedBox.Text = ArrayPrinter.Print<float>(this.sprite.SpeedSet);
            this.flipXBox.Checked = this.sprite.FlipX;
            this.flipYBox.Checked = this.sprite.FlipY;
            this.modeBox.SelectedIndex = this.sprite.Mode;
            this.isSetup = true;
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            base.Close();
        }
        private void okButton_Click(object sender, EventArgs e)
        {
            this.UpdateSprite();
            base.DialogResult = DialogResult.OK;
            base.Close();
        }
        private void UpdateSprite()
        {
            if (!this.isSetup)
            {
                return;
            }
            this.sprite.Name = this.nameBox.Text;
            try
            {
                string[] array = this.coordsBox.Text.Split(new char[]
                {
                    ','
                }, 2);
                Point coords = new Point(int.Parse(array[0]), int.Parse(array[1]));
                this.sprite.Coords = coords;
            }
            catch
            {
                this.sprite.Coords = default(Point);
            }
            try
            {
                string[] array2 = this.boundsBox.Text.Split(new char[]
                {
                    ','
                }, 2);
                Size bounds = new Size(int.Parse(array2[0]), int.Parse(array2[1]));
                this.sprite.Bounds = bounds;
            }
            catch
            {
                this.sprite.Bounds = default(Size);
            }
            try
            {
                string[] array3 = this.originBox.Text.Split(new char[]
                {
                    ','
                }, 2);
                Point origin = new Point(int.Parse(array3[0]), int.Parse(array3[1]));
                this.sprite.Origin = origin;
            }
            catch
            {
                this.sprite.Origin = default(Point);
            }
            try
            {
                this.sprite.Frames = int.Parse(this.framesBox.Text);
            }
            catch
            {
                this.sprite.Frames = 0;
            }
            this.sprite.SpeedSet = this.speeds;
            this.sprite.FlipX = this.flipXBox.Checked;
            this.sprite.FlipY = this.flipYBox.Checked;
            this.sprite.Mode = this.modeBox.SelectedIndex;
        }
        private void nameBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (Regex.Match(textBox.Text, ".+").Success)
            {
                textBox.Tag = true;
                textBox.BackColor = SystemColors.Window;
            }
            else
            {
                textBox.Tag = false;
                textBox.BackColor = Color.Red;
            }
            this.UpdateForm();
        }
        private void tbBounds_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (Regex.Match(textBox.Text, "^[0-9]+,[0-9]+$").Success)
            {
                textBox.Tag = true;
                textBox.BackColor = SystemColors.Window;
            }
            else
            {
                textBox.Tag = false;
                textBox.BackColor = Color.Red;
            }
            this.UpdateForm();
        }
        private void tbFrames_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (Regex.Match(textBox.Text, "^\\d+$").Success)
            {
                textBox.Tag = true;
                textBox.BackColor = SystemColors.Window;
                this.frames = int.Parse(textBox.Text);
                this.frame = 0;
                this.offset = 0;
            }
            else
            {
                textBox.Tag = false;
                textBox.BackColor = Color.Red;
            }
            this.UpdateForm();
        }
        private void tbSpeed_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string[] array = textBox.Text.Split(new char[]
            {
                ','
            });
            bool flag = array.Length == 0;
            float[] array2 = new float[array.Length];
            int num = 0;
            while (num < array.Length && !flag)
            {
                if (!Regex.Match(array[num], "^[-+]?[0-9]*\\.?[0-9]+$").Success)
                {
                    flag = true;
                    break;
                }
                textBox.Tag = true;
                textBox.BackColor = SystemColors.Window;
                array2[num] = float.Parse(array[num]);
                num++;
            }
            if (flag)
            {
                textBox.Tag = false;
                textBox.BackColor = Color.Red;
                this.frameTimer.Enabled = false;
            }
            else
            {
                this.speeds = array2;
            }
            this.UpdateForm();
        }
        private void flipXBox_CheckedChanged(object sender, EventArgs e)
        {
            this.UpdateForm();
        }
        private void flipYBox_CheckedChanged(object sender, EventArgs e)
        {
            this.UpdateForm();
        }
        private void modeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdateForm();
        }
        private void UpdateForm()
        {
            if (this.UpdateOKStatus())
            {
                this.UpdateSprite();
                this.previewBox.Refresh();
            }
        }
        private bool UpdateOKStatus()
        {
            this.okButton.Enabled = true;
            foreach (object obj in base.Controls)
            {
                Control control = (Control)obj;
                if (control is TextBox)
                {
                    TextBox textBox = (TextBox)control;
                    if (textBox.Tag != null && !(bool)textBox.Tag)
                    {
                        this.okButton.Enabled = false;
                    }
                }
            }
            return this.okButton.Enabled;
        }
        private void previewBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            if (this.sprite.Bounds.Width > 0 && this.sprite.Bounds.Height > 0)
            {
                Point location = new Point(this.sprite.Coords.X + this.offset, this.sprite.Coords.Y);
                Rectangle srcRect = new Rectangle(location, this.sprite.Bounds);
                Rectangle destRect = new Rectangle(0, 0, srcRect.Width, srcRect.Height);
                graphics.TranslateTransform(this.previewBox.Width / 2, this.previewBox.Height / 2);
                if (this.showGuides)
                {
                    graphics.DrawLine(Pens.Black, -500, 0, 500, 0);
                    graphics.DrawLine(Pens.Black, 0, -500, 0, 500);
                }
                if (this.showShadow)
                {
                    graphics.DrawImage(Resources.shadow, -8, -1);
                }
                graphics.ScaleTransform(this.sprite.FlipX ? -1 : 1, this.sprite.FlipY ? -1 : 1);
                graphics.TranslateTransform(-sprite.Origin.X, -sprite.Origin.Y);
                graphics.DrawImage(this.sheet, destRect, srcRect, GraphicsUnit.Pixel);
            }
        }
        private void frameTimer_Tick(object sender, EventArgs e)
        {
            if (this.sprite.Mode == 1)
            {
                this.frame = (this.frame + 1) % 4;
                this.offset = this.sprite.Bounds.Width * this.staggerFrames[this.frame];
            }
            else
            {
                this.frame = (this.frame + 1) % this.frames;
                this.offset = this.sprite.Bounds.Width * this.frame;
            }
            this.speedIndex = (this.speedIndex + 1) % this.speeds.Length;
            int val = (int)(16.67 / this.speeds[this.speedIndex]);
            this.frameTimer.Interval = Math.Max(1, val);
            this.previewBox.Refresh();
        }
        private void animateButton_Click(object sender, EventArgs e)
        {
            if (!this.isAnimating)
            {
                int val = (int)(16.67 / this.speeds[this.speedIndex]);
                this.frameTimer.Interval = Math.Max(1, val);
                this.frameTimer.Start();
                this.isAnimating = true;
                this.animateButton.Text = "Stop";
                return;
            }
            this.frameTimer.Stop();
            this.isAnimating = false;
            this.animateButton.Text = "Animate";
        }
        private void stepButton_Click(object sender, EventArgs e)
        {
            this.frameTimer_Tick(sender, e);
        }
        private void showGuidesItem_Click(object sender, EventArgs e)
        {
            this.showGuides = !this.showGuides;
            this.showGuidesItem.Checked = this.showGuides;
            this.previewBox.Refresh();
        }
        private void showShadowItem_Click(object sender, EventArgs e)
        {
            this.showShadow = !this.showShadow;
            this.showShadowItem.Checked = this.showShadow;
            this.previewBox.Refresh();
        }
        private bool isSetup;
        private bool isAnimating;
        private bool showGuides;
        private bool showShadow;
        private readonly Bitmap sheet;
        private readonly Sprite sprite;
        private int frames;
        private int frame;
        private int offset;
        private int speedIndex;
        private float[] speeds;
        private readonly int[] staggerFrames = new int[]
        {
            0,
            1,
            0,
            2
        };
    }
}
