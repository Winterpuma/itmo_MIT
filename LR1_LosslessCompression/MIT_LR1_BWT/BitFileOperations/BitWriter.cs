using System.Collections.Generic;

namespace MIT_LR1_BWT.BitFileOperations
{
	/// <summary>
	/// Писатель с заголовком и правильным количеством бит в конце байта.
	/// </summary>
	class BitWriter : SimpleBitWriter
	{
		public BitWriter()
		{
			// space for last byte size
			WriteBit(false);
			WriteBit(false);
			WriteBit(false);
		}

		public override bool[] FinishAndGetAllData()
		{
			var notFilled = SetSizeHeader();

			for (int i = 0; i < notFilled; i++)
				WriteBit(false);

			return data.ToArray();
		}

		public byte[] FinishAndGetAllByteData()
		{
			var boolArr = FinishAndGetAllData();

			return BitOperations.GetByteArray(boolArr);
		}

		private int SetSizeHeader()
		{
			var modBits = data.Count % 8;
			var notFilledBitsInLastByte = 8 - (modBits == 0 ? 8 : modBits);

			var cnt = notFilledBitsInLastByte;

			// Это конечно можно было сделать изящнее но я вожусь с этим участком кода более 4 часов и хочу спать.
			if (cnt >= 4)
			{
				data[0] = true;
				cnt -= 4;
			}
			if (cnt >= 2)
			{
				data[1] = true;
				cnt -= 2;
			}
			if (cnt == 1)
			{
				data[2] = true;
			}

			return notFilledBitsInLastByte;
		}
	}
}
