using System.Collections.Generic;

namespace MIT_LR1_BWT.BitFileOperations
{
	/// <summary>
	/// Простой писатель.
	/// Не выполняет никаких лишних вычислений и перестановок.
	/// Использовался для тестирования корректности построения и чтения дерева Хаффмана.
	/// </summary>
	class SimpleBitWriter : IBitWriter
	{
		protected readonly List<bool> data = new List<bool>();

		public void WriteBit(bool b)
		{
			data.Add(b);
		}

		public void WriteByte(byte b)
		{
			var byteBits = BitOperations.ConvertByteToBoolArray(b);

			WriteRange(byteBits);
		}

		public void WriteRange(IEnumerable<bool> b)
		{
			foreach (var bb in b)
				WriteBit(bb);
		}

		public virtual bool[] FinishAndGetAllData()
		{
			return data.ToArray();
		}
	}
}
