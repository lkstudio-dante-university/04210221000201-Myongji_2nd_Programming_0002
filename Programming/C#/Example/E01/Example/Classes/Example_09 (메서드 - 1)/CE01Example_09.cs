#define E08_METHOD_01
#define E08_METHOD_02
#define E08_METHOD_03

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E01.Example.Classes.Example_09
{
	/**
	 * Example 9
	 */
	internal class CE01Example_09
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
#if E08_METHOD_01
			int nValA = 0;
			int nValB = 0;

			char chOperator = '\0';

			Console.Write("수식 입력 : ");
			string[] oTokens = Console.ReadLine().Split();

			// 잘못된 수식을 입력했을 경우
			if(oTokens.Length < 3)
			{
				return;
			}

			int.TryParse(oTokens[0], out nValA);
			int.TryParse(oTokens[2], out nValB);

			char.TryParse(oTokens[1], out chOperator);

			decimal dmResult = GetResultCalc(nValA, chOperator, nValB);
			Console.WriteLine("{0} {1} {2} = {3}", nValA, chOperator, nValB, dmResult);
#elif E08_METHOD_02

#elif E08_METHOD_03

#endif // E08_METHOD_01
		}

#if E08_METHOD_01
		/** 수식 결과를 반환한다 */
		private static decimal GetResultCalc(int a_nValA, char a_chOperator, int a_nValB)
		{
			switch(a_chOperator)
			{
				case '+':
					return a_nValA + a_nValB;

				case '-':
					return a_nValA - a_nValB;

				case '*':
					return a_nValA * a_nValB;

				case '/':
					return a_nValA / (decimal)a_nValB;
			}

			return 0;
		}
#elif E08_METHOD_02

#elif E08_METHOD_03

#endif // E08_METHOD_01
	}
}
