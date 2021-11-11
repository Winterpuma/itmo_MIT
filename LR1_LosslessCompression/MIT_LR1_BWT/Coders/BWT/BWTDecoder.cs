using System;

namespace MIT_LR1_BWT.Coders.BWT
{
	class BWTDecoder
	{
		public static byte[] Code(byte[] input)
		{
            var length = input.Length - 4;
            var I = ByteArrToInt(input, input.Length - 4);
            var freq = new int[256];
            Array.Clear(freq, 0, freq.Length);
            // T1: Number of Preceding Symbols Matching Symbol in Current Position.
            var t1 = new int[length];
            // T2: Number of Symbols Lexicographically Less Than Current Symbol
            var t2 = new int[256];
            Array.Clear(t2, 0, t2.Length);
            // Construct T1
            for (var i = 0; i < length; i++)
            {
                t1[i] = freq[input[i]];
                freq[input[i]]++;
            }

            // Construct T2
            // Add $ special symbol in consideration to be less than any symbol
            t2[0] = 1;
            for (var i = 1; i < 256; i++)
            {
                t2[i] = t2[i - 1] + freq[i - 1];
            }

            var output = new byte[length];
            var nxt = 0;
            for (var i = length - 1; i >= 0; i--)
            {
                output[i] = input[nxt];
                var a = t1[nxt];
                var b = t2[input[nxt]];
                nxt = a + b;
                // Add $ special symbol index in consideration
                if (nxt >= I)
                {
                    nxt--;
                }
            }
            return output;
        }
        private static int ByteArrToInt(byte[] input, int startIndex)
        {
            return BitConverter.ToInt32(input, startIndex);
        }
    }
}
