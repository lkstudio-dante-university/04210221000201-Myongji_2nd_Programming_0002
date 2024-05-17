#define E17_DELEGATE_01
#define E17_DELEGATE_02
#define E17_DELEGATE_03

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 델리게이트란?
 * - 메서드를 데이터처럼 제어 할 수 있는 기능을 의미한다. (즉, 델리게이트를 활용하면 메서드를 특정 메서드에 입력으로
 * 전달하거나 메서드가 반환 값으로 메서드를 반환하는 것이 가능하다.)
 * 
 * 또한, 델리게이트를 통해 메서드를 호출하는 것이 가능하다는 특징이 존재한다. (즉, 메서드의 이름을 명시적으로 지정하지
 * 않아도 특정 메서드를 호출하는 것이 가능하다.)
 * 
 * C# 델리게이트 선언 방법
 * - delegate + 반환 형 + 델리게이트 이름 + 매개 변수
 * 
 * Ex)
 * delegate void SomeDelegate(int a_nValA, int a_nValB);
 * 
 * void SomeMethod(int a_nValA, int a_nValB)
 * {
 *		// Do Something
 * }
 * 
 * SomeDelegate oDelegate = SomeMethod;
 * oDelegate(10, 20);
 * 
 * 위와 같이 선언이 완료 된 델리게이트는 자료형처럼 사용하는 것이 가능하다. (즉, 델리게이트로 선언 된 변수에는
 * 일반적인 데이터가 아닌 메서드를 할당하는 것이 가능하다.)
 * 
 * 델리게이트로 선언 된 변수는 메서드를 참조하고 있기 때문에 델리게이트를 통해 참조하는 메서드를 간접적으로 호출하는
 * 것이 가능하다. (즉, 호출하기 위한 메서드의 이름을 명시하지 않아도 메서드 호출이 가능하다는 것을 알 수 있다.)
 */
namespace E01.Example.Classes.Example_17
{
	/**
	 * Example 17
	 */
	internal class CE01Example_17
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
#if E17_DELEGATE_01
			Console.Write("수식 입력 : ");
			var oTokens = Console.ReadLine().Split();

			int.TryParse(oTokens[0], out int nValA);
			int.TryParse(oTokens[2], out int nValB);

			char.TryParse(oTokens[1], out char chOperator);
			MethodCalc oMethodCalc = GetMethodCalc(chOperator);

			// 수식 메서드가 유효 할 경우
			if(oMethodCalc != null)
			{
				decimal dmResult = oMethodCalc(nValA, nValB);
				Console.WriteLine("결과 : {0}", dmResult);
			}
			else
			{
				Console.WriteLine("잘못된 수식을 입력했습니다.");
			}
#elif E17_DELEGATE_02
			var oRandom = new Random();
			var oListValues = new List<int>();

			for(int i = 0; i < 10; ++i)
			{
				oListValues.Add(oRandom.Next(1, 100));
			}

			Console.WriteLine("=====> 정렬 전 <=====");
			PrintValues(oListValues);

			SortValues(oListValues, CompareByAscending);

			Console.WriteLine("\n=====> 정렬 후 - 오름차순 <=====");
			PrintValues(oListValues);

			SortValues(oListValues, CompareByDescending);

			Console.WriteLine("\n=====> 정렬 후 - 내림차순 <=====");
			PrintValues(oListValues);
#elif E17_DELEGATE_03
			MethodPrint oMethodPrint = PrintMsgA;
			oMethodPrint += PrintMsgB;

			Console.WriteLine("=====> 델리게이트 체인 <=====");

			/*
			 * 델리게이트 체인을 활용하면 여러 메서드를 한번에 호출하는 것이 가능하다. (즉, 델리게이트 변수에 추가 된
			 * 메서드가 순차적으로 호출된다는 것을 알 수 있다.)
			 */
			oMethodPrint("Hello, World!");

			/*
			 * 델리게이트 변수에 특정 메서드를 추가하거나 제거하면 델리게이트 체인이 형성된다는 것을 알 수 있다. (즉, 
			 * += 연산자를 통해 메서드를 추가하거나 -= 연산자를 통해 메서드를 제거하는 것이 가능하다.)
			 */
			oMethodPrint += PrintMsgC;

