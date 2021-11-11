using System;
using System.Collections;

namespace MIT_LR1_BWT.BitFileOperations
{
	public static class BitOperations
	{
		public static bool[] ConvertByteToBoolArray(byte b)
		{
			// prepare the return result
			bool[] result = new bool[8];

			// check each bit in the byte. if 1 set to true, if 0 set to false
			for (int i = 0; i < 8; i++)
				result[i] = (b & (1 << i)) != 0;

			// reverse the array
			Array.Reverse(result);

			return result;
		}

		public static byte ConvertBoolArrayToByte(bool[] source)
		{
			byte result = 0;
			// This assumes the array never contains more than 8 elements!
			int index = 8 - source.Length;

			// Loop through the array
			foreach (bool b in source)
			{
				// if the element is 'true' set the bit at that position
				if (b)
					result |= (byte)(1 << (7 - index));

				index++;
			}

			return result;
		}

		public static byte[] GetByteArray(bool[] boolArr)
		{
			int len = boolArr.Length;
			int bytes = len >> 3;
			if ((len & 0x07) != 0) ++bytes;
			byte[] byteArr = new byte[bytes];
			for (int i = 0; i < boolArr.Length; i++)
			{
				if (boolArr[i])
					byteArr[i >> 3] |= (byte)(1 << (i & 0x07));
			}

			return byteArr;
		}

		public static bool[] GetBoolArray(byte[] byteArr)
		{
			BitArray bitArray = new BitArray(byteArr);

			var boolArr = new bool[bitArray.Length];

			bitArray.CopyTo(boolArr, 0);

			return boolArr;
		}
	}
}
