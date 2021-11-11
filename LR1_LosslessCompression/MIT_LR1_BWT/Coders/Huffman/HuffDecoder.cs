using System;
using System.Collections.Generic;
using System.Text;
using MIT_LR1_BWT.BitFileOperations;

namespace MIT_LR1_BWT.Coders.Huffman
{
	class HuffDecoder
	{
		public static byte[] Code(byte[] src)
		{
			// If file is empty
			if (src.Length == 0)
				return src;

			var boolArr = BitOperations.GetBoolArray(src);
			var reader = new BitReader(boolArr);
			var huffmanTree = HuffmanTree.UploadHuffmanTree(reader);
			var currentNode = huffmanTree.rootNode;
			var decoded = new List<byte>();
			
			while (!reader.EOF())
			{
				bool bit;
				try
				{
					bit = reader.ReadBit();
				}
				catch
				{
					break;
				}

				if (bit)
				{
					if (currentNode.rightNode != null)
					{
						currentNode = currentNode.rightNode;
					}
				}
				else
				{
					if (currentNode.leftNode != null)
					{
						currentNode = currentNode.leftNode;
					}
				}

				if (currentNode.IsLeaf())
				{
					decoded.Add(currentNode.character);
					currentNode = huffmanTree.rootNode;
				}
			}

			return decoded.ToArray();
		}
	}
}