			Console.WriteLine("\n=====> 델리게이트 체인 - 추가 후 <=====");
			oMethodPrint("Hello, World!");

			oMethodPrint -= PrintMsgB;

			Console.WriteLine("\n=====> 델리게이트 체인 - 제거 후 <=====");
			oMethodPrint("Hello, World!");

			/*
			 * 델리게이트 변수에 특정 메서드를 할당하면 델리게이트 체인 정보가 초기화된다는 것을 알 수 있다. (즉, 
			 * = 연산자를 사용 할 때는 주의 할 필요가 있다는 것을 알 수 있다.)
			 */
			oMethodPrint = PrintMsgA;

			Console.WriteLine("\n=====> 델리게이트 체인 - 할당 후 <=====");
			oMethodPrint("Hello, World!");
#endif // #if E17_DELEGATE_01
		}

#if E17_DELEGATE_01
		/** 델리게이트 */
		private delegate decimal MethodCalc(int a_nValA, int a_nValB);

		/** 덧셈 결과를 반환한다 */
		private static decimal GetValSum(int a_nValA, int a_nValB)
		{
			return a_nValA + a_nValB;
		}

		/** 뺄셈 결과를 반환한다 */
		private static decimal GetValSub(int a_nValA, int a_nValB)
		{
			return a_nValA - a_nValB;
		}

		/** 곱셈 결과를 반환한다 */
		private static decimal GetValMultiply(int a_nValA, int a_nValB)
		{
			return a_nValA * a_nValB;
		}

		/** 나눗셈 결과를 반환한다 */
		private static decimal GetValDivide(int a_nValA, int a_nValB)
		{
			return a_nValA / (decimal)a_nValB;
		}

		/** 수식 계산 메서드를 반환한다 */
		private static MethodCalc GetMethodCalc(char a_chOperator)
		{
			switch(a_chOperator)
			{
				case '+':
					return GetValSum;

				case '-':
					return GetValSub;

				case '*':
					return GetValMultiply;

				case '/':
					return GetValDivide;
			}

			return null;
		}
#elif E17_DELEGATE_02
		/** 델리게이트 */
		private delegate int MethodCompare(int a_nValA, int a_nValB);

		/** 오름차순 비교 결과를 반환한다 */
		private static int CompareByAscending(int a_nValA, int a_nValB)
		{
			return a_nValA - a_nValB;
		}

		/** 내림차순 비교 결과를 반환한다 */
		private static int CompareByDescending(int a_nValA, int a_nValB)
		{
			return a_nValB - a_nValA;
		}

		/** 값을 정렬한다 */
		private static void SortValues(List<int> a_oListValues, MethodCompare a_oCompare)
		{
			for(int i = 0; i < a_oListValues.Count - 1; ++i)
			{
				int nIdx = i;

				for(int j = i; j < a_oListValues.Count; ++j)
				{
					// 정렬이 필요 없을 경우
					if(a_oCompare(a_oListValues[nIdx], a_oListValues[j]) < 0)
					{
						continue;
					}

					nIdx = j;
				}

				int nTemp = a_oListValues[i];
				a_oListValues[i] = a_oListValues[nIdx];
				a_oListValues[nIdx] = nTemp;
			}
		}

		/** 값을 출력한다 */
		private static void PrintValues(List<int> a_oListValues)
		{
			for(int i = 0; i < a_oListValues.Count; ++i)
			{
				Console.Write("{0}, ", a_oListValues[i]);
			}

			Console.WriteLine();
		}
#elif E17_DELEGATE_03
		/** 델리게이트 */
		private delegate void MethodPrint(string a_oParams);

		/** 메세지를 출력한다 */
		private static void PrintMsgA(string a_oParams)
		{
			Console.WriteLine("메세지 A : {0}", a_oParams);
		}

		/** 메세지를 출력한다 */
		private static void PrintMsgB(string a_oParams)
		{
			Console.WriteLine("메세지 B : {0}", a_oParams);
		}

		/** 메세지를 출력한다 */
		private static void PrintMsgC(string a_oParams)
		{
			Console.WriteLine("메세지 C : {0}", a_oParams);
		}
#endif // #if E17_DELEGATE_01
	}
}
