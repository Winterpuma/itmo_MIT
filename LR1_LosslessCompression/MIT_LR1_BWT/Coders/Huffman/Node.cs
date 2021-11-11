using System;
using System.Collections.Generic;
using System.Text;

namespace MIT_LR1_BWT.Coders.Huffman
{
	class Node
	{
		public byte character { get; set; }
		public int frequency { get; set; }

		public Node parent;
		public Node leftNode;
		public Node rightNode;

		public Node(byte character, int frequency)
		{
			this.frequency = frequency;
			this.character = character;
		}

		public Node() { }

		public bool IsLeaf()
		{
			return leftNode == null && rightNode == null;
		}

		public List<bool> TraverseTree(byte symbol, List<bool> data)
		{
			if (IsLeaf())
			{
				if (symbol.Equals(character))
				{
					return data;
				}
				else
				{
					return null;
				}
			}
			else
			{
				List<bool> left = null;
				List<bool> right = null;

				if (leftNode != null)
				{
					List<bool> leftPath = new List<bool>();
					leftPath.AddRange(data);
					leftPath.Add(false);

					left = leftNode.TraverseTree(symbol, leftPath);
				}

				if (rightNode != null)
				{
					List<bool> rightPath = new List<bool>();
					rightPath.AddRange(data);
					rightPath.Add(true);
					right = rightNode.TraverseTree(symbol, rightPath);
				}

				if (left != null)
				{
					return left;
				}
				else
				{
					return right;
				}
			}
		}

		public void PrintPretty(string indent, bool last)
		{
			Console.Write(indent);
			if (last)
			{
				Console.Write("\\-");
				indent += "  ";
			}
			else
			{
				Console.Write("|-");
				indent += "| ";
			}
			Console.WriteLine((int)character);

			leftNode?.PrintPretty(indent, false);
			rightNode?.PrintPretty(indent, false);
		}
	}
}
