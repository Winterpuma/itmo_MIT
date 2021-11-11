using System;
using System.IO;

namespace MIT_LR1_BWT.Coders
{
	class Decoder : ICoder
	{
		public void Code(string srcFile, string dstFile)
		{
			var byteSrcData = File.ReadAllBytes(srcFile);

			var decodedHuff = Huffman.HuffDecoder.Code(byteSrcData);
			var decodedMTF = MTF.MTFDecoder.Code(decodedHuff);
			var decodedBWT = BWT.BWTDecoder.Code(decodedMTF);

			File.WriteAllBytes(dstFile, decodedBWT);
		}
	}
}
