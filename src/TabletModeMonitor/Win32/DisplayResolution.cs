namespace TabletModeMonitor.Win32
{
	public class DisplayResolution
	{
		public DisplayResolution(int width, int height)
		{
			this.Width = width;
			this.Height = height;
		}

		public int Width { get; }
		public int Height { get; }

		public override bool Equals(object obj)
		{
			var other = obj as DisplayResolution;

			return other != null && (
				this.Width == other.Width
				&& this.Height == other.Height
			);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				int hash = 17;

				hash = hash * 23 + this.Width.GetHashCode();
				hash = hash * 23 + this.Height.GetHashCode();

				return hash;
			}
		}

		public override string ToString()
		{
			return $"{Width} x {Height}";
		}
	}
}
