using MIT_LR1_BWT.Coders;
using System;
using System.IO;

namespace MIT_LR1_BWT
{
	class Program
	{
		static ICoder coder;

		static void Main(string[] args)
		{
			if (args.Length != 2)
			{
				Console.WriteLine($"Wrong amount of arguments. 2 expected, got {args.Length}.");
				return;
			}

			//SetEncodeMode();
			SetDecodeMode();

			coder.Code(args[0], args[1]);
		}

		static void SetEncodeMode()
		{
			Console.WriteLine("Encoder");
			coder = new Coders.Encoder();
		}

		static void SetDecodeMode()
		{
			Console.WriteLine("Decoder");
			coder = new Coders.Decoder();
		}


		static void CheckDir()
		{
			var files = Directory.GetFiles("calgarycorpus");

			foreach (string fileSrc in files)
			{
				Console.WriteLine();
				Console.WriteLine(fileSrc);

				var fileDst = fileSrc + "com";
				var fileRes = fileSrc + "res";

				new Coders.Encoder().Code(fileSrc, fileDst);
				new Coders.Decoder().Code(fileDst, fileRes);

				CheckByteFile(fileSrc, fileRes);
			}
		}

		static void CheckBitOp(string file1)
		{
			var bytes1 = File.ReadAllBytes(file1);
			var bools = BitFileOperations.BitOperations.GetBoolArray(bytes1);
			var bytes2 = BitFileOperations.BitOperations.GetByteArray(bools);

			CmpByteArr(bytes1, bytes2);
		}

		static void CheckByteFile(string file1, string file2)
		{
			var bytes1 = File.ReadAllBytes(file1);
			var bytes2 = File.ReadAllBytes(file2);

			CmpByteArr(bytes1, bytes2);
		}

		static void CmpByteArr(byte[] bytes1, byte[] bytes2)
		{
			if (bytes1.Length == bytes2.Length)
			{
				for (int i = 0; i < bytes1.Length; i++)
				{
					if (bytes1[i] != bytes2[i])
					{
						Console.WriteLine("Dismatch");
						break;
					}
				}
			}
			else
			{
				Console.WriteLine("Dismatch");
			}
		}
	}
}