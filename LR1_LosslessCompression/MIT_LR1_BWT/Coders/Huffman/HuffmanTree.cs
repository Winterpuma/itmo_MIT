using MIT_LR1_BWT.BitFileOperations;
using System.Collections.Generic;
using System.Linq;

namespace MIT_LR1_BWT.Coders.Huffman
{
	class HuffmanTree
	{
		public Node rootNode;

		public HuffmanTree(byte[] data)
		{
			var freq = CountFrequencies(data);

			rootNode = BuildTree(freq);
		}

		private HuffmanTree() { }

		public void SaveHuffmanTree(IBitWriter writer)
		{
			SaveTree(rootNode, writer);
		}

		public static HuffmanTree UploadHuffmanTree(IBitReader reader)
		{
			var root = ReadTree(reader);
			var tree = new HuffmanTree();

			tree.rootNode = root;

			return tree;
		}

		private Dictionary<byte, int> CountFrequencies(byte[] data)
		{
			Dictionary<byte, int> frequency = new Dictionary<byte, int>();

			foreach (byte curByte in data)
			{
				if (frequency.ContainsKey(curByte))
					frequency[curByte]++;
				else
					frequency.Add(curByte, 1);
			}

			return frequency;
		}

		private Node BuildTree(Dictionary<byte, int> frequency)
		{
			Node rootNode;
			List<Node> nodesToAdd = new List<Node>();

			// Add first layer of tree (symbols)
			foreach (var el in frequency)
				nodesToAdd.Add(new Node(el.Key, el.Value));

			while (nodesToAdd.Count > 1)
			{
				List<Node> orderedNodes = nodesToAdd.OrderBy(node => node.frequency).ToList();

				if (orderedNodes.Count >= 2)
				{
					// Take first two items
					List<Node> takenNode = orderedNodes.Take(2).ToList<Node>();

					// Create a parent node by combining the frequencies
					var parentFrequency = takenNode[0].frequency + takenNode[1].frequency;
					var parent = new Node()
					{
						frequency = parentFrequency,
						leftNode = takenNode[0],
						rightNode = takenNode[1]
					};

					takenNode[0].parent = parent;
					takenNode[1].parent = parent;

					nodesToAdd.Remove(takenNode[0]);
					nodesToAdd.Remove(takenNode[1]);
					nodesToAdd.Add(parent);
				}

			}

			rootNode = nodesToAdd.FirstOrDefault();

			return rootNode;
		}

		// https://coderoad.ru/759707/Эффективный-способ-хранения-дерева-Хаффмана
		private void SaveTree(Node root, IBitWriter writer)
		{
			if (root.IsLeaf())
			{
				writer.WriteBit(true);
				writer.WriteByte(root.character);
			}
			else
			{
				writer.WriteBit(false);

				SaveTree(root.leftNode, writer);
				SaveTree(root.rightNode, writer);
			}
		}

		private static Node ReadTree(IBitReader reader)
		{
			if (reader.ReadBit() == true)
			{
				return new Node() { character = reader.ReadByte() };
			}
			else
			{
				Node leftChild = ReadTree(reader);
				Node rightChild = ReadTree(reader);

				return new Node() { leftNode = leftChild, rightNode = rightChild };
			}
		}

	}
}
