//#define E10_METHOD_01
//#define E10_METHOD_02
//#define E10_METHOD_03
//#define E10_METHOD_04
#define E10_METHOD_05

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 가변 매개 변수란?
 * - 일반적인 매개 변수와 달리 개수가 정해져 있지 않는 매개 변수를 의미한다. (즉, 가변 매개 변수를 활용하면 특정 
 * 메서드에 원하는만큼 데이터를 전달하는 것이 가능하다.)
 * 
 * Ex)
 * void MethodSome(params int[] a_oValues)
 * {
 *		// Do Something
 * }
 * 
 * 위와 같이 params 키워드로 명시 된 매개 변수는 가변 매개 변수를 의미하며 배열의 형태로 전달 된다는 것을 알 수 있다.
 * 
 * 메서드 오버로딩이란?
 * - 동일한 이름의 메서드를 중복으로 구현 할 수 있는 기능을 의미한다. (즉, 일반적으로 동일한 이름의 메서드는 구현하는
 * 것이 불가능하지만 메서드 오버로딩 조건이 성립한다면 가능하다는 것을 알 수 있다.)
 * 
 * 단, C# 은 메서드의 매개 변수의 정보만을 가지고 메서드 오버로딩 가능 여부를 판별하기 떄문에 주의가 필요하다.
 * (즉, 반환 형은 메서드 오버로딩 여부를 판별하는데 사용하지 않는다는 것을 알 수 있다.)
 * 
 * Ex)
 * void MethodSome(int a_nVal);
 * void MethodSome(int a_nValA, int a_nValB);
 * 
 * 위의 경우 입력 데이터의 개수가 다르기 때문에 메서드 오버로딩이 가능하다.
 * 
 * void MethodSome(int a_nValA, int a_nValB);
 * void MethodSome(float a_fValA, float a_fValB);
 * 
 * 위의 경우 입력 데이터의 자료형이 다르기 때문에 역시 메서드 오버로딩이 성립한다는 것을 알 수 있다.
 * 
 * int MethodSome(int a_nVal);
 * void MethodSome(int a_nVal);
 * 
 * 위의 경우 반환 형은 다르지만 입력 데이터가 동일하기 때문에 메서드 오버로딩이 성립하지 않는다. (즉, 컴파일
 * 에러가 발생한다는 것을 알 수 있다.)
 * 
 * 디폴트 매개 변수란?
 * - 매개 변수에 초기 값을 부여하는 기능을 의미한다. (즉, 디폴트 매개 변수를 활용하면 메서드 호출 시 특정 데이터를
 * 전달하지 않아도 된다는 것을 알 수 있다.)
 * 
 * 일반적으로 특정 메서드가 매개 변수가 존재 할 경우 매개 변수의 개수만큼 데이터를 전달 할 필요가 있지만 디폴트
 * 매개 변수는 데이터를 생략하는 것이 가능하다. (즉, 입력 데이터가 생략 된 매개 변수는 자동으로 초기 값으로 할당
 * 된다는 것을 알 수 있다.)
 * 
 * Ex)
 * void MethodSome(int a_nValA, int a_nValB = 0)
 * {
 *		// Do Something
 * }
 * 
 * MethodSome(10);
 * MethodSome(10, 20);
 * 
 * 위와 같이 a_nValB 매개 변수는 디폴트 매개 변수이기 떄문에 메서드를 호출 시 해당 매개 변수의 입력 데이터를 명시하지
 * 않는다면 자동으로 0 이 할당 된다는 것을 알 수 있다.
 * 
 * 네임드 매개 변수란?
 * - 메서드 호출 시 데이터를 전달 받을 매개 변수를 지정 할 수 있는 기능을 의미한다. (즉, 네임드 매개 변수를 활용하면
 * 매개 변수의 순서와 입력 데이터의 순서를 일치시키지 않아도 된다는 것을 알 수 있다.)
 * 
 * 일반적으로 C# 메서드는 순서에 의해서 입력 데이터가 전달되지만 네임드 매개 변수를 활용하면 데이터를 전달 받을
 * 매개 변수를 지정하는 것이 가능하다.
 * 
 * Ex)
 * void MethodSome(int a_nValA, int a_nValB)
 * {
 *		// Do Something
 * }
 * 
 * MethodSome(10, 20);
 * MethodSome(a_nValB: 20, a_nValA: 10);
 * 
 * 위와 같이 입력 데이터를 전달 받을 매개 변수를 명시함으로 매개 변수의 순서와 입력 데이터의 순서가 달라 질 수 있다는
 * 것을 알 수 있다.
 */
namespace Example._04210221000201_Myongji_2nd_Programming_0002.E01.Example.Classes.Runtime.Example_10
{
	/**
	 * Example 10
	 */
	internal class CE01Example_10
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
#if E10_METHOD_01
			int nVal_SumA = GetValSum(1, 2, 3);
			int nVal_SumB = GetValSum(1, 2, 3, 4, 5, 6);
			int nVal_SumC = GetValSum(1, 2, 3, 4, 5, 6, 7, 8, 9);

