using System.IO;

namespace MIT_LR1_BWT.Coders
{
	interface ICoder
	{
		public void Code(Stream src, Stream dst);
	}
}
