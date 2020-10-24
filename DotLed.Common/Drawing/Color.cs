using System;

namespace DotLed.Common.Drawing
{
	public struct Color : IEquatable<Color>
	{

		private byte _a;
		private byte _r;
		private byte _g;
		private byte _b;
		private byte _w;

		/// <summary>
		/// This is the aplha channel of a color.
		/// </summary>
		public byte A {
			get {
				return _a;
			}
			set {
				_a = value;
			}
		}


		/// <summary>
		/// The Red channel.
		/// </summary>
		public byte R {
			get {
				return _r;
			}
			set {
				_r = value;
			}
		}

		/// <summary>
		/// The Green Channel
		/// </summary>
		public byte G {
			get {
				return _g;
			}
			set {
				_g = value;
			}
		}

		/// <summary>
		/// The Blue Channel
		/// </summary>
		public byte B {
			get {
				return _b;
			}
			set {
				_b = value;
			}
		}

		/// <summary>
		/// This is the white channel if there is one for a specsific led strip.
		/// </summary>
		public byte W {
			get {
				return _w;
			}
			set {
				_w = value;
			}
		}

		/// <summary>
		/// Hue value
		/// </summary>
		public decimal H {
			get {
				return GetHue();
			}
			set {
				ValueTuple<byte, byte, byte> rgb = HSLToRGB(value, S, L);
				_r = rgb.Item1;
				_g = rgb.Item2;
				_b = rgb.Item3;
			}
		}

		/// <summary>
		/// Saturation value
		/// </summary>
		public decimal S {
			get {
				return GetSaturation();
			}
			set {
				ValueTuple<byte, byte, byte> rgb = HSLToRGB(H, value, L);
				_r = rgb.Item1;
				_g = rgb.Item2;
				_b = rgb.Item3;
			}
		}

		/// <summary>
		/// Luminoity Value
		/// </summary>
		public decimal L {
			get {
				return GetLuminosity();
			}
			set {
				// Recalculating the rgb values
				ValueTuple<byte, byte, byte> rgb = HSLToRGB(H, S, value);
				_r = rgb.Item1;
				_g = rgb.Item2;
				_b = rgb.Item3;
			}
		}

		/// <summary>
		/// Gets a ARGB Value comprised of 4 bytes a single 32 bit integer.
		/// </summary>
		public int ARGB {
			get {
				return BitConverter.ToInt32(new byte[] { _a, _r, _g, _b }, 0);
			}
			set {
				byte[] argbBytes = BitConverter.GetBytes(value);

				_a = argbBytes[0];
				_r = argbBytes[1];
				_g = argbBytes[2];
				_b = argbBytes[3];
			}
		}





		/// <summary>
		/// This is a Color. Based from the System.Drawing.Color struct.
		/// </summary>
		/// <param name="color">The System.Drawing.Color struct.</param>
		public Color(System.Drawing.Color color)
		{
			_a = color.A;
			_r = color.R;
			_g = color.G;
			_b = color.B;
			_w = 0;
		}



		public Color(byte r, byte g, byte b)
		{
			_a = 0;
			_r = r;
			_g = g;
			_b = b;
			_w = 0;
		}


		public Color(byte a, byte r, byte g, byte b)
		{
			_a = a;
			_r = r;
			_g = g;
			_b = b;
			_w = 0;
		}

		public Color(decimal h, decimal s, decimal l)
		{
			ValueTuple<byte, byte, byte> rgb = HSLToRGB(h, s, l);

			_a = 0;
			_r = rgb.Item1;
			_g = rgb.Item2;
			_b = rgb.Item3;
			_w = 0;
		}





		public Color(int bitValue)
		{

			byte[] bytes = BitConverter.GetBytes(bitValue);

			_a = 0;
			_r = bytes[0];
			_g = bytes[1];
			_b = bytes[2];
			_b = bytes[3];
			_w = 0;

		}

		public Color(string hexString)
		{
			if (hexString[0] != '#') 
			{
				throw new ArgumentOutOfRangeException(nameof(hexString), $"The string {hexString} is not starting with a # indicating that its a hex value.");
			}

			// Get each seconds pair.
			byte[] bytes = HexToByteArray(hexString.Substring(1));

			_a = 0;
			_r = bytes[0];
			_g = bytes[1];
			_b = bytes[2];
			_b = bytes[3];
			_w = 0;
		}


