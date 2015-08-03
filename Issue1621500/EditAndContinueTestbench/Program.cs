using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditAndContinueTestbench
{
	[TestFixture]
	public class Program
	{

		static void Main(string[] args)
		{
			var program = new Program();

			program.Test();
        }

		[Test]
		public void Test()
		{
			var methods = new Methods();
			Test(methods);
        }

		public void Test(ITest test)
		{
			// 1
			test.MethodParamsString("a", "a", "a");
			// 2
			test.MethodParamsString("b", "b", "b", "b");
			// 3
			test.MethodParamsString("c", "c", "c", "c");
		}
	}


	public interface ITest
	{
		ITest MethodString(string item);
    }


	public static class TestExtensions
	{
		public static ITest MethodParamsString(this ITest obj,params string[] items)
		{
			Random r = new Random(Environment.TickCount);
			StringBuilder b = new StringBuilder();

			for (int i = 0; i < items.Length * 2; i++)
			{
				b.Append(items[r.Next(0, items.Length)]);
			}
			return obj.MethodString(b.ToString());
        }
    }

	public class Methods
		: ITest
	{
		public ITest MethodString(string item)
		{ 
			Debug.WriteIf(Environment.TickCount > 0x0FFFFFFF, item);

			return this;
		}
	}
}
