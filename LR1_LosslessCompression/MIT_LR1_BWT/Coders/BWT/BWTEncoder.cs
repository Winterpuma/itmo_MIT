using System;

namespace MIT_LR1_BWT.Coders.BWT
{
	class BWTEncoder
	{
		public static byte[] Code(byte[] input)
		{
			var output = new byte[input.Length + 4];
			var newInput = new short[input.Length + 1];

			for (var i = 0; i < input.Length; i++)
				newInput[i] = (short)(input[i] + 1);

			newInput[input.Length] = 0;
			var suffixArray = SuffixArray.Construct(newInput);
			var end = 0;
			var outputInd = 0;
			for (var i = 0; i < suffixArray.Length; i++)
			{
				if (suffixArray[i] == 0)
				{
					end = i;
					continue;
				}

				output[outputInd] = (byte)(newInput[suffixArray[i] - 1] - 1);
				outputInd++;
			}

			var endByte = IntToByteArr(end);
			endByte.CopyTo(output, input.Length);

			return output;
		}

		private static byte[] IntToByteArr(int i)
		{
			return BitConverter.GetBytes(i);
		}
	}
}
