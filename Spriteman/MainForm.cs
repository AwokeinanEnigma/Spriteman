using fNbt;
using Spriteman.Exceptions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Spriteman
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            this.InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.activePalette = 0;
            string[] commandLineArgs = Environment.GetCommandLineArgs();
            if (commandLineArgs.Length > 1)
            {
                string text = commandLineArgs[1];
                if (File.Exists(text))
                {
                    this.LoadFile(text);
                }
            }
        }
        private void spriteList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                MessageBox.Show("delete");
            }
        }
        private void LoadFile(string filename)
        {
            this.isLoaded = false;
            this.LoadSpriteSheet(filename);
            if (this.isLoaded)
            {
                this.saveButton.Enabled = true;
                this.saveAsButton.Enabled = true;
                this.importButton.Enabled = true;
                this.toolStripButton4.Enabled = true;
                this.addSpriteButton.Enabled = true;
                this.paletteButton.Enabled = true;
            }
        }
        private void openButton_Click(object sender, EventArgs e)
        {
            if (this.openImageDialog.ShowDialog(this) == DialogResult.OK)
            {
                this.LoadFile(this.openImageDialog.FileName);
            }
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (this.workingFileName != null)
            {
                this.SaveSpriteSheet(this.workingFileName);
                return;
            }
            this.saveAsButton_Click(sender, e);
        }
        private void saveAsButton_Click(object sender, EventArgs e)
        {
            if (this.saveImageDialog.ShowDialog(this) == DialogResult.OK)
            {
                this.SaveSpriteSheet(this.saveImageDialog.FileName);
                this.workingFileName = this.saveImageDialog.FileName;
            }
        }
        private void addSpriteButton_Click(object sender, EventArgs e)
        {
            this.AddSpriteRow(string.Format("untitled{0}", this.spriteList.Items.Count));
        }
        private void removeSpriteButton_Click(object sender, EventArgs e)
        {
            if (this.spriteList.SelectedItems.Count > 0)
            {
                this.spriteList.Items.Remove(this.spriteList.SelectedItems[0]);
            }
        }
        private void duplicateSpriteButton_Click(object sender, EventArgs e)
        {
            if (this.spriteList.SelectedItems.Count > 0)
            {
                Sprite sprite = (Sprite)this.spriteList.SelectedItems[0].Tag;
                Sprite sprite2 = new Sprite(string.Format("untitled{0}", this.spriteList.Items.Count), sprite.Coords, sprite.Bounds, sprite.Origin, sprite.Frames, sprite.SpeedSet, sprite.FlipX, sprite.FlipY, sprite.Mode);
                this.AddSpriteRow(sprite2);
            }
        }
        private void spriteList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem listViewItem = this.spriteList.SelectedItems[0];
            Sprite sprite = (Sprite)listViewItem.Tag;
            SpriteEditDialog spriteEditDialog = new SpriteEditDialog(this.image, sprite);
            if (spriteEditDialog.ShowDialog(this) == DialogResult.OK)
            {
                Sprite spriteResult = spriteEditDialog.SpriteResult;
                listViewItem.Tag = spriteResult;
                listViewItem.Text = spriteResult.Name;
                listViewItem.SubItems[1].Text = string.Format("{0},{1}", spriteResult.Coords.X, spriteResult.Coords.Y);
                listViewItem.SubItems[2].Text = string.Format("{0}×{1}", spriteResult.Bounds.Width, spriteResult.Bounds.Height);
                listViewItem.SubItems[3].Text = string.Format("{0},{1}", spriteResult.Origin.X, spriteResult.Origin.Y);
                listViewItem.SubItems[4].Text = string.Format("{0}", spriteResult.Frames);
                listViewItem.SubItems[5].Text = ArrayPrinter.Print<float>(spriteResult.SpeedSet);
                listViewItem.SubItems[6].Text = (spriteResult.FlipX ? "✓" : "");
                listViewItem.SubItems[7].Text = (spriteResult.FlipY ? "✓" : "");
                listViewItem.SubItems[8].Text = string.Format("{0}", spriteResult.Mode);
            }
        }
        private void paletteButton_Click(object sender, EventArgs e)
        {
            PaletteDialog paletteDialog = new PaletteDialog(this.palettes, this.activePalette);
            if (paletteDialog.ShowDialog(this) == DialogResult.OK)
            {
                this.palettes = paletteDialog.Palettes;
                this.activePalette = paletteDialog.ActivePalette;
                this.RemapColors(paletteDialog.PaletteRemap);
                this.RedrawImage();
                this.sheetBox.Refresh();
            }
        }
        private void importButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Custom palettes will be lost. Continue?", "Change Image", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes && this.importImageDialog.ShowDialog(this) == DialogResult.OK)
            {
                this.LoadSpriteSheetFromImage(this.importImageDialog.FileName, false);
            }
        }
        private void sheetBox_Paint(object sender, PaintEventArgs e)
        {
            if (this.spriteList.SelectedItems.Count > 0)
            {
                Sprite sprite = (Sprite)this.spriteList.SelectedItems[0].Tag;
                Brush[] array = new Brush[]
                {
                    new SolidBrush(Color.FromArgb(128, SystemColors.HotTrack)),
                    new SolidBrush(Color.FromArgb(128, SystemColors.Highlight))
                };
                Graphics graphics = e.Graphics;
                for (int i = 0; i < sprite.Frames; i++)
                {
                    Rectangle rect = new Rectangle(sprite.Coords, sprite.Bounds);
                    rect.X += sprite.Bounds.Width * i;
                    graphics.FillRectangle(array[i % 2], rect);
                }
            }
        }
        private void spriteList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.sheetBox.Refresh();
            if (this.spriteList.SelectedItems.Count > 0)
            {
                this.removeSpriteButton.Enabled = true;
                this.duplicateSpriteButton.Enabled = true;
                return;
            }
            this.removeSpriteButton.Enabled = false;
            this.duplicateSpriteButton.Enabled = false;
        }
        private void AddSpriteRow(Sprite sprite)
        {
            int count = this.spriteList.Items.Count;
            ListViewItem listViewItem = this.spriteList.Items.Add(string.Format(sprite.Name, count));
            listViewItem.SubItems.Add(string.Format("{0},{1}", sprite.Coords.X, sprite.Coords.Y));
            listViewItem.SubItems.Add(string.Format("{0}×{1}", sprite.Bounds.Width, sprite.Bounds.Height));
            listViewItem.SubItems.Add(string.Format("{0},{1}", sprite.Origin.X, sprite.Origin.Y));
            listViewItem.SubItems.Add(sprite.Frames.ToString());
            listViewItem.SubItems.Add(ArrayPrinter.Print<float>(sprite.SpeedSet));
            listViewItem.SubItems.Add(sprite.FlipX ? "✓" : "");
            listViewItem.SubItems.Add(sprite.FlipY ? "✓" : "");
            listViewItem.SubItems.Add(sprite.Mode.ToString());
            listViewItem.Tag = sprite;
        }
        private void AddSpriteRow(string name)
        {
            Point coords = default(Point);
            Size bounds = default(Size);
            Point origin = default(Point);
            int frames = 1;
            float[] speeds = new float[1];
            Sprite sprite = new Sprite(name, coords, bounds, origin, frames, speeds, false, false, 0);
            this.AddSpriteRow(sprite);
        }
        private void LoadSpriteSheet(string filename)
        {
            if (Path.GetExtension(filename) == ".dat" || Path.GetExtension(filename) == ".mtdat" )
            {
                try
                {
                    this.LoadSpriteSheetFromDat(filename);
                    this.sheetBox.Image = this.image;
                    this.sheetBox.Dock = DockStyle.None;
                    this.sheetBox.Size = this.image.Size;
                    this.workingFileName = filename;
                    this.isLoaded = true;
                    this.image.Save(filename + ".png");
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("{0}\n{1}", ex.Message, ex.StackTrace), "Image Loading Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
            }
            this.LoadSpriteSheetFromImage(filename);
        }
        private void LoadSpriteSheetFromImage(string filename)
        {
            this.LoadSpriteSheetFromImage(filename, true);
        }
        private void LoadSpriteSheetFromImage(string filename, bool clearSprites)
        {
            try
            {
                Bitmap bitmap = new Bitmap(filename);
                this.image = new Bitmap(bitmap.Width, bitmap.Height);
                using (Graphics graphics = Graphics.FromImage(this.image))
                {
                    graphics.DrawImage(bitmap, 0, 0, bitmap.Width, bitmap.Height);
                }
                bitmap.Dispose();
                this.sheetBox.Image = this.image;
                this.sheetBox.Dock = DockStyle.None;
                this.sheetBox.Size = this.image.Size;
                this.palettes = new List<List<Color>>();
                this.InitializePalette();
                if (clearSprites)
                {
                    this.spriteList.Items.Clear();
                }
                this.isLoaded = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Image Loading Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                this.image.Dispose();
                this.sheetBox.Image = null;
                this.palettes = new List<List<Color>>();
            }
        }

        private void LoadSpriteSheetFromDat(string filename)
        {
            NbtCompound rootTag = new NbtFile(filename).RootTag;
            NbtByteArray nbtByteArray = rootTag.Get<NbtByteArray>("img");
            this.indices = nbtByteArray.ByteArrayValue;
            NbtCompound nbtCompound = null;
            bool useList = false;
            NbtList nebtList = null;
            try
            {
                nbtCompound = rootTag.Get<NbtCompound>("pal");
            }
            catch
            {
                useList = true;
                nebtList = rootTag.Get<NbtList>("pal");
            }
            this.palettes = new List<List<Color>>();
            if (!useList)
            {
                using (IEnumerator<NbtTag> enumerator = nbtCompound.Tags.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        NbtTag nbtTag4 = enumerator.Current;
                        int[] intArrayValue = ((NbtIntArray)nbtTag4).IntArrayValue;
                        List<Color> list = new List<Color>();
                        for (int i = 0; i < intArrayValue.Length; i++)
                        {
                            Color item = Color.FromArgb(intArrayValue[i]);
                            list.Add(item);
                        }
                        this.palettes.Add(list);
                    }
                    goto IL_13F;
                }
            }
            foreach (NbtTag nbtTag5 in nebtList)
            {
                int[] intArrayValue2 = ((NbtIntArray)nbtTag5).IntArrayValue;
                List<Color> list2 = new List<Color>();
                for (int j = 0; j < intArrayValue2.Length; j++)
                {
                    Color item2 = Color.FromArgb(intArrayValue2[j]);
                    list2.Add(item2);
                }
                this.palettes.Add(list2);
            }
        IL_13F:
            this.spriteList.Items.Clear();
            NbtCompound nbtCompound2 = rootTag.Get<NbtCompound>("spr");
            if (nbtCompound2 != null)
            {
                foreach (NbtTag nbtTag6 in nbtCompound2.Tags)
                {
                    NbtCompound nbtCompound3 = (NbtCompound)nbtTag6;
                    string name = nbtCompound3.Name;
                    int[] intArrayValue3 = nbtCompound3.Get<NbtIntArray>("crd").IntArrayValue;
                    int[] intArrayValue4 = nbtCompound3.Get<NbtIntArray>("bnd").IntArrayValue;
                    int[] intArrayValue5 = nbtCompound3.Get<NbtIntArray>("org").IntArrayValue;
                    byte[] byteArrayValue = nbtCompound3.Get<NbtByteArray>("opt").ByteArrayValue;
                    int intValue = nbtCompound3.Get<NbtInt>("frm").IntValue;
                    NbtTag nbtTag3 = nbtCompound3.Get("spd");
                    float[] array;
                    if (nbtTag3.TagType == NbtTagType.Float)
                    {
                        array = new float[]
                        {
                            nbtTag3.FloatValue
                        };
                    }
                    else
                    {
                        NbtTag[] array2 = nbtCompound3.Get<NbtList>("spd").ToArray();
                        array = new float[array2.Length];
                        for (int k = 0; k < array2.Length; k++)
                        {
                            array[k] = array2[k].FloatValue;
                        }
                    }
                    Point coords = new Point(intArrayValue3[0], intArrayValue3[1]);
                    Size bounds = new Size(intArrayValue4[0], intArrayValue4[1]);
                    Point origin = new Point(intArrayValue5[0], intArrayValue5[1]);
                    bool flipX = byteArrayValue[0] == 1;
                    bool flipY = byteArrayValue[1] == 1;
                    int mode = byteArrayValue[2];
                    Sprite sprite = new Sprite(name, coords, bounds, origin, intValue, array, flipX, flipY, mode);
                    this.AddSpriteRow(sprite);
                }
            }
            int intValue2 = rootTag.Get<NbtInt>("w").IntValue;
            int num = this.indices.Length / intValue2;
            this.image = new Bitmap(intValue2, num);
            using (Graphics.FromImage(this.image))
            {
                for (int l = 0; l < num; l++)
                {
                    for (int m = 0; m < intValue2; m++)
                    {
                        List<Color> list3 = this.palettes[0];
                        int index = this.indices[l * intValue2 + m];
                        this.image.SetPixel(m, l, list3[index]);
                    }
                }
            }
        }

        private void RedrawImage()
        {
            using (Graphics graphics = Graphics.FromImage(this.image))
            {
                graphics.Clear(Color.Transparent);
                for (int i = 0; i < this.image.Height; i++)
                {
                    for (int j = 0; j < this.image.Width; j++)
                    {
                        List<Color> list = this.palettes[this.activePalette];
                        int num = this.indices[i * this.image.Width + j];
                        Color color = (num < list.Count) ? list[num] : Color.Black;
                        this.image.SetPixel(j, i, color);
                    }
                }
            }
        }

        private void InitializePalette()
        {
            List<Color> list = new List<Color>();
            this.indices = new byte[this.image.Width * this.image.Height];
            for (int i = 0; i < this.image.Width; i++)
            {
                for (int j = 0; j < this.image.Height; j++)
                {
                    Color pixel = this.image.GetPixel(i, j);
                    byte b;
                    if (!list.Contains(pixel))
                    {
                        b = (byte)list.Count;
                        list.Add(pixel);
                    }
                    else
                    {
                        b = (byte)list.IndexOf(pixel);
                    }
                    this.indices[j * this.image.Width + i] = b;
                    if (list.Count > 256)
                    {
                        throw new IndexOutOfRangeException("The number of colors in the palette has exceeded 256.");
                    }
                }
            }
            this.palettes.Add(list);
            this.activePalette = 0;
        }
        private void SaveSpriteSheet(string filename)
        {
            try
            {
                this.ValidateSaveData();
            }
            catch (DuplicateNameException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            NbtFile nbtFile = new NbtFile();
            NbtCompound rootTag = nbtFile.RootTag;
            NbtInt newTag = new NbtInt("w", this.image.Width);
            rootTag.Add(newTag);
            NbtCompound nbtCompound = new NbtCompound("pal");
            rootTag.Add(nbtCompound);
            for (int i = 0; i < this.palettes.Count; i++)
            {
                List<Color> list = this.palettes[i];
                int[] array = new int[list.Count];
                for (int j = 0; j < list.Count; j++)
                {
                    array[j] = list[j].ToArgb();
                }
                NbtIntArray newTag2 = new NbtIntArray(string.Format("{0}", i), array);
                nbtCompound.Add(newTag2);
            }
            NbtByteArray newTag3 = new NbtByteArray("img", this.indices);
            rootTag.Add(newTag3);
            NbtCompound nbtCompound2 = new NbtCompound("spr");
            foreach (object obj in this.spriteList.Items)
            {
                Sprite sprite = (Sprite)((ListViewItem)obj).Tag;
                NbtCompound nbtCompound3 = new NbtCompound(sprite.Name)
                {
                    new NbtIntArray("crd", new int[]
                {
                    sprite.Coords.X,
                    sprite.Coords.Y
                }),
                    new NbtIntArray("bnd", new int[]
                {
                    sprite.Bounds.Width,
                    sprite.Bounds.Height
                }),
                    new NbtIntArray("org", new int[]
                {
                    sprite.Origin.X,
                    sprite.Origin.Y
                }),
                    new NbtInt("frm", sprite.Frames)
                };
                NbtFloat[] array2 = new NbtFloat[sprite.SpeedSet.Length];
                for (int k = 0; k < array2.Length; k++)
                {
                    array2[k] = new NbtFloat(sprite.SpeedSet[k]);
                }
                nbtCompound3.Add(new NbtList("spd", array2, NbtTagType.Float));
                nbtCompound3.Add(new NbtByteArray("opt", new byte[]
                {
                    sprite.FlipX ? (byte)1 : (byte)0,
                    sprite.FlipY ? (byte)1 : (byte)0,
                    (byte)sprite.Mode
                }));
                nbtCompound2.Add(nbtCompound3);
            }
            rootTag.Add(nbtCompound2);
            nbtFile.SaveToFile(filename, NbtCompression.GZip);
        }
        private void ValidateSaveData()
        {
            List<string> list = new List<string>();
            foreach (object obj in this.spriteList.Items)
            {
                Sprite sprite = (Sprite)((ListViewItem)obj).Tag;
                if (list.Contains(sprite.Name))
                {
                    throw new DuplicateNameException(string.Format("\"{0}\" was used more than once. Sprite names must be unique.", sprite.Name));
                }
                list.Add(sprite.Name);
            }
        }
        private void RemapColors(List<Tuple<int, int>> remap)
        {
            for (int i = 0; i < remap.Count; i++)
            {
                Tuple<int, int> tuple = remap[i];
                for (int j = 0; j < this.indices.Length; j++)
                {
                    if (this.indices[j] == tuple.Item1)
                    {
                        this.indices[j] = (byte)tuple.Item2;
                    }
                    else if (this.indices[j] == tuple.Item2)
                    {
                        this.indices[j] = (byte)tuple.Item1;
                    }
                }
            }
        }
        private bool isLoaded;
        private string workingFileName;
        private Bitmap image;
        private List<List<Color>> palettes;
        private int activePalette;
        private byte[] indices;

        public void Extract(string filename)
        {
            try
            {
                NbtCompound rootTag = new NbtFile(filename).RootTag;
                NbtByteArray nbtByteArray = rootTag.Get<NbtByteArray>("img");
                if (nbtByteArray != null)
                {
                    Image img = GetImgFromDat(filename);
                    string str = filename.Replace(".dat", "").Replace("  ", " ");
                    img.Save(str + ".png");
                }
            }
            catch (Exception)
            {
            }
        }
        private Image GetImgFromDat(string filename)
        {
            NbtCompound rootTag = new NbtFile(filename).RootTag;
            NbtByteArray nbtByteArray = rootTag.Get<NbtByteArray>("img");
            this.indices = nbtByteArray.ByteArrayValue;
            NbtCompound nbtCompound = null;
            bool useList = false;
            NbtList nebtList = null;
            try
            {
                nbtCompound = rootTag.Get<NbtCompound>("pal");
            }
            catch
            {
                useList = true;
                nebtList = rootTag.Get<NbtList>("pal");
            }
            this.palettes = new List<List<Color>>();
            if (!useList)
            {
                using (IEnumerator<NbtTag> enumerator = nbtCompound.Tags.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        NbtTag nbtTag4 = enumerator.Current;
                        int[] intArrayValue = ((NbtIntArray)nbtTag4).IntArrayValue;
                        List<Color> list = new List<Color>();
                        for (int i = 0; i < intArrayValue.Length; i++)
                        {
                            Color item = Color.FromArgb(intArrayValue[i]);
                            list.Add(item);
                        }
                        this.palettes.Add(list);
                    }
                    goto IL_13F;
                }
            }
            foreach (NbtTag nbtTag5 in nebtList)
            {
                int[] intArrayValue2 = ((NbtIntArray)nbtTag5).IntArrayValue;
                List<Color> list2 = new List<Color>();
                for (int j = 0; j < intArrayValue2.Length; j++)
                {
                    Color item2 = Color.FromArgb(intArrayValue2[j]);
                    list2.Add(item2);
                }
                this.palettes.Add(list2);
            }
        IL_13F:
            this.spriteList.Items.Clear();
            NbtCompound nbtCompound2 = rootTag.Get<NbtCompound>("spr");
            if (nbtCompound2 != null)
            {
                foreach (NbtTag nbtTag6 in nbtCompound2.Tags)
                {
                    NbtCompound nbtCompound3 = (NbtCompound)nbtTag6;
                    string name = nbtCompound3.Name;
                    int[] intArrayValue3 = nbtCompound3.Get<NbtIntArray>("crd").IntArrayValue;
                    int[] intArrayValue4 = nbtCompound3.Get<NbtIntArray>("bnd").IntArrayValue;
                    int[] intArrayValue5 = nbtCompound3.Get<NbtIntArray>("org").IntArrayValue;
                    byte[] byteArrayValue = nbtCompound3.Get<NbtByteArray>("opt").ByteArrayValue;
                    int intValue = nbtCompound3.Get<NbtInt>("frm").IntValue;
                    NbtTag nbtTag3 = nbtCompound3.Get("spd");
                    float[] array;
                    if (nbtTag3.TagType == NbtTagType.Float)
                    {
                        array = new float[]
                        {
                            nbtTag3.FloatValue
                        };
                    }
                    else
                    {
                        NbtTag[] array2 = nbtCompound3.Get<NbtList>("spd").ToArray();
                        array = new float[array2.Length];
                        for (int k = 0; k < array2.Length; k++)
                        {
                            array[k] = array2[k].FloatValue;
                        }
                    }
                    Point coords = new Point(intArrayValue3[0], intArrayValue3[1]);
                    Size bounds = new Size(intArrayValue4[0], intArrayValue4[1]);
                    Point origin = new Point(intArrayValue5[0], intArrayValue5[1]);
                    bool flipX = byteArrayValue[0] == 1;
                    bool flipY = byteArrayValue[1] == 1;
                    int mode = byteArrayValue[2];
                    Sprite sprite = new Sprite(name, coords, bounds, origin, intValue, array, flipX, flipY, mode);
                    this.AddSpriteRow(sprite);
                }
            }
            int intValue2 = rootTag.Get<NbtInt>("w").IntValue;
            int num = this.indices.Length / intValue2;
            Bitmap img = new Bitmap(intValue2, num);
            using (Graphics.FromImage(img))
            {
                for (int l = 0; l < num; l++)
                {
                    for (int m = 0; m < intValue2; m++)
                    {
                        List<Color> list3 = this.palettes[0];
                        int index = this.indices[l * intValue2 + m];
                        img.SetPixel(m, l, list3[index]);
                    }
                }
            }
            return img;
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (this.openFolderDialog.ShowDialog(this) == DialogResult.OK)
            {
                foreach (string folder in Directory.GetDirectories(openFolderDialog.SelectedPath))
                {
                    foreach (string file in Directory.GetFiles(folder))
                    {
                        if (file.Contains(".dat"))
                        {
                            Extract(file);
                        }
                    }
                }
            }
        }

        public void LoadENUS(string filename)
        {
            List<string> everything = new List<string>();
            NbtCompound rootTag = new NbtFile(filename).RootTag;
            foreach (NbtTag thing in rootTag.Tags)
            {
                NbtCompound compound = thing as NbtCompound;
                foreach (NbtString stringo in compound)
                {
                    everything.Add($"------- START ENTRY[{stringo.Path}] -------");
                    everything.Add(remove_empty_lines(stringo.Value));
                    everything.Add("------- ENTRY END -------");

                }
            }
            string fileName = Path.GetFileName(filename);
            File.WriteAllLines($"en_us_{File.GetCreationTime(fileName)}.txt", everything.ToArray());

        }
        private string remove_empty_lines(string text)
        {
            StringBuilder text_sb = new StringBuilder(text);
            Regex rg_spaces = new Regex(@"(\r\n|\r|\n)([\s]+\r\n|[\s]+\r|[\s]+\n)");
            Match m = rg_spaces.Match(text_sb.ToString());
            while (m.Success)
            {
                text_sb = text_sb.Replace(m.Groups[2].Value, "");
                m = rg_spaces.Match(text_sb.ToString());
            }
            return text_sb.ToString().Trim();
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (this.openImageDialog.ShowDialog(this) == DialogResult.OK)
            {
                this.LoadENUS(this.openImageDialog.FileName);
            }

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (this.saveFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                this.image.Save(saveFileDialog1.FileName);
            }
        }
    }
}
