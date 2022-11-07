using System;
using System.Drawing;

namespace Spriteman
{
	public class Sprite
	{
		public string Name { get; set; }
		public Point Coords { get; set; }
		public Size Bounds { get; set; }
		public Point Origin { get; set; }
		public int Frames { get; set; }
		public float[] SpeedSet { get; set; }
		public bool FlipX { get; set; }
		public bool FlipY { get; set; }
		public int Mode { get; set; }
		public Sprite(string name, Point coords, Size bounds, Point origin, int frames, float[] speeds, bool flipX, bool flipY, int mode)
		{
			this.Name = name;
			this.Coords = coords;
			this.Bounds = bounds;
			this.Origin = origin;
			this.Frames = frames;
			this.SpeedSet = speeds;
			this.FlipX = flipX;
			this.FlipY = flipY;
			this.Mode = mode;
		}
	}
}
