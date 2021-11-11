namespace MIT_LR1_BWT.Coders.MTF
{
	class MTFEncoder
	{
		public static byte[] Code(byte[] src, int alphabetSize = 256)
		{
			byte[] dict = new byte[alphabetSize];
			byte[] res = new byte[src.Length];

			for (int i = 0; i < alphabetSize; i++)
				dict[i] = (byte)i;

			for (int i = 0; i < src.Length; i++)
			{
				for (int j = 0; j < dict.Length; j++)
				{
					if (dict[j] == src[i])
					{
						res[i] = (byte)j;

						for (int k = j - 1; k >= 0; k--)
							dict[k + 1] = dict[k];

						dict[0] = src[i];
						break;
					}
				}
			}

			return res;
		}
	}
}