			Console.WriteLine("{0}, {1}, {2}", nVal_SumA, nVal_SumB, nVal_SumC);
#elif E10_METHOD_02
			int nValA = 0;
			int nValB = 0;

			Console.Write("정수 (2 개) 입력 : ");
			var oTokens = Console.ReadLine().Split();

			// 데이터 개수가 부족 할 경우
			if(oTokens.Length < 2)
			{
				return;
			}

			int.TryParse(oTokens[0], out nValA);
			int.TryParse(oTokens[1], out nValB);

			/*
			 * GetValSum 메서드는 메서드 오버로딩에 의해 정수 데이터와 실수 데이터를 전달 받는 메서드가 각각 구현
			 * 되어있기 때문에 C# 컴파일러는 메서드 호출 시 전달되는 데이터를 기반으로 적절한 버전의 메서드를
			 * 호출해준다는 것을 알 수 있다. (즉, 사용자가 명시적으로 호출 할 메서드를 지정 할 필요가 없다는 것을
			 * 알 수 있다.)
			 */
			int nVal_Sum = GetValSum(nValA, nValB);
			float fSumVal = GetValSum((float)nValA, (float)nValB);

			Console.WriteLine("{0}, {1}", nVal_Sum, fSumVal);
#elif E10_METHOD_03
			var oListValues = new List<int>();
			SetupValues(oListValues, 10);

			Console.WriteLine("=====> 리스트 <=====");
			PrintValues(oListValues);

			var stResult = GetValMinMax(oListValues);

			/*
			 * 튜플의 각 요소에 별도의 이름을 명시하지 않았을 경우 기본적으로 Item1 부터 차례대로 각 요소의 이름이
			 * 설정된다. (즉, 필요에 따라 좀 더 명확한 이름을 작성하는 것이 가능하다.)
			 */
			Console.WriteLine("\n최소 값 : {0}", stResult.Item1);
			Console.WriteLine("최대 값 : {0}", stResult.Item2);
#elif E10_METHOD_04
			int nValSumA = GetValSum(10);
			int nValSumB = GetValSum(10, 20);

			Console.WriteLine("{0}, {1}", nValSumA, nValSumB);
#elif E10_METHOD_05
			int nValSumA = GetValSum(10, 20);
			int nValSumB = GetValSum(a_nValB: 20, a_nValA: 10);

			Console.WriteLine("{0}, {1}", nValSumA, nValSumB);
#endif // #if E10_METHOD_01
		}

#if E10_METHOD_01
		/*
		 * params 키워드는 가변 매개 변수를 전달받는 역할을 수행한다. (즉, 해당 키워드를 활용하면 메서드의 입력 데이터 
		 * 개수를 지정하지 않고 메서드를 구현하는 것이 가능하다.)
		 * 
		 * 일반적으로 메서드의 입력 데이터는 개수가 지정되어있지만 params 키워드를 통해 가변 매개 변수를 선언 할 경우 
		 * 원하는 만큼 데이터를 전달하는 것이 가능하다.
		 */
		/** 합계를 반환한다 */
		private static int GetValSum(params int[] a_oValues)
		{
			int nVal_Sum = 0;

			for(int i = 0; i < a_oValues.Length; ++i)
			{
				nVal_Sum += a_oValues[i];
			}

			return nVal_Sum;
		}
#elif E10_METHOD_02
		/** 합계를 반환한다 */
		private static int GetValSum(int a_nValA, int a_nValB)
		{
			return a_nValA + a_nValB;
		}

		/** 합계를 반환한다 */
		private static float GetValSum(float a_fValA, float a_fValB)
		{
			return a_fValA + a_fValB;
		}
#elif E10_METHOD_03
		/** 값을 설정한다 */
		private static void SetupValues(List<int> a_oListValues, int a_nNumValues)
		{
			var oRandom = new Random();
			a_oListValues.Clear();

			for(int i = 0; i < a_nNumValues; ++i)
			{
				a_oListValues.Add(oRandom.Next(0, 100));
			}
		}

		/*
		 * C# 의 튜플과 같은 기능을 활용하면 메서드가 2 개 이상의 결과 값을 반환하는 것이 가능하다. (즉, 메서드 자체는
		 * 여전히 하나의 데이터만 결과 값으로 반환 할 수 있다.)
		 */
		/** 최소, 최대 값을 반환한다 */
		private static (int, int) GetValMinMax(List<int> a_oListValues)
		{
			int nMinVal = int.MaxValue;
			int nMaxVal = int.MinValue;

			for(int i = 0; i < a_oListValues.Count; ++i)
			{
				nMinVal = Math.Min(nMinVal, a_oListValues[i]);
				nMaxVal = Math.Max(nMaxVal, a_oListValues[i]);
			}

			return (nMinVal, nMaxVal);
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
#elif E10_METHOD_04
		/** 합계를 반환한다 */
		public static int GetValSum(int a_nValA, int a_nValB = 0)
		{
			return a_nValA + a_nValB;
		}
#elif E10_METHOD_05
		/** 합계를 반환한다 */
		public static int GetValSum(int a_nValA, int a_nValB)
		{
			return a_nValA + a_nValB;
		}
#endif // #if E10_METHOD_01
	}
}
