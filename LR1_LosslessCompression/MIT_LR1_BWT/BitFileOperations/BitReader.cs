namespace MIT_LR1_BWT.BitFileOperations
{
	/// <summary>
	/// Читатель с заголовком и правильным количеством бит в конце байта.
	/// </summary>
	class BitReader : SimpleBitReader
	{
		readonly int lastPos;

		public BitReader(bool[] data) : base(data)
		{
			var notFilled = ReadHeader();
			lastPos = data.Length - notFilled;
		}

		public bool EOF()
		{
			return pos >= lastPos;
		}

		private int ReadHeader()
		{
			int notFilledBitsInLastByte = 0;

			if (ReadBit())
				notFilledBitsInLastByte += 4;
			if (ReadBit())
				notFilledBitsInLastByte += 2;
			if (ReadBit())
				notFilledBitsInLastByte += 1;

			return notFilledBitsInLastByte;
		}

	}
}
