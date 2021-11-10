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

			var fileSrc = File.Open(args[1], FileMode.Open);
			var fileDst = File.Create(args[2]);

			SetEncodeMode();
			//SetDecodeMode();

			coder.Code(fileSrc, fileDst);
		}

		static void SetEncodeMode()
		{
			coder = new Encoder(); 
		}

		static void SetDecodeMode()
		{
			coder = new Decoder();
		}
	}
}
