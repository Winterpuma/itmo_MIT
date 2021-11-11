using MIT_LR1_BWT.BitFileOperations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MIT_LR1_BWT.Coders.Huffman
{
	class HuffEncoder
	{
		public static byte[] Code(byte[] input)
		{
			// If file is empty
			if (input.Length == 0)
				return input;

			var huffmanTree = new HuffmanTree(input);
			var writer = new BitWriter();

			huffmanTree.SaveHuffmanTree(writer);

			for (int i = 0; i < input.Length; i++)
			{
				List<bool> encodedCharacter = huffmanTree.rootNode.TraverseTree(input[i], new List<bool>());
				
				writer.WriteRange(encodedCharacter);
			}

			return writer.FinishAndGetAllByteData();
		}
	}
}
