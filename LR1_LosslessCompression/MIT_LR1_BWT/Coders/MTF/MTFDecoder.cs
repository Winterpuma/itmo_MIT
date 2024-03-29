﻿namespace MIT_LR1_BWT.Coders.MTF
{
	class MTFDecoder
	{
		public static byte[] Code(byte[] src, int alphabetSize = 256)
		{
			// If file is empty
			if (src.Length == 0)
				return src;

			byte[] dict = new byte[alphabetSize];
			byte[] res = new byte[src.Length];

			for (int i = 0; i < alphabetSize; i++)
				dict[i] = (byte)i;

			for (int i = 0; i < src.Length; i++)
			{
				var j = src[i];
				res[i] = dict[j];

				for (int k = j - 1; k >= 0; k--)
					dict[k + 1] = dict[k];

				dict[0] = res[i];
			}

			return res;
		}
	}
}
