using System;

using DotLed.Common.Drawing;
using DotLed.Domain.Services.LedStrips;

namespace DotLed.Common.LedStrip.Normalizers
{
	public class Ws2812ColorNormalizer : ILedStripColorArrayNormalizer
    {
        private const int BytesPerComponent = 3;
        private const int BytesPerColor = BytesPerComponent * 3;


        // The Neo Pixels require a 50us delay (all zeros) after. Since Spi freq is not exactly
        // as requested 100us is used here with good practical results. 100us @ 2.4Mbps and 8bit
        // data means we have to add 30 bytes of zero padding.
        private const int ResetDelayInBytes = 30;


        private static readonly byte[] _lookup = new byte[256 * BytesPerComponent];


        static Ws2812ColorNormalizer()
        {
            for (int i = 0; i < 256; i++)
            {
                int data = 0;
                for (int j = 7; j >= 0; j--)
                {
                    data = (data << 3) | 0b100 | ((i >> j) << 1) & 2;
                }

                _lookup[i * BytesPerComponent + 0] = unchecked((byte)(data >> 16));
                _lookup[i * BytesPerComponent + 1] = unchecked((byte)(data >> 8));
                _lookup[i * BytesPerComponent + 2] = unchecked((byte)(data >> 0));
            }
        }



        public byte[] GetBytes(Color color)
		{
            byte[] result = new byte[8];
            result[0] = _lookup[color.G * BytesPerComponent + 0];
            result[1] = _lookup[color.G * BytesPerComponent + 1];
            result[2] = _lookup[color.G * BytesPerComponent + 2];
            result[3] = _lookup[color.R * BytesPerComponent + 0];
            result[4] = _lookup[color.R * BytesPerComponent + 1];
            result[5] = _lookup[color.R * BytesPerComponent + 2];
            result[6] = _lookup[color.B * BytesPerComponent + 0];
            result[7] = _lookup[color.B * BytesPerComponent + 1];
            result[8] = _lookup[color.B * BytesPerComponent + 2];

            return result;
        }

        public byte[] GetBytes(Span<Color> colors)
        {
            byte[] result = new byte[colors.Length * BytesPerColor];

            int offset = 0;

			foreach (Color color in colors)
			{
                result[offset++] = _lookup[color.G * BytesPerComponent + 0];
                result[offset++] = _lookup[color.G * BytesPerComponent + 1];
                result[offset++] = _lookup[color.G * BytesPerComponent + 2];
                result[offset++] = _lookup[color.R * BytesPerComponent + 0];
                result[offset++] = _lookup[color.R * BytesPerComponent + 1];
                result[offset++] = _lookup[color.R * BytesPerComponent + 2];
                result[offset++] = _lookup[color.B * BytesPerComponent + 0];
                result[offset++] = _lookup[color.B * BytesPerComponent + 1];
                result[offset++] = _lookup[color.B * BytesPerComponent + 2];
            }

            return result;			
		}
	}
}