		public static ValueTuple<byte, byte, byte> HSLToRGB(decimal h, decimal s, decimal l)
		{
			byte r;
			byte g;
			byte b;

			if (s == 0) {
				r = (byte)Math.Round(l * 255m);
				g = (byte)Math.Round(l * 255m);
				b = (byte)Math.Round(l * 255m);
			}
			else {
				decimal t1, t2;
				decimal th = h / 6.0m;

				if (l < 0.5m) {
					t2 = l * (1m + s);
				}
				else {
					t2 = (l + s) - (l * s);
				}
				t1 = 2m * l - t2;

				decimal tr, tg, tb;
				tr = th + (1.0m / 3.0m);
				tg = th;
				tb = th - (1.0m / 3.0m);

				tr = ColorCalc(tr, t1, t2);
				tg = ColorCalc(tg, t1, t2);
				tb = ColorCalc(tb, t1, t2);
				r = (byte)Math.Round(tr * 255m);
				g = (byte)Math.Round(tg * 255m);
				b = (byte)Math.Round(tb * 255m);
			}


			// Intenral function for calculating color by something
			decimal ColorCalc(decimal c, decimal t1, decimal t2)
			{
				if (c < 0) c += 1m;
				if (c > 1) c -= 1m;
				if (6.0m * c < 1.0m) return t1 + (t2 - t1) * 6.0m * c;
				if (2.0m * c < 1.0m) return t2;
				if (3.0m * c < 2.0m) return t1 + (t2 - t1) * (2.0m / 3.0m - c) * 6.0m;
				return t1;
			}

			return (r, g, b);
		}


		public static ValueTuple<decimal, decimal, decimal> RGBToHSL(byte r, byte g, byte b)
		{

			decimal min = Math.Min(Math.Min(r, g), b);
			decimal max = Math.Max(Math.Max(r, g), b);
			decimal delta = max - min;

			decimal h = 0;
			decimal s = 0;
			decimal l = (max + min) / 2.0m;

			if (delta != 0) {

				if (r == max) {
					h = (g - b) / delta;
				}
				else if (g == max) {
					h = 2m + (b - r) / delta;
				}
				else if (b == max) {
					h = 4m + (r - g) / delta;
				}
			}

			if (delta != 0) {
				if (((max + min) / 2.0m) < 0.5m) {
					s = delta / (max + min);
				}
				else {
					s = delta / (2.0m - max - min);
				}
			}

			return (h, s, l);
		}



		private decimal GetHue()
		{
			decimal min = Math.Min(Math.Min(_r, _g), _b);
			decimal max = Math.Max(Math.Max(_r, _g), _b);
			decimal delta = max - min;

			decimal h = 0;

			if (delta != 0) {

				if (_r == max) {
					h = (_g - _b) / delta;
				}
				else if (_g == max) {
					h = 2m + (_b - _r) / delta;
				}
				else if (_b == max) {
					h = 4m + (_r - _g) / delta;
				}
			}

			return h;
		}

		private decimal GetSaturation()
		{

			decimal min = Math.Min(Math.Min(_r, _g), _b);
			decimal max = Math.Max(Math.Max(_r, _g), _b);
			decimal delta = max - min;

			decimal s = 0;

			if (delta != 0) {
				if (((max + min) / 2.0m) < 0.5m) {
					s = delta / (max + min);
				}
				else {
					s = delta / (2.0m - max - min);
				}
			}

			return s;
		}

		private decimal GetLuminosity()
		{
			decimal min = Math.Min(Math.Min(_r, _g), _b);
			decimal max = Math.Max(Math.Max(_r, _g), _b);

			decimal l = (max + min) / 2.0m;

			return l;
		}


		public System.Drawing.Color ToSystemDrawing()
		{
			return System.Drawing.Color.FromArgb(ARGB);
		}



		/// <summary>
		/// This will convert the color to a hex string
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return $"#{BitConverter.ToString(new byte[] { _a, _r, _g, _b }).Replace("-", "")}";
		}

		public static byte[] HexToByteArray(string hex)
		{
			if (hex.Length % 2 == 1)
				throw new ArgumentOutOfRangeException(nameof(hex), $"The binary key {hex} cannot have an odd number of digits");

			byte[] arr = new byte[hex.Length >> 1];

			for (int i = 0; i < hex.Length >> 1; ++i) {
				arr[i] = (byte)((GetHexVal(hex[i << 1]) << 4) + (GetHexVal(hex[(i << 1) + 1])));
			}

			return arr;



			 int GetHexVal(char hexChar)
			{
				int val = (int)hexChar;
				//For uppercase A-F letters:
				//return val - (val < 58 ? 48 : 55);
				//For lowercase a-f letters:
				//return val - (val < 58 ? 48 : 87);
				//Or the two combined, but a bit slower:
				return val - (val < 58 ? 48 : (val < 97 ? 55 : 87));
			}
		}




		public bool Equals(Color other)
		{
			throw new NotImplementedException();
		}
	}
}
