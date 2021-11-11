namespace MIT_LR1_BWT.BitFileOperations
{
	/// <summary>
	/// Простой читатель.
	/// Не выполняет никаких лишних вычислений и перестановок.
	/// Использовался для тестирования корректности построения и чтения дерева Хаффмана.
	/// </summary>
	class SimpleBitReader : IBitReader
	{
		readonly bool[] data;
		int pos = 0;

		public SimpleBitReader(bool[] data)
		{
			this.data = data;
		}

		public bool ReadBit()
		{
			return data[pos++];
		}

		public byte ReadByte()
		{
			var byteBits = new bool[8];

			for (int i = 0; i < byteBits.Length; i++)
				byteBits[i] = ReadBit();

			return BitOperations.ConvertBoolArrayToByte(byteBits);
		}
	}
}
