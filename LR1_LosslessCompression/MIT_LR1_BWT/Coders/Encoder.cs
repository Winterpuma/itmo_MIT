using System;
using System.IO;

namespace MIT_LR1_BWT.Coders
{
	class Encoder : ICoder
	{
		public void Code(string srcFile, string dstFile)
		{
			var byteSrcData = File.ReadAllBytes(srcFile);

			var codedBWT = BWT.BWTEncoder.Code(byteSrcData);
			var codedMTF = MTF.MTFEncoder.Code(codedBWT);
			var codedHuff = Huffman.HuffEncoder.Code(codedMTF);

			File.WriteAllBytes(dstFile , codedHuff);
		}
	}
}
