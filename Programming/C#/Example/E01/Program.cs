#define E01_EXAMPLE
#define P01_PRACTICE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E01 {
	internal class Program {
		/** 메인 메서드 */
		static void Main(string[] args) {
#if E01_EXAMPLE
			Example.Classes.Example_01.CE01Example_01.Start(args);
#elif P01_PRACTICE

#endif // #if E01_EXAMPLE

			Console.ReadKey();
		}
	}
}
